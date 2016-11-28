using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class NoneBiasModificationGradationFilter : IBiasModificationGradationFilter
    {
        public IEnumerable<Bias> Filter(IEnumerable<Bias> input)
        {
            return Enumerable.Empty<Bias>();
        }

        public static NoneBiasModificationGradationFilter Create()
        {
            return new NoneBiasModificationGradationFilter();
        }
    }
}
