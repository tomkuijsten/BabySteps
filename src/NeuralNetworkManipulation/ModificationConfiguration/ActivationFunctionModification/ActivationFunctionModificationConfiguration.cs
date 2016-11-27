using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class ActivationFunctionModificationConfiguration : IActivationFunctionModificationConfiguration
    {
        public IActivationFunctionModificationManipulator ActivationFunctionManipulator { get; private set; }
        public IActivationFunctionModificationGradationFilter GradationFilter { get; private set; }
        public IActivationFunctionModificationTarget Target { get; private set; }

        private ActivationFunctionModificationConfiguration() { }

        public static ActivationFunctionModificationConfiguration Create()
        {
            return new ActivationFunctionModificationConfiguration();
        }

        public IActivationFunctionModificationConfiguration ConfigureGradationFilter(IActivationFunctionModificationGradationFilter activationFunctionModificationGradationFilter)
        {
            GradationFilter = activationFunctionModificationGradationFilter;
            return this;
        }

        public IActivationFunctionModificationConfiguration ConfigureTarget(IActivationFunctionModificationTarget activationFunctionModificationTarget)
        {
            Target = activationFunctionModificationTarget;
            return this;
        }

        public IActivationFunctionModificationConfiguration ConfigureManipulator(IActivationFunctionModificationManipulator activationFunctionModificationManipulator)
        {
            ActivationFunctionManipulator = activationFunctionModificationManipulator;
            return this;
        }
    }
}
