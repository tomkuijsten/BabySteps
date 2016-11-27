using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class AllBiasModificationTarget : IBiasModificationTarget
    {
        public IEnumerable<Bias> GetTarget(INeuralNetwork neuralNetwork)
        {
            return neuralNetwork.Biases;
        }

        public static AllBiasModificationTarget Create()
        {
            return new AllBiasModificationTarget();
        }
    }
}
