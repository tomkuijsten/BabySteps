using Devvy.NeuralNetwork.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devvy.NeuralNetwork.Neurons
{
    public class HiddenNeuron : CalculatableNeuron<InputNeuron, HiddenNeuron>
    {
        public List<Synapse<HiddenNeuron, OutputNeuron>> Outgoing { get; private set; }

        public HiddenNeuron() : base()
        {
            Outgoing = new List<Synapse<HiddenNeuron, OutputNeuron>>();
        }
    }
}
