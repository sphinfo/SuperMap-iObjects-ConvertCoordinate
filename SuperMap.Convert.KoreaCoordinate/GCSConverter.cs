using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Data;

namespace SuperMap.Convert.KoreaCoordinate
{
    /// <summary>
    /// TM 좌표계를 경위도 좌표계로 변환한다.
    /// </summary>
    public class GCSConverter    
    {
        private const string Bessel_W_PROJ = "+proj=tmerc +lat_0=38 +lon_0=125.0028902777778 +k=1 +x_0=200000 +y_0=500000 +ellps=bessel +units=m +no_defs";
        private const string Bessel_C_PROJ = "+proj=tmerc +lat_0=38 +lon_0=127.0028902777778 +k=1 +x_0=200000 +y_0=500000 +ellps=bessel +units=m +no_defs";
        private const string Bessel_E_PROJ = "+proj=tmerc +lat_0=38 +lon_0=129.0028902777778 +k=1 +x_0=200000 +y_0=500000 +ellps=bessel +units=m +no_defs";
        private const string Bessel_J_PROJ = "+proj=tmerc +lat_0=38 +lon_0=127.0028902777778 +k=1 +x_0=200000 +y_0=550000 +ellps=bessel +units=m +no_defs";
        private const string Bessel_ES_PROJ = "+proj=tmerc +lat_0=38 +lon_0=131.0028902777778 +k=1 +x_0=200000 +y_0=500000 +ellps=bessel +units=m +no_defs";
        private const string Bessel_GCS_PROJ = "+proj=longlat +ellps=bessel +no_defs";

        private const string GRS80_W_PROJ = "+proj=tmerc +lat_0=38 +lon_0=125 +k=1 +x_0=200000 +y_0=600000 +ellps=GRS80 +units=m +no_defs";
        private const string GRS80_C_PROJ = "+proj=tmerc +lat_0=38 +lon_0=127 +k=1 +x_0=200000 +y_0=600000 +ellps=GRS80 +units=m +no_defs";
        private const string GRS80_E_PROJ = "+proj=tmerc +lat_0=38 +lon_0=129 +k=1 +x_0=200000 +y_0=600000 +ellps=GRS80 +units=m +no_defs";
        private const string GRS80_ES_PROJ = "+proj=tmerc +lat_0=38 +lon_0=131 +k=1 +x_0=200000 +y_0=600000 +ellps=GRS80 +units=m +no_defs";
        private const string GRS80_GCS_PROJ = "+proj=longlat +ellps=GRS80 +no_defs";
        
        private string m_Current_GCS_PROJ = string.Empty;
        private string m_CurrentWork_PROJ = string.Empty;
                        
        public enum Bessel_Control_Point
        {
            Center,
            West,
            East,
            EastSea,
            Jeju
        }

        public enum GRS80_Control_Point
        {
            Center,
            West,
            East,
            EastSea            
        }
                
        public GCSConverter()
        {
            
        }

        public Dataset GetBesselGCSDataset(Datasource sourceDatasource, Dataset pcsDataset, string gcsPrjFile, Bessel_Control_Point controlPoint)
        {
            m_Current_GCS_PROJ = Bessel_GCS_PROJ;
            m_CurrentWork_PROJ = GetBesselControlPointPRJ(controlPoint);

            return GetGCSDataset(sourceDatasource, pcsDataset, gcsPrjFile);
        }

        public Dataset GetGRS80GCSDataset(Datasource sourceDatasource, Dataset pcsDataset, string gcsPrjFile, GRS80_Control_Point controlPoint)
        {
            m_Current_GCS_PROJ = GRS80_GCS_PROJ;
            m_CurrentWork_PROJ = GetGRS80ControlPointPRJ(controlPoint);

            return GetGCSDataset(sourceDatasource, pcsDataset, gcsPrjFile);
        }

        private Dataset GetGCSDataset(Datasource sourceDatasource, Dataset pcsDataset, string gcsPrjFile)
        {
            DatasetVector newGCSDatasetVector = HelperConvert.getEmptyGCSDatasetVector(sourceDatasource, pcsDataset, gcsPrjFile);
            if (newGCSDatasetVector == null) return null;
            
            DatasetVector pcsDatasetVector = pcsDataset as DatasetVector;
            bool result = GetGCSDataset(pcsDatasetVector, newGCSDatasetVector);
            if (result)
            {
                sourceDatasource.Datasets.Delete(pcsDataset.Name);
                return newGCSDatasetVector as Dataset;
            }
            else
            {
                return null;
            }            
        }

        private bool GetGCSDataset(DatasetVector pcsDatasetVector, DatasetVector gcsDatasetVector)
        {
            QueryParameter queryParameter = new QueryParameter();
            queryParameter.CursorType = CursorType.Dynamic;

            Recordset pcsRecordset = pcsDatasetVector.Query(queryParameter);
            Recordset gcsRecordset = gcsDatasetVector.Query(queryParameter);

            pcsRecordset.MoveFirst();
            while (!pcsRecordset.IsEOF)
            {
                Geometry pcsGeometry = pcsRecordset.GetGeometry();
                Geometry gcsGeometry = GetGCSGeometry(pcsGeometry);

                gcsRecordset.AddNew(gcsGeometry);
                gcsRecordset.Update();

                HelperConvert.CopyAttribute(pcsRecordset, gcsRecordset);

                pcsRecordset.MoveNext();
            }

            return true;
        }

        private Geometry GetGCSGeometry(Geometry pcsGeometry)
        {
            if (pcsGeometry is GeoRegion)
            {
                GeoRegion gcsRegion = new GeoRegion();
                GeoRegion pcsRegion = pcsGeometry as GeoRegion;

                for (int i = 0; i < pcsRegion.PartCount; i++)
                {
                    Point2Ds points = pcsRegion[i];
                    gcsRegion.AddPart(GetGCSPoints(points));
                }

                return gcsRegion;
            }

            return null;
        }

        private Point2Ds GetGCSPoints(Point2Ds points)
        {
            Point2Ds gcsPoints = new Point2Ds();

            foreach (Point2D pt in points)
            {
                gcsPoints.Add(GetGCSPoint(pt));
            }

            return gcsPoints;
        }

        private Point2D GetGCSPoint(Point2D point)
        {                        
            OSGeo.OSR.SpatialReference src = new OSGeo.OSR.SpatialReference("");
            src.ImportFromProj4(m_CurrentWork_PROJ);

            OSGeo.OSR.SpatialReference dst = new OSGeo.OSR.SpatialReference("");
            dst.ImportFromProj4(m_Current_GCS_PROJ);

            OSGeo.OSR.CoordinateTransformation ct = new OSGeo.OSR.CoordinateTransformation(src, dst);

            double[] p = new double[2];
            p[0] = point.X;
            p[1] = point.Y;

            ct.TransformPoint(p);

            return new Point2D(p[0], p[1]);
        }

        private string GetBesselControlPointPRJ(Bessel_Control_Point controlPoint)
        {
            switch (controlPoint)
            {
                case Bessel_Control_Point.Center:
                    {
                        return Bessel_C_PROJ;
                    }
                case Bessel_Control_Point.East:
                    {
                        return Bessel_E_PROJ;
                    }
                case Bessel_Control_Point.West:
                    {
                        return Bessel_W_PROJ;
                    }
                case Bessel_Control_Point.Jeju:
                    {
                        return Bessel_J_PROJ;
                    }
                case Bessel_Control_Point.EastSea:
                    {
                        return Bessel_ES_PROJ;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        private string GetGRS80ControlPointPRJ(GRS80_Control_Point controlPoint)
        {
            switch (controlPoint)
            {
                case GRS80_Control_Point.Center:
                    {
                        return GRS80_C_PROJ;
                    }
                case GRS80_Control_Point.East:
                    {
                        return GRS80_E_PROJ;
                    }
                case GRS80_Control_Point.West:
                    {
                        return GRS80_W_PROJ;
                    }
                case GRS80_Control_Point.EastSea:
                    {
                        return GRS80_ES_PROJ;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
    }
}
