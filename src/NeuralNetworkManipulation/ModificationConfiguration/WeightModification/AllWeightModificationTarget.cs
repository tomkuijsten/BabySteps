using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetwork.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public class AllWeightModificationTarget : IWeightModificationTarget
    {
        private AllWeightModificationTarget() { }

        public IEnumerable<ISynapse> GetTarget(INeuralNetwork neuralNetwork)
        {
            return neuralNetwork.Synapses;
        }

        public static AllWeightModificationTarget Create()
        {
            return new AllWeightModificationTarget();
        }
    }
}
