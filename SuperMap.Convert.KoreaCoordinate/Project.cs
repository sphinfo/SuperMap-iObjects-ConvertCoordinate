using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Data;

namespace SuperMap.Convert.KoreaCoordinate
{
    public class Project
    {
        /// <summary>
        /// Bessel PCS 좌표를 GRS80 esriPrjFile 파일 좌표로 바꾼다. (사용안 함)
        /// </summary>
        /// <param name="sourceDatasource"></param>
        /// <param name="sourceDatasetName"></param>
        /// <param name="esriPrjFile"></param>
        /// <returns></returns>
        public Dataset BesselToGRS80PCS(Datasource sourceDatasource, string sourceDatasetName, string esriPrjFile)
        {
            // // HelperConvert.Log("BesselToGRS80PCS Start");
            
            Dataset GRS80GCSDataset = BesselToGRS80GCS(sourceDatasource, sourceDatasetName);
            if (GRS80GCSDataset == null) return null;

            PrjCoordSys prjCoordSys = new PrjCoordSys();
            prjCoordSys.FromFile(@esriPrjFile, PrjFileType.Esri);
                                    
            bool result = CoordSysTranslator.Convert(GRS80GCSDataset, prjCoordSys, new CoordSysTransParameter(), CoordSysTransMethod.PositionVector);
            if (result)
            {
                // HelperConvert.Log("BesselToGRS80PCS End");

                return GRS80GCSDataset;
            }
            else
            {
                return null;
            }
        }

        public Dataset BesselToGRS80PCS(Datasource sourceDatasource, string sourceDatasetName, string esriPrjFile, Double offsetX, Double offsetY)
        {
            // HelperConvert.Log("BesselToGRS80PCS Start");

            Dataset GRS80GCSDataset = BesselToGRS80GCS(sourceDatasource, sourceDatasetName);
            if (GRS80GCSDataset == null) return null;

            PrjCoordSys prjCoordSys = new PrjCoordSys();
            prjCoordSys.FromFile(@esriPrjFile, PrjFileType.Esri);

            bool result = CoordSysTranslator.Convert(GRS80GCSDataset, prjCoordSys, new CoordSysTransParameter(), CoordSysTransMethod.PositionVector);
            if (result)
            {
                // HelperConvert.Log("BesselToGRS80PCS End");
                if ((offsetX == 0) && (offsetY == 0))
                {
                    return GRS80GCSDataset;                 
                }
                else
                {                
                    HelperConvert.OffsetDataset(GRS80GCSDataset as DatasetVector, offsetX, offsetY);
                    return GRS80GCSDataset;
                }                
            }
            else
            {
                return null;
            }
        }

        public Dataset BesselToGRS80PCS(Datasource sourceDatasource, Dataset gcsDataset, string esriPrjFile, Double offsetX, Double offsetY)
        {
            // HelperConvert.Log("BesselToGRS80PCS Start");

            Dataset GRS80GCSDataset = BesselToGRS80GCS(sourceDatasource, gcsDataset);
            if (GRS80GCSDataset == null) return null;

            PrjCoordSys prjCoordSys = new PrjCoordSys();
            prjCoordSys.FromFile(@esriPrjFile, PrjFileType.Esri);
            
            bool result = CoordSysTranslator.Convert(GRS80GCSDataset, prjCoordSys, new CoordSysTransParameter(), CoordSysTransMethod.PositionVector);
            if (result)
            {
                // HelperConvert.Log("BesselToGRS80PCS End");
                if ((offsetX == 0) && (offsetY == 0))
                {
                    return GRS80GCSDataset;
                }
                else
                {
                    HelperConvert.OffsetDataset(GRS80GCSDataset as DatasetVector, offsetX, offsetY);
                    return GRS80GCSDataset;
                }
            }
            else
            {
                return null;
            }
        }
                       
        private Dataset BesselToGRS80GCS(Datasource sourceDatasource, Dataset gcsDataset)
        {
            DatasetVector emptyGCSDatasetVector = HelperConvert.getEmptyGCSDatasetVector(sourceDatasource, gcsDataset, GeoCoordSysType.Grs1980);
            if (emptyGCSDatasetVector == null) return null;
            
            bool result = ConvertBesselDatasetVectorToGRS80(gcsDataset as DatasetVector, emptyGCSDatasetVector);
            if (result)
            {
                // HelperConvert.Log("BesselToGRS80GCS End");
                sourceDatasource.Datasets.Delete(gcsDataset.Name);
                return emptyGCSDatasetVector as Dataset;
            }
            else
            {
                return null;
            }
        }        

        /// <summary>
        /// 64 bit에서 사용
        /// </summary>
        /// <param name="sourceDatasource"></param>
        /// <param name="sourceDatasetName"></param>
        /// <returns></returns>
        private Dataset BesselToGRS80GCS(Datasource sourceDatasource, string sourceDatasetName)
        {
            // HelperConvert.Log("BesselToGRS80GCS Start");

            Dataset sourceDataset = sourceDatasource.Datasets[sourceDatasetName];
            if (sourceDataset == null) return null;

            Dataset gcsDataset = HelperConvert.ConvertToGCS(sourceDataset, GeoCoordSysType.Bessel1841);
            if (gcsDataset == null) return null;

            DatasetVector emptyGCSDatasetVector = HelperConvert.getEmptyGCSDatasetVector(sourceDatasource, sourceDataset, GeoCoordSysType.Grs1980);
            if (emptyGCSDatasetVector == null) return null;

            bool result = ConvertBesselDatasetVectorToGRS80(gcsDataset as DatasetVector, emptyGCSDatasetVector);
            if (result)
            {
                // HelperConvert.Log("BesselToGRS80GCS End");

                return emptyGCSDatasetVector as Dataset;
            }
            else
            {
                return null;
            }
        }

        public Dataset GRS80ToBesselPCS(Datasource sourceDatasource, string sourceDatasetName, string esriPrjFile)
        {
            Dataset besselGCSDataset = GRS80ToBesselGCS(sourceDatasource, sourceDatasetName);
            if (besselGCSDataset == null) return null;

            PrjCoordSys prjCoordSys = new PrjCoordSys();
            prjCoordSys.FromFile(@esriPrjFile, PrjFileType.Esri);

            bool result = CoordSysTranslator.Convert(besselGCSDataset, prjCoordSys, new CoordSysTransParameter(), CoordSysTransMethod.PositionVector);
            if (result)
            {
                return besselGCSDataset;
            }
            else
            {
                return null;
            }
        }

        public Dataset GRS80ToBesselPCS(Datasource sourceDatasource, string sourceDatasetName, string esriPrjFile, Double offsetX, Double offsetY)
        {
            Dataset besselGCSDataset = GRS80ToBesselGCS(sourceDatasource, sourceDatasetName);
            if (besselGCSDataset == null) return null;

            PrjCoordSys prjCoordSys = new PrjCoordSys();
            prjCoordSys.FromFile(@esriPrjFile, PrjFileType.Esri);

            bool result = CoordSysTranslator.Convert(besselGCSDataset, prjCoordSys, new CoordSysTransParameter(), CoordSysTransMethod.PositionVector);
            if (result)
            {
                HelperConvert.OffsetDataset(besselGCSDataset as DatasetVector, offsetX, offsetY);
                return besselGCSDataset;
            }
            else
            {
                return null;
            }
        }

        public Dataset GRS80ToBesselPCS(Datasource sourceDatasource, Dataset gcsDataset, string esriPrjFile, Double offsetX, Double offsetY)
        {
            Dataset besselGCSDataset = GRS80ToBesselGCS(sourceDatasource, gcsDataset);
            if (besselGCSDataset == null) return null;

            PrjCoordSys prjCoordSys = new PrjCoordSys();
            prjCoordSys.FromFile(@esriPrjFile, PrjFileType.Esri);

            bool result = CoordSysTranslator.Convert(besselGCSDataset, prjCoordSys, new CoordSysTransParameter(), CoordSysTransMethod.PositionVector);
            if (result)
            {
                if ((offsetX == 0) && (offsetY == 0))
                {
                    return besselGCSDataset;
                }
                else
                {
                    HelperConvert.OffsetDataset(besselGCSDataset as DatasetVector, offsetX, offsetY);
                    return besselGCSDataset;
                }
            }
            else
            {
                return null;
            }
        }

        public Dataset GRS80ToBesselPCS(Datasource sourceDatasource, Dataset gcsDataset, string pcsPrjFile, string gcsPrjFile, Double offsetX, Double offsetY)
        {
            Dataset besselGCSDataset = GRS80ToBesselGCS(sourceDatasource, gcsDataset, gcsPrjFile);
            if (besselGCSDataset == null) return null;

            PrjCoordSys prjCoordSys = new PrjCoordSys();
            prjCoordSys.FromFile(@pcsPrjFile, PrjFileType.Esri);

            bool result = CoordSysTranslator.Convert(besselGCSDataset, prjCoordSys, new CoordSysTransParameter(), CoordSysTransMethod.PositionVector);
            if (result)
            {
                if ((offsetX == 0) && (offsetY == 0))
                {
                    return besselGCSDataset;
                }
                else
                {
                    HelperConvert.OffsetDataset(besselGCSDataset as DatasetVector, offsetX, offsetY);
                    return besselGCSDataset;
                }
            }
            else
            {
                return null;
            }
        }

        public Dataset GRS80ToBesselGCS(Datasource sourceDatasource, string sourceDatasetName)
        {
            Dataset sourceDataset = sourceDatasource.Datasets[sourceDatasetName];
            if (sourceDataset == null) return null;

            Dataset gcsDataset = HelperConvert.ConvertToGCS(sourceDataset, GeoCoordSysType.Grs1980);
            if (gcsDataset == null) return null;
            
            DatasetVector emptyGCSDatasetVector = HelperConvert.getEmptyGCSDatasetVector(sourceDatasource, sourceDataset, GeoCoordSysType.Bessel1841);
            if (emptyGCSDatasetVector == null) return null;

            bool result = ConvertGRS80DatasetVectorToBessel(gcsDataset as DatasetVector, emptyGCSDatasetVector);
            if (result)
            {
                return emptyGCSDatasetVector as Dataset;
            }
            else
            {
                return null;
            }
        }

        public Dataset GRS80ToBesselGCS(Datasource sourceDatasource, Dataset gcsDataset)
        {
            DatasetVector emptyGCSDatasetVector = HelperConvert.getEmptyGCSDatasetVector(sourceDatasource, gcsDataset, GeoCoordSysType.Bessel1841);
            if (emptyGCSDatasetVector == null) return null;

            bool result = ConvertGRS80DatasetVectorToBessel(gcsDataset as DatasetVector, emptyGCSDatasetVector);
            if (result)
            {
                sourceDatasource.Datasets.Delete(gcsDataset.Name);
                return emptyGCSDatasetVector as Dataset;
            }
            else
            {
                return null;
            }
        }

        public Dataset GRS80ToBesselGCS(Datasource sourceDatasource, Dataset gcsDataset, string gcsPrjFile)
        {
            DatasetVector emptyGCSDatasetVector = HelperConvert.getEmptyGCSDatasetVector(sourceDatasource, gcsDataset,gcsPrjFile) ;
            if (emptyGCSDatasetVector == null) return null;

            bool result = ConvertGRS80DatasetVectorToBessel(gcsDataset as DatasetVector, emptyGCSDatasetVector);
            if (result)
            {
                sourceDatasource.Datasets.Delete(gcsDataset.Name);
                return emptyGCSDatasetVector as Dataset;
            }
            else
            {
                return null;
            }
        }

        private bool ConvertBesselDatasetVectorToGRS80(DatasetVector sourceDatasetVector, DatasetVector targetDatasetVector)
        {
            // HelperConvert.Log("ConvertBesselDatasetVectorToGRS80 Start");

            QueryParameter queryParameter = new QueryParameter();
            queryParameter.CursorType = CursorType.Dynamic;

            Recordset sourceRs = sourceDatasetVector.Query(queryParameter);
            Recordset targetRs = targetDatasetVector.Query(queryParameter);

            sourceRs.MoveFirst();
            while (!sourceRs.IsEOF)
            {
                Geometry sourceGeometry = sourceRs.GetGeometry();
                Geometry targetGeometry = HelperConvert.getConvertToGRS80Geometry(sourceGeometry);

                targetRs.AddNew(targetGeometry);
                targetRs.Update();

                HelperConvert.CopyAttribute(sourceRs, targetRs);

                sourceRs.MoveNext();
            }

            targetDatasetVector.Close();
            targetDatasetVector.ComputeBounds();

            // HelperConvert.Log("ConvertBesselDatasetVectorToGRS80 End");

            return true;
        }

        private bool ConvertGRS80DatasetVectorToBessel(DatasetVector sourceDatasetVector, DatasetVector targetDatasetVector)
        {
            QueryParameter queryParameter = new QueryParameter();
            queryParameter.CursorType = CursorType.Dynamic;

            Recordset sourceRs = sourceDatasetVector.Query(queryParameter);
            Recordset targetRs = targetDatasetVector.Query(queryParameter);

            sourceRs.MoveFirst();
            while (!sourceRs.IsEOF)
            {
                Geometry sourceGeometry = sourceRs.GetGeometry();
                Geometry targetGeometry = HelperConvert.getConvertToBesselGeometry(sourceGeometry);

                targetRs.AddNew(targetGeometry);
                targetRs.Update();

                HelperConvert.CopyAttribute(sourceRs, targetRs);
                
                sourceRs.MoveNext();
            }

            targetDatasetVector.Close();
            targetDatasetVector.ComputeBounds();

            return true;
        }
    }
}
