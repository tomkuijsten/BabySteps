using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.ActivationFunctions
{
    internal class BinaryActivationFunction : IActivationFunction
    {
        public ActivationFunctionCategory Category => ActivationFunctionCategory.Binary;

        public double Activate(double calculatedInput)
        {
            return (calculatedInput >= 0.5) ? 1 : 0;
        }
    }
}
