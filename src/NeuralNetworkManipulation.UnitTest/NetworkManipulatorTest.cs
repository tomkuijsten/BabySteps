using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabySteps.NeuralNetwork.NetworkManipulation;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification;
using BabySteps.NeuralNetworkManipulation;
using BabySteps.NeuralNetwork.NetworkTypes;

namespace NeuralNetworkManipulation.UnitTest
{
    [TestClass]
    public class NetworkManipulatorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var nn = SimpleNeuralNetworkFactory.Create(1, 1, 1);
            var initializer = new NetworkInitializer(1);
            initializer.Initialize(nn);
        }
    }
}
