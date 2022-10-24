using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.DataAccess.Concrete;
using Generator.Entities;

namespace Generator.UI.WF
{
    public partial class FormResultAdd : Form
    {
        private readonly string _objectId;
        private readonly string _profileId;
        private readonly string _schemaName;
        private readonly IObjectResultService _objecResultService = new ObjectResultService(new EfObjectResultDal());

        private readonly IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());
        private readonly List<string> resultList = new List<string>();

        public FormResultAdd(string objectId, string profileId, string schemaName)
        {
            _objectId = objectId;
            _profileId = profileId;
            _schemaName = schemaName;
            InitializeComponent();
        }

        public FormResultAdd()
        {
            //_objectId = "get_emc_incoming_summary_by_custom_criteria";
            //_profileId = "CLEARING_BACKOFFICE_V2";
            //_schemaName = "EMC";
            //_objectId = "get_emc_outgoing_detail_by_custom_criteria";
            //_profileId = "CLEARING_BACKOFFICE_V2";
            //_schemaName = "EMC";
            _objectId = "get_prm_terminal_sub_device_def";
            _profileId = "MerchantBackoffice";
            _schemaName = "CLR";
            //_objectId = "get_emc_incoming_detail_by_custom_criteria";
            //_profileId = "CLEARING_BACKOFFICE_V2";
            //_schemaName = "EMC";
            InitializeComponent();
        }

        private ComboBox CreateComboBox()
        {
            //Combobox
            var comboBox = new ComboBox();
            comboBox.BackColor = Color.White;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox.ForeColor = Color.FromArgb(35, 128, 109);
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
            panelCombobox.BackColor = Color.FromArgb(35, 128, 109);
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
            textBox.ForeColor = Color.FromArgb(35, 128, 109);
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
            panelTextBox.BackColor = Color.FromArgb(35, 128, 109);
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

        private string ResultSqlTextFormat(string sqlText)
        {
            var unionIndex = sqlText.IndexOf("union");
            if (unionIndex != -1) sqlText = sqlText.Substring(0, unionIndex);


            var selectIndex = sqlText.IndexOf("select");
            sqlText = sqlText.Substring(selectIndex);
            sqlText = sqlText.Substring(6);

            var fromIndex = sqlText.LastIndexOf("from");
            sqlText = sqlText.Substring(0, fromIndex);

            var straightSqlText = "";

            for (var i = 0; i < sqlText.Length; i++)
                if (sqlText[i] != Convert.ToChar("\n") && sqlText[i] != Convert.ToChar("\r"))
                    straightSqlText += sqlText[i].ToString();
            return straightSqlText.ToUpper();
        }

        private List<string> GetResulList(string straightSqlText)
        {
            var resultList = new List<string>();
            var caseIs = false;
            var tables = new List<string>();
            var column = "";
            for (var i = 0;
                 i < straightSqlText.Length;
                 i++)
            {
                if (straightSqlText[i] != Convert.ToChar(".") && straightSqlText[i] != Convert.ToChar(","))
                    column += straightSqlText[i].ToString();

                if (straightSqlText[i] == Convert.ToChar("."))
                    if (caseIs == false)
                    {
                        tables.Add(column);
                        column = "";
                        caseIs = false;
                    }

                if (straightSqlText[i] == Convert.ToChar(",") || i == straightSqlText.Length - 1)
                {
                    if (column == "TRN_PROCESS_TYPE_DESC")
                    {
                    }

                    if (column.IndexOf("CASE") != -1)
                    {
                        caseIs = true;
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
                    else if (!column.StartsWith("AS"))
                    {
                        if (column.IndexOf("AS") != -1 && column[column.IndexOf("AS") - 1] == ' ')
                        {
                            var asIndex = column.IndexOf("AS");
                            if (column.LastIndexOf("_") >= asIndex || column[asIndex - 1] == ')')
                            {
                                column = column.Substring(asIndex);
                                column = column.Substring(3);
                            }
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
            var panelList = new List<Panel>();
            var index = 1;
            //NameConfigure();
            for (var i = 0; i < resultList.Count; i++)
            {
                var resultType = _objecResultService.FindResultType(resultList[i]);
                var panel = CreateResultPanel();
                var name = "Result" + index;
                var comboBox = CreateComboBox();
                comboBox.Name = resultList[i] + "Type";
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

        private void FormResultAdd_Load(object sender, EventArgs e)
        {
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

        private void FormObjectResultAdd_SizeChanged(object sender, EventArgs e)
        {
            var width = PanelTop.Width / 3;
            PanelFirst.Width = width;
            PanelSecond.Width = width;
            PanelThird.Width = width;
            DatagridLabelSize();
        }

        private void BtnResultAdd_Click(object sender, EventArgs e)
        {
            var configureList = resultList.NameConfigure();

            string textBoxKey, comboBoxKey;

            for (var i = 0; i < resultList.Count; i++)
            {
                textBoxKey = resultList[i] + "Value";
                comboBoxKey = resultList[i] + "Type";
                var textbox = Controls.Find(textBoxKey, true);
                var comboBox = Controls.Find(comboBoxKey, true);

                //objectResults.Add();
                var objectResult = new ObjectResult
                {
                    NullableFlag = '1',
                    DataType = comboBox[0].Text,
                    ObjectId = _objectId,
                    ProfileId = _profileId,
                    ResultId = textbox[0].Text
                };

                _objecResultService.Add(objectResult);
                LblSonuc.Text = objectResult.ResultId + " eklendi";
            }

            var result = _objecResultService.GetAllByObjectId(_objectId, _profileId);
            DgwObject.DataSource = result;
            LblSonuc.Text = "Result listesi listelendi";
        }

        private void DgwObject_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridLabelSize();
            LblAdet.Text = "Toplam : " + DgwObject.RowCount;
        }

        private void BtnResultBul_Click(object sender, EventArgs e)
        {
            var sqlText = GetSqlText();
            if (sqlText == null) return;

            var straightSqlText = ResultSqlTextFormat(sqlText);

            var resultList = GetResulList(straightSqlText);

            var panelList = ResultPanel(resultList);
            var queue = panelList.Count / 3;
            var queueDouble = Convert.ToDouble(panelList.Count) / Convert.ToDouble(3);

            var queueRound = Math.Round(queueDouble);
            var queueMod = panelList.Count % 3;
            var queueSecond = queue;
            var queueThrid = queue;
            if (queue == queueRound && queueDouble != queueRound) queueSecond++;
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

            PanelTop.Height = PanelFirst.Controls.Count * 40 + 50;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void PanelTop_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label25_Click(object sender, EventArgs e)
        {
        }
    }
}