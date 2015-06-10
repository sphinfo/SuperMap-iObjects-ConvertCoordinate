using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Convert.KoreaCoordinate
{
    public class GRS80 : ISpheroid 
    {           
        public double a
        {
            get
            {
                return 6378137;
            }
        }

        public double b
        {
            get
            {
                return 6356752.31;
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
                return "GRS80";
            }
        }
    }
}
