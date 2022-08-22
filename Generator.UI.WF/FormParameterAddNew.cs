﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.DataAccess.Concrete;

namespace Generator.UI.WF
{
    public partial class FormParameterAddNew : Form
    {
        private string _objectId;
        private string _profileId;
        private string _schemaName;
        public FormParameterAddNew()
        {
              _objectId = "get_emc_outgoing_data";
            _profileId = "MASTERCARD_BATCH";
            _schemaName = "EMC";
        }
        public FormParameterAddNew(string objectId, string profileId, string schemaName)
        {
            _objectId = objectId;
            _profileId = profileId;
            _schemaName = schemaName;
            InitializeComponent();
        }
          List<string> resultList = new List<string>();
        private IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());
        private IObjectResultService _objecResultService = new ObjectResultService(new EfObjectResultDal());
        private List<string> NameConfigure()
        {
            List<string> configureName = new List<string>();
            for (int i = 0; i < resultList.Count; i++)
            {
                var st = resultList[i].ToLower();
                string yeniSt = "";
                for (var j = 0; j < st.Length; j++)
                {
                    if (j == 0)
                    {
                        yeniSt += st[0].ToString().ToUpper();
                    }
                    else
                    {
                        if (st[j - 1] == Convert.ToChar("_"))
                        {
                            yeniSt += st[j].ToString().ToUpper();
                            continue;
                        }
                        if (st[j] != Convert.ToChar("_"))
                        {
                            yeniSt += st[j];
                        }
                    }

                }

                configureName.Add(yeniSt);
                yeniSt = "";
            }
            return configureName;
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
                "date",
                "datetime",
                "decimal",
                "char",
                "int",
                "long",
                "time",
                "smallint",
                "object",
                "bool",
                "bit",
                "bigint"});
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
            textBox.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
        private string GetSqlText()
        {
            var sqlText = _objectEntityService.GetOracleText(_objectId, _profileId, _schemaName).ToLower();
            return string.IsNullOrWhiteSpace(sqlText) ? null : sqlText;
        }
        private string SqlTextFormat(string sqlText)
        {
            int unionIndex = sqlText.IndexOf("union");
            if(unionIndex!=-1)  sqlText = sqlText.Substring(0, unionIndex);
          

            int selectIndex = sqlText.IndexOf("select");
            sqlText = sqlText.Substring(selectIndex);
            sqlText = sqlText.Substring(6);

            int fromIndex = sqlText.LastIndexOf("from");
            sqlText = sqlText.Substring(fromIndex);

            string straightSqlText = "";

            for (int i = 0; i < sqlText.Length; i++)
            {
                if (sqlText[i] != Convert.ToChar($"\n") && sqlText[i] != Convert.ToChar($"\r"))
                {
                    straightSqlText += sqlText[i].ToString();
                }
            }
            return straightSqlText.ToUpper();
        }
        private List<string> GetResulList(string straightSqlText)
        {
            List<string> tables = new List<string>();
            string column = "";
            for (int i = 0; i < straightSqlText.Length; i++)
            {
                if (straightSqlText[i] != Convert.ToChar(".") && straightSqlText[i] != Convert.ToChar(","))
                {
                    column += straightSqlText[i].ToString();
                }

                if (straightSqlText[i] == Convert.ToChar("."))
                {
                    tables.Add(column);
                    column = "";
                }

                if (straightSqlText[i] == Convert.ToChar(",") || i == straightSqlText.Length - 1)
                {
                    if (column.IndexOf("CASE") != -1)
                    {
                        var elseIndex = column.IndexOf("ELSE");
                        if (elseIndex != -1)
                        {
                            column = column.Substring(elseIndex);
                            var endIndex = column.IndexOf("END");
                            if (endIndex != -1)
                            {
                                column = column.Substring(endIndex);
                                column = column.Substring(3);
                            }
                        }
                    }
                    else if (column.IndexOf("AS") != -1 && column[column.IndexOf("AS") - 1] == ' ')
                    {
                        var asIndex = column.IndexOf("AS");
                        if (column.LastIndexOf("_") >= asIndex || column[asIndex - 1] == ')')
                        {
                            column = column.Substring(asIndex);
                            column = column.Substring(3);
                        }
                    }

                    if (column.IndexOf("NULL") != -1)
                    {
                        column = column.Substring(column.IndexOf("NULL"));
                        column = column.Substring(5);
                    }
                    column = column.Trim();
                    resultList.Add(column);
                    column = "";
                }


            }
            return resultList;
        }
        private List<Panel> ResultPanel(List<string> resultList)
        {
            List<Panel> panelList = new List<Panel>();
            int index = 1;
            //NameConfigure();
            for (int i = 0; i < resultList.Count; i++)
            {
                var resultType = _objecResultService.FindParameterType(resultList[i]);
                Panel panel = CreateResultPanel();
                var name = "Result" + index;
                var comboBox = CreateComboBox();
                comboBox.Name = resultList[i] + "Type";
                comboBox.TabIndex = index;
                comboBox.Anchor = AnchorStyles.Right;
                if (resultType != null)
                {
                    comboBox.SelectedItem = resultType;
                }
                index++;

                var panelComboBox = CreateComboBoxPanel();
                panelComboBox.Name = "panelComboBox" + name;
                panelComboBox.TabIndex = index;
                panelComboBox.Anchor = AnchorStyles.Right;
                index++;
                var textBox = CreateTextBox();
                textBox.Name = resultList[i] + "Value";
                textBox.Text = resultList[i];
                textBox.TabIndex = index;
                textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                index++;
                var panelTextBox = CreateTextBoxPanel();
                panelTextBox.Name = "panelTextBox" + name;
                panelTextBox.TabIndex = index;
                panelTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                index++;

                panel.Controls.Add(comboBox);
                panel.Controls.Add(panelComboBox);
                panel.Controls.Add(panelTextBox);
                panel.Controls.Add(textBox);
                panelList.Add(panel);
               
            }
            return panelList;
        }

        private void FormParameterAdd_Load(object sender, EventArgs e)
        {

        }

   

        private void BtnParameterAdd_Click(object sender, EventArgs e)
        {

        }

        private void BtnParameterFind_Click(object sender, EventArgs e)
        {
              var sqlText = GetSqlText();
            if (sqlText == null) return;

            var straightSqlText = SqlTextFormat(sqlText);

            var resultList = GetResulList(straightSqlText);

            var panelList = ResultPanel(resultList);

            int queue= panelList.Count/3;
            int queueMod = panelList.Count % 3;
            int queueSecond=queue;
            int queueThrid=queue;

            if (queueMod==2)
            {
                queueSecond++;
            }
            int count=0;
            for (int i = panelList.Count ; i > 0; i--)
            {
                if (i >panelList.Count-queueThrid)
                {
                    PanelThird.Controls.Add(panelList[i-1]);
                }
                else if (i>queueSecond)
                {
                    PanelSecond.Controls.Add(panelList[i-1]);
                }
                else
                {
                    PanelFirst.Controls.Add(panelList[i-1]);
                }
                count++;
            }

            PanelTop.Height = PanelFirst.Controls.Count * 40 +50;
        }
    }
}
