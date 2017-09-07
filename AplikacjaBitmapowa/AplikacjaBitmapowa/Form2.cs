using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AplikacjaBitmapowa
{
    public partial class Form2 : Form
    {
        public Form2(int []histTabel)
        {
            InitializeComponent();
            histogram.ChartAreas[0].AxisX.Minimum = 0;
            histogram.Series.Add("Number of Pixels for each V");
            for(int i = 0;i<histTabel.Length;i++)
                histogram.Series["Number of Pixels for each V"].Points.Add(new DataPoint(i, histTabel[i]));            
            histogram.Series["Number of Pixels for each V"].ChartType = SeriesChartType.Line;
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
