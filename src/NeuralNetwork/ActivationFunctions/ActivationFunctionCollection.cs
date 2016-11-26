using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.ActivationFunctions
{
    public static class ActivationFunctionCollection
    {
        private static Random _randomizer;
        private static IEnumerable<IActivationFunction> _activationFunctions;

        public static IActivationFunction Sigmoid { get; private set; }

        static ActivationFunctionCollection()
        {
            _randomizer = new Random();

            Sigmoid = new SigmoidActivationFunction();

            _activationFunctions = new IActivationFunction[] {
                new BinaryActivationFunction(),
                new HyperbolicTangentActivationFunction(),
                new LinearActivationFunction(),
                new LinearTruncatedActivationFunction(),
                new LinearTruncatedAtZeroActivationFunction(),
                new PositiveNegativeBinaryActivationFunction(),
                Sigmoid
            };
        }

        public static IActivationFunction GetRandom()
        {
            var randomIndex = _randomizer.Next(0, _activationFunctions.Count() - 1);
            return _activationFunctions.ElementAt(randomIndex);
        }
    }
}
