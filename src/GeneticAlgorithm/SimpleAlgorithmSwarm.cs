using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetworkManipulation;
using BabySteps.NeuralNetwork.NetworkTypes;

namespace BabySteps.GeneticAlgorithm
{
    public class SimpleAlgorithmSwarm : IGeneticSwarm
    {
        /// <summary>
        /// The % which should survive an evolution
        /// </summary>
        private const double SURVIVORS_SIZE = 0.05;

        /// <summary>
        /// The % of the total neural network pool which should be randomized completely when evolving
        /// </summary>
        private const double NEW_RANDOM_SIZE = 0.2;

        private readonly int _nrOfInputs;
        private readonly int _nrOfOutputs;
        private readonly int _nrOfHidden;
        private readonly int _maxNrOfNetworks;
        private readonly List<INetworkData> _swarm;
        private readonly IOCalculation _fitnessFunction;

        public IEnumerable<INetworkData> Swarm => _swarm;

        public SimpleAlgorithmSwarm(int numberOfInputs, int numberOfOutputs, int maxNumberOfNetworks, IOCalculation fitnessFunction)
        {
            _swarm = new List<INetworkData>();
            _nrOfInputs = numberOfInputs;
            _nrOfOutputs = numberOfOutputs;
            // Just some weird calculation to determine hidden nodes, could be random sometime
            _nrOfHidden = _nrOfInputs + _nrOfOutputs;
            _fitnessFunction = fitnessFunction;
            _maxNrOfNetworks = maxNumberOfNetworks;

            var newGeneration = GenerateNewGeneration(_maxNrOfNetworks);
            _swarm.AddRange(newGeneration);
        }

        private IEnumerable<INetworkData> GenerateNewGeneration(int maxNumberOfNetworks)
        {
            var editor = NetworkEditor.CreateRandom(new DoubleRange(-5, 5), new DoubleRange(-5, 5));
            for (int i = 0; i < maxNumberOfNetworks; i++)
            {
                var nn = SimpleNeuralNetworkFactory.Create(_nrOfInputs, _nrOfHidden, _nrOfOutputs);
                editor.Manipulate(nn);

                yield return new NetworkData(nn, 0);
            }
        }

        public void Feed(double[] input)
        {
            foreach (var networkData in Swarm)
            {
                networkData.Network.CalculateNeuralNetwork(input);
                double[] output = networkData.Network.Output.Select(o => o.Value).ToArray();
                networkData.RegisterFeedResult(input, output, _fitnessFunction(input, output));
            }
        }

        public INetworkData GetWinner()
        {
            return PickTheTopX().First();
        }

        public void Evolve()
        {
            INetworkData[] survivors = PickTheTopX();

            foreach (var s in survivors)
            {
                Console.WriteLine(s);
            }

            EvolveNetworks(survivors);

            WipeSwarm();

            int randomSize = (int)(_maxNrOfNetworks * NEW_RANDOM_SIZE);
            int survivorGenerationSize = _maxNrOfNetworks - randomSize;

            _swarm.AddRange(CreateNewSurvivorGeneration(survivors, survivorGenerationSize));

            int randomAmount = _maxNrOfNetworks - _swarm.Count();
            _swarm.AddRange(GenerateNewGeneration(randomAmount));
        }

        private void WipeSwarm()
        {
            _swarm.Clear();
        }

        private IEnumerable<INetworkData> CreateNewSurvivorGeneration(INetworkData[] survivors, int survivorGenerationSize)
        {
            var nrOfSurvivors = survivors.Count();
            int nrOfVariationsPerSurvivor = survivorGenerationSize / nrOfSurvivors;
            var varyWeightsEditor = NetworkEditor.CreateVaryWeights(new DoubleRange(0.8, 1.2));

            foreach (var survivor in survivors)
            {
                _swarm.Add(survivor);
                for (int i = 0; i < nrOfVariationsPerSurvivor; i++)
                {
                    var nn = survivor.Network.Clone();
                    varyWeightsEditor.Manipulate(nn);

                    yield return new NetworkData(nn, survivor.Generation);
                }
            }
        }

        private void EvolveNetworks(INetworkData[] survivers)
        {
            foreach (var survivor in survivers)
            {
                survivor.Age();
            }
        }

        private INetworkData[] PickTheTopX()
        {
            int swarmSize = Swarm.Count();
            int nrOfSurvivors = (int)(swarmSize * SURVIVORS_SIZE);
            var networkDataOrderedByFitness = Swarm.OrderByDescending(s => s.NetworkFitness);
            var survivers = networkDataOrderedByFitness.Take(nrOfSurvivors).ToArray();

            return survivers;
        }
    }
}
