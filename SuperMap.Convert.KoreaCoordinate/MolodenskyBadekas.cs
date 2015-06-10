using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Convert.KoreaCoordinate
{
    public class MolodenskyBadekas : IMolodenskyBadekas
    {
        private double m_bx;
        private double m_by;
        private double m_bz;
                
        public double offsetX
        {
            get { return -145.907; }
        }

        public double offsetY
        {
            get { return 505.034; }
        }

        public double offsetZ
        {
            get { return 685.756; }
        }

        public double rotateX
        {
            get { return -1.162;  }
        }

        public double rotateY
        {
            get { return 2.347; }
        }

        public double rotateZ
        {
            get { return 1.592; }
        }

        public double scale
        {
            get { return 6.342; }
        }

        public double basicX
        {
            get
            {
                return m_bx;
            }
            set
            {
                this.m_bx = value;
            }
        }

        public double basicY
        {
            get
            {
                return m_by;
            }
            set
            {
                this.m_by = value;
            }
        }

        public double basicZ
        {
            get
            {
                return m_bz;
            }
            set
            {
                this.m_bz = value;
            }
        }

        public double getGRS80GeocentricX(double geocentX, double geocentY, double geocentZ)
        {
            double result;

            result = basicX + offsetX + (1 + scale * Math.Pow(10, -6)) *
                     ((geocentX + (basicX * -1)) + (rotateZ * Math.PI / 180 / 3600) *
                      (geocentY - basicY) - (rotateY * Math.PI / 180 / 3600) *
                      (geocentZ - basicZ));

            return result;
        }

        public double getGRS80GeocentricY(double geocentX, double geocentY, double geocentZ)
        {
            double result;

            result = basicY + offsetY + (1 + scale * Math.Pow(10, -6)) *
                     (((rotateZ * -1) * Math.PI / 180 / 3600) * (geocentX + (basicX * -1)) +
                      (geocentY - basicY) + (rotateX * Math.PI / 180 / 3600) *
                      (geocentZ - basicZ));

            return result;
        }

        public double getGRS80GeocentricZ(double geocentX, double geocentY, double geocentZ)
        {
            double result;

            result = basicZ + offsetZ + (1 + scale * Math.Pow(10, -6)) *
                     ((rotateY * Math.PI / 180 / 3600) * (geocentX + (basicX * -1)) -
                      (rotateX * Math.PI / 180 / 3600) * (geocentY - basicY) +
                      (geocentZ - basicZ));

            return result;
        }

        public double getBesselGeocentricX(double geocentX, double geocentY, double geocentZ)
        {
            double result;

            result = basicX + (offsetX * -1) + Math.Pow((1 + scale * Math.Pow(10, -6)), -1) *
                     ((geocentX + (basicX * -1)) + ((rotateZ * -1) * Math.PI / 180 / 3600) *
                      (geocentY - basicY) - ((rotateY * -1) * Math.PI / 180 / 3600) *
                      (geocentZ - basicZ));

            return result;
        }

        public double getBesselGeocentricY(double geocentX, double geocentY, double geocentZ)
        {
            double result;

            result = basicY + (offsetY * -1) + Math.Pow((1 + scale * Math.Pow(10, -6)), -1) *
                     ((rotateZ * Math.PI / 180 / 3600) * (geocentX + (basicX * -1)) +
                      (geocentY - basicY) + ((rotateX * -1) * Math.PI / 180 / 3600) *
                      (geocentZ - basicZ));

            return result;
        }

        public double getBesselGeocentricZ(double geocentX, double geocentY, double geocentZ)
        {
            double result;

            result = basicZ + (offsetZ * -1) + Math.Pow((1 + scale * Math.Pow(10, -6)), -1) *
                     (((rotateY * -1) * Math.PI / 180 / 3600) * (geocentX + (basicX * -1)) -
                      ((rotateX * -1) * Math.PI / 180 / 3600) * (geocentY - basicY) +
                      (geocentZ - basicZ));

            return result;
        }
        
        public double getGCSX(double geocentX, double geocentY, double geocentZ)
        {
            double result;

            result = Math.Atan(geocentY / geocentX) * 180 / Math.PI + 180;

            return result;
        }

        public double getGCSY(ISpheroid spheroid, double x, double y, double z)
        {
            double result;
            double a = spheroid.a;
            double b = spheroid.b;
            double ea = spheroid.ea;
            double eb = spheroid.eb;

            double c = z + Math.Pow(eb, 2) * b * Math.Pow(Math.Sin(Math.Atan(z * a / Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) / b)), 3);
            double o = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) - Math.Pow(ea, 2) * a * Math.Pow(Math.Cos(Math.Atan(z * a / Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) / b)), 3);

            result = Math.Atan(c / o) * 180 / Math.PI;

            return result;
        }
    }
}
