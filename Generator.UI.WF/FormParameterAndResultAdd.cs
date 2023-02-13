using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.DataAccess.Concrete;
using Generator.Entities;

namespace Generator.UI.WF
{
    public partial class FormParameterAndResultAdd : Form
    {
        private readonly string _objectId;
        private readonly string _profileId;
        private readonly string _schemaName;
        private readonly IObjectResultService _objecResultService = new ObjectResultService(new EfObjectResultDal());
        private readonly IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());

        private readonly IObjectParameterService _objectParameterService =
            new ObjectParameterService(new EfObjectParameterDal());

        private readonly List<string> results = new List<string>
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
            "bigint",
            "byte",
            "short",
            "tinyint",
            "Int16",
            "BigInt",
            "INT",
            "TIMESTAMP(6)",
            "BIGINT",
            "SMALLINT",
            "DATETIME"
        };

        public FormParameterAndResultAdd()
        {
            _objectId = "create_dis_case";
            _profileId = "CLEARING_BACKOFFICE_V2";
            _schemaName = "DIS";
            InitializeComponent();
        }

        public FormParameterAndResultAdd(string objectId, string profileId, string schemaName)
        {
            _objectId = objectId;
            _profileId = profileId;
            _schemaName = schemaName;
            InitializeComponent();
        }

        private void FormParameterAdd_Load(object sender, EventArgs e)
        {
            var comboBoxParameter = (DataGridViewComboBoxColumn)DgwParameter.Columns[3];
            var comboBoxResult = (DataGridViewComboBoxColumn)DgwResult.Columns[3];
            var parameters = new List<string>
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
                "bigint",
                "byte",
                "short",
                "tinyint",
                "Int16",
                "BigInt",
                "INT",
                "TIMESTAMP(6)",
                "BIGINT",
                "SMALLINT",
                "DATETIME"
            };

            comboBoxParameter.DataSource = parameters;
            comboBoxResult.DataSource = results;
        }

        private string GetOracleText()
        {
            var sqlText = _objectEntityService.GetOracleText(_objectId, _profileId, _schemaName);
            return string.IsNullOrWhiteSpace(sqlText) ? null : sqlText.ToLower();
        }
        private string GetMSSqlText()
        {
            var sqlText = _objectEntityService.GetMSSqlText(_objectId, _profileId, _schemaName);
            return string.IsNullOrWhiteSpace(sqlText) ? null : sqlText.ToLower();
        }
        private string ResultSqlTextFormat(string sqlText)
        {
            sqlText = sqlText.ToLower();
            if (sqlText.Contains("declare"))
            {
                var selectIndex = sqlText.LastIndexOf("select");
                sqlText = sqlText.Substring(selectIndex);
            }
            else
            {
                var unionIndex = sqlText.IndexOf("union");
                if (unionIndex != -1) sqlText = sqlText.Substring(0, unionIndex);

                var selectIndex = sqlText.IndexOf("select");
                sqlText = sqlText.Substring(selectIndex);
                sqlText = sqlText.Substring(6);
            }

            var fromIndex = sqlText.LastIndexOf("from");
            sqlText = sqlText.Substring(0, fromIndex);
            var straightSqlText = "";

            for (var i = 0; i < sqlText.Length; i++)
                if (sqlText[i] != Convert.ToChar("\n") && sqlText[i] != Convert.ToChar("\r") &&
                    sqlText[i] != Convert.ToChar("\t"))
                    straightSqlText += sqlText[i].ToString();
            return straightSqlText.ToUpper();
        }

        private string ParameterSqlTextFormat(string sqlText)
        {
            //var declare = sqlText.ToLower().IndexOf("declare");
            //if (declare != -1)
            //{
            //    var lastSelect = sqlText.LastIndexOf("Select");
            //    sqlText = sqlText.Substring(lastSelect);
            //}
            var straightSqlText = sqlText.Where(t => t != Convert.ToChar("\n") && t != Convert.ToChar("\r"))
                .Aggregate("", (current, t) => current + t);
            return straightSqlText.ToUpper();
        }

        private List<string> GetParameterList(string straightSqlText)
        {
            var parameterList = new List<string>();
            var column = "";
            var sqlText = "";
            for (var i = 0; i < straightSqlText.Length; i++)
                if (straightSqlText[i] == 'A' && straightSqlText[i + 1] == 'N' && straightSqlText[i + 2] == 'D' &&
                    straightSqlText[i - 1] == ' ')
                {
                    sqlText += 'é';
                    i += 2;
                }
                else if (straightSqlText[i] == 'O' && straightSqlText[i + 1] == 'R' && straightSqlText[i - 1] == ' ')
                {
                    sqlText += 'é';
                    i += 2;
                }
                else
                {
                    sqlText += straightSqlText[i];
                }

            for (var i = 0; i < sqlText.Length; i++)
            {
                if (sqlText[i] != Convert.ToChar("é"))
                {
                    if (column == null)
                        if (sqlText[i].ToString() == " ")
                            continue;
                    column += sqlText[i].ToString();
                }

                //if (sqlText[i] == Convert.ToChar("."))
                //    column = "";
                if (string.IsNullOrWhiteSpace(column)) continue;
                if ((sqlText[i] == Convert.ToChar("é") && column.Contains(":")) || i == sqlText.Length - 1 ||
                    (sqlText[i] == Convert.ToChar(" ") && column.Length > 2 && column.Contains(':')))
                {
                    if (column.StartsWith('(')) column = column.Remove(0, 1);
                    if (column.StartsWith(' ')) column = column.Remove(0, 1);
                    if (column.IndexOf(":") != -1)
                    {
                        var elseIndex = column.IndexOf(":");
                        if (column[elseIndex + 1] == '=')
                        {
                            column = "";
                            continue;
                        }

                        if (elseIndex != -1) column = column.Substring(elseIndex);
                        if (column.IndexOf("IS NULL") != -1) column = column.Substring(0, column.IndexOf("IS NULL"));
                        //column = column.Substring(5);
                        column = column.Trim();
                        while (column.EndsWith(')')) column = column.Remove(column.Length - 1, 1);

                        if (column.EndsWith(',')) column = column.Remove(column.Length - 1, 1);

                        if (column.StartsWith(':')) column = column.Remove(0, 1);

                        if (column.Contains(")"))
                        {
                            var index = column.IndexOf(")");
                            column = column.Substring(0, index);
                        }

                        if (column.Contains(";"))
                        {
                            var index = column.IndexOf(";");
                            column = column.Substring(0, index);
                        }

                        if (column.IndexOf("AS") != -1 && column[column.IndexOf("AS") - 1] == ' ')
                        {
                            var asIndex = column.IndexOf("AS");
                            column = column.Substring(0, asIndex);
                        }

                        if (column.Contains(",")) column = column.Substring(0, column.IndexOf(","));
                        column = column.Trim();

                        if (!parameterList.Contains(column)) parameterList.Add(column);
                        column = null;
                    }
                }
            }

            return parameterList;
        }


        private List<ObjectParameter> Parameters(List<string> parameters)
        {
            var list = new List<ObjectParameter>();
            foreach (var item in parameters)
            {
                var parameter = _objectParameterService.FindParameter(item);
                parameter.ProfileId = _profileId;
                parameter.ObjectId = _objectId;
                parameter.ParameterId = item;
                if (parameter.DataType == null)
                {
                    parameter.InputOutput = "i";
                    parameter.NullableFlag = '1';
                    if (parameter.ParameterId.Contains("_FLAG")) parameter.DataType = "char";
                }

                list.Add(parameter);
            }

            return list;
        }

        private void FindParameters()
        {
            var sqlText = GetOracleText();

            if (sqlText==null)
            {
                sqlText = GetMSSqlText();
            }
            if (sqlText == null) return;

            var straightSqlText = ParameterSqlTextFormat(sqlText);

            var parameterList = GetParameterList(straightSqlText);
            var parameters = Parameters(parameterList);
            parameters.ForEach(p =>
            {
                var row = new DataGridViewRow();
                row.CreateCells(DgwParameter);
                row.Cells[0].Value = p.ProfileId;
                row.Cells[1].Value = p.ObjectId;
                row.Cells[2].Value = p.ParameterId;
                if (results.Contains(p.DataType)) row.Cells[3].Value = p.DataType;

                row.Cells[4].Value = p.InputOutput;
                row.Cells[5].Value = p.NullableFlag;
                DgwParameter.Rows.Add(row);
            });
        }


        private void GetParameterList()
        {
            var parameter = _objectParameterService.GetAllObjectParameter(_objectId, _profileId);
            DgwObject.DataSource = parameter;
            LabelParameterResult.Text = $"Count: {DgwObject.Rows.Count}";
        }

        // public void DatagridLabelSize() //datagridview in boyutunu ayarlar
        // {
        //     var height = 41;
        //     foreach (DataGridViewRow dr in DgwObject.Rows) height += dr.Height;
        //     if (height > PanelPresentation.Height - 130)
        //         DgwObject.Height = PanelPresentation.Height - 130;
        //     else
        //         DgwObject.Height = height;
        //     LblAdet.Top = DgwObject.Bottom + 10;
        // }


        private void BtnParameterAdd_Click(object sender, EventArgs e)
        {
            var result = _objectParameterService.GetAllObjectParameter(_objectId, _profileId);
            var count = result.Count;
            if (result.Count > 0)
                foreach (var item in result)
                    _objectParameterService.Delete(item);


            foreach (DataGridViewRow row in DgwParameter.Rows)
                _objectParameterService.Add(new ObjectParameter
                {
                    ProfileId = row.Cells[0].Value.ToString(),
                    ObjectId = row.Cells[1].Value.ToString(),
                    ParameterId = row.Cells[2].Value.ToString(),
                    DataType = row.Cells[3].Value.ToString(),
                    InputOutput = row.Cells[4].Value.ToString(),
                    NullableFlag = (char)row.Cells[5].Value
                });

            GetParameterList();
            LblParameterList.Text = $"Count: {DgwObject.Rows.Count}";
        }

        private void BtnParameterList_Click(object sender, EventArgs e)
        {
            GetParameterList();
        }

        private void BtnParameterFind_Click(object sender, EventArgs e)
        {
            DgwParameter.Rows.Clear();
            FindParameters();
            LblSonuc.Text = $"Count: {DgwParameter.Rows.Count}";
        }

        private List<string> GetResulList(string straightSqlText)
        {
            var resultList = new List<string>();
            var caseIs = false;
            var tables = new List<string>();
            var column = "";
            for (var i = 0; i < straightSqlText.Length; i++)
            {
                if (straightSqlText[i] != Convert.ToChar(".") && straightSqlText[i] != Convert.ToChar(",") &&
                    straightSqlText[i] != '*') column += straightSqlText[i].ToString();

                if (straightSqlText[i] == Convert.ToChar("."))
                    if (caseIs == false)
                    {
                        tables.Add(column);
                        column = "";
                        caseIs = false;
                    }

                if (straightSqlText[i] == Convert.ToChar(",") || i == straightSqlText.Length - 1)
                {
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

                    if (column.IndexOf(" AS ") != -1)
                    {
                        var asIndex = column.IndexOf(" AS ");
                        if (column.LastIndexOf("_") >= asIndex || column[asIndex - 1] == ')')
                        {
                            column = column.Substring(asIndex);
                            column = column.Substring(4);
                        }
                    }

                    if (column.IndexOf("NULL") != -1)
                    {
                        column = column.Substring(column.IndexOf("NULL"));
                        column = column.Substring(5);
                    }

                    if (column.IndexOf(" ") != -1)
                    {
                        column = column.Substring(column.IndexOf(" "));
                    }
                    column = column.Trim();
                    if (!string.IsNullOrWhiteSpace(column)) resultList.Add(column);
                    column = "";
                }
            }

            return resultList;
        }

        private List<ObjectResult> Results(List<string> results)
        {
            var list = new List<ObjectResult>();
            foreach (var item in results)
            {
                var result = _objecResultService.FindResult(item);
                result.ProfileId = _profileId;
                result.ObjectId = _objectId;
                result.ResultId = item;
                if (result.DataType == null)
                {
                    result.NullableFlag = '1';
                    if (result.ResultId.Contains("_FLAG")) result.DataType = "char";
                }

                list.Add(result);
            }

            return list;
        }

        private void FindResults()
        {
            var sqlText = GetOracleText();

            if (sqlText == null)
            {
                sqlText = GetMSSqlText();
            }
            if (sqlText == null) return;
            var straightSqlText = ResultSqlTextFormat(sqlText);
            var resultList = GetResulList(straightSqlText);
            var results = Results(resultList);
            results.ForEach(p =>
            {
                var row = new DataGridViewRow();
                row.CreateCells(DgwResult);
                row.Cells[0].Value = p.ProfileId;
                row.Cells[1].Value = p.ObjectId;
                row.Cells[2].Value = p.ResultId;
                row.Cells[3].Value = p.DataType;
                row.Cells[4].Value = p.NullableFlag;
                DgwResult.Rows.Add(row);
            });
        }

        private void BtnResultFind_Click(object sender, EventArgs e)
        {
            DgwResult.Rows.Clear();
            FindResults();
            LblResultAdd.Text = $"Count: {DgwResult.Rows.Count}";
        }

        private void GetResultList()
        {
            var results = _objecResultService.GetAllByObjectId(_objectId, _profileId);
            DgwResultList.DataSource = results;
            LblResultList.Text = $"Count: {DgwResultList.Rows.Count}";
        }

        private void BtnResultAdd_Click(object sender, EventArgs e)
        {
            var result = _objecResultService.GetAllByObjectId(_objectId, _profileId);
            var count = result.Count;
            if (result.Count > 0)
                foreach (var item in result)
                    _objecResultService.Delete(item);

            foreach (DataGridViewRow row in DgwResult.Rows)
                _objecResultService.Add(new ObjectResult
                {
                    ProfileId = row.Cells[0].Value.ToString(),
                    ObjectId = row.Cells[1].Value.ToString(),
                    ResultId = row.Cells[2].Value.ToString(),
                    DataType = row.Cells[3].Value.ToString(),
                    NullableFlag = (char)row.Cells[4].Value
                });

            GetResultList();
            LblParameterList.Text = $"Count: {DgwResultList.Rows.Count}";
        }

        private void BtnResultList_Click(object sender, EventArgs e)
        {
            GetResultList();
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }
    }
}