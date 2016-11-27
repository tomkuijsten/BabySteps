using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.Synapses
{
    public class Synapse<TIn, TOut> : ISynapse where TIn : Neuron where TOut : Neuron
    {
        public TIn From { get; set; }
        public TOut To { get; set; }
        public double Weight { get; set; }

        object ISynapse.From
        {
            get
            {
                return From;
            }

            set
            {
                From = (TIn)value;
            }
        }

        object ISynapse.To
        {
            get
            {
                return this.To;
            }
            set
            {
                To = (TOut)value;
            }
        }

        public Synapse()
        {
            Weight = 0;
        }

        public override string ToString()
        {
            return $"Weight {Weight}";
        }
    }
}
