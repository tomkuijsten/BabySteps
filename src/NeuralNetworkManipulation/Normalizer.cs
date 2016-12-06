using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation
{
    public class Normalizer
    {
        private double _sourceMin;
        private double _sourceSpread;

        private double _targetSpread;
        private DoubleRange _targetRange;

        /// <summary>
        /// Initializes a new instance of the <see cref="Normalizer"/> class
        /// </summary>
        /// <param name="source">The known source (input) values</param>
        /// <param name="targetRange">The targetted range for the output value</param>
        public Normalizer(double[] source, DoubleRange targetRange)
        {
            _sourceMin = source.Min();
            _sourceSpread = source.Max() - _sourceMin;

            _targetRange = targetRange;
            _targetSpread = _targetRange.Max - _targetRange.Min;
        }

        public double Normalize(double input)
        {
            var relativeSourceSpread = 1 / _sourceSpread * (input - _sourceMin);
            return (_targetSpread * relativeSourceSpread) + _targetRange.Min;
        }

        public static double[] NormalizeAll(double[] source, DoubleRange targetRange)
        {
            var sourceMin = source.Min();
            var sourceSpread = source.Max() - sourceMin;

            var targetSpread = targetRange.Max - targetRange.Min;

            return source.Select(input => {
                var relativeSourceSpread = 1 / sourceSpread * (input - sourceMin);
                return (targetSpread * relativeSourceSpread) + targetRange.Min;
            }).ToArray();
        }
    }
}
