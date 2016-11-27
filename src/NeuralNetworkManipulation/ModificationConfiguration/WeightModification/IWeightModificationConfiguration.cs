using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public interface IWeightModificationConfiguration
    {
        IWeightModificationTarget Target { get; }
        IWeightModificationGradationFilter GradationFilter { get; }
        IWeightModification Manipulation { get; }

        IWeightModificationConfiguration ConfigureGradationFilter(IWeightModificationGradationFilter weightModificationGradationFilter);
        IWeightModificationConfiguration ConfigureTarget(IWeightModificationTarget weightModificationTarget);
        IWeightModificationConfiguration ConfigureModification(IWeightModification weightModification);
    }
}
