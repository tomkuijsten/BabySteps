using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration
{
    public interface INetworkModificationConfiguration
    {
        IBiasModificationConfiguration BiasModificationConfiguration { get; }
        IWeightModificationConfiguration WeightModificationConfiguration { get; }
        IActivationFunctionModificationConfiguration ActivationFunctionModificationConfiguration { get; }

        INetworkModificationConfiguration ConfigureBias(IBiasModificationConfiguration biasModificationConfiguration);
        INetworkModificationConfiguration ConfigureWeight(IWeightModificationConfiguration weightModificationConfiguration);
        INetworkModificationConfiguration ConfigureActivationFunction(IActivationFunctionModificationConfiguration activationFunctionModificationConfiguration);
    }
}
