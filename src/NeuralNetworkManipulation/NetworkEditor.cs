using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation
{
    public class NetworkEditor
    {
        private NetworkManipulator _manipulator;

        public static NetworkEditor CreateStaticValue(double biasValue, double weightValue)
        {
            var manipulationConfig = NetworkModificationConfiguration.Create()
                .ConfigureBias(BiasModificationConfiguration.Create()
                    .ConfigureTarget(AllBiasModificationTarget.Create())
                    .ConfigureGradationFilter(AllBiasModificationGradationFilter.Create())
                    .ConfigureModifier(StaticValueBiasModifier.Create(biasValue)))
                .ConfigureWeight(WeightModificationConfiguration.Create()
                    .ConfigureTarget(AllWeightModificationTarget.Create())
                    .ConfigureGradationFilter(AllWeightModificationGradationFilter.Create())
                    .ConfigureModifier(StaticValueWeightModifier.Create(weightValue)))
                .ConfigureActivationFunction(ActivationFunctionModificationConfiguration.Create()
                    .ConfigureTarget(AllActivationFunctionModificationTarget.Create())
                    .ConfigureGradationFilter(AllActivationFunctionModificationGradationFilter.Create())
                    .ConfigureModifier(RandomActivationFunctionModifier.Create())
                );

            var manipulator = new NetworkManipulator(manipulationConfig);

            return new NetworkEditor()
            {
                _manipulator = manipulator
            };
        }

        public static NetworkEditor CreateRandom(DoubleRange biasRange, DoubleRange weightRange)
        {
            var manipulationConfig = NetworkModificationConfiguration.Create()
                .ConfigureBias(BiasModificationConfiguration.Create()
                    .ConfigureTarget(AllBiasModificationTarget.Create())
                    .ConfigureGradationFilter(AllBiasModificationGradationFilter.Create())
                    .ConfigureModifier(RandomBiasModifier.Create(biasRange)))
                .ConfigureWeight(WeightModificationConfiguration.Create()
                    .ConfigureTarget(AllWeightModificationTarget.Create())
                    .ConfigureGradationFilter(AllWeightModificationGradationFilter.Create())
                    .ConfigureModifier(RandomWeightModifier.Create(weightRange)))
                .ConfigureActivationFunction(ActivationFunctionModificationConfiguration.Create()
                    .ConfigureTarget(AllActivationFunctionModificationTarget.Create())
                    .ConfigureGradationFilter(AllActivationFunctionModificationGradationFilter.Create())
                    .ConfigureModifier(RandomActivationFunctionModifier.Create())
                );

            var manipulator = new NetworkManipulator(manipulationConfig);

            return new NetworkEditor()
            {
                _manipulator = manipulator
            };
        }

        public static NetworkEditor CreateVaryWeights(DoubleRange varyPercentageRange)
        {
            var manipulationConfig = NetworkModificationConfiguration.Create()
                .ConfigureBias(IgnoreBiasModificationConfiguration.Create())
                .ConfigureActivationFunction(IgnoreActivationFunctionModificationConfiguration.Create())
                .ConfigureWeight(WeightModificationConfiguration.Create()
                    .ConfigureTarget(AllWeightModificationTarget.Create())
                    .ConfigureGradationFilter(AllWeightModificationGradationFilter.Create())
                    .ConfigureModifier(PercentageVariationWeightModifier.Create(varyPercentageRange)));

            var manipulator = new NetworkManipulator(manipulationConfig);

            return new NetworkEditor()
            {
                _manipulator = manipulator
            };
        }

        public void Manipulate(INeuralNetwork network)
        {
            _manipulator.Manipulate(network);
        }
    }
}
