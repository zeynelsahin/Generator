using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.DataAccess.Concrete;
using Generator.Entities;
using Generator.UI.WF.Elements;
using Generator.UI.WF.Enums;
using Generator.UI.WF.JavaScriptGenerate;
using Generator.UI.WF.Models;
using Button = Generator.UI.WF.Elements.Button;
using Column = Generator.UI.WF.Elements.Column;
using Parameter = Generator.UI.WF.Elements.Parameter;

namespace Generator.UI.WF
{
    public partial class FormUxGenerator : Form
    {
        public FormUxGenerator()
        {
            InitializeComponent();
        }

        // private async Task Deneme()
        // {
        //     var httpClient = new HttpClient();
        //     var response = await httpClient.GetAsync("https://localhost:5001/backoffice/api/getCurrencyDef");
        //     var deneme = response.EnsureSuccessStatusCode();
        //     var responseBody = response.Content.ReadAsStringAsync();
        // }

        private readonly IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());
        private readonly IObjectResultService _objectResultService = new ObjectResultService(new EfObjectResultDal());
        private readonly IServiceMethodService _serviceMethodService = new ServiceMethodService(new EfServiceMethodDal());
        private readonly IObjectParameterService _objectParameterService = new ObjectParameterService(new EfObjectParameterDal());

        private void FormUxGenerator_Load(object sender, EventArgs e)
        {
            CreateDefaultHeader();
            LoadMethodTypes();
            LoadDirectoryPaths();
            Deneme();
        }

        private void LoadMethodTypes()
        {
            var comboBoxServiceType = (DataGridViewComboBoxColumn)DgwComboBoxes.Columns[6];
            var methodTypes = File.ReadAllText(@"../../../JsonFiles/MethodTypes.json");
            var methodTypeList = JsonSerializer.Deserialize<List<string>>(methodTypes);
            comboBoxServiceType.DataSource = methodTypeList;
        }

        private void LoadProfiles(int rowIndex)
        {
            var comboBoxProfileType = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells[5];
            var profiles = File.ReadAllText(@"../../../JsonFiles/ObjectProfiles.json");
            var profileList = JsonSerializer.Deserialize<List<string>>(profiles);
            comboBoxProfileType.DataSource = profileList;
        }

        private void LoadDirectoryPaths()
        {
            var jsonString = File.ReadAllText(@"../../../JsonFiles/DirectoryPath.json");
            var list = JsonSerializer.Deserialize<List<DirectoryPath>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            CbxApplication.DataSource = list;
            CbxApplication.DisplayMember = "Application";
            CbxApplication.ValueMember = "Path";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("Add", "Add", "Add", "Success", "right", "add");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("Update", "Update", "Update", "Warning", "right", "edit");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("Save", "Save", "Save", "Success", "right", "save");
        }

        private void BtnUpdateQuestion_Click(object sender, EventArgs e)
        {
            //DgwHeader.Rows.Add("Add","Add","Add","Success","right","add");
        }

        private void BtnShowDetail_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("ShowDetail", "Show Detail", "ShowDetail", "", "right", "");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("Delete", "Delete", "Delete", "Danger", "right", "delete");
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("Clear", "Clear", "Clear", "Danger", "right", "clear");
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("List", "List", "List", "Success", "right", "list");
        }

        private void CreateDefaultHeader()
        {
            DgwHeader.Rows.Add("Clear", "Clear", "Clear", "Danger", "right", "clear");
            DgwHeader.Rows.Add("Update", "Update", "Update", "Warning", "right", "edit");
            DgwHeader.Rows.Add("Add", "Add", "Add", "Success", "right", "add");
            DgwHeader.Rows.Add("List", "List", "List", "Success", "right", "list");
        }

        private PageHeader CreatePageHeader()
        {
            var pageHeader = new PageHeader()
            { Title = TbxTitle.Text };


            foreach (DataGridViewRow item in DgwHeader.Rows)
                if (item.Index != DgwHeader.Rows.Count - 1)
                {
                    pageHeader.Buttons.Add(new Button
                    {
                        Id = item.Cells[0].Value.ToString(),
                        Text = item.Cells[1].Value.ToString(),
                        ActionCode = item.Cells[2].Value.ToString(),
                        TypeCss = item.Cells[3].Value.ToString(),
                        Alignment = item.Cells[4].Value.ToString(),
                        IconCss = item.Cells[5].Value.ToString()
                    });
                }

            return pageHeader;
        }

        private void BtnHeaderCreate_Click(object sender, EventArgs e)
        {
            RtbxPrensentation.Text = CreatePageHeader().ToString();
        }


        private void CbxProfileId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxProfileId.SelectedIndex != 0)
            {
                CbxObjectId.DataSource = GetObjectIdList(CbxProfileId.SelectedItem.ToString());
            }
            else if (CbxProfileId.SelectedIndex == 0)
            {
                CbxObjectId.DataSource = null;
                DgwObject.DataSource = null;
            }

            CbxObjectId.Focus();
        }

        private List<string> GetObjectIdList(string profileId)
        {
            var objects = new List<string>() { "Hiçbiri" };
            objects.AddRange(_objectEntityService.GetAllByProfileId(profileId.ToString()));
            return objects;
        }

        private void CbxObjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxObjectId.SelectedIndex != 0)
            {
                CbxCrudMethod.DataSource = null;
                GetColumnNameList();
                TbxGridName.Text = CbxObjectId.SelectedItem.ToString().NameConfigure();
                var getIndex = TbxGridName.Text.IndexOf("Get");
                if (getIndex != -1)
                {
                    TbxGridName.Text = TbxGridName.Text.Substring(3);
                }

                var tableService = new List<string>() { "Tümü" };
                var serviceMethods = _serviceMethodService.GetByObjectId(CbxObjectId.SelectedItem.ToString(), CbxProfileId.SelectedItem.ToString());
                if (serviceMethods.CustomMethodFlag == '0')
                {
                    if (serviceMethods.GetMethodFlag == '1') tableService.Add("Get");

                    //if (serviceMethods.DeleteMethodFlag == '1') tableService.Add("Delete");

                    if (serviceMethods.CreateMethodFlag == '1') tableService.Add("Create");

                    if (serviceMethods.ModifyMethodFlag == '1') tableService.Add("Modify");
                }


                CbxCrudMethod.DataSource = tableService;
            }
        }

        private List<OracleColumn> ResultList(string objectId, string profileId, string objectType)
        {
            var columnNames = new List<OracleColumn>();


            switch (objectType)
            {
                case "TABLE":
                    columnNames = _objectEntityService.GetOracleColumns(objectId);
                    break;
                case "CUSTOMSQL":
                    {
                        columnNames = _objectResultService.GetAll(objectId, profileId);
                        break;
                    }
            }

            return columnNames;
        }

        private void GetParameterList()
        {
            if (CbxObject.SelectedItem != null && CbxObject.SelectedIndex != 0)
            {
                var objectType = _objectEntityService.GetObjectType(CbxObject.SelectedItem.ToString(), CbxProfile.SelectedItem.ToString());
                CbxObjectType.SelectedItem = objectType;
                DgwContent.Rows.Clear();
                var columnNames = ResultList(CbxObject.SelectedItem.ToString(), CbxProfile.SelectedItem.ToString(), CbxObjectType.SelectedItem.ToString());
                columnNames.ForEach(column =>
                {
                    var dataType = "";
                    var columnName = column.Name.NameConfigure();
                    if (columnName.Contains("ValidFlag"))
                        dataType = BasicElementType.CheckBox.ToString();
                    else if (column.DataType.ToLower() == "date" || column.DataType.ToLower() == "datetime" || column.DataType.ToLower().Contains("timestamp"))
                        dataType = BasicElementType.DataEntry.ToString();
                    else
                        dataType = BasicElementType.TextBox.ToString();

                    DgwContent.Rows.Add(column.Name.NameConfigure(), column.Name.TextConfigure(), dataType);
                });
            }
            else
            {
                CbxLinkButton.DataSource = null;
                CbxStatusColor.DataSource = null;
                ClbColumnNames.Items.Clear();
                DgwObject.DataSource = null;
            }
        }

        private void GetColumnNameList()
        {
            if (CbxObjectId.SelectedItem != null && CbxObjectId.SelectedIndex != 0)
            {
                if (GetObjectType()) return;

                ClbColumnNames.Items.Clear();
                var columnNames = new List<string>();
                //columnNames.Add("Hiçbiri");
                if (CbxObjectType.SelectedItem.ToString() == "TABLE")
                {
                    columnNames.AddRange(_objectEntityService.GetColumnsName(CbxObjectId.SelectedItem.ToString()));
                    columnNames = columnNames.NameConfigure();
                    columnNames.ForEach(p =>
                    {
                        if (p == "Hiçbiri") return;
                        ClbColumnNames.Items.Add(p, true);
                    });
                    CbxLinkButton.DataSource = columnNames;
                    var columnNamesCopy = new List<string>();
                    columnNames.ForEach(s => columnNamesCopy.Add(s));
                    CbxStatusColor.DataSource = columnNamesCopy;
                    if (columnNamesCopy.Contains("VALID_FLAG"))
                    {
                        CbxStatusColor.SelectedValue = "VALID_FLAG";
                    }
                }
                else if (CbxObjectType.SelectedItem.ToString() == "CUSTOMSQL")
                {
                    var result = _objectResultService.GetAllByObjectId(CbxObjectId.SelectedItem.ToString(), CbxProfileId.SelectedItem.ToString());
                    result.ForEach(result => columnNames.Add(result.ResultId));
                    columnNames = columnNames.NameConfigure();
                    //var parameters = _objectParameterService.GetAllByObjectId(CbxObjectId.SelectedItem.ToString(), CbxProfileId.SelectedItem.ToString());
                    var columnNamesCopy = new List<string>();
                    columnNames.ForEach(s => columnNamesCopy.Add(s));
                    columnNames.ForEach(p =>
                    {
                        if (p == "Hiçbiri") return;
                        ClbColumnNames.Items.Add(p, true);
                    });
                    //if (parameters != null)
                    //{
                    //    for (var i = 0; i < ClbColumnNames.Items.Count; i++)
                    //    {
                    //        for (var j = 0; j < parameters.Count; j++)
                    //        {
                    //            var name = ClbColumnNames.Items[i];
                    //            if (name.ToString() == parameters[j].NameConfigure())
                    //            {
                    //                ClbColumnNames.SetItemCheckState(i, CheckState.Checked);
                    //            }
                    //        }
                    //    }
                    //}

                    CbxLinkButton.DataSource = columnNames;
                    columnNames.ForEach(s => columnNamesCopy.Add(s));
                    CbxStatusColor.DataSource = columnNamesCopy;
                }
            }
            else
            {
                CbxLinkButton.DataSource = null;
                CbxStatusColor.DataSource = null;
                ClbColumnNames.Items.Clear();
                DgwObject.DataSource = null;
            }
        }

        private string GetObjectType(string objectId, string profileId)
        {
            var objectType = _objectEntityService.GetObjectType(objectId, profileId);
            return objectType;
        }


        private bool GetObjectType()
        {
            if (string.IsNullOrWhiteSpace(CbxObjectId.Text)) return true;

            var objects = _objectEntityService.GetAllOrFilter(CbxObjectId.SelectedItem.ToString(), CbxProfileId.SelectedItem.ToString());
            DgwObject.DataSource = objects;
            CbxObjectType.SelectedItem = DgwObject.CurrentRow!.Cells[4].Value.ToString();
            //
            return false;
        }

        private void DgwObject_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DgwObject.RowCount != 0)
                PanelDgw.Height = 60;
            else
                PanelDgw.Height = 0;
        }

        private void CrudJavaScript()
        {
            var objectId = CbxObjectId.SelectedItem.ToString().NameConfigure();
            var method = new GetGridApiMethod();
            var crudType = CbxCrudMethod.SelectedItem.ToString();
            if (crudType == "Tümü")
            {
                foreach (var item in CbxCrudMethod.Items)
                {
                    switch (item)
                    {
                        case "Create":
                            method.MethodName = $"Create{objectId}";
                            break;
                        case "Update":
                            method.MethodName = $"Update{objectId}";
                            break;
                            //case "Delete":
                            //    method.MethodName = $"Delete{objectId}";
                            //    break;
                    }

                    method.ServiceName = $"get{objectId}";
                    method.ServiceName = $"get{objectId}";
                    method.PropName = TbxGridName.Text + "Grid";
                }
            }
        }

        private GridJavaScriptMethod GridJavaScript()
        {
            GridJavaScriptMethod gridJavaScriptMethod = new GridJavaScriptMethod();
            var objectId = CbxObjectId.SelectedItem.ToString().NameConfigure();
            if (CbxObjectType.SelectedItem.ToString() == "TABLE")
            {
                if (CbxCrudMethod.SelectedItem.ToString() == "Tümü")
                {
                    foreach (var item in CbxCrudMethod.Items)
                    {
                        if (item.ToString() == "Get")
                        {
                            var get = new GetGridApiMethod
                            {
                                MethodName = "Fill" + TbxGridName.Text + "List",
                                ServiceName = $"get{objectId}",
                                PropName = TbxGridName.Text + "Grid",
                                ParameterName = TbxGridName.Text + "Request",
                                ResultName = TbxGridName.Text + "Result"
                            };
                            gridJavaScriptMethod.GetGridApiMethod = get;
                        }
                        else if (item.ToString() == "Create")
                        {
                            var create = new CreateApiMethod
                            {
                                MethodName = "Create" + TbxGridName.Text,
                                ServiceName = $"create{objectId}",
                                ParameterName = TbxGridName.Text.UnifiedCaseConfigure()
                            };
                            GridJavaScriptParams(create);
                            gridJavaScriptMethod.CreateApiMethod = create;
                        }
                        else if (item.ToString() == "Modify")
                        {
                            var modify = new UpdateApiMethod
                            {
                                MethodName = "Update" + TbxGridName.Text,
                                ServiceName = $"modify{objectId}",
                                ParameterName = TbxGridName.Text.UnifiedCaseConfigure()
                            };
                            GridJavaScriptParams(modify);
                            gridJavaScriptMethod.UpdateApiMethod = modify;
                        }
                        else if (item.ToString() == "Delete")
                        {
                            MessageBox.Show("Delete Metodu Boş");
                        }
                    }
                }
                else
                {
                    if (CbxCrudMethod.SelectedItem.ToString() == "Create")
                    {
                        var create = new CreateApiMethod
                        {
                            MethodName = "Create" + TbxGridName.Text,
                            ServiceName = $"create{objectId}",
                            ParameterName = TbxGridName.Text.UnifiedCaseConfigure()
                        };
                        GridJavaScriptParams(create);
                        gridJavaScriptMethod.CreateApiMethod = create;
                    }
                    else if (CbxCrudMethod.SelectedItem.ToString() == "Modify")
                    {
                        var modify = new UpdateApiMethod
                        {
                            MethodName = "Update" + TbxGridName.Text,
                            ServiceName = $"modify{objectId}",
                            ParameterName = TbxGridName.Text.UnifiedCaseConfigure()
                        };
                        GridJavaScriptParams(modify);
                        gridJavaScriptMethod.UpdateApiMethod = modify;
                    }
                }
            }
            else if (CbxObjectType.SelectedItem.ToString() == "CUSTOMSQL")
            {
                var get = new GetGridApiMethod
                {
                    MethodName = "Fill" + TbxGridName.Text + "List"
                };
                if (objectId[0].ToString() == "G" && objectId[1].ToString() == "e" && objectId[2].ToString() == "t")
                {
                    get.ServiceName = objectId;
                    get.ParameterName = TbxGridName.Text + "Param";
                }
                else
                {
                    get.ServiceName = $"get{objectId}";
                    get.ParameterName = "Get" + TbxGridName.Text + "Param";
                }

                get.PropName = TbxGridName.Text + "Grid";
                get.ResultName = TbxGridName.Text + "Result";
                GridJavaScriptParams(get);
                gridJavaScriptMethod.GetGridApiMethod = get;
            }

            return gridJavaScriptMethod;
        }

        private void GridJavaScriptParams(ApiRequestMethod method)
        {
            foreach (var param in ClbColumnNames.CheckedItems)
                method.Parameter.Params.Add(new Param() { Key = param.ToString(), Value = param.ToString() });
        }

        private void JavaScriptParams(ApiRequestMethod method, IList paramList)
        {
            foreach (var param in paramList)
                method.Parameter.Params.Add(new Param() { Key = param.ToString(), Value = param.ToString() });
        }

        private GetComboBoxApiMethod CreateComboBoxJavaScript(string objectId, string objectType, string propName)
        {
            objectId = objectId.NameConfigure();
            var method = new GetComboBoxApiMethod();
            if (objectType == "TABLE")
            {
                method.ServiceName = $"get{objectId}";
                method.ResultName = objectId + "List";
                //method.Parameter.Params.Add(new Param() { Key = "ValidFlag", Value = "ValidFlag" });
            }
            else if (objectType == "CUSTOMSQL")
            {
                method.ServiceName = $"{objectId.CamelCaseConfigure()}";
                method.ResultName = objectId + "Result";
                var parameters = _objectParameterService.GetAllByObjectId(CbxContentJSObjectId.SelectedItem.ToString(), CbxContentJSProfileId.SelectedItem.ToString());
                parameters = parameters.NameConfigure();
                JavaScriptParams(method, parameters);
            }

            method.MethodName = "Fill" + objectId;
            method.PropName = propName;

            return method;
        }
        //Object dönülüp liste veya class olarak dönüş yapılabilir farklı metodlarda yazılabilir.

        private List<ApiRequestMethod> ComboBoxJavaScript()
        {
            List<ApiRequestMethod> getComboBoxApiMethods = new List<ApiRequestMethod>();
            for (int i = 0; i < DgwComboBoxes.Rows.Count - 1; i++)
            {
                var method = new GetComboBoxApiMethod();

                var row = DgwComboBoxes.Rows[i];
                var id = row.Cells[0].Value;
                var keyField = row.Cells[2].Value;
                var valueField = row.Cells[3].Value;
                var objectId = row.Cells[4].Value.ToString().NameConfigure().RemoveGet();
                var objectType = _objectEntityService.GetObjectType(row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());
                if (objectType == "TABLE")
                {
                    method.ServiceName = $"get{objectId}";
                    method.ResultName = objectId + "List";
                }
                else if (objectType == "CUSTOMSQL")
                {
                    method.ServiceName = $"{row.Cells[4].Value.ToString().CamelCaseConfigure()}";
                    var parameters = _objectParameterService.GetAllByObjectId(objectId, row.Cells[5].Value.ToString());
                    if (parameters != null)
                    {
                        JavaScriptParams(method, parameters);
                    }

                    method.ResultName = objectId + "Result";
                }

                method.MethodName = "Fill" + objectId;
                method.PropName = id.ToString();
                getComboBoxApiMethods.Add(method);
            }

            return getComboBoxApiMethods;
        }

        private List<ApiRequestMethod> UserControlJavaScript()
        {
            List<ApiRequestMethod> getComboBoxApiMethods = new List<ApiRequestMethod>();
            for (int i = 0; i < DgwComboBoxes.Rows.Count - 1; i++)
            {
                var method = new GetComboBoxApiMethod();

                var row = DgwComboBoxes.Rows[i];
                var id = row.Cells[0].Value;
                var keyField = row.Cells[2].Value;
                var valueField = row.Cells[3].Value;
                var objectId = row.Cells[4].Value.ToString().NameConfigure().RemoveGet();
                var objectType = _objectEntityService.GetObjectType(row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());
                if (objectType == "TABLE")
                {
                    method.ServiceName = $"get{objectId}";
                    method.ResultName = objectId + "List";
                }
                else if (objectType == "CUSTOMSQL")
                {
                    method.ServiceName = $"{row.Cells[4].Value.ToString().CamelCaseConfigure()}";
                    var parameters = _objectParameterService.GetAllByObjectId(objectId, row.Cells[5].Value.ToString());
                    if (parameters != null)
                    {
                        JavaScriptParams(method, parameters);
                    }

                    method.ResultName = objectId + "Result";
                }

                method.MethodName = "Fill" + objectId;
                method.PropName = id.ToString();
                getComboBoxApiMethods.Add(method);
            }

            return getComboBoxApiMethods;
        }

        private GridView CreateGridView()
        {
            var dateList = new List<string>();
            var otherList = new List<string>();
            var rowTemplate = new RowTemplate();
            foreach (var item in ClbColumnNames.CheckedItems)
            {
                var column = new Column()
                { Id = item.ToString(), Text = item.ToString(), FieldId = item.ToString() };
                column.Witdh = item.ToString()!.Length > 18 ? "150" : "100";
                column.LinkButton = CbxLinkButton.SelectedItem.ToString() == item.ToString() ? new LinkButton() { ActionCode = CbxActionCode.Text.ToString() } : null;

                rowTemplate.Columns.Add(column);
                if (item.ToString()!.Contains("Date"))
                    dateList.Add(item.ToString());
                else
                    otherList.Add(item.ToString());
            }

            var model = new Model() { };
            dateList.ForEach(s => model.Fields.Add(new Field() { Id = s.ToString(), DataSource = s.ToString(), Type = Types.Date }));
            otherList.ForEach(s => model.Fields.Add(new Field() { Id = s.ToString(), DataSource = s.ToString() }));

            var commandBar = new CommandBar()
            {
                ShowSearchBox = "true",
                ExcelExport = "true"
            };


            var gridView = new GridView()
            {
                Id = TbxGridName.Text + "Grid",
                Text = TbxGridName.Text + "Grid",
                Height = TbxHeight.Text,
                ShowStatus = "true",
                CommandBar = commandBar,
                RowTemplate = rowTemplate,
                Model = model
            };
            if (CbxStatusColor.SelectedItem != null)
            {
                gridView.StatusColorFieldId = CbxStatusColor.SelectedItem.ToString();
            }

            return gridView;
        }

        private void BtnGridCreate_Click(object sender, EventArgs e)
        {
            RtbxGrid.Text = "";
            RtbxGrid.Text += CreateGridView().ToString();
        }

        private void BtnCheckAll_Click(object sender, EventArgs e)
        {
            if (ClbColumnNames.Items.Count > 0)
                for (var i = 0; i < ClbColumnNames.Items.Count; i++)
                    ClbColumnNames.SetItemChecked(i, true);
        }

        private void BtnRemoveCheck_Click(object sender, EventArgs e)
        {
            var count = ClbColumnNames.Items.Count - 1;
            if (count > 0)
                for (var i = count; i >= 0; i--)
                    if (ClbColumnNames.GetItemCheckState(i) == CheckState.Checked)
                        ClbColumnNames.Items.RemoveAt(i);
        }

        private void BtnClearAllCheck_Click(object sender, EventArgs e)
        {
            if (ClbColumnNames.CheckedItems.Count > 0)
                for (var i = 0; i < ClbColumnNames.Items.Count; i++)
                    ClbColumnNames.SetItemChecked(i, false);
        }

        private void BtnJavaScriptCreate_Click(object sender, EventArgs e)
        {
            RtbxGrid.Text = null;
            RtbxGrid.Text = GridJavaScript().ToString();
        }

        private void CbxObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElementsAddView(false);
            DgwContent.Rows.Clear();
            DgwView.Rows.Clear();
            DgwComboBoxes.Rows.Clear();
            if (CbxObject.SelectedIndex != 0)
            {
                GetParameterList();
                var tableService = new List<string>();
                var serviceMethods = _serviceMethodService.GetByObjectId(CbxObject.SelectedItem.ToString(), CbxProfile.SelectedItem.ToString());
                //if (serviceMethods.CustomMethodFlag == '0')
                //{
                //    if (serviceMethods.GetMethodFlag == '1') tableService.Add("Get Method");

                //    // if (serviceMethods.GetValidMethodFlag == '1')
                //    // {
                //    //     tableService.Add("Get Valid Method");
                //    // }

                //    // if (serviceMethods.DeleteMethodFlag == '1')
                //    // {
                //    //     tableService.Add("Delete Method");
                //    // }

                //    if (serviceMethods.CreateMethodFlag == '1') tableService.Add("Create Method");

                //    if (serviceMethods.ModifyMethodFlag == '1') tableService.Add("Modify Method");
                //}

                CbxCrudMethod.DataSource = tableService;
            }
        }

        private void ElementsAddView(bool status)
        {
            if (DgwContent.Rows.Count > 1)
            {
                isBasicElementAddView = status;
            }

            if (DgwUserControl.Rows.Count > 1)
            {
                isUserControlAddView = status;
            }

            if (DgwComboBoxes.Rows.Count > 1)
            {
                isComboBoxAddView = status;
            }
        }

        private void CbxProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var elementNames = new List<string>() { "TextBox", "DataEntry", "CheckBox", "NumberEntry", "MoneyEntry", "UserControl" };
            var elementNamesView = new List<string>() { "TextBox", "DataEntry", "CheckBox", "ComboBox", "NumberEntry", "MoneyEntry", "UserControl" };
            if (CbxProfile.SelectedIndex != 0)
            {
                var objectList = GetObjectIdList(CbxProfile.SelectedItem.ToString());
                CbxObject.DataSource = objectList;

                var comboBox = (DataGridViewComboBoxColumn)DgwContent.Columns["ElementType"];
                comboBox.DataSource = elementNames;

                var comboBoxView = (DataGridViewComboBoxColumn)DgwView.Columns["ElementTypeView"];
                comboBoxView.DataSource = elementNamesView;
            }
            else if (CbxProfile.SelectedIndex == 0)
            {
                CbxObject.DataSource = null;
            }

            CbxObject.Focus();
        }


        private void BtnUp_Click(object sender, EventArgs e)
        {
            DataGridViewUp(DgwView);
        }

        private void DataGridViewUp(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count < 2) return;
            var totalRows = dataGridView.Rows.Count;
            var rowIndex = dataGridView.SelectedCells[0].OwningRow.Index;
            if (rowIndex == 0)
                return;
            var colIndex = dataGridView.SelectedCells[0].OwningColumn.Index;
            var selectedRow = dataGridView.Rows[rowIndex];
            dataGridView.Rows.Remove(selectedRow);
            dataGridView.Rows.Insert(rowIndex - 1, selectedRow);
            dataGridView.ClearSelection();
            dataGridView.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            DataGridViewDown(DgwView);
        }

        private void DataGridViewDown(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count < 2) return;
            var totalRows = dataGridView.Rows.Count - 1;
            var rowIndex = dataGridView.SelectedCells[0].OwningRow.Index;
            if (rowIndex == totalRows - 1)
                return;
            var colIndex = dataGridView.SelectedCells[0].OwningColumn.Index;
            var selectedRow = dataGridView.Rows[rowIndex];
            dataGridView.Rows.Remove(selectedRow);
            dataGridView.Rows.Insert(rowIndex + 1, selectedRow);
            dataGridView.ClearSelection();
            dataGridView.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
        }

        private void DgwContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
            {
                foreach (DataGridViewRow item in DgwContent.SelectedRows)
                    if (item.Index != DgwContent.Rows.Count - 1)
                    {
                        var row = new DataGridViewRow();

                        row.CreateCells(DgwComboBoxes);
                        row.Cells[0].Value = item.Cells[0].Value;
                        row.Cells[1].Value = item.Cells[1].Value;
                        row.Cells[6].Value = "Service Method";
                        DgwComboBoxes.Rows.Add(row);
                        DgwContent.Rows.Remove(item);
                    }
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.X)
            {
                foreach (DataGridViewRow item in DgwContent.SelectedRows)
                    if (item.Index != DgwContent.Rows.Count - 1)
                    {
                        var row = new DataGridViewRow();
                        row.CreateCells(DgwUserControl);
                        row.Cells[0].Value = item.Cells[0].Value;
                        row.Cells[3].Value = item.Cells[1].Value;
                        DgwUserControl.Rows.Add(row);
                        DgwContent.Rows.Remove(item);
                    }
            }
        }

        private void TabElement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
                DataGridViewUp(DgwView);
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.X) DataGridViewDown(DgwView);
        }

        private void BasicElementFill()
        {
            if (DgwContent.Rows.Count - 1 == 0) return;
            for (var i = 0; i < DgwContent.Rows.Count - 1; i++)
            {
                var item = DgwContent.Rows[i];
                var element = item.Cells[2].Value;
                var id = item.Cells[0].Value;
                var text = item.Cells[1].Value;
                DgwView.Rows.Add(id, text, element, "3");
            }
        }

        private void ComboBoxElementFill()
        {
            if (DgwComboBoxes.Rows.Count - 1 == 0) return;
            for (var i = 0; i < DgwComboBoxes.Rows.Count - 1; i++)
            {
                var item = DgwComboBoxes.Rows[i];
                var id = item.Cells[0].Value;
                var text = item.Cells[1].Value;
                DgwView.Rows.Add(id, text, "ComboBox", "3");
            }
        }

        private void UserControlFill()
        {
            if (DgwUserControl.Rows.Count - 1 == 0) return;
            for (var i = 0; i < DgwUserControl.Rows.Count - 1; i++)
            {
                var item = DgwUserControl.Rows[i];
                var id = item.Cells[0].Value;
                var text = item.Cells[3].Value;
                DgwView.Rows.Add(id, text, "UserControl", "3");
            }
        }

        private void BtnContentJavaScript_Click(object sender, EventArgs e)
        {
            ResultText.Text = null;
            foreach (var item in ComboBoxJavaScript())
            {
                ResultText.Text += item.ToString();
            }
        }

        private void NullExceptionMessage(string nullCells, bool multiple)
        {
            var message = nullCells;

            if (multiple)
            {
                message += " alanları boş geçilmemeli";
            }
            else
            {
                message += " alanı boş geçilmemeli";
            }

            MessageBox.Show(message);
        }

        private bool CheckCell(DataGridView gridView, params DataGridViewCell[] dataGridViewCell)
        {
            int counter = 0;
            bool check = true;
            string nullCells = "";
            foreach (var cell in dataGridViewCell)
            {
                if (cell.Value == null)
                {
                    counter++;
                    var column = cell.ColumnIndex;
                    nullCells += gridView.Columns[column].Name + " ";

                    check = false;
                }
            }

            bool isMultiple = counter > 1;

            if (!check)
            {
                NullExceptionMessage(nullCells, isMultiple);
            }

            return check;
        }

        private ComboBoxElement GetComboBoxElement(string id)
        {
            for (var i = 0; i < DgwComboBoxes.Rows.Count - 1; i++)
            {
                var comboBox = new ComboBoxElement();
                var row = DgwComboBoxes.Rows[i];
                if (id == row.Cells[0].Value.ToString())
                {
                    comboBox.Id = id;
                    var check = CheckCell(DgwComboBoxes, row.Cells[1], row.Cells[2], row.Cells[3]);
                    if (!check) return new ComboBoxElement();
                    comboBox.Text = row.Cells[1].Value.ToString();
                    comboBox.KeyField = row.Cells[2].Value.ToString();
                    comboBox.ValueField = row.Cells[3].Value.ToString();
                }

                return comboBox;
            }

            return new ComboBoxElement();
        }

        private UserControlElement GetUserControl(string id)
        {
            for (var i = 0; i < DgwUserControl.Rows.Count - 1; i++)
            {
                var userControl = new UserControlElement();
                var row = DgwUserControl.Rows[i];
                if (id == row.Cells[0].Value.ToString())
                {
                    userControl.Id = id;
                    var check = CheckCell(DgwUserControl, row.Cells[2], row.Cells[3], row.Cells[4]);
                    if (!check) return new UserControlElement();
                    userControl.Text = row.Cells[1].Value.ToString();
                    userControl.Id = id;
                    userControl.ControlId = row.Cells[1].Value.ToString();
                    var getActionCode = new Parameter
                    {
                        Key = "GetActionCode",
                        Text = row.Cells[2].Value.ToString()
                    };
                    var label = new Parameter
                    {
                        Key = "Label",
                        Text = row.Cells[3].Value.ToString()
                    };
                    var searchPage = new Parameter
                    {
                        Key = "SearchPage",
                        Text = row.Cells[4].Value.ToString()
                    };
                    userControl.Parameters.Add(getActionCode);
                    userControl.Parameters.Add(label);
                    userControl.Parameters.Add(searchPage);
                    return userControl;
                }
            }

            return new UserControlElement();
        }

        private ContentBlock CreateContent()
        {
            // string[] row = new string[] { "1", "Product 1", BasicElementType.CheckBox.ToString() };
            // DgwContent.Rows.Add(row);
            var row = new Row();
            var size = 0;

            var contentBlock = new ContentBlock();
            for (var i = 0; i < DgwView.Rows.Count - 1; i++)
            {
                IElement element = null;
                var viewRow = DgwView.Rows[i];
                var id = viewRow.Cells[0].Value.ToString();
                var text = viewRow.Cells[1].Value.ToString();
                var colSize = viewRow.Cells[3].Value.ToString();
                if (size < 12)
                {
                    switch (viewRow.Cells[2].Value)
                    {
                        case "TextBox":
                            element = new TextBoxElement()
                            {
                                Id = id,
                                Text = text
                            };
                            break;
                        case "DataEntry":
                            element = new DataEntry()
                            {
                                Id = id,
                                Text = text
                            };
                            break;

                        case "CheckBox":
                            element = new CheckBoxElement()
                            {
                                Checked = "true",
                                Id = id,
                                Text = text
                            };
                            break;
                        case "NumberEntry":
                            element = new NumberEntry()
                            {
                                NoFormat = "true",
                                MaxLenght = "10",
                                Text = text,
                                Id = id
                            };
                            break;
                        case "MoneyEntry":
                            element = new MoneyEntry()
                            {
                                Text = text,
                                Id = id
                            };
                            break;
                        case "ComboBox":
                            element = GetComboBoxElement(id);
                            break;
                        case "UserControl":
                            element = GetUserControl(id);
                            break;
                    }

                    var col = new Col()
                    {
                        Size = colSize,
                        Element = element
                    };
                    row.Elements.Add(col);

                    size += Convert.ToInt32(viewRow.Cells[3].Value);
                }
                else
                {
                    contentBlock.Rows.Add(row);
                    size = 0;
                    element = null;
                    row = new Row();
                }
            }

            contentBlock.Rows.Add(row);
            return contentBlock;
        }

        private void BtnContentCreate_Click(object sender, EventArgs e)
        {
            if (DgwView.RowCount <= 2) return;
            ResultText.Text = CreateContent().ToString();
        }

        private void TabElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabElement.SelectedTab == TabView)
            {
                ViewUserControl();
                ViewComboBox();
                ViewBasicElement();
                ElementsAddView(true);
            }
        }

        private bool isBasicElementAddView = false;
        private bool isComboBoxAddView = false;
        private bool isUserControlAddView = false;

        private void ViewBasicElement()
        {
            var isHere = false;

            if (!isBasicElementAddView)
            {
                BasicElementFill();
            }
            else
            {
                var list = DgwView.DataSource;
                for (var i = 0; i < DgwContent.Rows.Count - 1; i++)
                {
                    var content = DgwContent.Rows[i];
                    for (var j = 0; j < DgwView.Rows.Count - 1; j++)
                    {
                        var view = DgwView.Rows[j];
                        if (content.Cells[0].Value == view.Cells[0].Value)
                        {
                            view.Cells[1].Value = content.Cells[1].Value;
                            view.Cells[2].Value = content.Cells[2].Value;
                            isHere = true;
                        }
                    }

                    if (isHere == false) DgwView.Rows.Add(content.Cells[0].Value, content.Cells[1].Value, content.Cells[2].Value, "3");
                }
            }
        }

        private void ViewComboBox()
        {
            var isHere = false;

            if (!isComboBoxAddView)
                ComboBoxElementFill();
            else
                for (var i = 0; i < DgwComboBoxes.Rows.Count - 1; i++)
                {
                    var comboBox = DgwComboBoxes.Rows[i];
                    for (var j = 0; j < DgwView.Rows.Count - 1; j++)
                    {
                        var view = DgwView.Rows[j];
                        if (comboBox.Cells[0].Value == view.Cells[0].Value)
                        {
                            view.Cells[1].Value = comboBox.Cells[1].Value;
                            isHere = true;
                            return;
                        }
                    }

                    if (isHere == false) DgwView.Rows.Add(comboBox.Cells[0].Value, comboBox.Cells[1].Value, "ComboBox", "3");
                }
        }

        private void ViewUserControl()
        {
            var isHere = false;

            if (!isUserControlAddView)
                UserControlFill();
            else
                for (var i = 0; i < DgwUserControl.Rows.Count - 1; i++)
                {
                    var userControl = DgwUserControl.Rows[i];
                    for (var j = 0; j < DgwView.Rows.Count - 1; j++)
                    {
                        var view = DgwView.Rows[j];
                        if (userControl.Cells[0].Value == view.Cells[0].Value)
                        {
                            view.Cells[1].Value = userControl.Cells[3].Value;
                            isHere = true;
                            return;
                        }
                    }

                    if (isHere == false) DgwView.Rows.Add(userControl.Cells[0].Value, userControl.Cells[1].Value, "UserControl", "6");
                }
        }

        private void DgwContent_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DatagridLabelSize();
            LblContextTotal.Text = $"Toplam : {DgwContent.Rows.Count - 1}";
        }

        private void DgwContent_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            DatagridLabelSize();
            LblContextTotal.Text = $"Toplam : {DgwContent.Rows.Count - 1}";
        }

        private void DgwComboBoxes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LblComboBoxTotal.Text = $"Toplam : {DgwComboBoxes.Rows.Count - 1}";
        }

        private void DgwComboBoxes_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LblComboBoxTotal.Text = $"Toplam : {DgwComboBoxes.Rows.Count - 1}";
        }

        private void DgwView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LblViewTotal.Text = $"Toplam : {DgwView.Rows.Count - 1}";
        }

        private void DgwView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LblViewTotal.Text = $"Toplam : {DgwView.Rows.Count - 1}";
        }

        public void DatagridLabelSize() //datagridview in boyutunu ayarlar
        {
            var height = 41;
            foreach (DataGridViewRow dr in DgwContent.Rows) height += dr.Height;
            if (height > GbxResult.Height - 130)
                DgwContent.Height = GbxResult.Height - 130;
            else
                DgwObject.Height = height;
            LblContextTotal.Top = DgwContent.Bottom + 10;
        }

        private void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabMain.SelectedTab == TabContent)
            {
                CbxProfile.Focus();
            }
            else if (TabMain.SelectedTab == TabGridCreate)
            {
                CbxProfileId.Focus();
            }
        }

        void PageFilesCreate(string path, string fileName, PageXml pageXml, PageJs pageJs)
        {
            string xmlPath = Path.Combine(path, fileName + ".xml");
            string jsPath = Path.Combine(path, fileName + ".xml.js");

            if (File.Exists(xmlPath))
            {
                if (CbxOverrideWriteFile.Checked)
                {
                    File.WriteAllText(xmlPath, pageXml.ToString());
                }
                else
                {
                    File.WriteAllText(Path.Combine(path, fileName + "_Copy.xml"), pageXml.ToString());
                }
            }
            else
            {
                File.WriteAllText(xmlPath, pageXml.ToString());
            }

            if (File.Exists(xmlPath))
            {
                if (CbxOverrideWriteFile.Checked)
                {
                    File.WriteAllText(jsPath, pageJs.ToString());
                }
                else
                {
                    File.WriteAllText(Path.Combine(path, fileName + "_Copy.xml.js"), pageJs.ToString());
                }
            }
            else
            {
                File.WriteAllText(jsPath, pageJs.ToString());
            }
        }

        private PageXml PageXmlCreate()
        {
            if (CbxExportXML.Checked)
            {
                var pageXml = new PageXml
                {
                    Header = CreatePageHeader(),
                    Content = CreateContent(),
                    GridContent = CreateGridView()
                };
                return pageXml;
            }

            return null;
        }

        private PageJs PageJsCreate()
        {
            if (CbxJavaScriptExport.Checked)
            {
                var gridMethod = GridJavaScript();
                var pageJs = new PageJs()
                {
                    ApiRequestMethods = ComboBoxJavaScript(),
                    CreateApiMethod = gridMethod.CreateApiMethod,
                    GetGridApiMethod = gridMethod.GetGridApiMethod,
                    UpdateApiMethod = gridMethod.UpdateApiMethod,
                    PageName = TbxPageName.Text
                };
                return pageJs;
            }

            return null;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var pageXml = PageXmlCreate();
            var pageJs = PageJsCreate();

            PageFilesCreate(TbxPath.Text, TbxPageName.Text, pageXml, pageJs);
        }

        private void CbxContentJSProfileId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxContentJSProfileId.SelectedIndex != 0)
            {
                CbxContentJSObjectId.DataSource = GetObjectIdList(CbxContentJSProfileId.SelectedItem.ToString());
            }
            else if (CbxContentJSProfileId.SelectedIndex == 0)
            {
                CbxContentJSObjectId.DataSource = null;
            }

            CbxContentJSObjectId.Focus();
        }

        private void CbxContentJSObjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxContentJSObjectId.SelectedIndex != 0 && CbxContentJSObjectId.SelectedIndex != -1)
            {
                var objectType = _objectEntityService.GetObjectType(CbxContentJSObjectId.SelectedItem.ToString(), CbxContentJSProfileId.SelectedItem.ToString());
                CbxContentJSObjectType.SelectedItem = objectType;

                var result = ResultList(CbxContentJSObjectId.SelectedItem.ToString(), CbxContentJSProfileId.SelectedItem.ToString(), CbxContentJSObjectType.SelectedItem.ToString());
                result.ForEach(p =>
                {
                    CbxKeyField.Items.Add(p.Name);
                    CbxValueField.Items.Add(p.Name);
                });
            }
        }

        private void BtnPathName_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                // textBox3.Text = folderDlg.SelectedPath;
            }
        }

        private void DgwHeader_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LblHeaderTotal.Text = "Toplam : " + DgwHeader.Rows.Count.ToString();
        }

        private void DgwHeader_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LblHeaderTotal.Text = "Toplam : " + DgwHeader.Rows.Count.ToString();
        }

        private void BtnContentJSCreate_Click(object sender, EventArgs e)
        {
            if (CbxContentJSObjectId.SelectedItem != null && CbxContentJSObjectType.SelectedItem != null)
            {
                var javaScript = CreateComboBoxJavaScript(CbxContentJSObjectId.SelectedItem.ToString(), CbxContentJSObjectType.SelectedItem.ToString(), TbxPropName.Text);
                RtbxSingleJavaScript.Text = javaScript.ToString();
            }
        }

        private void LoadStaticMethod(int rowIndex)
        {
            var jsonString = File.ReadAllText(@"../../../JsonFiles/StaticMethods.json");
            var jsonNode = System.Text.Json.Nodes.JsonNode.Parse(jsonString);
            var comboBoxMethod = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells[4];
            List<string> methodList = jsonNode.AsArray().Select(p => p.AsObject()["MethodName"].ToString()).ToList();
            comboBoxMethod.DataSource = methodList;
            //foreach (var item in jsonNode.AsArray())
            //{
            //    var s = item.AsObject();
            //    var stype = s["KeyName"];
            //    var keyList = s[stype.ToString()];
            //    var KeyListType = keyList.ToJsonString();

            //}
        }

        private void GetStaticMethodKeyValue(int rowIndex)
        {
            List<string> list = new List<string>();
            var jsonString = File.ReadAllText(@"../../../JsonFiles/StaticMethods.json");
            var jsonNode = System.Text.Json.Nodes.JsonNode.Parse(jsonString);

            var comboBoxKey = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells["KeyField"];
            var comboBoxValue = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells["ValueField"];

            var methodList = jsonNode.AsArray().Select(p => p.AsObject()["MethodName"]).ToList();
            foreach (var node in jsonNode.AsArray())
            {
                var item = node.AsObject();
                var methodName = item["MethodName"].ToString();
                if (DgwComboBoxes.Rows[rowIndex].Cells[4].Value.ToString() == methodName)
                {
                    if (item["ValueName"] != null)
                    {
                        list.Add(item["ValueName"].ToString());
                    }
                    if (item["KeyName"] != null)
                    {
                        list.Add(item["KeyName"].ToString());
                    }
                    comboBoxValue.DataSource = list;
                    if (item["ValueName"] != null)
                    {
                        comboBoxKey.Value = item["ValueName"].ToString();
                    }
                    if (item["KeyName"] != null)
                    {
                        comboBoxKey.Value = item["KeyName"].ToString();
                    }
                    return;

                }
            }
        }
        private Type GetTypeValueKey(string typeName)
        {
            if (typeName == "string")
            {
                return typeof(string);
            }
            else if (typeName == "int")
            {
                return typeof(int);
            }
            else
            {
                return typeof(string);
            }
        }
        private void Deneme()
        {
            var jsonString = File.ReadAllText(@"../../../JsonFiles/StaticMethods.json");
            var jsonNode = System.Text.Json.Nodes.JsonNode.Parse(jsonString);
            for (int i = 0; i < DgwComboBoxes.Rows.Count - 1; i++)
            {
                foreach (var node in jsonNode.AsArray())
                {
                    var item = node.AsObject();

                    if (DgwComboBoxes.Rows[i].Cells[4].Value.ToString() == item["MethodName"].ToString())
                    {
                        var valueTypeName = item[item["ValueType"].ToString()].ToString();
                        var keyTypeName = item[item["KeyType"].ToString()].ToString();
                        Type valueType = GetTypeValueKey(valueTypeName);
                        Type keyType = GetTypeValueKey(keyTypeName);

                        if (item["ValueName"] != null)
                        {
                            var deneme = item["ValueName"].GetType();
                        }
                        if (item["KeyName"] != null)
                        {
                            var deneme2 = item["Number"];
                            var deneme3 = deneme2[0].GetType();
                        }
                        return;

                    }
                }
            }

        }
        private void DgwComboBoxes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgwComboBoxes.Rows.Count > 1)
            {
                var columnIndex = ((DataGridView)sender).CurrentCell.ColumnIndex;
                var rowIndex = ((DataGridView)sender).CurrentCell.RowIndex;
                if (columnIndex == 6)
                {
                    var comboBoxKey = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells["KeyField"];
                    var comboBoxValue = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells["ValueField"];
                    var comboBoxProfile = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells[5];
                    DgwComboBoxes.Rows[rowIndex].Cells[4].Value = null;
                    comboBoxProfile.Value = null;
                    comboBoxKey.Value = null;
                    comboBoxValue.Value = null;
                    comboBoxKey.DataSource = null;
                    comboBoxValue.DataSource = null;
                    comboBoxProfile.DataSource = null;
                    if (DgwComboBoxes.Rows[rowIndex].Cells[6].Value == null)
                    {
                        return;
                    }

                    var methodType = DgwComboBoxes.Rows[rowIndex].Cells[6].Value.ToString();
                    if (methodType == "Service Method")
                    {
                        LoadProfiles(rowIndex);
                    }
                    else if (methodType == "Static Method")
                    {
                        LoadStaticMethod(rowIndex);
                    }
                }
                else if (columnIndex == 5)
                {
                    if (DgwComboBoxes.Rows[rowIndex].Cells[5].Value == null) return;
                    var profileId = DgwComboBoxes.Rows[rowIndex].Cells[5].Value.ToString();
                    var comboBoxService = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells[4];
                    comboBoxService.DataSource = GetObjectIdList(profileId);
                    comboBoxService.Value = "Hiçbiri";
                }

                else if (columnIndex == 4)
                {
                    if (DgwComboBoxes.Rows[rowIndex].Cells[6].Value == null) return;
                    if (DgwComboBoxes.Rows[rowIndex].Cells[6].Value.ToString() == "Service Method")
                    {
                        if (DgwComboBoxes.Rows[rowIndex].Cells[5].Value == null) return;
                        var comboBoxKey = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells["KeyField"];
                        var comboBoxValue = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells["ValueField"];
                        if (DgwComboBoxes.Rows[rowIndex].Cells[4].Value.ToString() == "Hiçbiri")
                        {
                            comboBoxKey.Value = null;
                            comboBoxValue.Value = null;
                            comboBoxKey.DataSource = null;
                            comboBoxValue.DataSource = null;
                            return;
                        }

                        var profileId = DgwComboBoxes.Rows[rowIndex].Cells[5].Value.ToString();
                        var objectTye = GetObjectType(DgwComboBoxes.Rows[rowIndex].Cells[4].Value.ToString(), profileId);
                        var result = ResultList(DgwComboBoxes.Rows[rowIndex].Cells[4].Value.ToString(), profileId, objectTye);
                        var list = new List<string>();


                        result.ForEach(p => { list.Add(p.Name.NameConfigure()); });
                        comboBoxKey.Value = null;
                        comboBoxValue.Value = null;
                        comboBoxKey.DataSource = list;
                        comboBoxValue.DataSource = list;

                        if (list.Count <= 2)
                            list.ForEach(p =>
                            {
                                if (!p.ToLower().Contains("description"))
                                {
                                    DgwComboBoxes.Rows[rowIndex].Cells[2].Value = p;
                                }
                                else
                                {
                                    DgwComboBoxes.Rows[rowIndex].Cells[3].Value = p;
                                }
                            });
                        else
                            list.ForEach(p =>
                            {
                                if (p.ToLower().Contains("description")) DgwComboBoxes.Rows[rowIndex].Cells[3].Value = p;

                                if (p.ToLower().Contains("type")) DgwComboBoxes.Rows[rowIndex].Cells[2].Value = p;
                            });
                    }
                    else if (DgwComboBoxes.Rows[rowIndex].Cells[6].Value.ToString() == "Static Method")
                    {
                        GetStaticMethodKeyValue(rowIndex);
                    }
                }
            }
        }

        private string GetCbxApplicationValue()
        {
            return CbxApplication.SelectedValue.GetType() == typeof(DirectoryPath) ? ((DirectoryPath)CbxApplication.SelectedValue).Path : CbxApplication.SelectedValue.ToString();
        }

        private void CbxApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            var path = GetCbxApplicationValue();
            TbxPath.Text = Path.GetFullPath(path);
            CbxFolder.Items.Clear();
            foreach (var file in Directory.EnumerateDirectories(@path))
            {
                CbxFolder.Items.Add(Path.GetFileName(file));
            }
        }

        private void CbxFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbxPath.Text = Path.Combine(TbxPath.Text, CbxFolder.SelectedItem.ToString()!);
        }

        private void BtnPath_Click(object sender, EventArgs e)
        {
            using var folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = GetCbxApplicationValue();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                TbxPath.Text = folderBrowser.SelectedPath;
            }
        }

        private void CreateStaticMethod()
        {
        }

        private void DgwComboBoxes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}