using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.ActivationFunctions
{
    internal class SigmoidActivationFunction : IActivationFunction
    {
        public ActivationFunctionCategory Category => ActivationFunctionCategory.Logistic;

        public double Activate(double input)
        {
            return (1 / (1 + Math.Exp(-input)));
        }

        public override string ToString()
        {
            return $"Sigmoid function in category {Category}";
        }
    }
}
