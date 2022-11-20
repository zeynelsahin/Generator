using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.DataAccess.Concrete;
using Generator.Entities;

namespace Generator.UI.WF
{
    public partial class FormObjectAddUpdate : Form
    {
        private IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());

        private bool canFilter;
        public FormObjectAddUpdate( )
        {
            InitializeComponent();
        }

        private void FillObjectId()
        {
            CbxOjectId.DataSource = null;

            string profileId = null;
            string schemaName = null;
            if (CbxProfileId.SelectedIndex != -1 && CbxProfileId.SelectedIndex != 0) profileId = CbxProfileId.SelectedItem.ToString();
            if (CbxSchemaName.SelectedIndex != -1 && CbxSchemaName.SelectedIndex != 0) schemaName = CbxSchemaName.SelectedItem.ToString();
            var objectIdList = new List<string>
            {
                "Hiçbiri"
            };
            var result = _objectEntityService.GetAllOrFilter(null, profileId, schemaName).Select(p => p.ObjectId).ToList();
            objectIdList.AddRange(result);
            CbxOjectId.DataSource = objectIdList;
        }

        private void FillProfileId()
        {
            var objectIdList = new List<string>();
            var profiles = File.ReadAllText(@"JsonFiles/ObjectProfiles.json");
            objectIdList.AddRange(JsonSerializer.Deserialize<List<string>>(profiles));
            CbxProfileId.DataSource = objectIdList;
        }

        private void FillSchemaName()
        {
            var schemaList = new List<string>
            {
                "Hiçbiri"
            };
            var schemaNames = File.ReadAllText(@"JsonFiles/SchemaNames.json");
            schemaList.AddRange(JsonSerializer.Deserialize<List<string>>(schemaNames));

            CbxSchemaName.DataSource = schemaList;
        }

        private void FormObjectAddUpdate_Load(object sender, EventArgs e)
        {
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


        public void DatagridLabelSize() //datagridview in boyutunu ayarlar
        {
            var height = 41;
            foreach (DataGridViewRow dr in DgwObject.Rows) height += dr.Height;
            if (height > PanelPresentation.Height - 150)
                DgwObject.Height = PanelPresentation.Height - 150;
            else
                DgwObject.Height = height;
            LblAdet.Top = DgwObject.Bottom + 10;
        }

        private void DgwObject_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {
        }

        private void FormObjectAddUpdate_SizeChanged(object sender, EventArgs e)
        {
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
                if (selectedProfileId!=null )
                {
                    var result =
                   _objectEntityService.GetAllOrFilter(selectedObjectId, selectedProfileId, selectedSchemaName);
                    DgwObject.DataSource = result;
                }
                else
                {
                    DgwObject.DataSource = null;
                }
               
            }
        }

        private void CbxOjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxOjectId.SelectedIndex != -1 )
            {
                FilterObject();
            }
        }

        private void CbxProfileId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxProfileId.SelectedIndex != -1)
            {
                FilterObject();
                FillObjectId();
            }
        }

        private void DgwObject_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void CbxSchemaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxSchemaName.SelectedIndex != -1)
            {
                FilterObject();
                FillObjectId();
            }
        }

        private void BtnParametre_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(CbxObjectType.Text) && !string.IsNullOrWhiteSpace(TbxProfileId.Text) && !string.IsNullOrWhiteSpace(TbxSchemaName.Text))
            {
                var parameterAdd =
                    new FormParameterAndResultAdd(TbxObjectId.Text, TbxProfileId.Text, TbxSchemaName.Text);
                parameterAdd.Show();
            }
        }

        private void BtnResultAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CbxObjectType.Text) && !string.IsNullOrWhiteSpace(TbxProfileId.Text) && !string.IsNullOrWhiteSpace(TbxSchemaName.Text))
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
            CbxObjectType.SelectedItem = DgwObject.CurrentRow.Cells[4].Value.ToString();
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
            if (!string.IsNullOrWhiteSpace(CbxObjectType.Text) && !string.IsNullOrWhiteSpace(TbxProfileId.Text) && !string.IsNullOrWhiteSpace(CbxObjectType.Text))
            {
                var form = new FormServiceMethodAdd(TbxObjectId.Text, TbxProfileId.Text, CbxObjectType.Text);
                form.Show();
            }
        }

        private void TbxProfileId_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DgwObject_DataSourceChanged(object sender, EventArgs e)
        {
            DatagridLabelSize();
            LblAdet.Text = "Toplam : " + DgwObject.RowCount;
        }
    }
}