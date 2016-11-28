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
        IWeightModifier Modifier { get; }
    }
}
