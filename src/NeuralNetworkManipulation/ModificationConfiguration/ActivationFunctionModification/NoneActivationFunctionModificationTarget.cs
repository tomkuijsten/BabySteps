using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetwork.Neurons;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class NoneActivationFunctionModificationTarget : IActivationFunctionModificationTarget
    {
        private NoneActivationFunctionModificationTarget() { }

        public static NoneActivationFunctionModificationTarget Create()
        {
            return new NoneActivationFunctionModificationTarget();
        }

        public IEnumerable<ICalculatableNeuron> GetTarget(INeuralNetwork neuralNetwork)
        {
            return Enumerable.Empty<ICalculatableNeuron>();
        }
    }
}
