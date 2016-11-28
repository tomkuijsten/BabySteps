using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BabySteps.NeuralNetwork.Synapses;

namespace BabySteps.NeuralNetwork.NetworkTypes
{
    public class SimpleNeuralNetwork : INeuralNetwork, IClonable<INeuralNetwork>
    {
        public int Generation { get; set; }
        public HashSet<Neuron> Neurons { get; private set; }
        public HashSet<InputNeuron> Inputs { get; private set; }
        public HashSet<OutputNeuron> Output { get; private set; }
        public HashSet<HiddenNeuron> Hidden { get; private set; }
        public HashSet<Bias> Biases { get; set; }
        public HashSet<ISynapse> Synapses { get; private set; }

        public SimpleNeuralNetwork(IEnumerable<InputNeuron> inputs)
        {
            Generation = 1;
            Inputs = new HashSet<InputNeuron>(inputs);
            Hidden = new HashSet<HiddenNeuron>();
            Output = new HashSet<OutputNeuron>();
            Biases = new HashSet<Bias>();
            Synapses = new HashSet<ISynapse>();

            FindHidden();
            FindOutput();
            FindBiases();
            FindSynapses();
            FindNeurons();
        }

        private void FindNeurons()
        {
            Neurons = new HashSet<Neuron>(new Neuron[0].Concat(Inputs).Concat(Hidden).Concat(Output));
        }

        private void FindSynapses()
        {
            foreach (var outputSynapse in Inputs.SelectMany(i => i.Outgoing))
            {
                Synapses.Add(outputSynapse);
                Synapses.Add(outputSynapse.To.BiasSynapse);
                foreach (var targetOutput in outputSynapse.To.Outgoing)
                {
                    Synapses.Add(targetOutput);
                    Synapses.Add(targetOutput.To.BiasSynapse);
                }
            }
        }

        private void FindBiases()
        {
            foreach (var outputSynapse in Inputs.SelectMany(i => i.Outgoing))
            {
                Biases.Add(outputSynapse.To.BiasSynapse.From);
                foreach (var targetOutput in outputSynapse.To.Outgoing)
                {
                    Biases.Add(targetOutput.To.BiasSynapse.From);
                }
            }
        }

        private void FindHidden()
        {
            foreach (var input in Inputs)
            {
                foreach (var connection in input.Outgoing)
                {
                    Hidden.Add(connection.To);
                }
            }
        }

        private void FindOutput()
        {
            foreach (var hidden in Hidden)
            {
                foreach (var connection in hidden.Outgoing)
                {
                    Output.Add(connection.To);
                }
            }
        }

        public double[] CalculateNeuralNetwork(params double[] inputValues)
        {
            if (inputValues.Count() != Inputs.Count)
                throw new ArgumentException(nameof(inputValues));

            for (int i = 0; i < Inputs.Count; i++)
            {
                Inputs.ElementAt(i).Value = inputValues[i];
            }

            foreach (var hidden in Hidden)
            {
                CalculateHidden(hidden);
            }

            foreach (var output in Output)
            {
                CalculateOutput(output);
            }

            return Output.Select(o => o.Value).ToArray();
        }

        private static void CalculateOutput(OutputNeuron output)
        {
            var incomingSum = output.Incoming.Sum(i => i.From.Value * i.Weight);
            var withBias = incomingSum + (output.BiasSynapse.From.Value * output.BiasSynapse.Weight);
            output.Value = output.ActivationFunction.Activate(withBias);
        }

        private static void CalculateHidden(HiddenNeuron hidden)
        {
            var incomingSum = hidden.Incoming.Sum(i => i.From.Value * i.Weight);
            var withBias = incomingSum + (hidden.BiasSynapse.From.Value * hidden.BiasSynapse.Weight);
            hidden.Value = hidden.ActivationFunction.Activate(withBias);
        }

        public override string ToString()
        {
            return $"Simple network (generation {Generation}) with {Inputs.Count} inputs, {Hidden.Count} hiddens and {Output.Count} outputs";
        }

        public INeuralNetwork Clone()
        {
            var simpleNetwork = SimpleNeuralNetworkFactory.Create(Inputs.Count, Hidden.Count, Output.Count);

            // Copy weights
            for (int i = 0; i < Synapses.Count; i++)
            {
                simpleNetwork.Synapses.ElementAt(i).Weight = Synapses.ElementAt(i).Weight;
            }

            // Copy activation functions
            var sourceNeurons = Neurons.OfType<ICalculatableNeuron>().ToArray();
            var targetNeurons = simpleNetwork.Neurons.OfType<ICalculatableNeuron>().ToArray();
            for (int i = 0; i < sourceNeurons.Count(); i++)
            {
                targetNeurons.ElementAt(i).ActivationFunction = sourceNeurons.ElementAt(i).ActivationFunction;
            }

            return simpleNetwork;
        }
    }
}
