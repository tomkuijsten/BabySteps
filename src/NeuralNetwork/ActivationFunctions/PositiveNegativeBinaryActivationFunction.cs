using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.ActivationFunctions
{
    internal class PositiveNegativeBinaryActivationFunction : IActivationFunction
    {
        public ActivationFunctionCategory Category => ActivationFunctionCategory.Binary;

        public double Activate(double calculatedInput)
        {
            return (calculatedInput >= 0) ? 1 : -1;
        }

        public override string ToString()
        {
            return $"PositiveNegativeBinary function in category {Category}";
        }
    }
}
