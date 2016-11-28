using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork.Synapses;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public class NoneWeightModificationGradationFilter : IWeightModificationGradationFilter
    {
        private NoneWeightModificationGradationFilter() { }

        public static NoneWeightModificationGradationFilter Create()
        {
            return new NoneWeightModificationGradationFilter();
        }

        public IEnumerable<ISynapse> Filter(IEnumerable<ISynapse> input)
        {
            return Enumerable.Empty<ISynapse>();
        }
    }
}
