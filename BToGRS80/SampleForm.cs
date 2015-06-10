using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.Convert.KoreaCoordinate;

namespace BToGRS80
{
    public partial class SampleForm : Form
    {
        private Datasource m_datasource;
        
        public SampleForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Workspace workspace = new Workspace();

            DatasourceConnectionInfo datasourceConnectInfo = new DatasourceConnectionInfo();
            datasourceConnectInfo.EngineType = EngineType.UDB;
            datasourceConnectInfo.Server = @txtDatasource.Text;
            datasourceConnectInfo.Alias = "Test";
                        
            m_datasource = workspace.Datasources.Open(datasourceConnectInfo);
            if (m_datasource == null)
            {
                MessageBox.Show("헐..");
            }
        }

        private void btnToGRS80_Click(object sender, EventArgs e)
        {
            Dataset gcsDS = GetBesselGCSDataset();
            if (gcsDS == null) return;

            Double offsetX = Convert.ToDouble(textBox4.Text);
            Double offsetY = Convert.ToDouble(textBox5.Text);
            
            Project project = new Project();
            Dataset grs80Dataset = project.BesselToGRS80PCS(m_datasource, gcsDS, txtGRS80PCS.Text, offsetX, offsetY);
            if (grs80Dataset != null)
            {
                m_datasource.Datasets.Rename(grs80Dataset.Name, m_datasource.Datasets.GetAvailableDatasetName(txtTranslateDataset.Text));
                MessageBox.Show("grs80 변환 완료...");
            }
            else
            {
                MessageBox.Show("헐...");
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dataset gcsDS = GetGRS80GCSDataset();
            if (gcsDS == null) return;

            Double offsetX = Convert.ToDouble(textBox6.Text);
            Double offsetY = Convert.ToDouble(textBox7.Text);
            
            Project project = new Project();
            Dataset besselDataset = project.GRS80ToBesselPCS(m_datasource, gcsDS, txtBesselPCS.Text, @"C:\Data\좌표계\projection\GCS_BESSEL.prj", offsetX, offsetY);
            if (besselDataset != null)
            {
                m_datasource.Datasets.Rename(besselDataset.Name, m_datasource.Datasets.GetAvailableDatasetName(txtTranslateDataset.Text));                
                MessageBox.Show("Bessel 변환 완료...");
            }
        }

        private Dataset GetBesselGCSDataset()
        {
            Dataset srcDS = m_datasource.Datasets[txtSourceDataset.Text];
            Dataset copyDS = m_datasource.CopyDataset(srcDS, m_datasource.Datasets.GetAvailableDatasetName(txtSourceDataset.Text), EncodeType.None);

            GCSConverter.Bessel_Control_Point controlPoint = GetBesselControlPoint();
            GCSConverter gcsconverter = new GCSConverter();
            Dataset gcsDS = gcsconverter.GetBesselGCSDataset(m_datasource, copyDS, @"C:\Data\좌표계\projection\GCS_BESSEL.prj", controlPoint);

            return gcsDS;
        }

        private Dataset GetGRS80GCSDataset()
        {
            Dataset srcDS = m_datasource.Datasets[txtSourceDataset.Text];
            Dataset copyDS = m_datasource.CopyDataset(srcDS, m_datasource.Datasets.GetAvailableDatasetName(txtSourceDataset.Text), EncodeType.None);

            GCSConverter.GRS80_Control_Point controlPoint = GetGR080ControlPoint();
            GCSConverter gcsconverter = new GCSConverter();
            Dataset gcsDS = gcsconverter.GetGRS80GCSDataset(m_datasource, copyDS, @"C:\Data\좌표계\projection\GCS_WGS84.prj", controlPoint);

            return gcsDS;
        }

        private GCSConverter.Bessel_Control_Point GetBesselControlPoint()
        {
            switch (cbBesselControlPoint.SelectedIndex)
            {
                case 0:
                    {
                        return GCSConverter.Bessel_Control_Point.Center;
                    }
                case 1:
                    {
                        return GCSConverter.Bessel_Control_Point.West;
                    }
                case 2:
                    {
                        return GCSConverter.Bessel_Control_Point.East;
                    }
                case 3:
                    {
                        return GCSConverter.Bessel_Control_Point.EastSea;
                    }
                case 4:
                    {
                        return GCSConverter.Bessel_Control_Point.Jeju;
                    }
                default:
                    {
                        return GCSConverter.Bessel_Control_Point.Center;
                    }
            }
        }

        private GCSConverter.GRS80_Control_Point GetGR080ControlPoint()
        {
            switch (cbGRS80ControlPoint.SelectedIndex)
            {
                case 0:
                    {
                        return GCSConverter.GRS80_Control_Point.Center;
                    }
                case 1:
                    {
                        return GCSConverter.GRS80_Control_Point.West;
                    }
                case 2:
                    {
                        return GCSConverter.GRS80_Control_Point.East;
                    }
                case 3:
                    {
                        return GCSConverter.GRS80_Control_Point.EastSea;
                    }
                default:
                    {
                        return GCSConverter.GRS80_Control_Point.Center;
                    }
            }
        }
    }
}
