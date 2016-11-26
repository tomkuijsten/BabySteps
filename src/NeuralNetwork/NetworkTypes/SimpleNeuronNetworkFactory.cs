using Devvy.NeuralNetwork.Neurons;
using Devvy.NeuralNetwork.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devvy.NeuralNetwork.NetworkTypes
{
    public static class SimpleNeuronNetworkFactory
    {
        private static Random _rondomizer = new Random();

        public static SimpleNeuralNetwork CreateNeuralNetwork(int nrOfInput, int nrOfHidden, int nrOfOutputs)
        {
            var inputs = Enumerable.Range(0, nrOfInput).Select(i => new InputNeuron()).ToArray();
            var hiddens = Enumerable.Range(0, nrOfHidden).Select(i => new HiddenNeuron()).ToArray();
            var outputs = Enumerable.Range(0, nrOfOutputs).Select(i => new OutputNeuron()).ToArray();

            CreateInputHiddenSynapses(inputs, hiddens);

            CreateHiddenOutputSynapses(hiddens, outputs);

            CreateHiddenBiases(hiddens);

            CreateOutputBiases(outputs);

            return new SimpleNeuralNetwork(inputs);
        }

        public static INeuralNetwork CreateNeuralNetwork(INeuralNetwork baseNetwork)
        {
            var baseVariation = new SimpleNeuralNetwork(baseNetwork.Inputs);

            foreach (var input in baseVariation.Inputs)
            {
                input.Value = 0;
                foreach (var syn in input.Outgoing)
                {
                    syn.Weight *= (_rondomizer.NextDouble() + 0.5);
                }
            }

            foreach (var hidd in baseVariation.Hidden)
            {
                hidd.Value = 0;
                hidd.BiasSynapse.Weight *= (_rondomizer.NextDouble() + 0.5);
                hidd.BiasSynapse.From.Value *= (_rondomizer.NextDouble() + 0.5);
                foreach (var syn in hidd.Outgoing)
                {
                    syn.Weight *= (_rondomizer.NextDouble() + 0.5);
                }
            }

            foreach (var output in baseVariation.Output)
            {
                output.Value = 0;

                output.BiasSynapse.Weight *= (_rondomizer.NextDouble() + 0.5);
                output.BiasSynapse.From.Value *= (_rondomizer.NextDouble() + 0.5);
            }

            return baseVariation;
        }

        private static void CreateOutputBiases(IEnumerable<OutputNeuron> outputs)
        {
            foreach (var output in outputs)
            {
                Bias bias = new Bias();
                var synapse = new Synapse<Bias, Neuron>()
                {
                    From = bias,
                    To = output
                };

                bias.Outgoing = synapse;
                output.BiasSynapse = synapse;
            }
        }

        private static void CreateHiddenBiases(IEnumerable<HiddenNeuron> hiddens)
        {
            foreach (var hidden in hiddens)
            {
                Bias bias = new Bias();
                var synapse = new Synapse<Bias, Neuron>()
                {
                    From = bias,
                    To = hidden
                };

                bias.Outgoing = synapse;
                hidden.BiasSynapse = synapse;
            }
        }

        private static void CreateHiddenOutputSynapses(IEnumerable<HiddenNeuron> hiddens, IEnumerable<OutputNeuron> outputs)
        {
            foreach (var hidden in hiddens)
            {
                foreach (var output in outputs)
                {
                    var synapse = new Synapse<HiddenNeuron, OutputNeuron>() { From = hidden, To = output };
                    hidden.Outgoing.Add(synapse);
                    output.Incoming.Add(synapse);

                }
            }
        }

        private static void CreateInputHiddenSynapses(IEnumerable<InputNeuron> inputs, IEnumerable<HiddenNeuron> hiddens)
        {
            foreach (var input in inputs)
            {
                foreach (var hidden in hiddens)
                {
                    var synapse = new Synapse<InputNeuron, HiddenNeuron>() { From = input, To = hidden };
                    input.Outgoing.Add(synapse);
                    hidden.Incoming.Add(synapse);
                }
            }
        }
    }
}
