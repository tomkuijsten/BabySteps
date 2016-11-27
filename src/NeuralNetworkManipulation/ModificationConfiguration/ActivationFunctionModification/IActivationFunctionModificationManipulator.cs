using BabySteps.NeuralNetwork.ActivationFunctions;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public interface IActivationFunctionModificationManipulator
    {
        IActivationFunction Modify(IActivationFunction originalValue);
    }
}