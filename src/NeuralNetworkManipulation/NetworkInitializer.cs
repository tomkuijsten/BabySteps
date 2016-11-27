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
    public class NetworkInitializer
    {
        private double _baseValue;

        public NetworkInitializer(double baseValue)
        {
            _baseValue = baseValue;
        }

        public void Initialize(INeuralNetwork network)
        {
            var manipulationConfig = NetworkModificationConfiguration.Create()
                .ConfigureBias(BiasModificationConfiguration.Create()
                    .ConfigureTarget(AllBiasModificationTarget.Create())
                    .ConfigureGradationFilter(AllBiasModificationGradationFilter.Create())
                    .ConfigureWeight(StaticValueBiasModificationWeight.Create(_baseValue)))
                .ConfigureWeight(WeightModificationConfiguration.Create()
                    .ConfigureTarget(AllWeightModificationTarget.Create())
                    .ConfigureGradationFilter(AllWeightModificationGradationFilter.Create())
                    .ConfigureModification(StaticValueWeightModification.Create(_baseValue)))
                .ConfigureActivationFunction(ActivationFunctionModificationConfiguration.Create()
                    .ConfigureTarget(AllActivationFunctionModificationTarget.Create())
                    .ConfigureGradationFilter(AllActivationFunctionModificationGradationFilter.Create())
                    .ConfigureManipulator(RandomActivationFunctionModificationManipulator.Create())
                );

            var manipulator = new NetworkManipulator(manipulationConfig);

            manipulator.Manipulate(network);
        }
    }
}
