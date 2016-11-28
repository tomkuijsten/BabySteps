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
        static void Main(string[] args)
        {
            Dictionary<INeuralNetwork, List<Iris>> networks = new Dictionary<INeuralNetwork, List<Iris>>();
            var editor = NetworkEditor.CreateRandom(new DoubleRange(-5, 5), new DoubleRange(-5, 5));
            for (int i = 0; i < 1000; i++)
            {
                var nn = SimpleNeuralNetworkFactory.Create(4, 7, 3);
                editor.Manipulate(nn);
                networks.Add(nn, new List<Iris>());
            }

            var best20 = CalculateResult(networks);

            Console.ReadKey();

            var varyWeightsEditor = NetworkEditor.CreateVaryWeights(new DoubleRange(0.8, 1.2));
            while (true)
            {
                var bestNetworks = new Dictionary<INeuralNetwork, List<Iris>>(best20);
                foreach (var bestNetwork in bestNetworks.ToArray())
                {
                    INeuralNetwork newNetwork = bestNetwork.Key.Clone();
                    varyWeightsEditor.Manipulate(newNetwork);
                    bestNetworks.Add(newNetwork, new List<Iris>());
                }

                best20 = CalculateResult(bestNetworks);
                
                Console.ReadKey();
            }
        }

        private static Dictionary<INeuralNetwork, List<Iris>> CalculateResult(Dictionary<INeuralNetwork, List<Iris>> networks)
        {
            foreach (var network in networks)
            {
                foreach (var iris in IrisDataSet.IrisDataNormalized)
                {
                    var output = network.Key.CalculateNeuralNetwork(iris.Input);

                    double[] normalizedOutput = NormalizedOutput(output);

                    IrisType iType = GetIrisType(normalizedOutput);

                    if (iType == iris.Type)
                    {
                        network.Value.Add(iris);
                    }
                    //Console.WriteLine(string.Join(",", output));
                }
            }

            var best20 = networks.OrderByDescending(n => n.Value.Count).Take(20);
            foreach (var n in best20)
            {
                Console.WriteLine($"Network has {n.Value.Count} correct answers");
            }

            return best20.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private static IrisType GetIrisType(IEnumerable<double> normalizedOutput)
        {
            Dictionary<double[], IrisType> normalizationDict = new Dictionary<double[], IrisType>()
            {
                [new[] { 0d, 0d, 1d }] = IrisType.IrisSetosa,
                [new[] { 0d, 1d, 0d }] = IrisType.IrisSetosa,
                [new[] { 1d, 0d, 0d }] = IrisType.IrisSetosa
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
            return output.Select(o => o > 0.5 ? 1d : 0d).ToArray();
        }
    }
}
