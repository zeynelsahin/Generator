using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.DataAccess.Concrete;
using Generator.UI.WF.Elements;
using Button = Generator.UI.WF.Elements.Button;

namespace Generator.UI.WF
{
    public partial class FormUxGenerator : Form
    {
        public FormUxGenerator()
        {
            InitializeComponent();
        }

        private async Task Deneme()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5001/backoffice/api/getCurrencyDef");
            var deneme = response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync();
        }


        private readonly IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());
        private readonly IObjectResultService _objectResultService = new ObjectResultService(new EfObjectResultDal());

        private void FormUxGenerator_Load(object sender, EventArgs e)
        {
        }


        private void BtnHeaderCreate_Click(object sender, EventArgs e)
        {
            string headerChild = "";
            Button button = new Button()
            {
                Alignment = "right"
            };
            if (ChckbAdd.Checked)
            {
                button.ActionCode = "Add";
                button.Text = "Add";
                button.Id = "Add";
                button.TypeCss = "Success";
                button.IconCss = "add";
                headerChild += button.ToString();
            }

            if (ChckbList.Checked)
            {
                button.ActionCode = "List";
                button.Text = "List";
                button.Id = "List";
                button.TypeCss = "Primary";
                button.IconCss = "list";
                headerChild += button.ToString();
            }

            if (ChckbUpdate.Checked)
            {
                button.ActionCode = "Update";
                button.Text = "Update";
                button.Id = "Update";
                button.TypeCss = "Warning";
                button.IconCss = "edit";
                headerChild += button.ToString();
            }


            if (ChckbUpdateQuestion.Checked)
            {
                button.ActionCode = "Update";
                button.Text = "Update";
                button.Id = "Update";
                button.TypeCss = "Warning";
                button.IconCss = "edit";
                headerChild += button.ToString();
            }

            if (ChckbDelete.Checked)
            {
                button.ActionCode = "Delete";
                button.Text = "Delete";
                button.Id = "Delete";
                button.TypeCss = "Danger";
                button.IconCss = "clear";
                headerChild += button.ToString();
            }


            if (ChckbClear.Checked)
            {
                button.ActionCode = "Clear";
                button.Text = "Clear";
                button.Id = "Clear";
                button.TypeCss = "Danger";
                button.IconCss = "clear";
                headerChild += button.ToString();
            }


            PageHeader pageHeader = new PageHeader()
            {
                Title = TbxTitle.Text,
                Childes = headerChild
            };

            RtbxPrensentation.Text = pageHeader.ToString();
        }

        private void checkedListBox1_DragDrop(object sender, DragEventArgs e)
        {
            checkedListBox1.DoDragDrop(checkedListBox1.SelectedItem, DragDropEffects.Move);
        }

        private void CbxProfileId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxProfileId.SelectedIndex != 0)
            {
                List<string> objects = new List<string>();
                objects.Add("Hiçbiri");
                objects.AddRange(_objectEntityService.GetAllByProfileId(CbxProfileId.SelectedItem.ToString()));
                CbxObjectId.DataSource = objects;
            }
            else if (CbxProfileId.SelectedIndex == 0)
            {
                CbxObjectId.DataSource = null;
                DgwObject.DataSource = null;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void CbxObjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxObjectId.SelectedItem != null && CbxObjectId.SelectedIndex != 0)
            {
                if (string.IsNullOrWhiteSpace(CbxObjectId.Text))
                {
                    return;
                }
                var objects = _objectEntityService.GetByObjectId(CbxObjectId.SelectedItem.ToString(), CbxProfileId.SelectedItem.ToString());
                DgwObject.DataSource = objects;
                CbxObjectType.SelectedItem = DgwObject.CurrentRow.Cells[4].Value.ToString();
                //

                string xml = "";
                //ClbColumnNames.Items.Clear();
                xml += "\n<content-block helper-css=\"box\">";
                if (CbxObjectType.SelectedItem.ToString() == "TABLE")
                {
                    List<string> columnNames = new List<string>();
                    columnNames.Add("Hiçbiri");
                    columnNames.AddRange(_objectEntityService.GetColumnsName(CbxObjectId.SelectedItem.ToString()));
                    columnNames = columnNames.NameConfigure();

                    CbxLinkButton.DataSource = columnNames;
                    CbxStatusColor.DataSource = columnNames;

                    columnNames.ForEach(p =>
                    {
                        if (p == "Hiçbiri") return;
                        ClbColumnNames.Items.Add(p, true);
                    });
                }
                else if (CbxObjectType.SelectedItem.ToString() == "CUSTOMSQL")
                {
                    var result = _objectResultService.GetAllByObjectId(CbxObjectId.SelectedItem.ToString());
                    result.ForEach(p =>
                    {
                        if (p.DataType == "date" || p.DataType == "datetime")
                        {
                        }
                    });
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

        private void DgwObject_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DgwObject.RowCount != 0)
            {
                PanelDgw.Height = 60;
            }
            else
            {
                PanelDgw.Height = 0;
            }
        }

        private void BtnGridCreate_Click(object sender, EventArgs e)
        {

        }

        private void BtnCheckAll_Click(object sender, EventArgs e)
        {
            if (ClbColumnNames.Items.Count > 0)
            {
                for (int i = 0; i < ClbColumnNames.Items.Count; i++)
                {
                    ClbColumnNames.SetItemChecked(i, true);
                }
            }
        }

        private void BtnRemoveCheck_Click(object sender, EventArgs e)
        {
            var list = ClbColumnNames.CheckedItems;
            if (ClbColumnNames.CheckedItems.Count > 0)
            {
                for (int i = 0; i < ClbColumnNames.Items.Count; i++)
                {
                    if (ClbColumnNames.GetItemCheckState(i) == CheckState.Checked)
                    {
                        ClbColumnNames.Items.RemoveAt(i);
                    }
                }
            }
        }

        private void BtnClearAllCheck_Click(object sender, EventArgs e)
        {
            if (ClbColumnNames.CheckedItems.Count > 0)
            {
                for (int i = 0; i < ClbColumnNames.Items.Count; i++)
                {
                    ClbColumnNames.SetItemChecked(i, false);
                }
            }
        }
    }
}