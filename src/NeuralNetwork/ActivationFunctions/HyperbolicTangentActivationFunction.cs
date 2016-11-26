using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devvy.NeuralNetwork.ActivationFunctions
{
    internal class HyperbolicTangentActivationFunction : IActivationFunction
    {
        public ActivationFunctionCategory Category => ActivationFunctionCategory.Logistic;

        public double Activate(double calculatedInput)
        {
            return Math.Tanh(calculatedInput);
        }
    }
}
