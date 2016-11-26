using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devvy.NeuralNetwork.ActivationFunctions
{
    public interface IActivationFunction
    {
        ActivationFunctionCategory Category { get; }
        double Activate(double calculatedInput);
    }
}
