using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeleMedic.Library
{
    public partial class HeaderUC : UserControl
    {
        public event EventHandler<EventArgs> OnButtonOpenClick;

        public HeaderUC()
        {
            InitializeComponent();
        }

        public string Title
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (OnButtonOpenClick != null)
                OnButtonOpenClick(this, e);
        }
    }
}
