using BabySteps.NeuralNetwork.Neurons;
using BabySteps.NeuralNetwork.Synapses;
using BabySteps.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork.NetworkTypes;
using BabySteps.NeuralNetworkManipulation;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var nn = SimpleNeuralNetworkFactory.Create(1, 1, 1);
            NetworkEditor.InitializeStaticValue(nn, 1, 1);
        }
    }
}
