using Devvy.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devvy.NeuralNetwork
{
    public interface INeuralNetwork : IClonable<INeuralNetwork>, ICleanable
    {
        IEnumerable<Bias> Biases { get; set; }
        int Generation { get; set; }
        HashSet<InputNeuron> Inputs { get; }
        HashSet<OutputNeuron> Output { get; }
        void CalculateNeuralNetwork(params double[] inputValues);
    }
}
