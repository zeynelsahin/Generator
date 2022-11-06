using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.DataAccess.Concrete;
using Generator.Entities;

namespace Generator.UI.WF
{
    public partial class FormServiceMethodAdd : Form
    {
        private readonly string _classType;
        private readonly string _objectId;
        private readonly string _profileId;

        private readonly IServiceMethodService _serviceMethodService =
            new ServiceMethodService(new EfServiceMethodDal());

        public FormServiceMethodAdd(string objectId, string profileId, string classType)
        {
            _objectId = objectId;
            _profileId = profileId;
            _classType = classType;
            InitializeComponent();
        }

        private void FormServiceMethodAdd_Load(object sender, EventArgs e)
        {
            CbxObjectType.SelectedItem = _classType;
            DgwAdd.Rows.Add(_profileId, _objectId, "SERVICE", false, false, false, false, false, false, false, false,
                false, false);
            if (_classType == "CUSTOMSQL")
            {
                DgwAdd.Rows[0].Cells[10].Value = true;
            }
            else if (_classType == "TABLE")
            {
                DgwAdd.Rows[0].Cells[8].Value = true;
                DgwAdd.Rows[0].Cells[9].Value = true;
            }
        }

        private void BtnServiceMethodAdd_Click(object sender, EventArgs e)
        {
            LblSonuc.Text = "";
            if (CheckServiceMethodAdd())
            {
                LblSonuc.Text = "    Zaten ekli";
                return;
            }

            AddServiceMethod();
        }

        private void AddServiceMethod()
        {
            var serviceMethod = new ServiceMethod
            {
                ProfileId = DgwAdd.Rows[0].Cells[0].Value.ToString(),
                ObjectId = DgwAdd.Rows[0].Cells[1].Value.ToString(),
                ClassType = DgwAdd.Rows[0].Cells[2].Value.ToString(),
                GetMethodFlag = DgwAdd.Rows[0].Cells[3].Value.ConvertChar(),
                GetValidMethodFlag = DgwAdd.Rows[0].Cells[4].Value.ConvertChar(),
                GetPagedMethodFlag = DgwAdd.Rows[0].Cells[5].Value.ConvertChar(),
                GetPrimaryKeyMethodFlag = DgwAdd.Rows[0].Cells[6].Value.ConvertChar(),
                DeleteMethodFlag = DgwAdd.Rows[0].Cells[7].Value.ConvertChar(),
                CreateMethodFlag = DgwAdd.Rows[0].Cells[8].Value.ConvertChar(),
                ModifyMethodFlag = DgwAdd.Rows[0].Cells[9].Value.ConvertChar(),
                CustomMethodFlag = DgwAdd.Rows[0].Cells[10].Value.ConvertChar(),
                IndexMethodFlag = DgwAdd.Rows[0].Cells[11].Value.ConvertChar(),
                OnlyEntityFlag = DgwAdd.Rows[0].Cells[12].Value.ConvertChar()
            };
            _serviceMethodService.Add(serviceMethod);
        }

        private bool CheckServiceMethodAdd()
        {
            var result = _serviceMethodService.GetByObjectId(_objectId, _profileId);
            return result != null ? true : false;
        }

        private void List()
        {
            var result = _serviceMethodService.GetByObjectId(_objectId, _profileId);
            var list = new List<ServiceMethod> { result };
            DgwList.DataSource = list;
        }

        private void BtnServiceMethodList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void BtnOverrideAdd_Click(object sender, EventArgs e)
        {
            var result = _serviceMethodService.GetByObjectId(_objectId, _profileId);
            if (result != null)
            {
                _serviceMethodService.Delete(result);
                AddServiceMethod();
                LblSonuc.Text = "   Ezilerek eklendi";
            }
            else
            {
                AddServiceMethod();
                LblSonuc.Text = "";
            }

            List();
        }
    }
}