using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabySteps.NeuralNetwork.NetworkManipulation;

namespace NeuralNetworkManipulation.UnitTest
{
    [TestClass]
    public class NetworkManipulatorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var manipulationConfig = NetworkModificationConfiguration.Create()
                .ConfigureBias(BiasModificationConfiguration.Create()
                    .ConfigureTarget(AllBiasModificationTarget.Create())
                    .ConfigureGradationFilter(AllBiasModificationGradationFilter.Create())
                    .ConfigureWeight(PercentageVariationBiasModificationWeight.Create(0.9, 1.1)));

            var manipulator = new NetworkManipulator(manipulationConfig);

            //manipulator.Manipulate(network);
        }
    }
}
