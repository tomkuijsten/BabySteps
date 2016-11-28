using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class NoneBiasModificationTarget : IBiasModificationTarget
    {
        public IEnumerable<Bias> GetTarget(INeuralNetwork neuralNetwork)
        {
            return Enumerable.Empty<Bias>();
        }

        public static NoneBiasModificationTarget Create()
        {
            return new NoneBiasModificationTarget();
        }
    }
}
