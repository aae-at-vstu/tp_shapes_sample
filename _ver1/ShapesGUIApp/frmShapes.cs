using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presenter;
using Shape4ViewAdapter;

namespace ShapesGUIApp
{
    public partial class frmShapes : Form, IView
    {
        int percent;

        List<string> lst;

        public frmShapes()
        {
            InitializeComponent();
            lst = new List<string>();
        }

        public bool AskYesOrNo(string quest)
        {
            return MessageBox.Show(quest, "Вопрос", MessageBoxButtons.YesNo)
                == DialogResult.Yes;
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        //public void ShowShapeList(List<string> shapes)
        //{
        //    listBox1.DataSource = shapes;
        //}

        public void ShowShapeList(List<Shape4View> shapes)
        {
            dataGridView1.DataSource = shapes;
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
                //dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dc.Width = 35;
            dataGridView1.Columns[0].Width = 45;
            dataGridView1.RowHeadersVisible = false;
       }

        public void ShowTotResults(float area, float perimeter)
        {
            label2.Text = area.ToString();
            label4.Text = perimeter.ToString();
        }

        public void OneMorePercent()
        {
            percent++;
            if (percent > 100)
                percent = 0;
            progressBar1.Value = percent;
            progressBar1.Refresh();
        }

        public Presenter.Presenter Pres { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            percent = 0;
            progressBar1.Value = percent;
            progressBar1.Refresh();
            Pres.ShowReport(radioButton1.Checked ? 1 : radioButton3.Checked ? 2 : 0);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = radioButton4.Checked;
            button1.Enabled = !radioButton4.Checked;
            if (radioButton4.Checked)
            {
                lst.Clear();
                dataGridView1.DataSource = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lst.Add(comboBox1.SelectedIndex.ToString() + ";" + textBox1.Text + ";" +
                textBox2.Text + ";0");
            percent = 0;
            progressBar1.Value = percent;
            progressBar1.Refresh();
            Pres.ShowReport(lst);
        }

        private void frmShapes_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
