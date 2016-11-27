using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class AllBiasModificationGradationFilter : IBiasModificationGradationFilter
    {
        public IEnumerable<Bias> Filter(IEnumerable<Bias> input)
        {
            return input;
        }

        public static AllBiasModificationGradationFilter Create()
        {
            return new AllBiasModificationGradationFilter();
        }
    }
}
