using BabySteps.NeuralNetwork;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BabySteps.GeneticAlgorithm
{
    public delegate double IOCalculation(double[] input, double[] output);

    public struct FeedResult
    {
        public double[] Input { get; }
        public double[] Output { get; }
        public double Fitness { get; }

        public FeedResult(double[] input, double[] output, double fitness)
        {
            Input = input;
            Output = output;
            Fitness = fitness;
        }
    }

    public interface INeuralNetworkMetadata
    {
        int Generation { get; }
        INeuralNetwork Network { get; }
        double NetworkFitness { get; }
        IEnumerable<FeedResult> FeedResults { get; }

        void RegisterFeedResult(double[] input, double[] output, double fitness);
        void Age();
    }

    public interface IGeneticSwarm
    {
        IEnumerable<INeuralNetworkMetadata> Swarm { get; }

        void Feed(double[] input);

        void Evolve();

        INeuralNetworkMetadata GetWinner();
    }
}