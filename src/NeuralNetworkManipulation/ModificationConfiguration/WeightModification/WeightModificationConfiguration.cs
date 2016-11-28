using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public class WeightModificationConfiguration : IWeightModificationConfiguration
    {
        public IWeightModificationGradationFilter GradationFilter { get; private set; }
        public IWeightModifier Modifier { get; private set; }
        public IWeightModificationTarget Target { get; private set; }

        public static WeightModificationConfiguration Create()
        {
            return new WeightModificationConfiguration();
        }

        public WeightModificationConfiguration ConfigureGradationFilter(IWeightModificationGradationFilter weightModificationGradationFilter)
        {
            GradationFilter = weightModificationGradationFilter;
            return this;
        }

        public WeightModificationConfiguration ConfigureModifier(IWeightModifier weightModifier)
        {
            Modifier = weightModifier;
            return this;
        }

        public WeightModificationConfiguration ConfigureTarget(IWeightModificationTarget weightModificationTarget)
        {
            Target = weightModificationTarget;
            return this;
        }
    }
}
