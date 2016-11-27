using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.Synapses
{
    public interface ISynapse
    {
        object From { get; set; }
        object To { get; set; }
        double Weight { get; set; }

    }
}
