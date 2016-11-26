using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.ActivationFunctions
{
    internal class LinearTruncatedAtZeroActivationFunction : IActivationFunction
    {
        public ActivationFunctionCategory Category => ActivationFunctionCategory.Lineair;

        public double Activate(double calculatedInput)
        {
            return (calculatedInput >= 1) ? 1 : (calculatedInput <= 0) ? 0 : calculatedInput;
        }
    }
}
