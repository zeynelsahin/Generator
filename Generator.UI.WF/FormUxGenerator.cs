using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using System.Xml;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.Business.Constants;
using Generator.DataAccess.Concrete;
using Generator.Entities;
using Generator.UI.WF.Elements;
using Generator.UI.WF.Enums;
using Generator.UI.WF.JavaScriptGenerate;
using Generator.UI.WF.Models;
using Button = Generator.UI.WF.Elements.Button;
using Parameter = Generator.UI.WF.Elements.Parameter;

namespace Generator.UI.WF
{
    public partial class FormUxGenerator : Form
    {
        private readonly IActionOptionService _actionOptionService = new ActionOptionService(new EfActionOptionDal());

        // private async Task Deneme()
        // {
        //     var httpClient = new HttpClient();
        //     var response = await httpClient.GetAsync("https://localhost:5001/backoffice/api/getCurrencyDef");
        //     var deneme = response.EnsureSuccessStatusCode();
        //     var responseBody = response.Content.ReadAsStringAsync();
        // }

        private readonly IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());

        private readonly IObjectParameterService _objectParameterService =
            new ObjectParameterService(new EfObjectParameterDal());

        private readonly IObjectResultService _objectResultService = new ObjectResultService(new EfObjectResultDal());

        private readonly IServiceMethodService _serviceMethodService =
            new ServiceMethodService(new EfServiceMethodDal());

        private readonly IServiceOptionService _serviceOptionService =
            new ServiceOptionService(new EfServiceOptionDal());

        private readonly IStringOptionService _stringOptionService = new StringOptionService(new EfStringOptionDal());

        private readonly IMenuOptionService _menuOptionService = new MenuOptionService(new EfMenuOptionDal());

        private readonly IPageOptionService _pageOptionService = new PageOptionService(new EfPageOptionDal());
        private bool isBasicElementAddView;
        private bool isComboBoxAddView;
        private bool isUserControlAddView;

        public FormUxGenerator()
        {
            InitializeComponent();
        }

        private void FormUxGenerator_Load(object sender, EventArgs e)
        {
            CreateDefaultHeader();
            LoadMethodTypes();
            LoadDirectoryPaths();
            LoadProfiles();
            LoadStaticMethod();
            //JavaScript Create Update 
        }

        private void LoadMethodTypes()
        {
            var comboBoxServiceType = (DataGridViewComboBoxColumn)DgwComboBoxes.Columns[6];
            var methodTypes = File.ReadAllText(@"JsonFiles/MethodTypes.json");
            var methodTypeList = JsonSerializer.Deserialize<List<string>>(methodTypes);
            comboBoxServiceType.DataSource = methodTypeList;
        }

        private void LoadProfiles(int rowIndex)
        {
            var comboBoxProfileType = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells[5];
            var profiles = File.ReadAllText(@"JsonFiles/ObjectProfiles.json");
            comboBoxProfileType.DataSource = JsonSerializer.Deserialize<List<string>>(profiles);
        }

        private void LoadProfiles()
        {
            var profiles = File.ReadAllText(@"JsonFiles/ObjectProfiles.json");
            CbxProfile.DataSource = JsonSerializer.Deserialize<List<string>>(profiles);
            CbxContentJSProfileId.DataSource = JsonSerializer.Deserialize<List<string>>(profiles);
            CbxProfileId.DataSource = JsonSerializer.Deserialize<List<string>>(profiles);
            CbxService1ProfileId.DataSource = JsonSerializer.Deserialize<List<string>>(profiles);
            CbxService2ProfileId.DataSource = JsonSerializer.Deserialize<List<string>>(profiles);
        }

        private void LoadDirectoryPaths()
        {
            var jsonString = File.ReadAllText(@"JsonFiles/DirectoryPath.json");
            CbxApplication.DataSource = JsonSerializer.Deserialize<List<DirectoryPath>>(jsonString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            ;
            CbxApplication.DisplayMember = "Application";
            CbxApplication.ValueMember = "Path";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("Add", "Add", "Add", "Success", "Right", "add");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("Update", "Update", "Update", "Warning", "Right", "edit");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("Save", "Save", "Save", "Success", "Right", "save");
        }

        private void BtnUpdateQuestion_Click(object sender, EventArgs e)
        {
            //DgwHeader.Rows.Add("Add","Add","Add","Success","Right","add");
        }

        private void BtnShowDetail_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("ShowDetail", "Show Detail", "ShowDetail", "", "Right", "");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("Delete", "Delete", "Delete", "Danger", "Right", "delete");
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("Clear", "Clear", "Clear", "Danger", "Right", "clear");
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            DgwHeader.Rows.Add("List", "List", "List", "Success", "Right", "list");
        }

        private void CreateDefaultHeader()
        {
            DgwHeader.Rows.Add("List", "List", "List", "Success", "Right", "list");
            DgwHeader.Rows.Add("Add", "Add", "Add", "Success", "Right", "add");
            DgwHeader.Rows.Add("Update", "Update", "Update", "Warning", "Right", "edit");
            DgwHeader.Rows.Add("Clear", "Clear", "Clear", "Danger", "Right", "clear");
        }

        private PageHeader CreatePageHeader()
        {
            var pageHeader = new PageHeader { Title = TbxTitle.Text };
            foreach (DataGridViewRow item in DgwHeader.Rows)
                if (item.Index != DgwHeader.Rows.Count - 1)
                    pageHeader.Buttons.Add(new Button
                    {
                        Id = item.Cells[0].Value.ToString(),
                        Text = item.Cells[1].Value.ToString(),
                        ActionCode = item.Cells[2].Value.ToString(),
                        TypeCss = item.Cells[3].Value.ToString(),
                        Alignment = item.Cells[4].Value.ToString(),
                        IconCss = item.Cells[5].Value.ToString()
                    });

            return pageHeader;
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
            var objects = new List<string> { "Hiçbiri" };
            objects.AddRange(_objectEntityService.GetAllByProfileId(profileId));
            return objects;
        }

        private List<string> GetCustomObjectIdList(string profileId)
        {
            var objects = new List<string> { "Hiçbiri" };
            objects.AddRange(_objectEntityService.GetAllCustomByProfileId(profileId));
            return objects;
        }

        private void CbxObjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbxCrudMethod.DataSource = null;
            if (CbxObjectId.SelectedIndex == 0) return;
            GetColumnNameList();
            TbxGridName.Text = CbxObjectId.SelectedItem.ToString().NameConfigure();
            TbxGridName.Text = TbxGridName.Text.GridNameConfig();
            CbxCrudMethod.DataSource = ServiceMethodList(CbxObjectId.SelectedItem.ToString(),
                CbxProfileId.SelectedItem.ToString());
        }

        private void ServiceMethodDisable()
        {
            GpBxCreate.Visible = true;
            GpxUpdate.Visible = true;

            if (CbxObjectType.Text != "TABLE") return;
            if (CbxCrudMethod.SelectedItem != null)
            {
                if (CbxCrudMethod.SelectedItem.ToString() == "Tümü")
                {
                    if (CbxCrudMethod.Items.Contains("Create"))
                        GpBxCreate.Visible = false;

                    if (CbxCrudMethod.Items.Contains("Modify"))
                        GpxUpdate.Visible = false;
                }
                else
                {
                    if (CbxCrudMethod.SelectedItem.ToString() == "Create")
                        GpBxCreate.Visible = false;

                    if (CbxCrudMethod.SelectedItem.ToString() == "Modify")
                        GpxUpdate.Visible = false;
                }
            }
        }

        private List<string> ServiceMethodList(string objectId, string profileId)
        {
            var tableService = new List<string> { "Tümü" };
            var serviceMethods = _serviceMethodService.GetByObjectId(objectId, profileId);

            if (!(serviceMethods is { CustomMethodFlag: '0' })) return tableService;

            if (serviceMethods.GetMethodFlag == '1') tableService.Add("Get");

            if (serviceMethods.GetPrimaryKeyMethodFlag == '1') tableService.Add("GetByPrimaryKey");

            if (serviceMethods.GetValidMethodFlag == '1') tableService.Add("GetByValidFlag");

            //if (serviceMethods.DeleteMethodFlag == '1') tableService.Add("Delete");

            if (serviceMethods.CreateMethodFlag == '1') tableService.Add("Create");

            if (serviceMethods.ModifyMethodFlag == '1') tableService.Add("Modify");

            return tableService;
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

        private List<OracleColumn> ParameterList(string objectId, string profileId, string objectType)
        {
            var columnNames = new List<OracleColumn>();


            switch (objectType)
            {
                case "TABLE":
                    columnNames = _objectEntityService.GetOracleColumns(objectId);
                    break;
                case "CUSTOMSQL":
                    {
                        columnNames = _objectParameterService.GetAll(objectId, profileId);
                        break;
                    }
            }

            return columnNames;
        }

        private void GetParameterList()
        {
            var objectType = _objectEntityService.GetObjectType(CbxObject.SelectedItem.ToString(),
                CbxProfile.SelectedItem.ToString());
            CbxObjectTypes.SelectedItem = objectType;
            if (CbxObject.SelectedItem != null && CbxObject.SelectedIndex != 0 && CbxObjectTypes.SelectedItem != null)
            {
                DgwContent.Rows.Clear();
                var columnNames = ParameterList(CbxObject.SelectedItem.ToString(), CbxProfile.SelectedItem.ToString(),
                    CbxObjectTypes.SelectedItem.ToString());
                columnNames.ForEach(column =>
                {
                    var dataType = "";
                    var columnName = column.Name;
                    if (columnName.Contains("_FLAG"))
                        dataType = BasicElementType.CheckBox.ToString();
                    else if (column.DataType.ToLower() == "date")
                        dataType = BasicElementType.DateEntry.ToString();
                    else if (column.DataType.ToLower() == "datetime" || column.DataType.ToLower().Contains("timestamp"))
                        dataType = BasicElementType.DateTimeEntry.ToString();
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
                CbxStatusColor.DataSource = null;
                ClbColumnNames.Items.Clear();
                var columnNames = new List<string>();
                columnNames.Add("Hiçbiri");
                if (CbxObjectType.SelectedItem.ToString() == "TABLE")
                {
                    var result = _objectEntityService.GetColumnsName(CbxObjectId.SelectedItem.ToString()).NameConfigure();
                    result.ForEach(p => columnNames.Add(p));
                    result.ForEach(p => ClbColumnNames.Items.Add(p, true));

                    CbxLinkButton.DataSource = columnNames;
                    var columnNamesCopy = columnNames.Select(s => s).ToList();
                    CbxStatusColor.DataSource = columnNamesCopy;
                    if (columnNamesCopy.Contains("ValidFlag")) CbxStatusColor.SelectedItem = "ValidFlag";
                }
                else if (CbxObjectType.SelectedItem.ToString() == "CUSTOMSQL")
                {
                    var result = _objectResultService.GetAllByObjectId(CbxObjectId.SelectedItem.ToString(),
                        CbxProfileId.SelectedItem.ToString()).Select(p => p.ResultId).ToList().NameConfigure();

                    result.ForEach(p => ClbColumnNames.Items.Add(p, true));
                    result.ForEach(result => columnNames.Add(result));
                    //var parameters = _objectParameterService.GetAllByObjectId(CbxObjectId.SelectedItem.ToString(), CbxProfileId.SelectedItem.ToString());
                    CbxLinkButton.DataSource = columnNames;
                    var columnNamesCopy = columnNames.Select(p => p).ToList();
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

            var objects = _objectEntityService.GetAllOrFilter(CbxObjectId.SelectedItem.ToString(),
                CbxProfileId.SelectedItem.ToString());
            DgwObject.DataSource = objects;
            if (DgwObject.Rows.Count > 0)
            {
                CbxObjectType.SelectedItem = objects[0].ObjectType;
                return false;
            }

            //
            return true;
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

        private GridJavaScriptMethod GridJavaScript(string objectId, string profileId, string objectType,
            string crudMethod)
        {
            var gridJavaScriptMethod = new GridJavaScriptMethod();
            if (objectId == null) return gridJavaScriptMethod;
            switch (objectType)
            {
                case "TABLE" when crudMethod == "Tümü":
                    {
                        foreach (var item in CbxCrudMethod.Items)
                            if (item.ToString() == "Get")
                                gridJavaScriptMethod.GetGridApiMethod = GridGetApiMethod(objectId);
                            else if (item.ToString() == "GetByPrimaryKey")
                                gridJavaScriptMethod.GetGridApiMethod = GridGetByPrimaryKeyApiMethod(objectId);
                            else if (item.ToString() == "GetByValidFlag")
                                gridJavaScriptMethod.GetGridApiMethod = GridGetByValidFlagApiMethod(objectId);
                            else if (item.ToString() == "Create")
                                gridJavaScriptMethod.CreateApiMethod = GridCreateApiMethod(objectId, "TABLE", profileId, objectType);
                            else if (item.ToString() == "Modify")
                                gridJavaScriptMethod.UpdateApiMethod = GridUpdateApiMethod(objectId, "TABLE", profileId, objectType);
                            else if (item.ToString() == "Delete") MessageBox.Show("Delete Metodu Boş");

                        break;
                    }
                case "TABLE" when crudMethod == "Create":
                    gridJavaScriptMethod.CreateApiMethod = GridCreateApiMethod(objectId, "TABLE", profileId, objectType);
                    break;
                case "TABLE" when crudMethod == "Modify":
                    gridJavaScriptMethod.UpdateApiMethod = GridUpdateApiMethod(objectId, "TABLE", profileId, objectType);
                    break;
                case "TABLE" when crudMethod == "Get":
                    gridJavaScriptMethod.GetGridApiMethod = GridGetApiMethod(objectId);
                    break;
                case "TABLE" when crudMethod == "GetByPrimaryKey":
                    gridJavaScriptMethod.GetGridApiMethod = GridGetByPrimaryKeyApiMethod(objectId);
                    break;
                case "TABLE" when crudMethod == "GetByValidFlag":
                    gridJavaScriptMethod.GetGridApiMethod = GridGetByValidFlagApiMethod(objectId);
                    break;
                case "CUSTOMSQL":
                    {
                        if (objectId.ToLower().Contains("create"))
                        {
                            gridJavaScriptMethod.CreateApiMethod = GridCreateApiMethod(objectId, "CUSTOM_SQL", profileId, objectType);
                        }
                        else if (objectId.ToLower().Contains("update"))
                        {
                            gridJavaScriptMethod.UpdateApiMethod = GridUpdateApiMethod(objectId, "CUSTOM_SQL", profileId, objectType);
                        }
                        else
                        {
                            var get = GetGridApiMethodCustomSql(objectId, profileId);
                            gridJavaScriptMethod.GetGridApiMethod = get;
                        }

                        break;
                    }
            }

            var serviceId = GetServiceId(profileId);
            if (gridJavaScriptMethod.GetGridApiMethod != null)
            {
                gridJavaScriptMethod.GetGridApiMethod.ServiceId = serviceId;
                gridJavaScriptMethod.GetGridApiMethod.ProfileId = profileId;
            }

            if (gridJavaScriptMethod.UpdateApiMethod != null)
            {
                gridJavaScriptMethod.UpdateApiMethod.ServiceId = serviceId;
                gridJavaScriptMethod.UpdateApiMethod.ProfileId = profileId;
            }

            if (gridJavaScriptMethod.CreateApiMethod != null)
            {
                gridJavaScriptMethod.CreateApiMethod.ServiceId = serviceId;
                gridJavaScriptMethod.CreateApiMethod.ProfileId = profileId;
            }

            return gridJavaScriptMethod;
        }

        private UpdateApiMethod UpdateGridApiMethodCustomSql(string objectId, string profileId)
        {
            var update = new UpdateApiMethod
            {
                MethodName = "Modify" + objectId.NameConfigure().RemoveGet().RemoveUpdate(),
                ServiceName = objectId.CamelCaseConfigure(),
                ParameterName = objectId.NameConfigure() + "Param",
                ResultName = objectId.NameConfigure() + "Result",
                ProfileId = profileId,
                ObjectType = "CUSTOM_SQL"
            };
            var parameters = _objectParameterService.GetAllByObjectId(objectId,
                profileId);
            parameters = parameters.NameConfigure();
            JavaScriptParams(update, parameters);
            return update;
        }

        private CreateApiMethod CreateGridApiMethodCustomSql(string objectId, string profileId)
        {
            var create = new CreateApiMethod()
            {
                MethodName = "Create" + objectId.NameConfigure().RemoveGet().RemoveCreate(),
                ServiceName = objectId.CamelCaseConfigure(),
                ParameterName = objectId.NameConfigure() + "Param",
                ResultName = objectId.NameConfigure() + "Result",
                ProfileId = profileId,
                ObjectType = "CUSTOM_SQL"
            };
            var parameters = _objectParameterService.GetAllByObjectId(objectId,
                profileId);
            parameters = parameters.NameConfigure();
            JavaScriptParams(create, parameters);
            return create;
        }

        private GetGridApiMethod GetGridApiMethodCustomSql(string objectId, string profileId)
        {
            var get = new GetGridApiMethod
            {
                MethodName = "Fill" + TbxGridName.Text + "List",
                ServiceName = objectId.CamelCaseConfigure(),
                ParameterName = objectId.NameConfigure() + "Param",
                PropName = objectId.NameConfigure().GridNameConfig() + "Grid",
                ResultName = objectId.NameConfigure() + "Result",
                ObjectType = "CUSTOM_SQL"
            };
            var parameters = _objectParameterService.GetAllByObjectId(objectId,
                profileId);
            parameters = parameters.NameConfigure();
            JavaScriptParams(get, parameters);
            return get;
        }

        private GetGridApiMethod GridGetApiMethod(string objectId)
        {
            var get = new GetGridApiMethod
            {
                MethodName = "Fill" + objectId.NameConfigure() + "List",
                ServiceName = ("get_" + objectId).CamelCaseConfigure(),
                PropName = objectId.NameConfigure() + "Grid",
                ParameterName = objectId.NameConfigure() + "Request",
                ResultName = objectId.NameConfigure() + "Result",
                ObjectType = "TABLE"
            };
            return get;
        }

        private GetGridApiMethod GridGetByPrimaryKeyApiMethod(string objectId)
        {
            var get = new GetGridApiMethod
            {
                MethodName = "Fill" + objectId.NameConfigure() + "List",
                ServiceName = ("get_" + objectId).CamelCaseConfigure(),
                PropName = objectId.NameConfigure() + "Grid",
                // ParameterName = objectId.NameConfigure() + "Request",
                ResultName = objectId.NameConfigure(),
                ObjectType = "TABLE"
            };
            var primaryKey = _objectEntityService.GetTablePrimaryKeyList(objectId);
            if (primaryKey.Count != 0)
                get.Parameter.Params.Add(new Param
                { Key = primaryKey[0].NameConfigure(), Value = primaryKey[0].NameConfigure() });
            return get;
        }

        private GetGridApiMethod GridGetByValidFlagApiMethod(string objectId)
        {
            var get = new GetGridApiMethod
            {
                MethodName = "Fill" + objectId.NameConfigure() + "List",
                ServiceName = ("get_" + objectId).CamelCaseConfigure(),
                PropName = objectId.NameConfigure() + "Grid",
                // ParameterName = objectId.NameConfigure() + "Request",
                ResultName = objectId.NameConfigure(),
                ObjectType = "TABLE"
            };
            get.Parameter.Params.Add(new Param { Key = "ValidFlag", Value = "ValidFlag" });
            return get;
        }

        private CreateApiMethod GridCreateApiMethod(string objectId, string crudType, string profileId, string objectType)
        {
            var create = new CreateApiMethod
            {
                MethodName = "Create" + objectId.NameConfigure(),
                ServiceName = ("create_" + objectId).CamelCaseConfigure(),
                ParameterName = objectId.NameConfigure(),
                ObjectType = crudType,
                ResultName = ("create_" + objectId).NameConfigure(),
                ServiceId = GetServiceId(profileId)
            };
            var result = ParameterList(objectId, profileId, objectType);
            var parameters = result.Select(p => p.Name.NameConfigure()).ToList().DarkListRemove();
            JavaScriptParams(create, parameters);
            return create;
        }

        private UpdateApiMethod GridUpdateApiMethod(string objectId, string crudType, string profileId, string objectType)
        {
            var modify = new UpdateApiMethod
            {
                MethodName = "Modify" + objectId.NameConfigure(),
                ServiceName = ("Modify_" + objectId).CamelCaseConfigure(),
                ParameterName = objectId.NameConfigure(),
                ObjectType = crudType,
                ResultName = ("update" + objectId).NameConfigure(),
                ServiceId = GetServiceId(profileId)
            };
            var result = ParameterList(objectId, profileId, objectType);
            var parameters = result.Select(p => p.Name.NameConfigure()).ToList().DarkListRemove();
            JavaScriptParams(modify, parameters);
            return modify;
        }

        private void JavaScriptParams(ApiRequestMethod method, IList paramList)
        {
            foreach (var param in paramList)
                method.Parameter.Params.Add(new Param { Key = param.ToString(), Value = param.ToString() });
        }

        private GetComboBoxApiMethod CreateComboBoxJavaScript(string objectId, string objectType, string propName)
        {
            var configObjectId = objectId.NameConfigure();
            var method = new GetComboBoxApiMethod();
            if (objectType == "TABLE")
            {
                method.ServiceName = $"{objectId.CamelCaseConfigure()}";
                method.ResultName = configObjectId + "Result";
            }
            else if (objectType == "CUSTOMSQL")
            {
                method.ServiceName = $"{objectId.CamelCaseConfigure()}";
                method.ResultName = configObjectId + "Result";
                if (CbxOneServiceParameter.Checked)
                {
                    var parameters = _objectParameterService.GetAllByObjectId(
                        CbxContentJSObjectId.SelectedItem.ToString(), CbxContentJSProfileId.SelectedItem.ToString());
                    parameters = parameters.NameConfigure();
                    JavaScriptParams(method, parameters);
                    method.ParameterName = configObjectId + "Param";
                    if (CbxOneServiceResult.Checked)
                    {
                    }
                }
            }

            method.MethodName = "Fill" + configObjectId.RemoveGet();
            method.PropName = propName;

            return method;
        }
        //Object dönülüp liste veya class olarak dönüş yapılabilir farklı metodlarda yazılabilir.

        private List<ApiRequestMethod> ComboBoxServiceMethod()
        {
            var getComboBoxApiMethods = new List<ApiRequestMethod>();
            for (var i = 0; i < DgwComboBoxes.Rows.Count - 1; i++)
            {
                var row = DgwComboBoxes.Rows[i];
                if (row.Cells[6].Value.ToString() == "Service Method")
                {
                    var method = new GetComboBoxApiMethod();
                    var id = row.Cells[0].Value;

                    var objectId = row.Cells[4].Value.ToString().NameConfigure().RemoveGet();
                    var objectType = _objectEntityService.GetObjectType(row.Cells[4].Value.ToString(),
                        row.Cells[5].Value.ToString());
                    if (objectType == "TABLE")
                    {
                        method.ServiceName = $"get{objectId}";
                        method.ResultName = objectId + "List";
                    }
                    else if (objectType == "CUSTOMSQL")
                    {
                        method.ServiceName = $"{row.Cells[4].Value.ToString().CamelCaseConfigure()}";
                        var parameters = _objectParameterService.GetAllByObjectId(row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString());
                        if (parameters != null) JavaScriptParams(method, parameters.NameConfigure());

                        method.ResultName = objectId + "Result";
                    }

                    method.MethodName = "Fill" + objectId;
                    method.PropName = id.ToString();
                    method.ProfileId = row.Cells[5].Value.ToString();
                    method.ServiceId = GetServiceId(method.ProfileId);
                    getComboBoxApiMethods.Add(method);
                }
            }

            return getComboBoxApiMethods;
        }

        private List<ApiRequestMethod> UserControlJavaScript()
        {
            var getComboBoxApiMethods = new List<ApiRequestMethod>();
            for (var i = 0; i < DgwComboBoxes.Rows.Count - 1; i++)
            {
                var method = new GetComboBoxApiMethod();

                var row = DgwComboBoxes.Rows[i];
                var id = row.Cells[0].Value;
                var keyField = row.Cells[2].Value;
                var valueField = row.Cells[3].Value;
                var objectId = row.Cells[4].Value.ToString().NameConfigure().RemoveGet();
                var objectType =
                    _objectEntityService.GetObjectType(row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());
                if (objectType == "TABLE")
                {
                    method.ServiceName = $"get{objectId}";
                    method.ResultName = objectId + "List";
                }
                else if (objectType == "CUSTOMSQL")
                {
                    method.ServiceName = $"{row.Cells[4].Value.ToString().CamelCaseConfigure()}";
                    var parameters = _objectParameterService.GetAllByObjectId(objectId, row.Cells[5].Value.ToString());
                    if (parameters != null) JavaScriptParams(method, parameters);

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
            var amountList = new List<string>();
            var rowTemplate = new RowTemplate();
            foreach (var item in ClbColumnNames.CheckedItems)
            {
                var column = new Column { Id = item.ToString(), Text = item.ToString(), FieldId = item.ToString() };

                column.Witdh = Math.Ceiling(item.ToString().TitleConfig()!.Length * 7.09).ToString();
                column.LinkButton = CbxLinkButton.SelectedItem.ToString() == item.ToString()
                    ? new LinkButton { ActionCode = CbxActionCode.Text }
                    : null;

                if (item.ToString()!.Contains("Date"))
                    dateList.Add(item.ToString());
                else if (item.ToString().ToLower().Contains("amount"))
                {
                    amountList.Add(item.ToString());
                    column.Alignment = "Right";
                }
                else
                    otherList.Add(item.ToString());

                rowTemplate.Columns.Add(column);
            }

            var model = new Model();
            amountList.ForEach(s => model.Fields.Add(new Field { Id = s.ToString(), DataSource = s.ToString(), Type = Types.Money }));
            dateList.ForEach(s => model.Fields.Add(new Field { Id = s.ToString(), DataSource = s.ToString(), Type = Types.Date }));
            otherList.ForEach(s => model.Fields.Add(new Field { Id = s.ToString(), DataSource = s.ToString() }));

            var commandBar = new CommandBar
            {
                ShowSearchBox = "true",
                ExcelExport = "true"
            };


            var gridView = new GridView
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
                gridView.StatusColorFieldId = CbxStatusColor.SelectedItem.ToString();

            return gridView;
        }

        private string GetServiceId(string profileId)
        {
            var text = File.ReadAllText(@"JsonFiles/Services.json");
            var services = JsonSerializer.Deserialize<List<Service>>(text);
            var serviceId = services.SingleOrDefault(p => p.ProfileId == profileId).ServiceId;
            if (string.IsNullOrWhiteSpace(serviceId))
            {
                MessageBox.Show(
                    "Profile ait ServiceId eklenmemiş. Action optins da bulunan ServiceId yi Object içerisinde bulunan ProfileId ile birlikte Services.json dosyasına ekleyiniz");
                return null;
            }

            return serviceId;
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
            if (CbxObjectId.SelectedItem.ToString() != "Hiçbiri")
            {
                RtbxGrid.Text = null;
                RtbxGrid.Text = GridJavaScript(CbxObjectId.SelectedItem.ToString(),
                    CbxProfileId.SelectedItem.ToString(),
                    CbxObjectType.SelectedItem.ToString(),
                    CbxCrudMethod.SelectedItem.ToString()).ToString();
            }
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
                var serviceMethods = _serviceMethodService.GetByObjectId(CbxObject.SelectedItem.ToString(),
                    CbxProfile.SelectedItem.ToString());
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
            if (DgwContent.Rows.Count > 1) isBasicElementAddView = status;

            if (DgwUserControl.Rows.Count > 1) isUserControlAddView = status;

            if (DgwComboBoxes.Rows.Count > 1) isComboBoxAddView = status;
        }

        private void CbxProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var jsonString = File.ReadAllText(@"JsonFiles/Elements.json");
            if (CbxProfile.SelectedIndex != 0)
            {
                var objectList = GetObjectIdList(CbxProfile.SelectedItem.ToString());
                CbxObject.DataSource = objectList;


                var comboBoxView = (DataGridViewComboBoxColumn)DgwView.Columns["ElementTypeView"];
                var list = JsonSerializer.Deserialize<List<string>>(jsonString,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).ToList();
                comboBoxView.DataSource = list;

                var comboBox = (DataGridViewComboBoxColumn)DgwContent.Columns["ElementType"];
                var list1 = JsonSerializer.Deserialize<List<string>>(jsonString,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).ToList();
                list1.Remove("ComboBox");
                comboBox.DataSource = list1;
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

        private void BtnDown_Click(object sender, EventArgs e)
        {
            DataGridViewDown(DgwView);
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

                foreach (DataGridViewRow item in DgwComboBoxes.Rows)
                    if (item.Index != DgwComboBoxes.Rows.Count - 1)
                        LoadProfiles(item.Index);
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
            foreach (var method in ComboBoxStaticMethod()) ResultText.Text += method.ToString();

            foreach (var item in ComboBoxServiceMethod()) ResultText.Text += item.ToString();
        }

        private void NullExceptionMessage(string nullCells, bool multiple)
        {
            var message = nullCells;

            if (multiple)
                message += " alanları boş geçilmemeli";
            else
                message += " alanı boş geçilmemeli";

            MessageBox.Show(message);
        }

        private bool CheckCell(DataGridView gridView, params DataGridViewCell[] dataGridViewCell)
        {
            var counter = 0;
            var check = true;
            var nullCells = "";
            foreach (var cell in dataGridViewCell)
                if (cell.Value == null)
                {
                    counter++;
                    var column = cell.ColumnIndex;
                    nullCells += gridView.Columns[column].Name + " ";

                    check = false;
                }

            var isMultiple = counter > 1;

            if (!check) NullExceptionMessage(nullCells, isMultiple);

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
                    var check = CheckCell(DgwComboBoxes, row.Cells[1], row.Cells[2]);
                    if (!check) return new ComboBoxElement();
                    comboBox.Text = row.Cells[1].Value.ToString();
                    comboBox.KeyField = row.Cells[2].Value.ToString();

                    comboBox.ValueField = row.Cells[3].Value == null ? string.Empty : row.Cells[3].Value.ToString();
                    return comboBox;
                }
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
                    var check = CheckCell(DgwUserControl, row.Cells[2], row.Cells[4]);
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

                switch (viewRow.Cells[2].Value)
                {
                    case "TextBox":
                        element = new TextBoxElement
                        {
                            Id = id,
                            Text = text
                        };
                        break;
                    case "DateEntry":
                        element = new DateEntry
                        {
                            Id = id,
                            Text = text
                        };
                        break;

                    case "CheckBox":
                        element = new CheckBoxElement
                        {
                            Checked = "true",
                            Id = id,
                            Text = text
                        };
                        break;
                    case "NumberEntry":
                        element = new NumberEntry
                        {
                            NoFormat = "true",
                            MaxLenght = "10",
                            Text = text,
                            Id = id
                        };
                        break;
                    case "MoneyEntry":
                        element = new MoneyEntry
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
                    case "DateTimeEntry":
                        element = new DateTimeEntry
                        {
                            Id = id,
                            Text = text
                        };
                        break;
                }
                if (size < 12)
                {
                    var col = new Col
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
                    row = new Row();
                    var col = new Col
                    {
                        Size = colSize,
                        Element = element
                    };

                    row.Elements.Add(col);
                    size += Convert.ToInt32(viewRow.Cells[3].Value);
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

                    if (isHere == false)
                        DgwView.Rows.Add(content.Cells[0].Value, content.Cells[1].Value, content.Cells[2].Value, "3");
                }
            }
        }

        private void ViewComboBox() //ComboBoxları View e ekler
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

                    if (isHere == false)
                        DgwView.Rows.Add(comboBox.Cells[0].Value, comboBox.Cells[1].Value, "ComboBox", "3");
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

                    if (isHere == false)
                        DgwView.Rows.Add(userControl.Cells[0].Value, userControl.Cells[1].Value, "UserControl", "6");
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
            var height = 41 + DgwContent.Rows.Cast<DataGridViewRow>().Sum(dr => dr.Height);
            if (height > GbxResult.Height - 130)
                DgwContent.Height = GbxResult.Height - 130;
            else
                DgwObject.Height = height;
            LblContextTotal.Top = DgwContent.Bottom + 10;
        }

        private bool CheckActionIfExist(string actionId)
        {
            return DgwAction.Rows.Cast<DataGridViewRow>()
                .Any(actionRow => actionId == actionRow.Cells[3].Value.ToString());
        }

        private void Actions(PageJs pageJs)
        {
            DgwAction.Rows.Clear();
            if (pageJs.ApiRequestMethods.Count > 0)
                foreach (var method in pageJs.ApiRequestMethods)
                {
                    DgwAction.Rows.Add("EVUX", "Development", CbxActionOptionApplicationId.SelectedItem.ToString(),
                        method.ServiceName, method.ServiceName,
                        method.ServiceId, "1");
                    DgwAction.Rows.Add("UXLocal", "Development", CbxActionOptionApplicationId.SelectedItem.ToString(),
                        method.ServiceName, method.ServiceName,
                        method.ServiceId + "Local", "1");
                }

            if (pageJs.CreateApiMethod != null)
            {
                DgwAction.Rows.Add("EVUX", "Development", CbxActionOptionApplicationId.SelectedItem.ToString(),
                    pageJs.CreateApiMethod.ServiceName, pageJs.CreateApiMethod.ServiceName,
                    pageJs.CreateApiMethod.ServiceId, "1");
                DgwAction.Rows.Add("UXLocal", "Development", CbxActionOptionApplicationId.SelectedItem.ToString(),
                    pageJs.CreateApiMethod.ServiceName, pageJs.CreateApiMethod.ServiceName,
                    pageJs.CreateApiMethod.ServiceId + "Local", "1");
            }

            if (pageJs.UpdateApiMethod != null)
            {
                DgwAction.Rows.Add("EVUX", "Development", CbxActionOptionApplicationId.SelectedItem.ToString(),
                    pageJs.UpdateApiMethod.ServiceName, pageJs.UpdateApiMethod.ServiceName,
                    pageJs.UpdateApiMethod.ServiceId, "1");
                DgwAction.Rows.Add("UXLocal", "Development", CbxActionOptionApplicationId.SelectedItem.ToString(),
                    pageJs.UpdateApiMethod.ServiceName, pageJs.UpdateApiMethod.ServiceName,
                    pageJs.UpdateApiMethod.ServiceId + "Local", "1");
            }

            if (pageJs.GetGridApiMethod != null)
            {
                DgwAction.Rows.Add("EVUX", "Development", CbxActionOptionApplicationId.SelectedItem.ToString(),
                    pageJs.GetGridApiMethod.ServiceName, pageJs.GetGridApiMethod.ServiceName,
                    pageJs.GetGridApiMethod.ServiceId, "1");
                DgwAction.Rows.Add("UXLocal", "Development", CbxActionOptionApplicationId.SelectedItem.ToString(),
                    pageJs.GetGridApiMethod.ServiceName, pageJs.GetGridApiMethod.ServiceName,
                    pageJs.GetGridApiMethod.ServiceId + "Local", "1");
            }
        }

        private void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabMain.SelectedTab == TabContent)
                CbxProfile.Focus();
            else if (TabMain.SelectedTab == TabGridCreate) CbxProfileId.Focus();
        }

        private void XmlFileCreate(string path, string fileName, PageXml pageXml)
        {
            var xmlPath = Path.Combine(path, fileName + ".xml");

            var basePath = Path.Combine("App", CbxFolder.SelectedItem.ToString());

            if (File.Exists(xmlPath))
            {
                if (CbxOverrideWriteFile.Checked)
                {
                    File.WriteAllText(xmlPath, pageXml.ToString());
                    ContentInclude(basePath, fileName + ".xml");
                    CreateExportLog(Messages.XMLFileOvveride, fileName + ".xml", xmlPath);
                }
                else
                {
                    File.WriteAllText(Path.Combine(path, fileName + "_Copy.xml"), pageXml.ToString());
                    ContentInclude(basePath, fileName + "_Copy.xml");
                    CreateExportLog(Messages.XMLCopyFileCreated, fileName + "_Copy.xml", Path.Combine(path, fileName + "_Copy.xml"));
                }
            }
            else
            {
                File.WriteAllText(xmlPath, pageXml.ToString());
                ContentInclude(basePath, fileName + ".xml");
                CreateExportLog(Messages.XMLFileCreated, fileName + ".xml", xmlPath);
            }
        }

        private void JsFileCreate(string path, string fileName, PageJs pageJs)
        {
            var jsPath = Path.Combine(path, fileName + ".xml.js");
            var basePath = Path.Combine("App", CbxFolder.SelectedItem.ToString());
            if (File.Exists(jsPath))
            {
                if (CbxOverrideWriteFile.Checked)
                {
                    File.WriteAllText(jsPath, pageJs.ToString());
                    ContentInclude(basePath, fileName + ".xml.js");
                    CreateExportLog(Messages.JSFileOvveride, fileName, jsPath);
                }
                else
                {
                    File.WriteAllText(Path.Combine(path, fileName + "_Copy.xml.js"), pageJs.ToString());
                    ContentInclude(basePath, fileName + "_Copy.xml.js");
                    CreateExportLog(Messages.JSCopyFileCreated, fileName + "_Copy.xml.js", Path.Combine(path, fileName + "_Copy.xml.js"));
                }
            }
            else
            {
                File.WriteAllText(jsPath, pageJs.ToString());
                ContentInclude(basePath, fileName + ".xml.js");
                CreateExportLog(Messages.JSFileCreated, fileName, jsPath);
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

            CreateExportLog(Messages.CbxXMLtNotChecked);
            return null;
        }

        private PageJs PageJsCreate(PageXml pageXml)
        {
            if (CbxJavaScriptExport.Checked)
            {
                if (CbxObjectId.SelectedItem == null)
                {
                    CreateExportLog(Messages.ObjectIdNotSelected);
                    return null;
                }

                if (CbxProfileId.SelectedItem == null)
                {
                    CreateExportLog(Messages.ProfileIdNotSelected);
                    return null;
                }

                if (CbxObjectType.SelectedItem == null)
                {
                    CreateExportLog(Messages.ObjectTypeNull);
                    return null;
                }

                if (string.IsNullOrWhiteSpace(CbxCrudMethod.Text))
                {
                    CreateExportLog(Messages.CrudMethodNull);
                    return null;
                }

                var gridMethod = GridJavaScript(CbxObjectId.SelectedItem.ToString(),
                    CbxProfileId.SelectedItem.ToString(),
                    CbxObjectType.SelectedItem.ToString(),
                    CbxCrudMethod.Text);

                var pageJs = new PageJs
                {
                    ApiRequestMethods = ComboBoxServiceMethod(),
                    CreateApiMethod = gridMethod.CreateApiMethod,
                    GetGridApiMethod = gridMethod.GetGridApiMethod,
                    UpdateApiMethod = gridMethod.UpdateApiMethod,
                    PageName = TbxPageName.Text,
                    PageXml = pageXml,
                    StaticMethods = ComboBoxStaticMethod()
                };
                if (gridMethod.CreateApiMethod == null) pageJs.CreateApiMethod = Service1Create();

                if (gridMethod.UpdateApiMethod == null) pageJs.UpdateApiMethod = Service2Create();

                return pageJs;
            }

            CreateExportLog(Messages.CbxJavaSricptNotChecked);
            return null;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            DgwAction.Rows.Clear();
            if (string.IsNullOrWhiteSpace(TbxPageName.Text))
            {
                CreateExportLog(Messages.PageNameNull);
                return;
            }

            if (string.IsNullOrWhiteSpace(TbxPath.Text))
            {
                CreateExportLog(Messages.PathNull);
                return;
            }

            RtbxFileExportLog.Text += "\n";
            CreateExportLog("******** XML LOG START ********");
            var pageXml = PageXmlCreate();

            if (pageXml == null)
            {
                CreateExportLog(Messages.XMLFileNotCreated);
            }
            else
            {
                XmlFileCreate(TbxPath.Text, TbxPageName.Text, pageXml);
                StringOption(pageXml);
            }

            CreateExportLog("******** XML LOG END ********");
            RtbxFileExportLog.Text += "\n";
            CreateExportLog("******** JS LOG START ********");
            var pageJs = PageJsCreate(pageXml);

            if (pageJs == null)
            {
                CreateExportLog(Messages.JSFileNotCreated);
            }
            else
            {
                JsFileCreate(TbxPath.Text, TbxPageName.Text, pageJs);
                Actions(pageJs);
            }

            CreateExportLog("******** JS LOG END ********");
            PageOption();
            LoadMenuView();
            MenuOption();
        }


        private void ContentInclude(string basePath, string path)
        {
            var xmlFile = Path.Combine(((DirectoryPath)CbxApplication.SelectedItem).Path, "UX.Web.csproj");
            var xmlns = "http://schemas.microsoft.com/developer/msbuild/2003";
            //Xmlns attribute siliniyor
            var file = File.ReadAllText(xmlFile);
            if (file.IndexOf(Path.Combine(basePath, path)) != -1) return;
            var indexXmlns = file.IndexOf("xmlns");
            if (indexXmlns < 100 && indexXmlns != -1)
            {
                var define = file.Remove(indexXmlns, 59);
                File.WriteAllText(xmlFile, define);
            }

            var doc = new XmlDocument();
            doc.Load(xmlFile);
            var root = doc.DocumentElement;
            var list = root?.ChildNodes[6];
            var nodeList = list.Cast<object>().Cast<XmlNode>().ToList();

            var element = doc.CreateElement("Content");
            var attribute = doc.CreateAttribute("Include");
            attribute.Value = Path.Combine(basePath, path);
            element.Attributes.Append(attribute);
            nodeList.Add(element);
            var basePathSelect = nodeList.Where(p => p.Attributes[0].Value.Contains(basePath) == true).ToList();


            if (basePathSelect == null || basePathSelect.Count <= 0)
            {
                MessageBox.Show("Lütfen tek seferlik enerate ettiğiniz projeyi existing ediniz");
            }
            else
            {
                basePathSelect = basePathSelect.OrderBy(p => p.Attributes[0].Value).ToList();

                var elementIndex = basePathSelect.IndexOf(element);
                if (elementIndex == basePathSelect.Count - 1)
                {
                    var refChild = basePathSelect[elementIndex - 1];
                    list.InsertAfter(element, refChild);
                }
                else
                {
                    var refChild = basePathSelect[elementIndex + 1];
                    list.InsertBefore(element, refChild);
                }

                doc.Save(xmlFile);
            }

            var attribute1 = doc.CreateAttribute("xmlns");
            attribute1.Value = xmlns;
            root.Attributes.Append(attribute1);
            doc.Save(xmlFile);
        }

        private XmlElement CreateElement(string path, XmlDocument doc)
        {
            var elementXml = doc.CreateElement("Content");
            var attribute = doc.CreateAttribute("Include");
            attribute.Value = path;
            elementXml.Attributes.Append(attribute);
            return elementXml;
        }

        private void StringOption(PageXml pageXml)
        {
            var title = ((PageHeader)pageXml.Header).Title;
            DgwString.Rows.Clear();
            DgwString.Rows.Add("tr-TR", title, title.TitleConfig());
            DgwString.Rows.Add("en-US", title, title.TitleConfig());
        }

        private void PageOption()
        {
            DgwPage.Rows.Clear();
            if (CbxFolder.SelectedItem == null)
            {
                MessageBox.Show("PageOption için ApplicaitonId gerekli. Applicaiton Folder dan geliyor boş olamaz");
                return;
            }

            DgwPage.Rows.Add("EVUX", "Development", CbxFolder.SelectedItem.ToString(), TbxPageName.Text,
                TbxPageName.Text, '1');
            DgwPage.Rows.Add("UXLocal", "Development", CbxFolder.SelectedItem.ToString(), TbxPageName.Text,
                TbxPageName.Text, '1');
            DgwPage.Rows.Add("EVFBUX", "Development", CbxFolder.SelectedItem.ToString(), TbxPageName.Text,
                TbxPageName.Text, '1');
        }

        private void MenuOption()
        {
            DgwMenu.Rows.Clear();
            if (CbxFolder.SelectedItem == null)
            {
                MessageBox.Show("Menu Option için ApplicaitonId  gerekli. Applicaiton Folder dan geliyor boş olamaz");
                return;
            }

            DgwMenu.Rows.Add("EVUX", "Development", CbxFolder.SelectedItem.ToString(), TbxPageName.Text, "", TbxPageName.Text, TbxPageName.Text.TitleConfig());
            DgwMenu.Rows.Add("UXLocal", "Development", CbxFolder.SelectedItem.ToString(), TbxPageName.Text, "", TbxPageName.Text, TbxPageName.Text.TitleConfig());
            DgwMenu.Rows.Add("EVFBUX", "Development", CbxFolder.SelectedItem.ToString(), TbxPageName.Text, "", TbxPageName.Text, TbxPageName.Text.TitleConfig());
        }

        private void LoadMenuView()
        {
            MenuView.Nodes.Clear();
            var menuViewList = new List<TreeNode>();
            var allMenu = _menuOptionService.GetAll().OrderBy(p => p.MenuId);
            var baseMenuList = allMenu.Where(p => p.ParentMenuId == null).ToList();
            baseMenuList.ForEach(p =>
            {
                var node = new TreeNode() { Text = p.Name, Name = p.MenuId };
                MenuView.Nodes.Add(node);
                menuViewList.Add(node);
            });

            var notBaseMenuList = allMenu.Where(p => p.ParentMenuId != null).ToList();

            var addMenuList = new List<TreeNode>();
            while (notBaseMenuList.Count != 0)
            {
                for (var index = 0; index < notBaseMenuList.Count; index++)
                {
                    var a = notBaseMenuList[index];
                    foreach (var t in menuViewList)
                    {
                        if (a.ParentMenuId != t.Name) continue;
                        var node = new TreeNode() { Text = a.Name, Name = a.MenuId };
                        t.Nodes.Add(node);
                        menuViewList.Add(node);
                        notBaseMenuList.RemoveAt(index);
                        break;
                    }
                }
            }
        }

        private void CbxContentJSProfileId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxContentJSProfileId.SelectedIndex != 0)
                CbxContentJSObjectId.DataSource = GetObjectIdList(CbxContentJSProfileId.SelectedItem.ToString());
            else if (CbxContentJSProfileId.SelectedIndex == 0) CbxContentJSObjectId.DataSource = null;

            CbxContentJSObjectId.Focus();
        }

        private void CbxContentJSObjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxContentJSObjectId.SelectedIndex != 0 && CbxContentJSObjectId.SelectedIndex != -1)
            {
                CbxKeyField.Items.Clear();
                CbxValueField.Items.Clear();
                var objectType = _objectEntityService.GetObjectType(CbxContentJSObjectId.SelectedItem.ToString(),
                    CbxContentJSProfileId.SelectedItem.ToString());
                CbxContentJSObjectType.SelectedItem = objectType;

                var result = ResultList(CbxContentJSObjectId.SelectedItem.ToString(),
                    CbxContentJSProfileId.SelectedItem.ToString(), CbxContentJSObjectType.SelectedItem.ToString());
                result.ForEach(p =>
                {
                    CbxKeyField.Items.Add(p.Name);
                    CbxValueField.Items.Add(p.Name);
                });
                CbxContentJsCrudType.DataSource = ServiceMethodList(CbxContentJSObjectId.SelectedItem.ToString(),
                    CbxContentJSProfileId.SelectedItem.ToString());
            }
        }

        private void BtnPathName_Click(object sender, EventArgs e)
        {
            using var folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            var result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                // textBox3.Text = folderDlg.SelectedPath;
            }
        }

        private void DgwHeader_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LblHeaderTotal.Text = $"Toplam : {DgwHeader.Rows.Count - 1}";
        }

        private void DgwHeader_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LblHeaderTotal.Text = $"Toplam : {DgwHeader.Rows.Count - 1}";
        }

        private void BtnContentJSCreate_Click(object sender, EventArgs e)
        {
            if (CbxContentJSObjectId.SelectedItem != null && CbxContentJSObjectType.SelectedItem != null)
            {
                var javaScript = CreateComboBoxJavaScript(CbxContentJSObjectId.SelectedItem.ToString(),
                    CbxContentJSObjectType.SelectedItem.ToString(), TbxPropName.Text);
                RtbxSingleJavaScript.Text = javaScript.ToString();
            }
        }

        private void LoadStaticMethod(int rowIndex)
        {
            var jsonString = File.ReadAllText(@"JsonFiles/StaticMethods.json");
            var jsonNode = JsonNode.Parse(jsonString);
            var comboBoxMethod = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells[4];
            var methodList = jsonNode.AsArray().Select(p => p.AsObject()["MethodName"].ToString()).ToList();
            comboBoxMethod.DataSource = methodList;
        }

        private void LoadStaticMethod()
        {
            var jsonString = File.ReadAllText(@"JsonFiles/StaticMethods.json");
            var jsonNode = JsonNode.Parse(jsonString);
            var methodList = jsonNode.AsArray().Select(p => p.AsObject()["MethodName"].ToString()).ToList();
            CbxStaticJavaScript.DataSource = methodList;
        }

        private void GetStaticMethodKeyValue(int rowIndex)
        {
            var list = new List<string>();
            var jsonString = File.ReadAllText(@"JsonFiles/StaticMethods.json");
            var jsonNode = JsonNode.Parse(jsonString);

            var comboBoxKey = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells["KeyField"];
            var comboBoxValue = (DataGridViewComboBoxCell)DgwComboBoxes.Rows[rowIndex].Cells["ValueField"];

            comboBoxKey.Value = null;
            comboBoxValue.Value = null;
            comboBoxKey.DataSource = null;
            comboBoxValue.DataSource = null;

            var methodList = jsonNode.AsArray().Select(p => p.AsObject()["MethodName"]).ToList();
            foreach (var node in jsonNode.AsArray())
            {
                var item = node.AsObject();
                var methodName = item["MethodName"].ToString();
                if (DgwComboBoxes.Rows[rowIndex].Cells[4].Value.ToString() == methodName)
                {
                    if (item["ValueName"] != null) list.Add(item["ValueName"].ToString());

                    if (item["KeyName"] != null) list.Add(item["KeyName"].ToString());

                    comboBoxValue.DataSource = list;
                    comboBoxKey.DataSource = list;
                    if (item["ValueName"] != null) comboBoxValue.Value = item["ValueName"].ToString();

                    if (item["KeyName"] != null) comboBoxKey.Value = item["KeyName"].ToString();

                    return;
                }
            }
        }

        private void GetStaticMethodKeyValue()
        {
            var jsonString = File.ReadAllText(@"JsonFiles/StaticMethods.json");
            var jsonNode = JsonNode.Parse(jsonString);
            var methodList = jsonNode.AsArray().Select(p => p.AsObject()["MethodName"]).ToList();
            foreach (var node in jsonNode.AsArray())
            {
                var item = node.AsObject();
                if (CbxStaticJavaScript.SelectedItem.ToString() == item["MethodName"].ToString())
                {
                    CbxStaticValueField.Text = " ";
                    if (item["ValueName"] != null) CbxStaticValueField.Text = item["ValueName"].ToString();

                    if (item["KeyName"] != null) CbxStaticKeyField.Text = item["KeyName"].ToString();

                    TbxMethodName.Text = item["KeyName"] + "List";
                    return;
                }
            }
        }

        private Type GetTypeValueKey(string typeName)
        {
            if (typeName == "string")
                return typeof(string);
            if (typeName == "int")
                return typeof(int);
            return typeof(string);
        }

        private List<object> ConvertToList(JsonArray array)
        {
            var list = new List<object>();
            foreach (var item in array) list.Add(item.ToJsonString().ConvertUtf8());

            return list;
        }

        private List<StaticMethod> ComboBoxStaticMethod()
        {
            var staticMethods = new List<StaticMethod>();
            var jsonString = File.ReadAllText(@"JsonFiles/StaticMethods.json");
            var jsonNode = JsonNode.Parse(jsonString);
            for (var i = 0; i < DgwComboBoxes.Rows.Count - 1; i++)
                if (DgwComboBoxes.Rows[i].Cells[6].Value.ToString() == "Static Method")
                    foreach (var node in jsonNode.AsArray())
                    {
                        var item = node.AsObject();

                        if (DgwComboBoxes.Rows[i].Cells[4].Value.ToString() == item["MethodName"].ToString())
                        {
                            var valueName = item["ValueName"] != null ? item["ValueName"].ToString() : null;
                            var keyName = item["KeyName"] != null ? item["KeyName"].ToString() : null;

                            var staticMethod = new KeyValueStaticMethod
                            {
                                MethodDescription = item["MethodDescription"].ToString().ConvertUtf8(),
                                MethodName = "Fill" + item["MethodName"].ToString().ConvertUtf8() + "List",
                                PropName = DgwComboBoxes.Rows[i].Cells[0].Value.ToString().ConvertUtf8()
                            };

                            if (valueName != null)
                            {
                                var values = ConvertToList((JsonArray)item[valueName]);
                                staticMethod.ValueName = valueName.ConvertUtf8();
                                staticMethod.ValueList = values;
                            }

                            if (keyName != null)
                            {
                                var keys = ConvertToList((JsonArray)item[keyName]);
                                staticMethod.KeyName = keyName.ConvertUtf8();
                                staticMethod.KeyList = keys;
                            }

                            staticMethods.Add(staticMethod);
                        }
                    }

            return staticMethods;
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
                    if (DgwComboBoxes.Rows[rowIndex].Cells[6].Value == null) return;

                    var methodType = DgwComboBoxes.Rows[rowIndex].Cells[6].Value.ToString();
                    if (methodType == "Service Method")
                        LoadProfiles(rowIndex);
                    else if (methodType == "Static Method") LoadStaticMethod(rowIndex);
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
                        var objectTye = GetObjectType(DgwComboBoxes.Rows[rowIndex].Cells[4].Value.ToString(),
                            profileId);
                        var result = ResultList(DgwComboBoxes.Rows[rowIndex].Cells[4].Value.ToString(), profileId,
                            objectTye);
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
                                    DgwComboBoxes.Rows[rowIndex].Cells[2].Value = p;
                                else
                                    DgwComboBoxes.Rows[rowIndex].Cells[3].Value = p;
                            });
                        else
                            list.ForEach(p =>
                            {
                                if (p.ToLower().Contains("description"))
                                    DgwComboBoxes.Rows[rowIndex].Cells[3].Value = p;

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
            return CbxApplication.SelectedValue.GetType() == typeof(DirectoryPath)
                ? Path.Combine(((DirectoryPath)CbxApplication.SelectedValue).Path, "App")
                : Path.Combine(CbxApplication.SelectedValue.ToString(), "App");
        }

        private void CbxApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            var path = GetCbxApplicationValue();
            TbxPath.Text = Path.GetFullPath(path);
            CbxFolder.Items.Clear();
            foreach (var file in Directory.EnumerateDirectories(path))
            {
                CbxFolder.Items.Add(Path.GetFileName(file));
                CbxActionOptionApplicationId.Items.Add(Path.GetFileName(file));
                CbxPageOptionApplication.Items.Add(Path.GetFileName(file));
                CbxMenuOptionApplication.Items.Add(Path.GetFileName(file));
            }

            CbxFolder.SelectedIndex = 0;
        }

        private void CbxFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            var path = GetCbxApplicationValue();
            TbxPath.Text = Path.GetFullPath(path);
            TbxPath.Text = Path.Combine(TbxPath.Text, CbxFolder.SelectedItem.ToString()!);
            CbxActionOptionApplicationId.SelectedItem = CbxFolder.SelectedItem;
            CbxPageOptionApplication.SelectedItem = CbxFolder.SelectedItem;
            CbxMenuOptionApplication.SelectedItem = CbxFolder.SelectedItem;
        }

        private void BtnPath_Click(object sender, EventArgs e)
        {
            using var folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = GetCbxApplicationValue();
            var result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                TbxPath.Text = folderBrowser.SelectedPath;
        }

        private void BtnAddActions_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < DgwAction.Rows.Count - 1; i++)
            {
                var row = DgwAction.Rows[i];
                var action = new ActionOption
                {
                    DomainId = row.Cells[0].Value.ToString(),
                    Environment = row.Cells[1].Value.ToString(),
                    ApplicationId = row.Cells[2].Value.ToString(),
                    ActionId = row.Cells[3].Value.ToString(),
                    ServiceActionName = row.Cells[4].Value.ToString(),
                    ServiceId = row.Cells[5].Value.ToString(),
                    ValidFlag = '1',
                    Description = string.Empty
                };
                var actionIfCheck = _actionOptionService.Get(action.DomainId, action.Environment, action.ApplicationId,
                    action.ActionId);
                if (actionIfCheck != null) return;
                _actionOptionService.Add(action);
            }
        }

        private void BtnListAction_Click(object sender, EventArgs e)
        {
            GetListToAddAction();
        }

        private void GetListToAddAction()
        {
            if (DgwAction.Rows.Count == 0) return;
            var actions = new List<ActionOption>();
            for (var i = 0; i < DgwAction.Rows.Count - 1; i++)
            {
                var row = DgwAction.Rows[i];
                var domainId = row.Cells[0].Value.ToString();
                var applicationId = row.Cells[2].Value.ToString();
                var actionId = row.Cells[3].Value.ToString();
                var result = _actionOptionService.Get(domainId, "Development", applicationId, actionId);
                actions.Add(result);
            }

            DgwActionResult.DataSource = actions;
        }

        private void BtnStaticMethod_Click(object sender, EventArgs e)
        {
            var jsonString = File.ReadAllText(@"JsonFiles/StaticMethods.json");
            var jsonNode = JsonNode.Parse(jsonString);

            foreach (var node in jsonNode.AsArray())
            {
                var item = node.AsObject();

                if (CbxStaticJavaScript.SelectedItem.ToString() == item["MethodName"].ToString())
                {
                    var staticMethod = new KeyValueStaticMethod();

                    staticMethod.MethodName = "Fill" + item["MethodName"].ToString().ConvertUtf8() + "List";
                    staticMethod.PropName = TbxPropName.Text;
                    if (CbxStaticValueField.Text != " ")
                    {
                        var values = ConvertToList((JsonArray)item[CbxStaticValueField.Text]);
                        staticMethod.ValueName = CbxStaticValueField.Text;
                        staticMethod.ValueList = values;
                    }

                    if (CbxStaticKeyField.Text != null)
                    {
                        var keys = ConvertToList((JsonArray)item[CbxStaticKeyField.Text]);
                        staticMethod.KeyName = CbxStaticKeyField.Text;
                        staticMethod.KeyList = keys;
                    }

                    RtbxSingleJavaScript.Text = staticMethod.ToString();
                    return;
                }
            }
        }

        private void CbxStaticJavaScript_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxStaticJavaScript.SelectedItem != null) GetStaticMethodKeyValue();
        }
        private string GridApiMethod(string objectId, string profileId, string crudMethod, string objectType)
        {
            var method = "";
            switch (crudMethod)
            {
                case "Create":
                    method = GridCreateApiMethod(objectId, "TABLE", profileId, objectType).ToString();
                    break;
                case "Modify":
                    method = GridUpdateApiMethod(objectId, "TABLE", profileId, objectType).ToString();
                    break;
                case "Get":
                    method = GridGetApiMethod(objectId).ToString();
                    break;
                case "GetByPrimaryKey":
                    method = GridGetByPrimaryKeyApiMethod(objectId).ToString();
                    break;
                case "GetByValidFlag":
                    method = GridGetByValidFlagApiMethod(objectId).ToString();
                    break;
            }
            return method;

        }
        private CreateApiMethod Service1Create()
        {
            if (CbxService1ObjectId.SelectedItem == null) return null;
            if (CbxService1ObjectType.SelectedItem.ToString() == "TABLE")
            {
                var create = GridCreateApiMethod(CbxService1ObjectId.SelectedItem.ToString(), "TABLE", CbxService1ProfileId.SelectedItem.ToString(), CbxService1ObjectType.SelectedItem.ToString());
                return create;
            }
            else
            {
                var service1 = CreateGridApiMethodCustomSql(CbxService1ObjectId.SelectedItem.ToString(),
                CbxService1ProfileId.SelectedItem.ToString());
                service1.ServiceId = GetServiceId(service1.ProfileId);
                return service1;
            }
        }

        private UpdateApiMethod Service2Create()
        {
            if (CbxService2ObjectId.SelectedItem == null) return null;
            if (CbxService2ObjectType.SelectedItem.ToString() == "TABLE")
            {
                var update = GridUpdateApiMethod(CbxService2ObjectId.SelectedItem.ToString(), "TABLE", CbxService2ProfileId.SelectedItem.ToString(), CbxService2ObjectType.SelectedItem.ToString());
                return update;
            }
            else
            {
                var service2 = UpdateGridApiMethodCustomSql(CbxService2ObjectId.SelectedItem.ToString(),
             CbxService2ProfileId.SelectedItem.ToString());
                service2.ServiceId = GetServiceId(service2.ProfileId);
                return service2;
            }
        }

        private void BtnGridServiceJavaScriptCreate_Click(object sender, EventArgs e)
        {
            if (Service1Create() != null)
                RtbxGridServiceResult.Text = Service1Create().ToString();
            if (Service2Create() != null)
                RtbxGridServiceResult.Text += Service2Create().ToString();
        }

        private void CbxService1ProfileId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxService1ProfileId.SelectedIndex != 0)
            {
                var list = new List<string>();
                var objectIdList = GetObjectIdList(CbxService1ProfileId.SelectedItem.ToString());

                foreach (var item in objectIdList)
                {
                    var serviceMethods = _serviceMethodService.GetByObjectId(item, CbxService1ProfileId.SelectedItem.ToString());
                    if (serviceMethods == null) continue;
                    if (serviceMethods.CreateMethodFlag == '1')
                    {
                        list.Add(item);
                    }
                    else if (serviceMethods.CustomMethodFlag == '1')
                    {
                        if (item.ToLower().Contains("update") || item.ToLower().Contains("modify"))
                        {
                            list.Add(item);
                        }
                    }
                }
                CbxService1ObjectId.DataSource = list;
            }
            else if (CbxService1ProfileId.SelectedIndex == 0)
            {
                CbxService1ObjectId.DataSource = null;
            }

            CbxService1ObjectId.Focus();
        }

        private void CbxService2ProfileId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxService2ProfileId.SelectedIndex != 0)
            {
                var list = new List<string>();
                var objectIdList = GetObjectIdList(CbxService2ProfileId.SelectedItem.ToString());

                foreach (var item in objectIdList)
                {
                    var serviceMethods = _serviceMethodService.GetByObjectId(item, CbxService2ProfileId.SelectedItem.ToString());
                    if (serviceMethods == null) continue;
                    if (serviceMethods.ModifyMethodFlag == '1')
                    {
                        list.Add(item);
                    }
                    else if (serviceMethods.CustomMethodFlag == '1')
                    {
                        if (item.ToLower().Contains("create") || item.ToLower().Contains("add"))
                        {
                            list.Add(item);
                        }
                    }
                }
                CbxService2ObjectId.DataSource = list;

            }
            else if (CbxService2ProfileId.SelectedIndex == 0)
            {
                CbxService2ObjectId.DataSource = null;
            }

            CbxService2ObjectId.Focus();
        }

        private void CbxService1ObjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxService1ObjectId.SelectedIndex == 0 || CbxService1ObjectId.SelectedIndex == -1) return;
            var objectType =
                GetObjectType(CbxService1ObjectId.SelectedItem.ToString(),
                    CbxService1ProfileId.SelectedItem.ToString());
            CbxService1ObjectType.SelectedItem = objectType;
            CbxService1ObjectType.Text = objectType;
            //if (objectType == "TABLE")
            //{
            //    var crudTypes = ServiceMethodList(CbxService1ObjectId.SelectedItem.ToString(), CbxService1ProfileId.SelectedItem.ToString());
            //    crudTypes.Remove("Tümü");
            //    CbxService1CrudType.DataSource = crudTypes;
            //}

        }

        private void CbxService2ObjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxService2ObjectId.SelectedIndex == 0 || CbxService2ObjectId.SelectedIndex == -1) return;
            var objectType =
                GetObjectType(CbxService2ObjectId.SelectedItem.ToString(),
                    CbxService2ProfileId.SelectedItem.ToString());
            CbxService2ObjectType.SelectedItem = objectType;
            CbxService2ObjectType.Text = objectType;
            //if (objectType == "TABLE")
            //{
            //    var crudTypes = ServiceMethodList(CbxService2ObjectId.SelectedItem.ToString(), CbxService2ProfileId.SelectedItem.ToString());
            //    crudTypes.Remove("Tümü");
            //    CbxService2CrudType.DataSource = crudTypes;
            //}

        }

        private void BtnGridServiceClear_Click(object sender, EventArgs e)
        {
            CbxService1ObjectId.DataSource = null;
            CbxService2ObjectId.DataSource = null;
            CbxService1ObjectType.Text = "";
            CbxService2ObjectType.Text = "";
            CbxService1ProfileId.SelectedIndex = 0;
            CbxService2ProfileId.SelectedIndex = 0;
        }

        private List<Event> Events = new List<Event>();

        private void EventAdd(string eventName, string content)
        {
            Events.Add(new Event()
            {
                EventName = eventName,
                Content = content
            });
            if (Events.All(p => p.EventName != eventName)) DgwEvent.Rows.Add(eventName);
        }

        private void EventRemove(string eventName)
        {
            var firstOrDefault = Events.FirstOrDefault(p => p.EventName == eventName);
            if (firstOrDefault != null) Events.Remove(firstOrDefault);
        }

        private void EventUpdate(string eventName, string content, Event @event = null)
        {
            if (@event == null) return;
            @event.EventName = eventName;
            @event.Content = content;
        }

        private void CbxCrudMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceMethodDisable();
        }

        private void BtnStringList_Click(object sender, EventArgs e)
        {
            GetStringOptionList();
        }

        private void GetStringOptionList()
        {
            if (DgwString.Rows.Count == 0) return;
            var stringOptions = new List<StringOption>();
            for (var i = 0; i < DgwString.Rows.Count - 1; i++)
            {
                var row = DgwString.Rows[i];
                var languageId = row.Cells[0].Value.ToString();
                var keyId = row.Cells[1].Value.ToString();
                var result = _stringOptionService.Get(languageId, keyId);
                stringOptions.Add(result);
            }

            DgwStringResult.DataSource = stringOptions;
        }

        private void CreateExportLog(string message)
        {
            RtbxFileExportLog.Text += "Date time: " + DateTime.Now.ToString("MM/dd HH:mm") + "  Message : " + message + "\n";
        }

        private void CreateExportLog(string message, string pageName)
        {
            RtbxFileExportLog.Text += "Date time: " + DateTime.Now.ToString("MM/dd HH:mm") + " + Message : " + message + "\n" + "  PageName : " + pageName;
        }

        private void CreateExportLog(string message, string pageName, string path)
        {
            RtbxFileExportLog.Text += "Date time: " + DateTime.Now.ToString("MM/dd HH:mm") + "  Message : " + message + "  PageName : " + pageName + "  Path : " + path + "\n";
        }

        private void BtnAddStrings_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxTitle.Text)) return;
            for (var i = 0; i < DgwString.Rows.Count - 1; i++)
            {
                var row = DgwString.Rows[i];
                var stringOption = new StringOption
                {
                    LanguageId = row.Cells[0].Value.ToString(),
                    KeyId = row.Cells[1].Value.ToString(),
                    Value = row.Cells[2].Value.ToString()
                };
                var stringOptionIfCheck = _stringOptionService.Get(stringOption.LanguageId, stringOption.KeyId);
                if (stringOptionIfCheck != null) return;
                _stringOptionService.Add(stringOption);
            }
        }

        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            RtbxFileExportLog.Text = null;
        }

        private void BtnMenuAdd_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < DgwMenu.Rows.Count - 1; i++)
            {
                var row = DgwMenu.Rows[i];
                var menuOption = new MenuOption()
                {
                    DomainId = row.Cells[0].Value.ToString(),
                    Environment = row.Cells[1].Value.ToString(),
                    ApplicationId = row.Cells[2].Value.ToString(),
                    MenuId = row.Cells[3].Value.ToString(),
                    ParentMenuId = row.Cells[4].Value.ToString(),
                    PageId = row.Cells[5].Value.ToString(),
                    Name = row.Cells[6].Value.ToString(),
                    Icon = null,
                    SortId = 1,
                    ValidFlag = '1'
                };
                var menuOptionCheck = _menuOptionService.Get(menuOption.DomainId, menuOption.Environment, menuOption.ApplicationId, menuOption.MenuId);
                if (menuOptionCheck != null) return;
                _menuOptionService.Add(menuOption);
            }
            LoadMenuView();
        }

        private void BtnMenuResult_Click(object sender, EventArgs e)
        {
            GetMenuOptions();
        }

        private void GetMenuOptions()
        {
            if (DgwMenu.Rows.Count == 0) return;
            var menuOption = new List<MenuOption>();
            for (var i = 0; i < DgwMenu.Rows.Count - 1; i++)
            {
                var row = DgwMenu.Rows[i];
                var domainId = row.Cells[0].Value.ToString();
                var environment = row.Cells[1].Value.ToString();
                var applicationId = row.Cells[2].Value.ToString();
                var menuId = row.Cells[3].Value.ToString();

                var result = _menuOptionService.Get(domainId, environment, applicationId, menuId);
                menuOption.Add(result);
            }

            DgwMenuResult.DataSource = menuOption;
        }

        private void MenuView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedMenu = MenuView.SelectedNode.Name;
            if (selectedMenu == null) return;
            for (var i = 0; i < DgwMenu.Rows.Count - 1; i++)
            {
                var row = DgwMenu.Rows[i];
                row.Cells[4].Value = selectedMenu;
            }
        }

        private void BtnPageAdd_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < DgwPage.Rows.Count - 1; i++)
            {
                var row = DgwPage.Rows[i];
                var pageOption = new PageOption()
                {
                    DomainId = row.Cells[0].Value.ToString(),
                    Environment = row.Cells[1].Value.ToString(),
                    ApplicationId = row.Cells[2].Value.ToString(),
                    PageId = row.Cells[3].Value.ToString(),
                    Name = row.Cells[4].Value.ToString(),
                    ValidFlag = '1'
                };
                var pageOptionCheck = _pageOptionService.Get(pageOption.DomainId, pageOption.Environment, pageOption.ApplicationId, pageOption.PageId);
                if (pageOptionCheck != null) return;
                _pageOptionService.Add(pageOption);
            }
        }

        private void BtnPageList_Click(object sender, EventArgs e)
        {
            GetPageOptions();
        }
        private void GetPageOptions()
        {
            if (DgwPage.Rows.Count == 0) return;
            var pageOption = new List<PageOption>();
            for (var i = 0; i < DgwPage.Rows.Count - 1; i++)
            {
                var row = DgwPage.Rows[i];
                var domainId = row.Cells[0].Value.ToString();
                var environment = row.Cells[1].Value.ToString();
                var applicationId = row.Cells[2].Value.ToString();
                var pageId = row.Cells[3].Value.ToString();
                var result = _pageOptionService.Get(domainId, environment, applicationId, pageId);
                pageOption.Add(result);
            }

            DgwPageResult.DataSource = pageOption;
        }

        private void BtnHeaderCreate_Click(object sender, EventArgs e)
        {
            RtbxPrensentation.Text = CreatePageHeader().ToString();
            Console.WriteLine();
        }
    }
}