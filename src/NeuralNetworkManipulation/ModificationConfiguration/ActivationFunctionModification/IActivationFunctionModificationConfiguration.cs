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
        IActivationFunctionModifier Modifier { get; }
    }
}
