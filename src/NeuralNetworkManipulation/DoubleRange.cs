using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation
{
    public struct DoubleRange
    {
        public double Min { get; }
        public double Max { get; }

        public DoubleRange(double min, double max)
        {
            Min = min;
            Max = max;
        }

        public override string ToString()
        {
            return $"{Min} to {Max}";
        }
    }
}
