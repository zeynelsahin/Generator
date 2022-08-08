using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.DataAccess.Concrete;

namespace Generator.UI.WF
{
    public partial class FormObjectParamaterAdd : Form
    {
        public FormObjectParamaterAdd()
        {
            InitializeComponent();
        }

        private IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());
        private void FormObjectParamaterAdd_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newResult = "";
            var result = _objectEntityService.GetOracleTextBy("get_emc_generate_deneme",
                "CLEARING_BACKOFFICE_V2", "EMC").ToLower();

            var deneme = result[1];
            char[] chars = new char[5000];
            for (int i = 0; i < result.Length; i++)
            {
                chars[i] = result[i];
            }
            int[] fromCatch = new int[4];
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == Convert.ToChar("f"))
                {
                    fromCatch[0] = i;
                }
                if (chars[i] == Convert.ToChar("r") && i== fromCatch[0] + 1)
                {
                    fromCatch[1] = i;
                }
                if (chars[i] == Convert.ToChar("o") && i== fromCatch[1] + 1)
                {
                    fromCatch[2] = i;
                }
                if (chars[i] == Convert.ToChar("m") && i== fromCatch[2] + 1)
                {
                    fromCatch[3] = i;
                    newResult = result.Substring(0, i + 1);
                    MessageBox.Show(newResult);
                    break;
                }
            }

            int count;
            string duzMetin = "";
            for (int i = 0; i < newResult.Length; i++)
            {
                if (newResult[i]!=Convert.ToChar($"\n") && newResult[i]!=Convert.ToChar($"\r") &&newResult[i]!=Convert.ToChar(" ") &&i>5)
                {
                    duzMetin += newResult[i].ToString();
                }
            }
            MessageBox.Show(duzMetin);
            duzMetin=duzMetin.ToUpper();
            List<string> resultList = new List<string>();
            List<string> tables = new List<string>();
            string column="";
            int son;
            for (int i = 0; i < duzMetin.Length; i++)
            {
                if (duzMetin[i] != Convert.ToChar(".") && duzMetin[i] != Convert.ToChar(","))
                {
                    column += duzMetin[i].ToString();
                }

                if (duzMetin[i] == Convert.ToChar("."))
                {
                    tables.Add(column);
                    column = "";
                }

                if (duzMetin[i]==Convert.ToChar(","))
                {
                    resultList.Add(column);
                    column = "";
                }

                if (i==duzMetin.Length-1)
                {
                    resultList.Add(column);
                    column = "";
                }
            }

            foreach (var r in resultList)
            {
                LblSonuc.Text = r;
            }
        }
    }
}
