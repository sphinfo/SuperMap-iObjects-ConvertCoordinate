using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Convert.KoreaCoordinate
{
    public interface IMolodenskyBadekas
    {
        double offsetX
        {
            get;
        }

        double offsetY
        {
            get;
        }

        double offsetZ
        {            
            get;
        }

        double rotateX
        {
            get;
        }

        double rotateY
        {
            get;
        }

        double rotateZ
        {
            get;
        }

        double scale
        {
            get;
        }
        double basicX
        {
            get;
            set;
        }

        double basicY
        {
            get;
            set;
        }

        double basicZ
        {
            get;
            set;
        }
    }
}
