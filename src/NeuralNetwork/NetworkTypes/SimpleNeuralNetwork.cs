using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BabySteps.NeuralNetwork.Synapses;

namespace BabySteps.NeuralNetwork.NetworkTypes
{
    public class SimpleNeuralNetwork : INeuralNetwork
    {
        public int Generation { get; set; }
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

        public void CalculateNeuralNetwork(params double[] inputValues)
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
    }
}
