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
using Generator.Entities;

namespace Generator.UI.WF
{
    public partial class FormParameterAdd : Form
    {
        private string _objectId;
        private string _profileId;
        private string _schemaName;

        public FormParameterAdd()
        {
            _objectId = "get_terminal_transactions_list_by_custom_cretiria";
            _profileId = "MerchantBackoffice";
            _schemaName = "TRN";
            InitializeComponent();
        }

        public FormParameterAdd(string objectId, string profileId, string schemaName)
        {
            _objectId = objectId;
            _profileId = profileId;
            _schemaName = schemaName;
            InitializeComponent();
        }

        private List<string> parameterList = new List<string>();
        private IObjectParameterService _objectParameterService = new ObjectParameterService(new EfObjectParameterDal());
        private IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());
        private IObjectResultService _objecResultService = new ObjectResultService(new EfObjectResultDal());

        private List<string> NameConfigure()
        {
            var configureName = new List<string>();
            for (var i = 0; i < parameterList.Count; i++)
            {
                var st = parameterList[i].ToLower();
                var yeniSt = "";
                for (var j = 0; j < st.Length; j++)
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

                        if (st[j] != Convert.ToChar("_")) yeniSt += st[j];
                    }

                configureName.Add(yeniSt);
                yeniSt = "";
            }

            return configureName;
        }

        private ComboBox CreateComboBox()
        {
            //Combobox
            var comboBox = new ComboBox();
            comboBox.BackColor = Color.White;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox.ForeColor = Color.FromArgb((int)(byte)35, (int)(byte)128, (int)(byte)109);
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[]
            {
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
                "bigint"
            });
            comboBox.Location = new Point(299, 1);
            comboBox.Name = "name";
            comboBox.Size = new Size(168, 32);
            return comboBox;
        }

        private Panel CreateComboBoxPanel()
        {
            //Panel Combox altı
            var panelCombobox = new Panel();
            panelCombobox.BackColor = Color.FromArgb((int)(byte)35, (int)(byte)128, (int)(byte)109);
            panelCombobox.Location = new Point(299, 34);
            panelCombobox.Name = "panel103";
            panelCombobox.Size = new Size(166, 2);
            panelCombobox.TabIndex = 316;
            return panelCombobox;
        }

        private TextBox CreateTextBox()
        {
            var textBox = new TextBox();
            textBox.BackColor = Color.White;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox.ForeColor = Color.FromArgb((int)(byte)35, (int)(byte)128, (int)(byte)109);
            textBox.Location = new Point(14, 3);
            textBox.Name = "name";
            textBox.Size = new Size(249, 30);
            textBox.Text = "123";

            return textBox;
        }

        private Panel CreateTextBoxPanel()
        {
            //Panel TextBox Altı
            var panelTextBox = new Panel();
            panelTextBox.BackColor = Color.FromArgb((int)(byte)35, (int)(byte)128, (int)(byte)109);
            panelTextBox.Location = new Point(14, 35);
            panelTextBox.Name = "panel20";
            panelTextBox.Size = new Size(249, 2);
            panelTextBox.TabIndex = 315;

            return panelTextBox;
        }

        private Panel CreateResultPanel()
        {
            var panel = new Panel();
            panel.BackColor = Color.White;
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Name = "panel102";
            panel.Size = new Size(489, 40);
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
            var unionIndex = sqlText.IndexOf("union");
            if (unionIndex != -1) sqlText = sqlText.Substring(0, unionIndex);


            var selectIndex = sqlText.IndexOf("select");
            sqlText = sqlText.Substring(selectIndex);
            sqlText = sqlText.Substring(6);

            var fromIndex = sqlText.LastIndexOf("where");
            sqlText = sqlText.Substring(fromIndex);
            sqlText = sqlText.Substring(6);
            var straightSqlText = "";

            for (var i = 0; i < sqlText.Length; i++)
                if (sqlText[i] != Convert.ToChar($"\n") && sqlText[i] != Convert.ToChar($"\r"))
                    straightSqlText += sqlText[i].ToString();
            return straightSqlText.ToUpper();
        }

        private List<string> GetParameterList(string straightSqlText)
        {
            var tables = new List<string>();
            var column = "";
            straightSqlText = straightSqlText.Replace("AND", "é");
            for (var i = 0; i < straightSqlText.Length; i++)
            {
                if (straightSqlText[i] != Convert.ToChar(".") && straightSqlText[i] != Convert.ToChar("é"))
                {
                    if (column == null)
                        if (straightSqlText[i].ToString() == " ")
                            continue;

                    column += straightSqlText[i].ToString();
                }

                if (straightSqlText[i] == Convert.ToChar("é") || i == straightSqlText.Length - 1)
                {
                    if (column.StartsWith('(')) column = column.Remove(0, 1);
                    if (column.StartsWith(' ')) column = column.Remove(0, 1);
                    while (column.IndexOf(" ") != -1)
                    {
                        var elseIndex = column.IndexOf(" ");
                        if (elseIndex != -1) column = column.Substring(0, elseIndex);
                    }

                    if (column.IndexOf("NULL") != -1)
                    {
                        column = column.Substring(column.IndexOf("NULL"));
                        column = column.Substring(5);
                    }

                    if (column.EndsWith(')')) column = column.Remove(column.Length - 1, 1);

                    if (column.EndsWith(',')) column = column.Remove(column.Length - 1, 1);

                    if (column.StartsWith(':')) column = column.Remove(0, 1);
                    if (string.IsNullOrWhiteSpace(column)) column = column.Trim();
                    parameterList.Add(column);
                    column = null;
                }
            }

            return parameterList;
        }

        private List<Panel> PamaeterPanel(List<string> parameterList)
        {
            var panelList = new List<Panel>();
            var index = 1;
            //NameConfigure();
            for (var i = 0; i < parameterList.Count; i++)
            {
                var resultType = _objectParameterService.FindParameterType(parameterList[i]);
                var panel = CreateResultPanel();
                var name = "Result" + index;
                var comboBox = CreateComboBox();
                comboBox.Name = parameterList[i] + "Type";
                comboBox.TabIndex = index;
                comboBox.Anchor = AnchorStyles.Right;
                if (resultType != null) comboBox.SelectedItem = resultType;
                index++;

                var panelComboBox = CreateComboBoxPanel();
                panelComboBox.Name = "panelComboBox" + name;
                panelComboBox.TabIndex = index;
                panelComboBox.Anchor = AnchorStyles.Right;
                index++;
                var textBox = CreateTextBox();
                textBox.Name = parameterList[i] + "Value";
                textBox.Text = parameterList[i];
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

        private void BtnParameterFind_Click(object sender, EventArgs e)
        {
            var sqlText = GetSqlText();
            if (sqlText == null) return;

            var straightSqlText = SqlTextFormat(sqlText);

            var parameterList = GetParameterList(straightSqlText);

            var panelList = PamaeterPanel(parameterList);
            var queue = panelList.Count / 3;
            var queueDouble = Convert.ToDouble(panelList.Count) / Convert.ToDouble(3);

            var queueRound = Math.Round(queueDouble);
            var queueMod = panelList.Count % 3;
            var queueSecond = queue;
            var queueThrid = queue;

            if (queue == queueRound && queueDouble != queueRound) queueSecond++;
            if (queueRound > queue) queueSecond--;
            if (queueMod == 2) queueSecond++;
            var count = 0;
            for (var i = panelList.Count; i > 0; i--)
            {
                if (i > panelList.Count - queueThrid)
                    PanelThird.Controls.Add(panelList[i - 1]);
                else if (i > queueSecond)
                    PanelSecond.Controls.Add(panelList[i - 1]);
                else
                    PanelFirst.Controls.Add(panelList[i - 1]);
                count++;
            }

            PanelTop.Height = PanelFirst.Controls.Count * 40 + 70;
        }

        private void BtnParameterAdd_Click(object sender, EventArgs e)
        {
            var configureList = NameConfigure();

            string textBoxKey, comboBoxKey;

            for (var i = 0; i < parameterList.Count; i++)
            {
                textBoxKey = parameterList[i] + "Value";
                comboBoxKey = parameterList[i] + "Type";
                var textbox = Controls.Find(textBoxKey, true);
                var comboBox = Controls.Find(comboBoxKey, true);

                //objectResults.Add();
                var objectParameter = new ObjectParameter()
                {
                    NullableFlag = '1',
                    DataType = comboBox[0].Text,
                    ObjectId = _objectId,
                    ProfileId = _profileId,
                    ParameterId = textbox[0].Text,
                    InputOutput = "i"
                };

                _objectParameterService.Add(objectParameter);
            }

            var parameter = _objectParameterService.GetAllByObjectId(_objectId, _profileId);
            DgwObject.DataSource = parameter;
            LblSonuc.Text = "Parameter listesi listelendi";
        }

        public void DatagridLabelSize() //datagridview in boyutunu ayarlar
        {
            var height = 41;
            foreach (DataGridViewRow dr in DgwObject.Rows) height += dr.Height;
            if (height > PanelPresentation.Height - 130)
                DgwObject.Height = PanelPresentation.Height - 130;
            else
                DgwObject.Height = height;
            LblAdet.Top = DgwObject.Bottom + 10;
        }

        private void FormParameterAdd_SizeChanged(object sender, EventArgs e)
        {
            var width = PanelTop.Width / 3;
            PanelFirst.Width = width;
            PanelSecond.Width = width;
            PanelThird.Width = width;
            DatagridLabelSize();
        }
    }
}