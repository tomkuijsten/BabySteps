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
            ManipulateWeights(network);
            ManipulateActivationFunctions(network);
        }

        private void ManipulateActivationFunctions(INeuralNetwork network)
        {
            var calculatableNeuronTarget = _modConfig.ActivationFunctionModificationConfiguration.Target;
            var calculatableNeurons = calculatableNeuronTarget.GetTarget(network);
            var filteredNeurons = _modConfig.ActivationFunctionModificationConfiguration.GradationFilter.Filter(calculatableNeurons);
            foreach (var calculatableNeuron in filteredNeurons)
            {
                calculatableNeuron.ActivationFunction = _modConfig.ActivationFunctionModificationConfiguration.ActivationFunctionManipulator.Modify(calculatableNeuron.ActivationFunction);
            }
        }

        private void ManipulateWeights(INeuralNetwork network)
        {
            var synapseTarget = _modConfig.WeightModificationConfiguration.Target;
            var synapses = synapseTarget.GetTarget(network);
            var filterSynapses = _modConfig.WeightModificationConfiguration.GradationFilter.Filter(synapses);
            foreach (var synapse in filterSynapses)
            {
                synapse.Weight = _modConfig.WeightModificationConfiguration.Manipulation.Modify(synapse.Weight);
            }
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
