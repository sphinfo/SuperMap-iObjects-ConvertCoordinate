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
            HelperConvert.Log("GRS80:GetBesselGCSDataset Start()");

            Dataset gcsDS = GetBesselGCSDataset();
            if (gcsDS == null) return;

            HelperConvert.Log("GRS80:GetBesselGCSDataset End()");

            Double offsetX = Convert.ToDouble(textBox4.Text);
            Double offsetY = Convert.ToDouble(textBox5.Text);

            Project project = new Project();
            Dataset grs80Dataset = project.BesselToGRS80PCS(m_datasource, gcsDS, cbGRS80PCS.Text, offsetX, offsetY);
            if (grs80Dataset != null)
            {
                m_datasource.Datasets.Rename(grs80Dataset.Name, m_datasource.Datasets.GetAvailableDatasetName(txtTranslateDataset.Text));

                HelperConvert.Log("grs80 변환 완료...");
                MessageBox.Show("grs80 변환 완료...");
            }
            else
            {
                MessageBox.Show("헐...");
            }
        }

        private Dataset GetBesselGCSDataset()
        {
            Dataset srcDS = m_datasource.Datasets[txtSourceDataset.Text];
            Dataset copyDS = m_datasource.CopyDataset(srcDS, m_datasource.Datasets.GetAvailableDatasetName(txtSourceDataset.Text), EncodeType.None);
            Dataset gcsDS = HelperConvert.ConvertToGCS(copyDS, GeoCoordSysType.Bessel1841);

            return gcsDS;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelperConvert.Log("Bessel:GetBesselGCSDataset Start()");

            Dataset gcsDS = GetGRS80GCSDataset();
            if (gcsDS == null) return;

            HelperConvert.Log("Bessel:GetBesselGCSDataset End()");

            Double offsetX = Convert.ToDouble(textBox6.Text);
            Double offsetY = Convert.ToDouble(textBox7.Text);

            Project project = new Project();
            Dataset besselDataset = project.GRS80ToBesselPCS(m_datasource, gcsDS, cbBesselPCS.Text, offsetX, offsetY);
            if (besselDataset != null)
            {
                m_datasource.Datasets.Rename(besselDataset.Name, m_datasource.Datasets.GetAvailableDatasetName(txtTranslateDataset.Text));

                HelperConvert.Log("Bessel 변환 완료...");
                MessageBox.Show("Bessel 변환 완료...");
            }
        }

        private Dataset GetGRS80GCSDataset()
        {
            Dataset srcDS = m_datasource.Datasets[txtSourceDataset.Text];
            Dataset copyDS = m_datasource.CopyDataset(srcDS, m_datasource.Datasets.GetAvailableDatasetName(txtSourceDataset.Text), EncodeType.None);
            Dataset gcsDS = HelperConvert.ConvertToGCS(srcDS, GeoCoordSysType.Wgs1984);

            return gcsDS;
        }
    }
}
