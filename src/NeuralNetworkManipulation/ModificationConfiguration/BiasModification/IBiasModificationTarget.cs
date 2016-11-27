using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public interface IBiasModificationTarget
    {
        IEnumerable<Bias> GetTarget(INeuralNetwork neuralNetwork);
    }
}
