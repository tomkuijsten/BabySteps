namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public interface IWeightModifier
    {
        double Modify(double originalValue);
    }
}