using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration
{
    public class NetworkModificationConfiguration : INetworkModificationConfiguration
    {
        public IBiasModificationConfiguration BiasModificationConfiguration { get; private set; }

        public static NetworkModificationConfiguration Create()
        {
            return new NetworkModificationConfiguration();
        }

        public INetworkModificationConfiguration ConfigureBias(IBiasModificationConfiguration biasModificationConfiguration)
        {
            BiasModificationConfiguration = biasModificationConfiguration;
            return this;
        }
    }
}
