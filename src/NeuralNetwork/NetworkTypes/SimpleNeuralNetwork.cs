using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BabySteps.NeuralNetwork
{
    public class SimpleNeuralNetwork : INeuralNetwork
    {
        public int Generation { get; set; }
        public HashSet<InputNeuron> Inputs { get; private set; }
        public HashSet<OutputNeuron> Output { get; private set; }
        public HashSet<HiddenNeuron> Hidden { get; private set; }

        public IEnumerable<Bias> Biases
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public SimpleNeuralNetwork(IEnumerable<InputNeuron> inputs)
        {
            Generation = 1;
            Inputs = new HashSet<InputNeuron>(inputs);
            Hidden = new HashSet<HiddenNeuron>();
            Output = new HashSet<OutputNeuron>();

            FindHidden();

            FindOutput();
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
