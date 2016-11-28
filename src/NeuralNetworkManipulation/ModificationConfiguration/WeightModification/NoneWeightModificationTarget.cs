using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetwork.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public class NoneWeightModificationTarget : IWeightModificationTarget
    {
        private NoneWeightModificationTarget() { }

        public IEnumerable<ISynapse> GetTarget(INeuralNetwork neuralNetwork)
        {
            return Enumerable.Empty<ISynapse>();
        }

        public static NoneWeightModificationTarget Create()
        {
            return new NoneWeightModificationTarget();
        }
    }
}
