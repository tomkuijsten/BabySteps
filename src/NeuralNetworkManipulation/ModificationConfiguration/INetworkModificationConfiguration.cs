using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification;
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
        INetworkModificationConfiguration ConfigureBias(IBiasModificationConfiguration biasModificationConfiguration);
    }
}
