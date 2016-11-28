using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class IgnoreBiasModificationConfiguration : IBiasModificationConfiguration
    {
        public IBiasModificationGradationFilter GradationFilter { get; private set; }
        public IBiasModificationTarget Target { get; private set; }
        public IBiasModifier Modifier { get; private set; }

        public static IBiasModificationConfiguration Create()
        {
            var instance = new IgnoreBiasModificationConfiguration()
            {
                GradationFilter = NoneBiasModificationGradationFilter.Create(),
                Target = NoneBiasModificationTarget.Create()
            };

            return instance;
        }
    }
}
