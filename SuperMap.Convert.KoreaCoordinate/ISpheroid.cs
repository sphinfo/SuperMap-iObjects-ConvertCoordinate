using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Convert.KoreaCoordinate
{
    public interface ISpheroid
    {
        /// <summary>
        /// 장반경
        /// </summary>
        double a
        {
            get;
        }

        /// <summary>
        /// 단반경
        /// </summary>
        double b
        {
            get;
        }

        /// <summary>
        /// 이심률
        /// </summary>
        double ea
        {            
            get;
        }

        /// <summary>
        /// 이심률
        /// </summary>
        double eb
        {
            get;
        }

        string name
        {
            get;         
        }
    }
}
