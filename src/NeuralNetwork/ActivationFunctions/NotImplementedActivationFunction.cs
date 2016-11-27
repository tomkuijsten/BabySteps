using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.ActivationFunctions
{
    public class NotImplementedActivationFunction : IActivationFunction
    {
        public ActivationFunctionCategory Category => ActivationFunctionCategory.Unsorted;

        public double Activate(double calculatedInput)
        {
            throw new NotImplementedException("Invalid activation function is used");
        }
    }
}
