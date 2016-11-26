using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devvy.NeuralNetwork.ActivationFunctions
{
    internal class LinearActivationFunction : IActivationFunction
    {
        public ActivationFunctionCategory Category => ActivationFunctionCategory.Lineair;

        public double Activate(double calculatedInput)
        {
            return calculatedInput;
        }
    }
}
