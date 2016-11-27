using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration
{
    public class NetworkModificationConfiguration : INetworkModificationConfiguration
    {
        public IActivationFunctionModificationConfiguration ActivationFunctionModificationConfiguration { get; private set; }
        public IBiasModificationConfiguration BiasModificationConfiguration { get; private set; }

        public IWeightModificationConfiguration WeightModificationConfiguration { get; private set; }

        public static NetworkModificationConfiguration Create()
        {
            return new NetworkModificationConfiguration();
        }

        public INetworkModificationConfiguration ConfigureActivationFunction(IActivationFunctionModificationConfiguration activationFunctionModificationConfiguration)
        {
            ActivationFunctionModificationConfiguration = activationFunctionModificationConfiguration;
            return this;
        }

        public INetworkModificationConfiguration ConfigureBias(IBiasModificationConfiguration biasModificationConfiguration)
        {
            BiasModificationConfiguration = biasModificationConfiguration;
            return this;
        }

        public INetworkModificationConfiguration ConfigureWeight(IWeightModificationConfiguration weightModificationConfiguration)
        {
            WeightModificationConfiguration = weightModificationConfiguration;
            return this;
        }
    }
}
