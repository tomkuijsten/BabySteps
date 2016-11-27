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
        public IWeightModification Manipulation { get; private set; }
        public IWeightModificationTarget Target { get; private set; }

        public static IWeightModificationConfiguration Create()
        {
            return new WeightModificationConfiguration();
        }

        public IWeightModificationConfiguration ConfigureGradationFilter(IWeightModificationGradationFilter weightModificationGradationFilter)
        {
            GradationFilter = weightModificationGradationFilter;
            return this;
        }

        public IWeightModificationConfiguration ConfigureModification(IWeightModification weightModification)
        {
            Manipulation = weightModification;
            return this;
        }

        public IWeightModificationConfiguration ConfigureTarget(IWeightModificationTarget weightModificationTarget)
        {
            Target = weightModificationTarget;
            return this;
        }
    }
}
