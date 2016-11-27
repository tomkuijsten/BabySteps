using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class BiasModificationConfiguration : IBiasModificationConfiguration
    {
        public IBiasModificationGradationFilter GradationFilter { get; private set; }

        public IBiasModificationTarget Target { get; private set; }
        public IBiasModificationWeight WeightManipulation { get; private set; }

        public static IBiasModificationConfiguration Create()
        {
            return new BiasModificationConfiguration();
        }

        public IBiasModificationConfiguration ConfigureGradationFilter(IBiasModificationGradationFilter biasModificationGradationFilter)
        {
            GradationFilter = biasModificationGradationFilter;
            return this;
        }

        public IBiasModificationConfiguration ConfigureTarget(IBiasModificationTarget biasModificationTarget)
        {
            Target = biasModificationTarget;
            return this;
        }

        public IBiasModificationConfiguration ConfigureWeight(IBiasModificationWeight biasModificationWeight)
        {
            WeightManipulation = biasModificationWeight;
            return this;
        }
    }
}
