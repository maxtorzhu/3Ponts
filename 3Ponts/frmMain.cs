using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3Ponts
{
    public partial class frmMain : Form
    {
        const int round = 5;

        public frmMain()
        {
            InitializeComponent();
            ClearForm();
        }

        #region 通用方法


        private void ClearForm()
        {
            try
            {
                numA.Value = numB.Value = numC.Value = 0.00M;
                txtP1.Text = txtP2.Text = txtP3.Text = "";
                txtH1.Text = txtH2.Text = txtH3.Text = "";
                txtZDGSJ875.Text = txtZDGSJ764.Text = txtZDGSJ666.Text = "";

                numAF.Value = numBF.Value = numCF.Value = 0.00M;
                txtSupportF.Text = txtTargetF.Text = "";

                numDD.Value = numJXW.Value = 0m;
                txtTarget.Text = "";
            }
            catch
            {
                throw new NotImplementedException();

            }

        }

        #endregion

        #region 半对数


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double a, b, c, h1 = 0, h2 = 0, h3 = 0, p1 = 0, p2 = 0, p3 = 0;
            double m = 0.618, n = 0.382, m1 = 1.618, n1 = 1.382;
            double ZDGSJ875 = 0.00d, ZDGSJ764 = 0d, ZDGSJ666 = 0d;

            a = Convert.ToDouble(numA.Value);
            b = Convert.ToDouble(numB.Value);

            if (a > b)//计算回撤点位
            {
                p1 = Math.Pow(a, m) * Math.Pow(b, n);
                p2 = Math.Sqrt(a * b);
                p3 = Math.Pow(b, m) * Math.Pow(a, n);

            }
            else//计算反弹点位
            {
                p3 = Math.Pow(a, m) * Math.Pow(b, n);
                p2 = Math.Sqrt(a * b);
                p1 = Math.Pow(b, m) * Math.Pow(a, n);
            }
            ZDGSJ875 = Math.Pow(a, 0.875) * Math.Pow(b, 0.125);
            ZDGSJ764 = Math.Pow(a, 0.764) * Math.Pow(b, 0.236);
            ZDGSJ666 = Math.Pow(a, 0.666) * Math.Pow(b, 0.333);

            txtP1.Text = Math.Round(p1, round).ToString();
            txtP2.Text = Math.Round(p2, round).ToString();
            txtP3.Text = Math.Round(p3, round).ToString();
            txtZDGSJ875.Text = Math.Round(ZDGSJ875, round).ToString();
            txtZDGSJ764.Text = Math.Round(ZDGSJ764, round).ToString();
            txtZDGSJ666.Text = Math.Round(ZDGSJ666, round).ToString();

            if (numC.Value > 0)
            {
                c = Convert.ToDouble(numC.Value);

                h1 = Math.Round(b * c / a, round);
                h2 = Math.Round(Math.Pow(b / a, n1) * Convert.ToDouble(numC.Value), round);
                h3 = Math.Round(Math.Pow(b / a, m1) * Convert.ToDouble(numC.Value), round);

                txtH1.Text = h1.ToString();
                txtH2.Text = h2.ToString();
                txtH3.Text = h3.ToString();
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            numA.Value = numB.Value = numC.Value = 0.00M;
            txtP1.Text = txtP2.Text = txtP3.Text = "";
            txtH1.Text = txtH2.Text = txtH3.Text = "";
            txtZDGSJ875.Text = txtZDGSJ764.Text = txtZDGSJ666.Text = "";
        }

        #endregion

        #region 简单计算

        private void btnCalculate1_Click(object sender, EventArgs e)
        {
            double a, b, c, s, h;
            a = Convert.ToDouble(numAF.Value);//L起涨点
            b = Convert.ToDouble(numBF.Value);//H高点
            c = Convert.ToDouble(numCF.Value);//回踩点

            if (a > b)
            {

                s = (a - b) / 3 + b;//支撑
                txtSupportF.Text = Math.Round(s, round).ToString();

                if (c > 0)
                {
                    h = a - b + c;
                    txtTargetF.Text = Math.Round(h, round).ToString();
                }
            }
            else
            {
                s = (b - a) / 3 + a;//压力
                txtSupportF.Text = Math.Round(s, round).ToString();

                if (c > 0)
                {
                    h = b - a + c;
                    txtTargetF.Text = Math.Round(h, round).ToString();
                }
            }

            txtTarget1234.Text = Math.Round(b * c / a, round).ToString();
        }

        private void btnClearF_Click(object sender, EventArgs e)
        {
            numAF.Value = numBF.Value = numCF.Value = 0.00M;
            txtSupportF.Text = txtTargetF.Text = "";
        }

        #endregion


        #region 顶底测距



        private void btnClearDD_Click(object sender, EventArgs e)
        {
            numDD.Value = numJXW.Value = 0m;
            txtTarget.Text = "";
        }

        private void btnCalculate2_Click(object sender, EventArgs e)
        {
            decimal jxw = numJXW.Value, dd = numDD.Value;
            txtTarget.Text = Math.Round((jxw * jxw) / dd, round).ToString();
        }



        #endregion
    }
}
