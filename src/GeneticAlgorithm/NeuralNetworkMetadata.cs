using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork;

namespace BabySteps.GeneticAlgorithm
{
    internal class NeuralNetworkMetadata : INeuralNetworkMetadata
    {
        private List<FeedResult> _feedResults;

        public IEnumerable<FeedResult> FeedResults => _feedResults;
        public int Generation { get; private set; }
        public INeuralNetwork Network { get; }

        public NeuralNetworkMetadata(INeuralNetwork neuralNetwork, int generation)
        {
            _feedResults = new List<FeedResult>();
            Network = neuralNetwork;
            Generation = generation;
        }

        public double NetworkFitness
        {
            get
            {
                return FeedResults.Sum(r => r.Fitness);
            }
        }

        public void RegisterFeedResult(double[] input, double[] output, double fitness)
        {
            _feedResults.Add(new FeedResult(input, output, fitness));
        }

        public void Age()
        {
            _feedResults.Clear();
            Generation++;
        }

        public override string ToString()
        {
            return $"GEN-{Generation}: got fed {FeedResults.Count()} times, fitness result is {NetworkFitness}";
        }
    }
}
