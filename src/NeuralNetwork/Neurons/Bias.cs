﻿using Devvy.NeuralNetwork.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devvy.NeuralNetwork.Neurons
{
    public class Bias : Neuron
    {
        public Synapse<Bias, Neuron> Outgoing { get; set; }

        public Bias()
        {
            Value = 1;
        }
    }
}