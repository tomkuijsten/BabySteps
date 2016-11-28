using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class IgnoreActivationFunctionModificationConfiguration : IActivationFunctionModificationConfiguration
    {
        public IActivationFunctionModifier Modifier { get; private set; }
        public IActivationFunctionModificationGradationFilter GradationFilter { get; private set; }
        public IActivationFunctionModificationTarget Target { get; private set; }

        private IgnoreActivationFunctionModificationConfiguration() { }

        public static IgnoreActivationFunctionModificationConfiguration Create()
        {
            var instance = new IgnoreActivationFunctionModificationConfiguration()
            {
                Target = NoneActivationFunctionModificationTarget.Create(),
                GradationFilter = NoneActivationFunctionModificationGradationFilter.Create()
            };

            return instance;
        }
    }
}
