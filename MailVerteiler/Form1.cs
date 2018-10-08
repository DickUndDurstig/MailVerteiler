using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailVerteiler
{
    public partial class Form1 : Form
    {

        CSVReader csvReader;
        StringCollection extraFilters;

        public Form1()
        {
            InitializeComponent();

            InitFilter();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            labelFilePath.Text = openFileDialog1.FileName;
            LoadFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void InitFilter()
        {
            comboBoxFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBoxFilter.ImageList = new ImageList();

            //add default filters
            comboBoxFilter.Items.Add("");
            comboBoxFilter.Items.Add("97320");
            comboBoxFilter.Items.Add(new ImageComboItem("Hallo", new Font("Verdana", 8), Color.Black, 0));

            extraFilters = (StringCollection)Properties.Settings.Default["filters"];
            if (extraFilters != null)
                foreach (string filter in extraFilters)
                {
                    comboBoxFilter.Items.Add(filter);
                }

            int index = (int)Properties.Settings.Default["cbFilterIndex"];
            comboBoxFilter.SelectedIndex = index;

            string filePath = (string)Properties.Settings.Default["filePath"];
            labelFilePath.Text = filePath;
            openFileDialog1.FileName = filePath;

            if (String.IsNullOrEmpty(filePath) == false)
            {
                LoadFile();
            }
        }

        private void LoadFile()
        {
            csvReader = new CSVReader();
            csvReader.ReadCSV(openFileDialog1.FileName);
            csvReader.PopulateDataGridView(dataGridView1, comboBoxFilter.GetItemText(comboBoxFilter.SelectedItem));
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (csvReader != null)
                csvReader.PopulateDataGridView(dataGridView1, comboBoxFilter.GetItemText(comboBoxFilter.SelectedItem));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default["cbFilterIndex"] = comboBoxFilter.SelectedIndex;
            Properties.Settings.Default["filePath"] = openFileDialog1.FileName;
            Properties.Settings.Default["filters"] = extraFilters;
            Properties.Settings.Default.Save();
        }

        private void buttonDeleteFilter_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
        }
    }
}
