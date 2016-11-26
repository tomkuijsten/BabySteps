using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.Synapses
{
    public class Synapse<TIn, TOut> where TIn : Neuron where TOut : Neuron
    {
        private static Random RANDOMIZER = new Random();

        public TIn From { get; set; }
        public TOut To { get; set; }
        public double Weight { get; set; }

        public Synapse()
        {
            Weight = RANDOMIZER.NextDouble() * 10 -5;
        }
    }
}
