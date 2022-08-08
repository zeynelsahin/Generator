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
using Generator.Business.Constants;
using Generator.DataAccess.Concrete;
using Generator.Entities;

namespace Generator.UI.WF
{
    public partial class FormObjectAddUpdate : Form
    {
        public FormObjectAddUpdate(Profile profile)
        {
            _profile = profile;
            InitializeComponent();
        }

        private Profile _profile;
        private IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());

        private void FillObjectId()
        {
            var objectIdList = new List<string>()
            {
                "Hiçbiri"
            };
            var result = _objectEntityService.GetAllObjectId();
            objectIdList.AddRange(result);
            CbxOjectId.DataSource = objectIdList;
        }
        private void FillProfileId()
        {
            var objectIdList = new List<string>()
            {
                "Tümü"
            };
            var result = _objectEntityService.GetAllProfileId();
            objectIdList.AddRange(result);
            CbxProfileId.DataSource = objectIdList;
        }

        private void FillSchemaName()
        {
            var objectIdList = new List<string>()
            {
                "Tümü"
            };
            var result = _objectEntityService.GetAllSchemaName();
            objectIdList.AddRange(result);
            CbxSchemaName.DataSource = objectIdList;
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
        }

        private bool CheckIfObjectExists(string objectId)
        {
            var result = !_objectEntityService.GetByObjectId(objectId).Any();
            return result;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            var objectEntity = NewObjectEntity();
            bool objectExists = CheckIfObjectExists(objectEntity.ObjectId);

            if (objectExists)
            {
                LblSonuc.Text = "Sonuç : " + Messages.ObjectIdAlreadyExists;
            }

            try
            {
                _objectEntityService.Add(objectEntity);

            }
            catch(Exception exception)
            {
            }
        }
        public void DatagridLabelSize( )//datagridview in boyutunu ayarlar
        {
            int height = 41;
            foreach (DataGridViewRow dr in DgwObject.Rows)
            {
                height += dr.Height;
            }
            if (height > PanelPresentation.Height-50)
            {
                DgwObject.Height = PanelPresentation.Height-50;
            }
            else
            {
                DgwObject.Height = height;
            }
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
            var width = PanelTop.Width/4;
            PanelFirst.Width = width;
            PanelSecond.Width = width;
            PanelThird.Width = width;
            PanelFourth.Width = width;
            DatagridLabelSize();
        }

        private void FilterObject()
        {
            if (CbxOjectId.SelectedIndex == 0)
            {
                DgwObject.DataSource = null;
                return;
            }
            var selectedObjectId = CbxOjectId.SelectedItem.ToString();
            var selectedProfileId = CbxProfileId.SelectedItem.ToString();
            var selectedSchemaName = CbxSchemaName.SelectedItem.ToString();
            if (selectedProfileId=="Tümü")
            {
                selectedProfileId = null;
            }

            if (selectedSchemaName=="Tümü")
            {
                selectedSchemaName = null;
            }
            var result = _objectEntityService.GetByObjectId(selectedObjectId,selectedProfileId,selectedSchemaName);
            DgwObject.DataSource = result;
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
    }
}
