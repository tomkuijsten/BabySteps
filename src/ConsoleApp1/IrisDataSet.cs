using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class IrisDataSet
    {
        public static IEnumerable<Iris> IrisData { get; private set; }
        public static IEnumerable<Iris> IrisDataNormalized { get; private set; }

        static IrisDataSet()
        {
            IrisData = new Iris[] {
                new Iris(5.1,3.5,1.4,0.2,IrisType.IrisSetosa),
                new Iris(4.9,3.0,1.4,0.2,IrisType.IrisSetosa),
                new Iris(4.7,3.2,1.3,0.2,IrisType.IrisSetosa),
                new Iris(4.6,3.1,1.5,0.2,IrisType.IrisSetosa),
                new Iris(5.0,3.6,1.4,0.2,IrisType.IrisSetosa),
                new Iris(5.4,3.9,1.7,0.4,IrisType.IrisSetosa),
                new Iris(4.6,3.4,1.4,0.3,IrisType.IrisSetosa),
                new Iris(5.0,3.4,1.5,0.2,IrisType.IrisSetosa),
                new Iris(4.4,2.9,1.4,0.2,IrisType.IrisSetosa),
                new Iris(4.9,3.1,1.5,0.1,IrisType.IrisSetosa),
                new Iris(5.4,3.7,1.5,0.2,IrisType.IrisSetosa),
                new Iris(4.8,3.4,1.6,0.2,IrisType.IrisSetosa),
                new Iris(4.8,3.0,1.4,0.1,IrisType.IrisSetosa),
                new Iris(4.3,3.0,1.1,0.1,IrisType.IrisSetosa),
                new Iris(5.8,4.0,1.2,0.2,IrisType.IrisSetosa),
                new Iris(5.7,4.4,1.5,0.4,IrisType.IrisSetosa),
                new Iris(5.4,3.9,1.3,0.4,IrisType.IrisSetosa),
                new Iris(5.1,3.5,1.4,0.3,IrisType.IrisSetosa),
                new Iris(5.7,3.8,1.7,0.3,IrisType.IrisSetosa),
                new Iris(5.1,3.8,1.5,0.3,IrisType.IrisSetosa),
                new Iris(5.4,3.4,1.7,0.2,IrisType.IrisSetosa),
                new Iris(5.1,3.7,1.5,0.4,IrisType.IrisSetosa),
                new Iris(4.6,3.6,1.0,0.2,IrisType.IrisSetosa),
                new Iris(5.1,3.3,1.7,0.5,IrisType.IrisSetosa),
                new Iris(4.8,3.4,1.9,0.2,IrisType.IrisSetosa),
                new Iris(5.0,3.0,1.6,0.2,IrisType.IrisSetosa),
                new Iris(5.0,3.4,1.6,0.4,IrisType.IrisSetosa),
                new Iris(5.2,3.5,1.5,0.2,IrisType.IrisSetosa),
                new Iris(5.2,3.4,1.4,0.2,IrisType.IrisSetosa),
                new Iris(4.7,3.2,1.6,0.2,IrisType.IrisSetosa),
                new Iris(4.8,3.1,1.6,0.2,IrisType.IrisSetosa),
                new Iris(5.4,3.4,1.5,0.4,IrisType.IrisSetosa),
                new Iris(5.2,4.1,1.5,0.1,IrisType.IrisSetosa),
                new Iris(5.5,4.2,1.4,0.2,IrisType.IrisSetosa),
                new Iris(4.9,3.1,1.5,0.1,IrisType.IrisSetosa),
                new Iris(5.0,3.2,1.2,0.2,IrisType.IrisSetosa),
                new Iris(5.5,3.5,1.3,0.2,IrisType.IrisSetosa),
                new Iris(4.9,3.1,1.5,0.1,IrisType.IrisSetosa),
                new Iris(4.4,3.0,1.3,0.2,IrisType.IrisSetosa),
                new Iris(5.1,3.4,1.5,0.2,IrisType.IrisSetosa),
                new Iris(5.0,3.5,1.3,0.3,IrisType.IrisSetosa),
                new Iris(4.5,2.3,1.3,0.3,IrisType.IrisSetosa),
                new Iris(4.4,3.2,1.3,0.2,IrisType.IrisSetosa),
                new Iris(5.0,3.5,1.6,0.6,IrisType.IrisSetosa),
                new Iris(5.1,3.8,1.9,0.4,IrisType.IrisSetosa),
                new Iris(4.8,3.0,1.4,0.3,IrisType.IrisSetosa),
                new Iris(5.1,3.8,1.6,0.2,IrisType.IrisSetosa),
                new Iris(4.6,3.2,1.4,0.2,IrisType.IrisSetosa),
                new Iris(5.3,3.7,1.5,0.2,IrisType.IrisSetosa),
                new Iris(5.0,3.3,1.4,0.2,IrisType.IrisSetosa),
                new Iris(7.0,3.2,4.7,1.4,IrisType.IrisVersicolor),
                new Iris(6.4,3.2,4.5,1.5,IrisType.IrisVersicolor),
                new Iris(6.9,3.1,4.9,1.5,IrisType.IrisVersicolor),
                new Iris(5.5,2.3,4.0,1.3,IrisType.IrisVersicolor),
                new Iris(6.5,2.8,4.6,1.5,IrisType.IrisVersicolor),
                new Iris(5.7,2.8,4.5,1.3,IrisType.IrisVersicolor),
                new Iris(6.3,3.3,4.7,1.6,IrisType.IrisVersicolor),
                new Iris(4.9,2.4,3.3,1.0,IrisType.IrisVersicolor),
                new Iris(6.6,2.9,4.6,1.3,IrisType.IrisVersicolor),
                new Iris(5.2,2.7,3.9,1.4,IrisType.IrisVersicolor),
                new Iris(5.0,2.0,3.5,1.0,IrisType.IrisVersicolor),
                new Iris(5.9,3.0,4.2,1.5,IrisType.IrisVersicolor),
                new Iris(6.0,2.2,4.0,1.0,IrisType.IrisVersicolor),
                new Iris(6.1,2.9,4.7,1.4,IrisType.IrisVersicolor),
                new Iris(5.6,2.9,3.6,1.3,IrisType.IrisVersicolor),
                new Iris(6.7,3.1,4.4,1.4,IrisType.IrisVersicolor),
                new Iris(5.6,3.0,4.5,1.5,IrisType.IrisVersicolor),
                new Iris(5.8,2.7,4.1,1.0,IrisType.IrisVersicolor),
                new Iris(6.2,2.2,4.5,1.5,IrisType.IrisVersicolor),
                new Iris(5.6,2.5,3.9,1.1,IrisType.IrisVersicolor),
                new Iris(5.9,3.2,4.8,1.8,IrisType.IrisVersicolor),
                new Iris(6.1,2.8,4.0,1.3,IrisType.IrisVersicolor),
                new Iris(6.3,2.5,4.9,1.5,IrisType.IrisVersicolor),
                new Iris(6.1,2.8,4.7,1.2,IrisType.IrisVersicolor),
                new Iris(6.4,2.9,4.3,1.3,IrisType.IrisVersicolor),
                new Iris(6.6,3.0,4.4,1.4,IrisType.IrisVersicolor),
                new Iris(6.8,2.8,4.8,1.4,IrisType.IrisVersicolor),
                new Iris(6.7,3.0,5.0,1.7,IrisType.IrisVersicolor),
                new Iris(6.0,2.9,4.5,1.5,IrisType.IrisVersicolor),
                new Iris(5.7,2.6,3.5,1.0,IrisType.IrisVersicolor),
                new Iris(5.5,2.4,3.8,1.1,IrisType.IrisVersicolor),
                new Iris(5.5,2.4,3.7,1.0,IrisType.IrisVersicolor),
                new Iris(5.8,2.7,3.9,1.2,IrisType.IrisVersicolor),
                new Iris(6.0,2.7,5.1,1.6,IrisType.IrisVersicolor),
                new Iris(5.4,3.0,4.5,1.5,IrisType.IrisVersicolor),
                new Iris(6.0,3.4,4.5,1.6,IrisType.IrisVersicolor),
                new Iris(6.7,3.1,4.7,1.5,IrisType.IrisVersicolor),
                new Iris(6.3,2.3,4.4,1.3,IrisType.IrisVersicolor),
                new Iris(5.6,3.0,4.1,1.3,IrisType.IrisVersicolor),
                new Iris(5.5,2.5,4.0,1.3,IrisType.IrisVersicolor),
                new Iris(5.5,2.6,4.4,1.2,IrisType.IrisVersicolor),
                new Iris(6.1,3.0,4.6,1.4,IrisType.IrisVersicolor),
                new Iris(5.8,2.6,4.0,1.2,IrisType.IrisVersicolor),
                new Iris(5.0,2.3,3.3,1.0,IrisType.IrisVersicolor),
                new Iris(5.6,2.7,4.2,1.3,IrisType.IrisVersicolor),
                new Iris(5.7,3.0,4.2,1.2,IrisType.IrisVersicolor),
                new Iris(5.7,2.9,4.2,1.3,IrisType.IrisVersicolor),
                new Iris(6.2,2.9,4.3,1.3,IrisType.IrisVersicolor),
                new Iris(5.1,2.5,3.0,1.1,IrisType.IrisVersicolor),
                new Iris(5.7,2.8,4.1,1.3,IrisType.IrisVersicolor),
                new Iris(6.3,3.3,6.0,2.5,IrisType.IrisVirginica),
                new Iris(5.8,2.7,5.1,1.9,IrisType.IrisVirginica),
                new Iris(7.1,3.0,5.9,2.1,IrisType.IrisVirginica),
                new Iris(6.3,2.9,5.6,1.8,IrisType.IrisVirginica),
                new Iris(6.5,3.0,5.8,2.2,IrisType.IrisVirginica),
                new Iris(7.6,3.0,6.6,2.1,IrisType.IrisVirginica),
                new Iris(4.9,2.5,4.5,1.7,IrisType.IrisVirginica),
                new Iris(7.3,2.9,6.3,1.8,IrisType.IrisVirginica),
                new Iris(6.7,2.5,5.8,1.8,IrisType.IrisVirginica),
                new Iris(7.2,3.6,6.1,2.5,IrisType.IrisVirginica),
                new Iris(6.5,3.2,5.1,2.0,IrisType.IrisVirginica),
                new Iris(6.4,2.7,5.3,1.9,IrisType.IrisVirginica),
                new Iris(6.8,3.0,5.5,2.1,IrisType.IrisVirginica),
                new Iris(5.7,2.5,5.0,2.0,IrisType.IrisVirginica),
                new Iris(5.8,2.8,5.1,2.4,IrisType.IrisVirginica),
                new Iris(6.4,3.2,5.3,2.3,IrisType.IrisVirginica),
                new Iris(6.5,3.0,5.5,1.8,IrisType.IrisVirginica),
                new Iris(7.7,3.8,6.7,2.2,IrisType.IrisVirginica),
                new Iris(7.7,2.6,6.9,2.3,IrisType.IrisVirginica),
                new Iris(6.0,2.2,5.0,1.5,IrisType.IrisVirginica),
                new Iris(6.9,3.2,5.7,2.3,IrisType.IrisVirginica),
                new Iris(5.6,2.8,4.9,2.0,IrisType.IrisVirginica),
                new Iris(7.7,2.8,6.7,2.0,IrisType.IrisVirginica),
                new Iris(6.3,2.7,4.9,1.8,IrisType.IrisVirginica),
                new Iris(6.7,3.3,5.7,2.1,IrisType.IrisVirginica),
                new Iris(7.2,3.2,6.0,1.8,IrisType.IrisVirginica),
                new Iris(6.2,2.8,4.8,1.8,IrisType.IrisVirginica),
                new Iris(6.1,3.0,4.9,1.8,IrisType.IrisVirginica),
                new Iris(6.4,2.8,5.6,2.1,IrisType.IrisVirginica),
                new Iris(7.2,3.0,5.8,1.6,IrisType.IrisVirginica),
                new Iris(7.4,2.8,6.1,1.9,IrisType.IrisVirginica),
                new Iris(7.9,3.8,6.4,2.0,IrisType.IrisVirginica),
                new Iris(6.4,2.8,5.6,2.2,IrisType.IrisVirginica),
                new Iris(6.3,2.8,5.1,1.5,IrisType.IrisVirginica),
                new Iris(6.1,2.6,5.6,1.4,IrisType.IrisVirginica),
                new Iris(7.7,3.0,6.1,2.3,IrisType.IrisVirginica),
                new Iris(6.3,3.4,5.6,2.4,IrisType.IrisVirginica),
                new Iris(6.4,3.1,5.5,1.8,IrisType.IrisVirginica),
                new Iris(6.0,3.0,4.8,1.8,IrisType.IrisVirginica),
                new Iris(6.9,3.1,5.4,2.1,IrisType.IrisVirginica),
                new Iris(6.7,3.1,5.6,2.4,IrisType.IrisVirginica),
                new Iris(6.9,3.1,5.1,2.3,IrisType.IrisVirginica),
                new Iris(5.8,2.7,5.1,1.9,IrisType.IrisVirginica),
                new Iris(6.8,3.2,5.9,2.3,IrisType.IrisVirginica),
                new Iris(6.7,3.3,5.7,2.5,IrisType.IrisVirginica),
                new Iris(6.7,3.0,5.2,2.3,IrisType.IrisVirginica),
                new Iris(6.3,2.5,5.0,1.9,IrisType.IrisVirginica),
                new Iris(6.5,3.0,5.2,2.0,IrisType.IrisVirginica),
                new Iris(6.2,3.4,5.4,2.3,IrisType.IrisVirginica),
                new Iris(5.9,3.0,5.1,1.8,IrisType.IrisVirginica)
            };

            NormalizeData();
        }

        private static void NormalizeData()
        {
            var offset1 = IrisData.Select(d => d.Spec1).Min();
            var max1 = IrisData.Select(d => d.Spec1).Max();
            Func<double, double> normalize1 = (i) => (i * (1 / max1)) + offset1;

            var offset2 = IrisData.Select(d => d.Spec2).Min();
            var max2 = IrisData.Select(d => d.Spec2).Max();
            Func<double, double> normalize2 = (i) => (i * (1 / max2)) + offset2;

            var offset3 = IrisData.Select(d => d.Spec3).Min();
            var max3 = IrisData.Select(d => d.Spec3).Max();
            Func<double, double> normalize3 = (i) => (i * (1 / max3)) + offset3;

            var offset4 = IrisData.Select(d => d.Spec4).Min();
            var max4 = IrisData.Select(d => d.Spec4).Max();
            Func<double, double> normalize4 = (i) => (i * (1 / max4)) + offset4;

            IrisDataNormalized = IrisData.Select(d => new Iris(normalize1(d.Spec1), normalize2(d.Spec2), normalize3(d.Spec3), normalize4(d.Spec4), d.Type)).ToArray();
        }
    }

    public struct Iris
    {
        public IrisType Type { get; private set; }
        public double Spec1 { get; private set; }
        public double Spec2 { get; private set; }
        public double Spec3 { get; private set; }
        public double Spec4 { get; private set; }

        public double[] Input
        {
            get
            {
                return new[] { Spec1, Spec2, Spec3, Spec4 };
            }
        }

        public Iris(double spec1, double spec2, double spec3, double spec4, IrisType irisType)
        {
            this.Spec1 = spec1;
            this.Spec2 = spec2;
            this.Spec3 = spec3;
            this.Spec4 = spec4;
            this.Type = irisType;
        }
    }

    public enum IrisType
    {
        Unkown,
        IrisVersicolor,
        IrisVirginica,
        IrisSetosa
    }
}


