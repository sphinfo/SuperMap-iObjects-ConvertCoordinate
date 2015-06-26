using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SuperMap.Data;

namespace SuperMap.Convert.KoreaCoordinate
{
    public static class HelperConvert
    {                
        public static Dataset ConvertToGCS(Dataset sourceDataset, GeoCoordSysType geoCoordSysType)
        {
            GeoCoordSys geoCoordSys = new GeoCoordSys(geoCoordSysType, GeoSpatialRefType.EarthLongitudeLatitude);

            PrjCoordSys prjCoordSys = new PrjCoordSys();
            prjCoordSys.GeoCoordSys = geoCoordSys;
            prjCoordSys.Type = PrjCoordSysType.EarthLongitudeLatitude;

            bool result = CoordSysTranslator.Convert(sourceDataset, prjCoordSys, new CoordSysTransParameter(),  
                CoordSysTransMethod.GeocentricTranslation);
            if (result)
            {
                return sourceDataset;
            }
            else
            {
                return null;
            }
        }
       
        public static DatasetVector getEmptyGCSDatasetVector(Datasource sourceDatasource, Dataset sourceDataset, GeoCoordSysType geoCoordSysType)
        {
            DatasetVectorInfo datasetVectorInfo = new DatasetVectorInfo();
            datasetVectorInfo.Type = sourceDataset.Type;
            datasetVectorInfo.Name = sourceDatasource.Datasets.GetAvailableDatasetName("GCS_" + sourceDataset.Name);

            GeoCoordSys geoCoordSys = new GeoCoordSys(geoCoordSysType, GeoSpatialRefType.EarthLongitudeLatitude);

            PrjCoordSys prjCoordSys = new PrjCoordSys();
            prjCoordSys.GeoCoordSys = geoCoordSys;
            prjCoordSys.Type = PrjCoordSysType.EarthLongitudeLatitude;

            DatasetVector newDataset = sourceDatasource.Datasets.Create(datasetVectorInfo);
            newDataset.PrjCoordSys = prjCoordSys;

            DatasetVector dsVector = sourceDataset as DatasetVector;
            FieldInfos sourceFieldInfos = dsVector.FieldInfos;

            foreach (FieldInfo sourcefieldInfo in sourceFieldInfos)
            {
                if (newDataset.FieldInfos.IndexOf(sourcefieldInfo.Name) < 0)
                {
                    newDataset.FieldInfos.Add(sourcefieldInfo.Clone());
                }
            }

            return newDataset as DatasetVector;
        }

        public static DatasetVector getEmptyGCSDatasetVector(Datasource sourceDatasource, Dataset sourceDataset, string gcsPrjFile)
        {
            DatasetVectorInfo datasetVectorInfo = new DatasetVectorInfo();
            datasetVectorInfo.Type = sourceDataset.Type;
            datasetVectorInfo.Name = sourceDatasource.Datasets.GetAvailableDatasetName("GCS_" + sourceDataset.Name);

            PrjCoordSys prjCoordSys = new PrjCoordSys();            
            prjCoordSys.FromFile(@gcsPrjFile, PrjFileType.Esri);

            DatasetVector newDataset = sourceDatasource.Datasets.Create(datasetVectorInfo);
            newDataset.PrjCoordSys = prjCoordSys;

            DatasetVector dsVector = sourceDataset as DatasetVector;
            FieldInfos sourceFieldInfos = dsVector.FieldInfos;

            foreach (FieldInfo sourcefieldInfo in sourceFieldInfos)
            {
                if (newDataset.FieldInfos.IndexOf(sourcefieldInfo.Name) < 0)
                {
                    newDataset.FieldInfos.Add(sourcefieldInfo.Clone());
                }
            }

            return newDataset as DatasetVector;
        }

        public static Geometry getConvertToGRS80Geometry(Geometry geometry)
        {
            if (geometry is GeoRegion)
            {
                GeoRegion grs80Region = new GeoRegion();
                GeoRegion region = geometry as GeoRegion;

                for (int i = 0; i < region.PartCount; i++)
                {
                    Point2Ds points = region[i];
                    grs80Region.AddPart(getConvertToGRS80Points(points));
                }

                return grs80Region;
            }
            else if (geometry is GeoLine)
            {
                GeoLine grs80Line = new GeoLine();
                GeoLine line = geometry as GeoLine;

                for (int i = 0; i < line.PartCount; i++)
                {
                    Point2Ds points = line[i];
                    grs80Line.AddPart(getConvertToGRS80Points(points));
                }

                return grs80Line;
            }
            else if (geometry is GeoPoint)
            {
                GeoPoint point = geometry as GeoPoint;

                Point2D grs80Point = getConvertToGRS80Point(new Point2D(point.X, point.Y));

                return new GeoPoint(grs80Point);
            }
            else
            {
                return null;
            }
        }

        public static Geometry getConvertToBesselGeometry(Geometry geometry)
        {        
            if (geometry is GeoRegion)
            {
                GeoRegion besselRegion = new GeoRegion();
                GeoRegion region = geometry as GeoRegion;

                for (int i = 0; i < region.PartCount; i++)
                {
                    Point2Ds points = region[i];
                    besselRegion.AddPart(getConvertToBesselPoints(points));
                }

                return besselRegion;
            }
            else if (geometry is GeoLine)
            {
                GeoLine besselLine = new GeoLine();
                GeoLine line = geometry as GeoLine;

                for (int i = 0; i < line.PartCount; i++)
                {
                    Point2Ds points = line[i];
                    besselLine.AddPart(getConvertToBesselPoints(points));
                }

                return besselLine;
            }
            else if (geometry is GeoPoint)
            {
                GeoPoint point = geometry as GeoPoint;
                Point2D besselPoint = getConvertToBesselPoint(new Point2D(point.X, point.Y));

                return new GeoPoint(besselPoint);
            }
            else
            {
                return null;
            }
        }

        public static Geometry getConvertToBesselGeometry1(Geometry geometry)
        {
            if (geometry.Type == GeometryType.GeoRegion)
            {
                GeoRegion besselRegion = new GeoRegion();
                GeoRegion region = geometry as GeoRegion;

                for (int i = 0; i < region.PartCount; i++)
                {
                    Point2Ds points = region[i];
                    besselRegion.AddPart(getConvertToBesselPoints(points));
                }

                return besselRegion;
            }
            else if (geometry.Type == GeometryType.GeoLine)
            {
                GeoLine besselLine = new GeoLine();
                GeoLine line = geometry as GeoLine;

                for (int i = 0; i < line.PartCount; i++)
                {
                    Point2Ds points = line[i];
                    besselLine.AddPart(getConvertToBesselPoints(points));
                }

                return besselLine;
            }
            else if (geometry.Type == GeometryType.GeoPoint)
            {
                GeoPoint point = geometry as GeoPoint;
                Point2D besselPoint = getConvertToBesselPoint(new Point2D(point.X, point.Y));

                return new GeoPoint(besselPoint);
            }
            else
            {
                return null;
            }
        }

        public static void CopyAttribute(Recordset sourceRs, Recordset targetRs)
        {
            FieldInfos sourceFieldInfos = sourceRs.GetFieldInfos();
            foreach (FieldInfo sourcefieldInfo in sourceFieldInfos)
            {
                if ((targetRs.GetFieldInfos().IndexOf(sourcefieldInfo.Name) != 0) && (!sourcefieldInfo.IsSystemField))
                {
                    targetRs.Edit(); 
                    targetRs.SetFieldValue(sourcefieldInfo.Name, sourceRs.GetFieldValue(sourcefieldInfo.Name));
                    targetRs.Update();
                }
            }
        }

        private static Point2Ds getConvertToGRS80Points(Point2Ds points)
        {
            Point2Ds grs80Points = new Point2Ds();

            foreach (Point2D pt in points)
            {
                grs80Points.Add(getConvertToGRS80Point(pt));
            }

            return grs80Points;
        }

        private static Point2D getConvertToGRS80Point(Point2D point)
        {            
            MolodenskyBadekas mb = new MolodenskyBadekas();
            mb.basicX = -3159521.31;
            mb.basicY = 4068151.32;
            mb.basicZ = 3748113.85;

            double x = point.X;
            double y = point.Y;

            // HelperConvert.Log("Bessel: " + System.Convert.ToString(x) + "," + System.Convert.ToString(y));

            Bessel bessel = new Bessel();
            Geocentric besselGeocentric = new Geocentric(bessel);
            double geocentX = besselGeocentric.getGeocentricX(x, y);
            double geocentY = besselGeocentric.getGeocentricY(x, y);
            double geocentZ = besselGeocentric.getGeocentricZ(x, y);

            // HelperConvert.Log("Bessel Geocentric: " + System.Convert.ToString(geocentX) + "," + System.Convert.ToString(geocentY) + "," + System.Convert.ToString(geocentZ));

            double geocentGRS80X = mb.getGRS80GeocentricX(geocentX, geocentY, geocentZ);
            double geocentGRS80Y = mb.getGRS80GeocentricY(geocentX, geocentY, geocentZ);
            double geocentGRS80Z = mb.getGRS80GeocentricZ(geocentX, geocentY, geocentZ);

            // HelperConvert.Log("GRS80 Geocentric: " + System.Convert.ToString(geocentGRS80X) + "," + System.Convert.ToString(geocentGRS80Y) + "," + System.Convert.ToString(geocentGRS80Z));

            GRS80 grs80 = new GRS80();
            double gcsGrs80X = Math.Round(mb.getGCSX(geocentGRS80X, geocentGRS80Y, geocentGRS80Z), 9);
            double gcsGrs80Y = Math.Round(mb.getGCSY(grs80, geocentGRS80X, geocentGRS80Y, geocentGRS80Z), 9);

            //double offsetX = 0.002276072;
            //double offsetY = -0.003081412;
            // HelperConvert.Log("GRS80 GCS: " + System.Convert.ToString(gcsGrs80X + offsetX) + "," + System.Convert.ToString(gcsGrs80Y + offsetY));
            
            return new Point2D(gcsGrs80X, gcsGrs80Y);
        }

        private static Point2Ds getConvertToBesselPoints(Point2Ds points)
        {
            Point2Ds besselPoints = new Point2Ds();

            foreach (Point2D pt in points)
            {
                besselPoints.Add(getConvertToBesselPoint(pt));
            }

            return besselPoints;
        }

        private static Point2D getConvertToBesselPoint(Point2D point)
        {
            MolodenskyBadekas mb = new MolodenskyBadekas();
            mb.basicX = -3159666.86;
            mb.basicY = 4068655.70;
            mb.basicZ = 3748799.65;

            GRS80 grs80 = new GRS80();
            Bessel bessel = new Bessel();

            Geocentric grs80Geocentric = new Geocentric(grs80);

            double x = point.X;
            double y = point.Y;

            double geocentX = grs80Geocentric.getGeocentricX(x, y);
            double geocentY = grs80Geocentric.getGeocentricY(x, y);
            double geocentZ = grs80Geocentric.getGeocentricZ(x, y);

            double geocentBesselX = mb.getBesselGeocentricX(geocentX, geocentY, geocentZ);
            double geocentBesselY = mb.getBesselGeocentricY(geocentX, geocentY, geocentZ);
            double geocentBesselZ = mb.getBesselGeocentricZ(geocentX, geocentY, geocentZ);

            double gcsBesselX = Math.Round(mb.getGCSX(geocentBesselX, geocentBesselY, geocentBesselZ), 9);
            double gcsBesselY = Math.Round(mb.getGCSY(bessel, geocentBesselX, geocentBesselY, geocentBesselZ), 9);

            return new Point2D(gcsBesselX, gcsBesselY);
        }

        public static void Log(string str)
        {
            string DirPath = @"C:\Util\SuperMap\Logs";
            string FilePath = @"C:\Util\SuperMap\Logs\SupeMap_" + DateTime.Today.ToString("yyyyMMdd") + ".log";            
            string temp;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);
            
            try
            {
                if (di.Exists != true) Directory.CreateDirectory(DirPath);

                if (fi.Exists != true)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        temp = string.Format("[{0}] : {1}", GetDateTime(), str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        temp = string.Format("[{0}] : {1}", GetDateTime(), str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                // 
            }
        }

        public static void OffsetDataset(DatasetVector datasetVector, Double offsetX, Double offsetY)
        {
            QueryParameter queryParameter = new QueryParameter();
            queryParameter.CursorType = CursorType.Dynamic;

            Recordset recordSet = datasetVector.Query(queryParameter);
            recordSet.Batch.Begin();
            recordSet.MoveFirst();

            while (!recordSet.IsEOF)
            {
                recordSet.Edit();

                Geometry sourceGeometry = recordSet.GetGeometry();
                sourceGeometry.Offset(offsetX, offsetY);
                
                recordSet.SetGeometry(sourceGeometry);
                recordSet.MoveNext();
            }

            recordSet.Batch.Update();
        }

        private static string GetDateTime()
        {
            DateTime NowDate = DateTime.Now;
            return NowDate.ToString("yyyy-MM-dd HH:mm:ss") + ":" + NowDate.Millisecond.ToString("000");
        }
    }
}
