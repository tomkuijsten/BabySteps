using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public class IgnoreWeightModificationConfiguration : IWeightModificationConfiguration
    {
        public IWeightModificationGradationFilter GradationFilter { get; private set; }
        public IWeightModifier Modifier { get; private set; }
        public IWeightModificationTarget Target { get; private set; }

        public static IgnoreWeightModificationConfiguration Create()
        {
            var instance = new IgnoreWeightModificationConfiguration() {
                Target = NoneWeightModificationTarget.Create(),
                GradationFilter = NoneWeightModificationGradationFilter.Create()
            };

            return instance;
        }
    }
}
