using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class ActivationFunctionModificationConfiguration : IActivationFunctionModificationConfiguration
    {
        public IActivationFunctionModifier Modifier { get; private set; }
        public IActivationFunctionModificationGradationFilter GradationFilter { get; private set; }
        public IActivationFunctionModificationTarget Target { get; private set; }

        private ActivationFunctionModificationConfiguration() { }

        public static ActivationFunctionModificationConfiguration Create()
        {
            return new ActivationFunctionModificationConfiguration();
        }

        public ActivationFunctionModificationConfiguration ConfigureGradationFilter(IActivationFunctionModificationGradationFilter activationFunctionModificationGradationFilter)
        {
            GradationFilter = activationFunctionModificationGradationFilter;
            return this;
        }

        public ActivationFunctionModificationConfiguration ConfigureTarget(IActivationFunctionModificationTarget activationFunctionModificationTarget)
        {
            Target = activationFunctionModificationTarget;
            return this;
        }

        public ActivationFunctionModificationConfiguration ConfigureModifier(IActivationFunctionModifier activationFunctionModifier)
        {
            Modifier = activationFunctionModifier;
            return this;
        }
    }
}
