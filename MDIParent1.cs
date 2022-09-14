
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Raw_Material
{
    public partial class MDIParent1 : Form
    {
        private int childFormRawMaterial= 1;
        private int childFormLastYear= 1;
        private int childFormThisYear = 1;

        public MDIParent1()
        {
            InitializeComponent();
        }


        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //список сырья открыть
            Form childForm = new Form1
            {
                MdiParent = this,
                Text = "Таблица Список Сырья № " + childFormRawMaterial++
            };
            //childForm.DataGridView1 = 
            childForm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form childForm = new Form2
            {
                MdiParent = this,
                Text = "Таблица Поступление сырья № " + childFormThisYear++
            };
            childForm.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Form3
            {
                MdiParent = this,
                Text = "Таблица Поступление за прошлый год № " + childFormLastYear++
            };
            childForm.Show();

        }
    }
}
