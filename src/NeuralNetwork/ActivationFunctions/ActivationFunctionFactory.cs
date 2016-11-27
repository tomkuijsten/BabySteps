using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.ActivationFunctions
{
    public static class ActivationFunctionFactory
    {
        private static Random _randomizer;
        private static Dictionary<ActivationFunctionCategory, IEnumerable<IActivationFunction>> _activationFunctionsByCategory;
        private static IEnumerable<IActivationFunction> _allActivationFunctions;

        internal static IActivationFunction NotImplemented { get; private set; }

        public static IActivationFunction Sigmoid { get; private set; }
        public static IActivationFunction HyperbolicTangent { get; private set; }
        public static IActivationFunction Binary { get; private set; }
        public static IActivationFunction PositiveNegativeBinary { get; private set; }
        public static IActivationFunction Linear { get; private set; }
        public static IActivationFunction LinearTruncated { get; private set; }
        public static IActivationFunction LinearTruncatedAtZero { get; private set; }

        static ActivationFunctionFactory()
        {
            _randomizer = new Random();
            NotImplemented = new NotImplementedActivationFunction();

            InitializeActivationFunctions();
        }

        public static void InitializeActivationFunctions()
        {
            Sigmoid = new SigmoidActivationFunction();
            Binary = new BinaryActivationFunction();
            HyperbolicTangent = new HyperbolicTangentActivationFunction();
            Linear = new LinearActivationFunction();
            LinearTruncated = new LinearTruncatedActivationFunction();
            LinearTruncatedAtZero = new LinearTruncatedAtZeroActivationFunction();
            PositiveNegativeBinary = new PositiveNegativeBinaryActivationFunction();

            _allActivationFunctions = new[] { Sigmoid, Binary, HyperbolicTangent, Linear, LinearTruncated, LinearTruncatedAtZero, PositiveNegativeBinary };
            _activationFunctionsByCategory = new Dictionary<ActivationFunctionCategory, IEnumerable<IActivationFunction>>();

            foreach (ActivationFunctionCategory category in Enum.GetValues(typeof(ActivationFunctionCategory)))
            {
                if (category == ActivationFunctionCategory.Unsorted)
                    continue;

                _activationFunctionsByCategory[category] = _allActivationFunctions.Where(f => f.Category == category).ToArray();
            }
        }

        public static IActivationFunction CreateRandom()
        {
            var randomIndex = _randomizer.Next(0, _activationFunctionsByCategory.Count() - 1);
            return _allActivationFunctions.ElementAt(randomIndex);
        }
    }
}
