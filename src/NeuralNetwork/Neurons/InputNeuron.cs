using Devvy.NeuralNetwork.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devvy.NeuralNetwork.Neurons
{
    public class InputNeuron : Neuron
    {
        public List<Synapse<InputNeuron, HiddenNeuron>> Outgoing { get; private set; }

        public InputNeuron()
        {
            Outgoing = new List<Synapse<InputNeuron, HiddenNeuron>>();
        }
    }
}
