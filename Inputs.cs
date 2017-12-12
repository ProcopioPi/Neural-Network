using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural
{
    public class Input
    {
        #region Properties
        List<double> features = new List<double>();               
        double[] desiredValue;
        string desire;
        #endregion 
    
        #region Fields
        public int Size
        {
            get { return features.Count; }
        }

        public double[] Features
        {
            get { return features.ToArray(); }
        }

        public double[] DesiredValue
        {
            get { return desiredValue; }
        }

        public string Desire
        {
            get { return desire; }
        }
        #endregion

        public Input(double[] features, double[] desiredValue,string desire)
        {
            this.features.AddRange(features);
            this.desiredValue = desiredValue;
            this.desire = desire;
        }

        public Input(double[] features, double[] desiredValue)
        {
            this.features.AddRange(features);
            this.desiredValue = desiredValue;
            this.desire += desiredValue[0];
        }


        public override string ToString()
        {
            string str;

            str = string.Empty;
            str += "{ " + features[0];
            for (int i = 1; i < features.Count; i++)
                str += ", " + features[i];
            str += " }";

            str += " == ";
            str += "{ " + desiredValue[0];
            if (desiredValue != null)
                for (int d = 1; d < desiredValue.Length; d++)
                    str += ", " + desiredValue[d];
            str += " }";

            return str;
        }
    }
}
