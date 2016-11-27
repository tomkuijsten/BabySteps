using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.Neurons
{
    public abstract class Neuron
    {
        public double Value { get; set; }

        public Neuron()
        {
            Value = 0;
        }
    }
}
