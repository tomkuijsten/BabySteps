using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public interface IActivationFunctionModificationConfiguration
    {
        IActivationFunctionModificationTarget Target { get; }
        IActivationFunctionModificationGradationFilter GradationFilter { get; }
        IActivationFunctionModificationManipulator ActivationFunctionManipulator { get; }

        IActivationFunctionModificationConfiguration ConfigureGradationFilter(IActivationFunctionModificationGradationFilter activationFunctionModificationGradationFilter);
        IActivationFunctionModificationConfiguration ConfigureTarget(IActivationFunctionModificationTarget activationFunctionModificationTarget);
        IActivationFunctionModificationConfiguration ConfigureManipulator(IActivationFunctionModificationManipulator activationFunctionModificationManipulator);
    }
}
