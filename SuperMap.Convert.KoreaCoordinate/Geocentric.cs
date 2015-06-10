using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Convert.KoreaCoordinate
{
    public class Geocentric
    {
        private ISpheroid m_Spheroid;

        public Geocentric(ISpheroid spheroid)
        {
            m_Spheroid = spheroid;
        }

        public double getGeocentricX(double gcsX, double gcsY)
        {
            double a = m_Spheroid.a;
            double b = m_Spheroid.b;
            double z = 0;   // 타원체고
            double result = 0;                       
                        
            result = Math.Pow(a, 2) /
                     Math.Sqrt(Math.Pow(a, 2) * Math.Pow(Math.Cos(gcsY * Math.PI / 180), 2) + Math.Pow(b, 2) * Math.Pow(Math.Sin(gcsY * Math.PI / 180), 2) + z) *
                     Math.Cos(gcsY * Math.PI / 180) * Math.Cos(gcsX * Math.PI / 180);

            return result;
        }

        public double getGeocentricY(double gcsX, double gcsY)
        {
            double a = m_Spheroid.a;
            double b = m_Spheroid.b;
            double z = 0;   // 타원체고
            double result = 0;

            result = Math.Pow(a, 2) /
                     Math.Sqrt(Math.Pow(a, 2) * Math.Pow(Math.Cos(gcsY * Math.PI / 180), 2) + Math.Pow(b, 2) * Math.Pow(Math.Sin(gcsY * Math.PI / 180), 2) + z) *
                     Math.Cos(gcsY * Math.PI / 180) * Math.Sin(gcsX * Math.PI / 180);

            return result;
        }

        public double getGeocentricZ(double gcsX, double gcsY)
        {
            double a = m_Spheroid.a;
            double b = m_Spheroid.b;
            double z = 0;   // 타원체고
            double result = 0;

            result = Math.Pow(a, 2) /
                     Math.Sqrt(Math.Pow(a, 2) * Math.Pow(Math.Cos(gcsY * Math.PI / 180), 2) + Math.Pow(b, 2) * Math.Pow(Math.Sin(gcsY * Math.PI / 180), 2)) *
                     ((Math.Pow(b, 2) / Math.Pow(a, 2)) + z) * Math.Sin(gcsY * Math.PI / 180);

            return result;
        }

        public double getGeocentricX(double gcsX, double gcsY, double h)
        {
            double a = m_Spheroid.a;
            double b = m_Spheroid.b;
            double z = h;   // 타원체고
            double result = 0;

            result = (Math.Pow(a, 2) /
                     Math.Sqrt(Math.Pow(a, 2) * Math.Pow(Math.Cos(gcsY * Math.PI / 180), 2) + 
                     Math.Pow(b, 2) * Math.Pow(Math.Sin(gcsY * Math.PI / 180), 2)) + z) *
                     Math.Cos(gcsY * Math.PI / 180) * Math.Cos(gcsX * Math.PI / 180);

            return result;
        }

        public double getGeocentricY(double gcsX, double gcsY, double h)
        {
            double a = m_Spheroid.a;
            double b = m_Spheroid.b;
            double z = h;   // 타원체고
            double result = 0;

            result = (Math.Pow(a, 2) /
                     Math.Sqrt(Math.Pow(a, 2) * Math.Pow(Math.Cos(gcsY * Math.PI / 180), 2) + Math.Pow(b, 2) * Math.Pow(Math.Sin(gcsY * Math.PI / 180), 2)) + z) *
                     Math.Cos(gcsY * Math.PI / 180) * Math.Sin(gcsX * Math.PI / 180);

            return result;
        }

        public double getGeocentricZ(double gcsX, double gcsY, double h)
        {
            double a = m_Spheroid.a;
            double b = m_Spheroid.b;
            double z = h;   // 타원체고
            double result = 0;

            result = (Math.Pow(a, 2) /
                      Math.Sqrt(Math.Pow(a, 2) * Math.Pow(Math.Cos(gcsY * Math.PI / 180), 2) + 
                               Math.Pow(b, 2) * Math.Pow(Math.Sin(gcsY * Math.PI / 180), 2)) * 
                      (Math.Pow(b, 2) / Math.Pow(a, 2)) + z) * 
                     Math.Sin(gcsY * Math.PI / 180);

            return result;
        }
    }
}
