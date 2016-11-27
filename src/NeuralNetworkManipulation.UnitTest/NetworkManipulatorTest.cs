using Microsoft.VisualStudio.TestTools.UnitTesting;
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
