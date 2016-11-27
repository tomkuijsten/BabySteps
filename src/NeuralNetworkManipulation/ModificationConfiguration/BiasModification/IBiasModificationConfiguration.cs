﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public interface IBiasModificationConfiguration
    {
        IBiasModificationTarget Target { get; }
        IBiasModificationGradationFilter GradationFilter { get; }
        IBiasModificationWeight WeightManipulation { get; }

        IBiasModificationConfiguration ConfigureGradationFilter(IBiasModificationGradationFilter biasModificationGradationFilter);
        IBiasModificationConfiguration ConfigureTarget(IBiasModificationTarget biasModificationTarget);
        IBiasModificationConfiguration ConfigureWeight(IBiasModificationWeight biasModificationWeight);
    }
}
