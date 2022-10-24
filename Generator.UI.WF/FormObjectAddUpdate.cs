using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Constants;
using Generator.Entities;

namespace Generator.UI.WF
{
    public partial class FormObjectAddUpdate : Form
    {
        private readonly IObjectEntityService _objectEntityService;
        //private IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());

        private readonly Profile _profile;

        private bool canFilter;

        public FormObjectAddUpdate(Profile profile, IObjectEntityService objectEntityService)
        {
            _profile = profile;
            _objectEntityService = objectEntityService;
            InitializeComponent();
        }

        private void FillObjectId()
        {
            CbxOjectId.DataSource = null;
            var objectIdList = new List<string>
            {
                "Hiçbiri"
            };
            var result = _objectEntityService.GetAllObjectId();
            objectIdList.AddRange(result);
            CbxOjectId.DataSource = objectIdList;
        }

        private void FillProfileId()
        {
            var objectIdList = new List<string>
            {
                "Hiçbiri"
            };
            var profiles = File.ReadAllText(@"../../../JsonFiles/ObjectProfiles.json");
            objectIdList.AddRange(JsonSerializer.Deserialize<List<string>>(profiles));
            CbxProfileId.DataSource = objectIdList;
        }

        private void FillSchemaName()
        {
            var schemaList = new List<string>
            {
                "Hiçbiri"
            };
            var schemaNames = File.ReadAllText(@"../../../JsonFiles/SchemaNames.json");
            schemaList.AddRange(JsonSerializer.Deserialize<List<string>>(schemaNames));

            CbxSchemaName.DataSource = schemaList;
        }

        private void FillProfile()
        {
            var objectEntity = _profile.ObjectEntity;
            TbxValidFlag.Text = objectEntity.ValidFlag.ToString();
            TbxGenerateUIFlag.Text = objectEntity.GenerateUIFlag.ToString();
            TbxUIPathSuffix.Text = objectEntity.UIPathSuffix;
            TbxObjectId.Text = objectEntity.ObjectId;
            CbxObjectType.SelectedItem = objectEntity.ObjectType;
            TbxProfileId.Text = objectEntity.ProfileId;
            TbxRepositoryName.Text = objectEntity.RepositoryName;
            TbxSchemaName.Text = objectEntity.SchemaName;
            TbxOracleSchemaName.Text = objectEntity.OracleSchemaName;
            TbxText.Text = objectEntity.Text;
            TbxOracleText.Text = objectEntity.OracleText;
            TbxResultCollectionFlag.Text = objectEntity.ResultCollectionFlag.ToString();
            TbxSpcallFlag.Text = objectEntity.SpcallFlag.ToString();
            TbxIgnoreDefaultCollumnsFlag.Text = objectEntity.IgnoreDefaultColumnsFlag.ToString();
            TbxLocalTransactionFlag.Text = objectEntity.LocalTransactionFlag.ToString();
            TbxCustomPagedFlag.Text = objectEntity.CustomPagedFlag.ToString();
        }

        private ObjectEntity NewObjectEntity()
        {
            var objectEntity = new ObjectEntity
            {
                ValidFlag = Convert.ToChar(TbxValidFlag.Text),
                GenerateUIFlag = Convert.ToChar(TbxGenerateUIFlag.Text),
                UIPathSuffix = TbxUIPathSuffix.Text,
                ObjectId = TbxObjectId.Text,
                ObjectType = CbxObjectType.SelectedItem.ToString(),
                ProfileId = TbxProfileId.Text,
                RepositoryName = TbxRepositoryName.Text,
                SchemaName = TbxSchemaName.Text,
                OracleSchemaName = TbxOracleSchemaName.Text,
                Text = TbxText.Text,
                OracleText = TbxOracleText.Text,
                ResultCollectionFlag = Convert.ToChar(TbxResultCollectionFlag.Text),
                SpcallFlag = Convert.ToChar(TbxSpcallFlag.Text),
                IgnoreDefaultColumnsFlag = Convert.ToChar(TbxIgnoreDefaultCollumnsFlag.Text),
                LocalTransactionFlag = Convert.ToChar(TbxLocalTransactionFlag.Text),
                CustomPagedFlag = Convert.ToChar(TbxCustomPagedFlag.Text)
            };
            return objectEntity;
        }

        private void FormObjectAddUpdate_Load(object sender, EventArgs e)
        {
            FillProfile();
            FillObjectId();
            FillProfileId();
            FillSchemaName();
            canFilter = true;
        }

        private bool CheckIfObjectExists(string objectId)
        {
            var result = _objectEntityService.GetAllOrFilter(objectId).Any();
            return result;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            var objectEntity = NewObjectEntity();
            var objectExists = CheckIfObjectExists(objectEntity.ObjectId);

            if (objectExists) LblSonuc.Text = "Sonuç : " + Messages.ObjectIdAlreadyExists;

            try
            {
                _objectEntityService.Add(objectEntity);
            }
            catch (Exception exception)
            {
            }
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

        private void DgwObject_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridLabelSize();
            LblAdet.Text = "Toplam : " + DgwObject.RowCount;
        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {
        }

        private void FormObjectAddUpdate_SizeChanged(object sender, EventArgs e)
        {
            var width = PanelTop.Width / 4;
            PanelFirst.Width = width;
            PanelSecond.Width = width;
            PanelThird.Width = width;
            PanelFourth.Width = width;
            DatagridLabelSize();
        }

        private void FilterObject()
        {
            if (canFilter)
            {
                var selectedObjectId = CbxOjectId.SelectedIndex == 0 ? null : CbxOjectId.SelectedItem.ToString();
                var selectedProfileId = CbxProfileId.SelectedIndex == 0 ? null : CbxProfileId.SelectedItem.ToString();
                var selectedSchemaName =
                    CbxSchemaName.SelectedIndex == 0 ? null : CbxSchemaName.SelectedItem.ToString();
                var result =
                    _objectEntityService.GetAllOrFilter(selectedObjectId, selectedProfileId, selectedSchemaName);
                DgwObject.DataSource = result;
            }
        }

        private void CbxOjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterObject();
        }

        private void CbxProfileId_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterObject();
        }

        private void DgwObject_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void CbxSchemaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterObject();
        }

        private void BtnParametre_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxObjectId.Text))
            {
                var parameterAdd =
                    new FormParameterAndResultAdd(TbxObjectId.Text, TbxProfileId.Text, TbxSchemaName.Text);
                parameterAdd.Show();
            }
        }

        private void BtnResultAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxObjectId.Text))
            {
                var formResult = new FormResultAdd(TbxObjectId.Text, TbxProfileId.Text, TbxSchemaName.Text);
                formResult.Show();
            }
        }

        private void DgwObject_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            TbxObjectId.Text = DgwObject.CurrentRow.Cells[3].Value.ToString();
            TbxProfileId.Text = DgwObject.CurrentRow.Cells[5].Value.ToString();
            TbxSchemaName.Text = DgwObject.CurrentRow.Cells[7].Value.ToString();
            if (DgwObject.CurrentRow.Cells[10].Value != null)
                TbxOracleText.Text = DgwObject.CurrentRow.Cells[10].Value.ToString();
        }

        private void TbxOracleText_MouseClick(object sender, MouseEventArgs e)
        {
            //FormViewText _formViewText = new FormViewText();
            //_formViewText.TextValue = TbxOracleText.Text;
            //_formViewText.Show();
        }

        private void TbxOracleText_TextChanged(object sender, EventArgs e)
        {
        }

        private void FormObjectAddUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtnOracle_Click(object sender, EventArgs e)
        {
            FillObjectId();
        }

        private void BtnUxGenerator_Click(object sender, EventArgs e)
        {
            var formUxGenerator = new FormUxGenerator();
            formUxGenerator.Show();
        }

        private void BtnServiceMethodAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TbxObjectId.Text))
            {
                var form = new FormServiceMethodAdd(TbxObjectId.Text, TbxProfileId.Text, CbxObjectType.Text);
                form.Show();
            }
        }

        private void TbxProfileId_TextChanged(object sender, EventArgs e)
        {
        }
    }
}