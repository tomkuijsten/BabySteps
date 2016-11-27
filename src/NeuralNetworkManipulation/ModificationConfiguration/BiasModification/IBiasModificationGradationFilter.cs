using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public interface IBiasModificationGradationFilter
    {
        IEnumerable<Bias> Filter(IEnumerable<Bias> input);
    }
}
