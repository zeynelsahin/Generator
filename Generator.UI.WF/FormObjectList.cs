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
    public partial class FormObjectList : Form
    {
        public FormObjectList(Profile profile)
        {
            _profile = profile;
            InitializeComponent();
        }

        private Profile _profile;
        private IObjectEntityService _objectEntityService = new ObjectEntityService(new EfObjectEntityDal());

      
    }
}
