using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.ActivationFunctions
{
    internal class LinearTruncatedActivationFunction : IActivationFunction
    {
        public ActivationFunctionCategory Category => ActivationFunctionCategory.Lineair;

        public double Activate(double calculatedInput)
        {
            return (calculatedInput >= 1) ? 1 : (calculatedInput <= -1) ? -1 : calculatedInput;
        }

        public override string ToString()
        {
            return $"LinearTruncated function in category {Category}";
        }
    }
}
