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
        public IBiasModifier Modifier { get; private set; }

        public static BiasModificationConfiguration Create()
        {
            return new BiasModificationConfiguration();
        }

        public BiasModificationConfiguration ConfigureGradationFilter(IBiasModificationGradationFilter biasModificationGradationFilter)
        {
            GradationFilter = biasModificationGradationFilter;
            return this;
        }

        public BiasModificationConfiguration ConfigureTarget(IBiasModificationTarget biasModificationTarget)
        {
            Target = biasModificationTarget;
            return this;
        }

        public BiasModificationConfiguration ConfigureModifier(IBiasModifier biasModifier)
        {
            Modifier = biasModifier;
            return this;
        }
    }
}
