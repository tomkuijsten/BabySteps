using BabySteps.NeuralNetwork.Neurons;
using BabySteps.NeuralNetwork.Synapses;
using BabySteps.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork.NetworkTypes;
using BabySteps.NeuralNetworkManipulation;

namespace ConsoleApp1
{
    class Program
    {
        private static int _generation = 0;
        static void Main(string[] args)
        {
            Dictionary<INeuralNetwork, List<Iris>> networks = new Dictionary<INeuralNetwork, List<Iris>>();
            var editor = NetworkEditor.CreateRandom(new DoubleRange(-5, 5), new DoubleRange(-5, 5));
            for (int i = 0; i < 1000; i++)
            {
                var nn = SimpleNeuralNetworkFactory.Create(4, 5, 3);
                editor.Manipulate(nn);
                networks.Add(nn, new List<Iris>());
            }

            var best20 = CalculateResult(networks);

            //Console.ReadKey();

            var varyWeightsEditor = NetworkEditor.CreateVaryWeights(new DoubleRange(0.8, 1.2));
            while (true)
            {
                var bestNetworks = new Dictionary<INeuralNetwork, List<Iris>>(best20);
                foreach (var bestNetwork in bestNetworks.ToArray())
                {
                    for (int i = 0; i < 100; i++)
                    {
                        INeuralNetwork newNetwork = bestNetwork.Key.Clone();
                        varyWeightsEditor.Manipulate(newNetwork);
                        bestNetworks.Add(newNetwork, new List<Iris>()); 
                    }
                }

                for (int i = 0; i < 500; i++)
                {
                    var nn = SimpleNeuralNetworkFactory.Create(4, Randomizer.NextInRange(new IntRange(2, 10)), 3);
                    editor.Manipulate(nn);
                    bestNetworks.Add(nn, new List<Iris>());
                }

                best20 = CalculateResult(bestNetworks);
                
                //Console.ReadKey();
            }
        }

        private static Dictionary<INeuralNetwork, List<Iris>> CalculateResult(Dictionary<INeuralNetwork, List<Iris>> networks)
        {
            foreach (var network in networks.AsParallel())
            {
                double[] output = null;
                double[] fitness = null;
                double[] normalizedOutput = null;
                foreach (var iris in IrisDataSet.IrisDataNormalized.AsParallel())
                {
                    output = network.Key.CalculateNeuralNetwork(iris.Input);

                    normalizedOutput = NormalizedOutput(output);
                    fitness = CalculateFitness(normalizedOutput);

                    IrisType iType = GetIrisType(fitness);

                    if (iType == iris.Type)
                    {
                        network.Value.Add(iris);
                    }
                }

                //Console.WriteLine($"{string.Join("|", output)} => {string.Join("|", normalizedOutput)} => {string.Join("|", fitness)}");
            }

            _generation++;

            Console.WriteLine("===========================================");
            Console.WriteLine($"======== SCORE FOR GENERATION {_generation} ==========");
            Console.WriteLine("===========================================");
            var best20 = networks.OrderByDescending(n => n.Value.Count).Take(20).ToArray();
            foreach (var n in best20)
            {
                Console.WriteLine($"Network (gen {n.Key.Generation}) has {n.Value.Count} correct answers");
                n.Key.Generation++;
                n.Value.Clear();
            }
            Console.WriteLine("===========================================");
            Console.WriteLine("");


            return best20.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private static IrisType GetIrisType(IEnumerable<double> normalizedOutput)
        {
            Dictionary<double[], IrisType> normalizationDict = new Dictionary<double[], IrisType>()
            {
                [new[] { 0d, 0d, 1d }] = IrisType.IrisSetosa,
                [new[] { 0d, 1d, 0d }] = IrisType.IrisVersicolor,
                [new[] { 1d, 0d, 0d }] = IrisType.IrisVirginica
            };

            foreach (var norm in normalizationDict)
            {
                if (normalizedOutput.SequenceEqual(norm.Key))
                {
                    return norm.Value;
                }
            }

            return IrisType.Unkown;
        }

        private static double[] NormalizedOutput(double[] output)
        {
            return Normalizer.NormalizeAll(output, new DoubleRange(0, 1));
        }

        private static double[] CalculateFitness(double[] normalizedOutput)
        {
            return normalizedOutput.Select(n => n > 0.8 ? 1d : 0d).ToArray();
        }
    }
}
