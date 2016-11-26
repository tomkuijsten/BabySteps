using Devvy.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devvy.NeuralNetwork.NetworkManipulation
{
    public class SampleManipulation
    {
        public void ManipulateNetwork(INeuralNetwork network)
        {
            var manipulationConfig = NetworkModificationConfiguration.Create()
                .ConfigureBias(BiasModificationConfiguration.Create()
                    .ConfigureGradationFilter(AllBiasModificationGradationFilter.Create())
                    .ConfigureTarget(AllBiasModificationTarget.Create())
                    .ConfigureWeight(PercentageVariationBiasModificationWeight.Create(0.9, 1.1)));

            var manipulator = new NetworkManipulator(manipulationConfig);

            manipulator.Manipulate(network);
        }
    }

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
    /// <summary>
    /// Bias (all/hidden/output):
    /// Weights (ToHidden/ToOutput):
    ///  - % min/max afwijking
    ///  - random/static
    ///  - All, One, x%
    /// ActivationFunction (Hidden/Output/All):
    ///  - Randomize/VaryInCategory/Generalize
    ///  - All, One, x%
    /// </summary>
    /// 
    public interface INetworkModificationConfiguration
    {
        IBiasModificationConfiguration BiasModificationConfiguration { get; }
        INetworkModificationConfiguration ConfigureBias(IBiasModificationConfiguration biasModificationConfiguration);
    }

    public class NetworkModificationConfiguration : INetworkModificationConfiguration
    {
        public IBiasModificationConfiguration BiasModificationConfiguration { get; private set; }

        public static NetworkModificationConfiguration Create()
        {
            return new NetworkModificationConfiguration();
        }

        public INetworkModificationConfiguration ConfigureBias(IBiasModificationConfiguration biasModificationConfiguration)
        {
            BiasModificationConfiguration = biasModificationConfiguration;
            return this;
        }
    }

    public interface IBiasModificationConfiguration
    {
        IBiasModificationTarget Target { get; }
        IBiasModificationGradationFilter GradationFilter { get; }
        IBiasModificationWeight WeightManipulation { get; }
        IBiasModificationConfiguration ConfigureGradationFilter(IBiasModificationGradationFilter biasModificationGradationFilter);
        IBiasModificationConfiguration ConfigureTarget(IBiasModificationTarget biasModificationTarget);
        IBiasModificationConfiguration ConfigureWeight(IBiasModificationWeight biasModificationWeight);
    }

    public class BiasModificationConfiguration : IBiasModificationConfiguration
    {
        public IBiasModificationGradationFilter GradationFilter { get; private set; }

        public IBiasModificationTarget Target { get; private set; }
        public IBiasModificationWeight WeightManipulation { get; private set; }

        public static IBiasModificationConfiguration Create()
        {
            return new BiasModificationConfiguration();
        }

        public IBiasModificationConfiguration ConfigureGradationFilter(IBiasModificationGradationFilter biasModificationGradationFilter)
        {
            GradationFilter = biasModificationGradationFilter;
            return this;
        }

        public IBiasModificationConfiguration ConfigureTarget(IBiasModificationTarget biasModificationTarget)
        {
            Target = biasModificationTarget;
            return this;
        }

        public IBiasModificationConfiguration ConfigureWeight(IBiasModificationWeight biasModificationWeight)
        {
            WeightManipulation = biasModificationWeight;
            return this;
        }
    }

    public interface IBiasModificationTarget
    {
        IEnumerable<Bias> GetTarget(INeuralNetwork neuralNetwork);
    }

    public class AllBiasModificationTarget : IBiasModificationTarget
    {
        public IEnumerable<Bias> GetTarget(INeuralNetwork neuralNetwork)
        {
            return neuralNetwork.Biases;
        }

        public static AllBiasModificationTarget Create()
        {
            return new AllBiasModificationTarget();
        }
    }

    public interface IBiasModificationGradationFilter
    {
        IEnumerable<Bias> Filter(IEnumerable<Bias> input);
    }

    public class AllBiasModificationGradationFilter : IBiasModificationGradationFilter
    {
        public IEnumerable<Bias> Filter(IEnumerable<Bias> input)
        {
            return input;
        }

        public static AllBiasModificationGradationFilter Create()
        {
            return new AllBiasModificationGradationFilter();
        }
    }


    public interface IBiasModificationWeight
    {
        double Modify(double originalValue);
    }

    public class PercentageVariationBiasModificationWeight : IBiasModificationWeight
    {
        private Random _randomizer;
        private double _minVariationPercentage;
        private double _maxVariationPercentage;

        public static PercentageVariationBiasModificationWeight Create(double minVariation, double maxVariation)
        {
            var instance = new PercentageVariationBiasModificationWeight();
            instance._randomizer = new Random();
            instance._minVariationPercentage = minVariation;
            instance._maxVariationPercentage = maxVariation;

            return instance;
        }

        public double Modify(double originalValue)
        {
            var random = _randomizer.NextDouble();
            var scope = _maxVariationPercentage - _minVariationPercentage;
            var variationFactor = (scope * random) + _minVariationPercentage;

            return variationFactor * originalValue;
        }
    }
}
