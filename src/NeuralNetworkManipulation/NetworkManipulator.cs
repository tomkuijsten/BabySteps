using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetworkManipulation.ModificationConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation
{
    public class NetworkManipulator
    {
        private INetworkModificationConfiguration _modConfig;

        public NetworkManipulator(INetworkModificationConfiguration networkModificationConfiguration)
        {
            _modConfig = networkModificationConfiguration;
        }

        public void Manipulate(INeuralNetwork network)
        {
            ManipulateBiases(network);
        }

        private void ManipulateBiases(INeuralNetwork network)
        {
            var biasTarget = _modConfig.BiasModificationConfiguration.Target;
            var biases = biasTarget.GetTarget(network);
            var filterTargets = _modConfig.BiasModificationConfiguration.GradationFilter.Filter(biases);
            foreach (var bias in filterTargets)
            {
                var newBiasWeight = _modConfig.BiasModificationConfiguration.WeightManipulation.Modify(bias.Outgoing.Weight);
                bias.Outgoing.Weight = newBiasWeight;
            }
        }
    }
}
