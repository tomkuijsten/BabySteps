using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork.Synapses;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public class AllWeightModificationGradationFilter : IWeightModificationGradationFilter
    {
        private AllWeightModificationGradationFilter() { }

        public static AllWeightModificationGradationFilter Create()
        {
            return new AllWeightModificationGradationFilter();
        }

        public IEnumerable<ISynapse> Filter(IEnumerable<ISynapse> input)
        {
            return input;
        }
    }
}
