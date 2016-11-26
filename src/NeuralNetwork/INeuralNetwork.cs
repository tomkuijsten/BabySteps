using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork
{
    public interface INeuralNetwork
    {
        int Generation { get; set; }
        HashSet<InputNeuron> Inputs { get; }
        HashSet<OutputNeuron> Output { get; }
        IEnumerable<Bias> Biases { get; }
        void CalculateNeuralNetwork(params double[] inputValues);
    }
}
