using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.DataAccess.Concrete;
using static System.Windows.Forms.AnchorStyles;

namespace Generator.UI.WF
{
    public partial class FormObjectResultAdd : Form
    {
        public FormObjectResultAdd()
        {
            InitializeComponent();
        }
        List<string> resultList = new List<string>();
        private IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());
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
                if (chars[i] == Convert.ToChar("r") && i == fromCatch[0] + 1)
                {
                    fromCatch[1] = i;
                }
                if (chars[i] == Convert.ToChar("o") && i == fromCatch[1] + 1)
                {
                    fromCatch[2] = i;
                }
                if (chars[i] == Convert.ToChar("m") && i == fromCatch[2] + 1)
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
                if (newResult[i] != Convert.ToChar($"\n") && newResult[i] != Convert.ToChar($"\r") && newResult[i] != Convert.ToChar(" ") && i > 5)
                {
                    duzMetin += newResult[i].ToString();
                }
            }
            MessageBox.Show(duzMetin);
            duzMetin = duzMetin.ToUpper();

            List<string> tables = new List<string>();
            string column = "";
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

                if (duzMetin[i] == Convert.ToChar(","))
                {
                    resultList.Add(column);
                    column = "";
                }

                if (i == duzMetin.Length - 1)
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

        private ComboBox CreateComboBox()
        {
            //Combobox
            ComboBox comboBox = new ComboBox();
            comboBox.BackColor = System.Drawing.Color.White;
            comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] {
                "varchar",
                "datetime",
                "decimal",
                "char",
                "int",
                "long"});
            comboBox.Location = new System.Drawing.Point(299, 1);
            comboBox.Name = "name";
            comboBox.Size = new System.Drawing.Size(168, 32);
            return comboBox;
        }

        private Panel CreateComboBoxPanel()
        {

            //Panel Combox altı
            Panel panelCombobox = new Panel();
            panelCombobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            panelCombobox.Location = new System.Drawing.Point(299, 34);
            panelCombobox.Name = "panel103";
            panelCombobox.Size = new System.Drawing.Size(166, 2);
            panelCombobox.TabIndex = 316;
            return panelCombobox;
        }

        private TextBox CreateTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.BackColor = System.Drawing.Color.White;
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            textBox.Location = new System.Drawing.Point(14, 3);
            textBox.Name = "name";
            textBox.Size = new System.Drawing.Size(249, 30);
            textBox.Text = "123";

            return textBox;
        }

        private Panel CreateTextBoxPanel()
        {
            //Panel TextBox Altı
            Panel panelTextBox = new Panel();
            panelTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            panelTextBox.Location = new System.Drawing.Point(14, 35);
            panelTextBox.Name = "panel20";
            panelTextBox.Size = new System.Drawing.Size(249, 2);
            panelTextBox.TabIndex = 315;

            return panelTextBox;
        }

        private Panel CreateResultPanel()
        {

            Panel panel = new Panel();
            panel.BackColor = Color.White;
            panel.Dock = System.Windows.Forms.DockStyle.Top;
            panel.Location = new System.Drawing.Point(0, 0);
            panel.Name = "panel102";
            panel.Size = new System.Drawing.Size(489, 40);
            panel.TabIndex = 327;

            return panel;
        }
        private void FormObjectResultAdd_Load(object sender, EventArgs e)
        {
            button2.PerformClick();
            List<Panel> panelList = new List<Panel>();
            int count = 1;
            for (int i = 0; i < resultList.Count; i++)
            {
                Panel panel = CreateResultPanel();
                var name = "Result" + count;
                var comboBox = CreateComboBox();
                comboBox.Name = "comboBox" + name;
                comboBox.TabIndex = count;
                comboBox.Anchor=  AnchorStyles.Right;
                count++;

                var panelComboBox = CreateComboBoxPanel();
                panelComboBox.Name = "panelComboBox" + name;
                panelComboBox.TabIndex = count;
                panelComboBox.Anchor = AnchorStyles.Right;
                count++;
                var textBox = CreateTextBox();
                textBox.Name = "textBox" + name;
                textBox.TabIndex = count;
                textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                count++;
                var panelTextBox = CreateTextBoxPanel();
                panelTextBox.Name = "panelTextBox" + name;
                panelTextBox.TabIndex = count;
                panelTextBox.Anchor= AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                count++;


                panel.Controls.Add(comboBox);
                panel.Controls.Add(panelComboBox);
                panel.Controls.Add(panelTextBox);
                panel.Controls.Add(textBox);
                panelList.Add(panel);
            }

            string sıra = "first";
            for (int i = 0; i < panelList.Count; i++)
            {
                if (sıra == "first")
                {
                    PanelFirst.Controls.Add(panelList[i]);
                    sıra = "second";
                    continue;
                }
                if (sıra == "second")
                {
                    PanelSecond.Controls.Add(panelList[i]);
                    sıra = "third";
                    continue;
                }

                if (sıra == "third")
                {
                    PanelThird.Controls.Add(panelList[i]);
                    sıra = "first";
                    continue;
                }
            }

            PanelTop.Height = PanelFirst.Controls.Count * 40;
        }
        public void DatagridLabelSize()//datagridview in boyutunu ayarlar
        {
            int height = 41;
            foreach (DataGridViewRow dr in DgwObject.Rows)
            {
                height += dr.Height;
            }
            if (height > PanelPresentation.Height - 50)
            {
                DgwObject.Height = PanelPresentation.Height - 50;
            }
            else
            {
                DgwObject.Height = height;
            }
            LblAdet.Top = DgwObject.Bottom + 10;
        }
        private void FormObjectResultAdd_SizeChanged(object sender, EventArgs e)
        {
            var width = PanelTop.Width / 3;
            PanelFirst.Width = width;
            PanelSecond.Width = width;
            PanelThird.Width = width;
            DatagridLabelSize();
        }
    }
}
