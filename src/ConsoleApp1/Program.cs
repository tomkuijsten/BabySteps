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

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int generationNr = 0;
            IEnumerable<INeuralNetwork> basedOn = null;
            while (true)
            {
                generationNr++;
                List<INeuralNetwork> networks = new List<INeuralNetwork>();
                var trainingData = IrisDataSet.IrisDataNormalized;

                if(basedOn != null)
                {
                    networks.AddRange(basedOn);
                    foreach (var nn in basedOn)
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            //networks.Add(SimpleNeuralNetworkFactory.Create(nn));
                        }
                    }
                }

                for (int i = networks.Count; i < 5000; i++)
                {
                    networks.Add(SimpleNeuralNetworkFactory.Create(4, 20, 3));
                }

                Dictionary<INeuralNetwork, double> score = new Dictionary<INeuralNetwork, double>();
                foreach (var network in networks.AsParallel())
                {
                    List<double> results = new List<double>();
                    int success = 0;
                    foreach (var irisData in trainingData)
                    {
                        network.CalculateNeuralNetwork(irisData.Input);
                        var output = network.Output.Select(o => o.Value).ToArray();
                        if (TryAnalyzeOutput(output, out var normalizedOutput) && normalizedOutput == irisData.Type)
                        {
                            success++;
                        }
                    }
                    score.Add(network, (100.0 / trainingData.Count()) * success);
                }

                var topScoringNetworks = score.Where(s => s.Value > 0).OrderByDescending(s => s.Value).Take(20);
                Console.WriteLine($"Generation {generationNr} training finished");

                foreach (var network in topScoringNetworks)
                {
                    Console.WriteLine($"Generation {network.Key.Generation} trained, score: {network.Value}%");
                }

                //Console.WriteLine("Want to continue? press any key");
                Console.Read();

                basedOn = topScoringNetworks.Select(t => t.Key);
                foreach(var topper in basedOn)
                {
                    topper.Generation++;
                }
            }
        }

        private static bool TryAnalyzeOutput(double[] output, out IrisType type)
        {
            //Console.WriteLine($"{(string.Join(",", output))}");
            var normalized = output.Select(o => o >= 1 ? 1 : 0);
            if (normalized.SequenceEqual(new[] { 1, 0, 0 }))
            {
                type = IrisType.IrisVirginica;
            }
            else if (normalized.SequenceEqual(new[] { 0, 1, 0 }))
            {
                type = IrisType.IrisVirginica;

            }
            else if (normalized.SequenceEqual(new[] { 0, 0, 1 }))
            {
                type = IrisType.IrisVirginica;

            }
            else
            {
                type = IrisType.Unkown;
                return false;
            }

            return true;
        }
    }
}
