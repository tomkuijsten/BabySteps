using BabySteps.NeuralNetwork.ActivationFunctions;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public interface IActivationFunctionModifier
    {
        IActivationFunction Modify(IActivationFunction originalValue);
    }
}