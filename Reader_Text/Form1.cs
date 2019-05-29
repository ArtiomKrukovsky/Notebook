using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reader_Text
{
    public interface IMainView
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetCount(int count);
        event EventHandler Btn_Select;
        event EventHandler Btn_Save;
        event EventHandler Btn_Open;
        event EventHandler ContentChanget;
    }

    public partial class Main : Form, IMainView
    {
        public Main()
        {
            InitializeComponent();
            btn_Open.Click += Btn_Open_Click;
            btn_save.Click += Btn_save_Click;
            btn_select.Click += Btn_select_Click;
            Main_Page.TextChanged += Main_Page_TextChanged;
        }

        private void Main_Page_TextChanged(object sender, EventArgs e)
        {
            ContentChanget?.Invoke(this, EventArgs.Empty);
        }

        private void Btn_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовые файлы|*.txt| Все файлы|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TB_Path.Text = ofd.FileName;
                if (Btn_Open != null) Btn_Open(this, EventArgs.Empty);
            }
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            Btn_Save?.Invoke(this, EventArgs.Empty);
        }

        private void Btn_Open_Click(object sender, EventArgs e)
        {
            Btn_Open?.Invoke(this, EventArgs.Empty);
        }

        public string FilePath
        {
            get { return TB_Path.Text; }
        }

        public string Content
        {
            get { return Main_Page.Text; }
            set { Main_Page.Text = value; }
        }

        public event EventHandler Btn_Select;
        public event EventHandler Btn_Save;
        public event EventHandler Btn_Open;
        public event EventHandler ContentChanget;

        public void SetCount(int count)
        {
            toolStripStatusLabel2.Text = count.ToString();
        }
    }
}
