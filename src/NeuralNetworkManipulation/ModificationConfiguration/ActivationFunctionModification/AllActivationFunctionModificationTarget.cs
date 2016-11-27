using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetwork.Neurons;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class AllActivationFunctionModificationTarget : IActivationFunctionModificationTarget
    {
        private AllActivationFunctionModificationTarget() { }

        public static AllActivationFunctionModificationTarget Create()
        {
            return new AllActivationFunctionModificationTarget();
        }

        public IEnumerable<ICalculatableNeuron> GetTarget(INeuralNetwork neuralNetwork)
        {
            return neuralNetwork.Neurons.OfType<ICalculatableNeuron>().ToArray();
        }
    }
}
