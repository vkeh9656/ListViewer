using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewer
{
    public partial class Form1 : Form
    {
        List<string> _strList = new List<string>();

        List<int> _intList = new List<int>();

        ArrayList _arrayList = new ArrayList();


        public Form1()
        {
            InitializeComponent();
        }

        private void pBox_Click(object sender, EventArgs e)
        {
            PictureBox pbox = sender as PictureBox;

            string strSelectText = string.Empty;

            switch(pbox.Name) 
            {
                case "pBox1":
                    strSelectText = "cake";
                    break;
                case "pBox2":
                    strSelectText = "burger";
                    break;
                case "pBox3":
                    strSelectText = "pizza";
                    break;
                case "pBox4":
                    strSelectText = "icecream";
                    break;
            }

            _strList.Add(strSelectText);

            UIDisplay();

            DataGridViewDisplay();
        }

        

        private void UIDisplay()
        {
            int iCake = 0;
            int iBurger = 0;
            int iPizza = 0;
            int iIcecream = 0;

            foreach (var item in _strList)
            {
                switch (item)
                {
                    case "cake":
                        iCake++;
                        break;
                    case "burger":
                        iBurger++;
                        break;
                    case "pizza":
                        iPizza++;
                        break;
                    case "icecream":
                        iIcecream++;
                        break;
                }
            }

            lblPick1.Text = iCake.ToString();
            lblPick2.Text = iBurger.ToString();
            lblPick3.Text = iPizza.ToString();
            lblPick4.Text = iIcecream.ToString();

            lblTotalCount.Text = "Total Count: " + _strList.Count.ToString();
        }

        private void DataGridViewDisplay()
        {
            //dgListView.Rows.Clear();


            //foreach(string item in _strList)
            //{
            //    dgListView.Rows.Add(item);
            //}

            dgListView.DataSource = _strList.Select(x => new { value = x }).ToList();

            foreach(DataGridViewRow row in dgListView.Rows)
            {
                row.HeaderCell.Value = row.Index.ToString();
            }

            dgListView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
    }
}
