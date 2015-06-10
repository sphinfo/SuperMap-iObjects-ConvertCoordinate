using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Data;

namespace SuperMap.Convert.KoreaCoordinate
{
    public class Bessel : ISpheroid 
    {                
        public double a
        {
            get
            {
                return 6377397.155;
            }
        }

        public double b
        {
            get
            {
                return 6356078.963;
            }
        }

        public double ea
        {
            get { return Math.Sqrt((Math.Pow(a, 2) - Math.Pow(b, 2)) / Math.Pow(a, 2)); }
        }

        public double eb
        {
            get { return Math.Sqrt((Math.Pow(a, 2) - Math.Pow(b, 2)) / Math.Pow(b, 2)); }
        }


        public string name
        {
            get
            {
                return "Bessel1840";
            }
        }
    }
}
