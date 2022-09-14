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
    enum State { Insert, Update, Select };
    public partial class Form1 : Form
    {
        static State st = State.Select;
        public Form1()
        {
            InitializeComponent();
        }
        public DataGridView DataGridView1
        {
            get
            {
                return dataGridView1;
            }
            set
            {
                dataGridView1 = value;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сырьеDataSet.ViewСписокСырья". При необходимости она может быть перемещена или удалена.
            this.viewСписокСырьяTableAdapter.Fill(this.сырьеDataSet.ViewСписокСырья);

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Добавить
            try
            {
                queriesTableAdapter1.СписокСырья_Insert(textBox1.Text);
                this.viewСписокСырьяTableAdapter.Fill(this.сырьеDataSet.ViewСписокСырья);

            }
            catch (Exception)
            {

                MessageBox.Show("Заполните корректно текстовое поле!", "Предупреждение");
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //Удалить
            int id;
            DataRowView dt;

            dt = (DataRowView)this.viewСписокСырьяBindingSource.Current;
            id = (int)dt["Код_сырья"];
            try
            {
                queriesTableAdapter1.СписокСырья_Delete(id);
                this.viewСписокСырьяTableAdapter.Fill(this.сырьеDataSet.ViewСписокСырья);

            }
            catch (Exception)
            {

                MessageBox.Show("Выделите строку!", "Предупреждение");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Сохранить изменения
            int id;
            DataRowView dt;

            dt = (DataRowView)this.viewСписокСырьяBindingSource.Current;
            id = (int)dt["Код_сырья"];
            try
            {
                queriesTableAdapter1.СписокСырья_Update(id, textBox1.Text);
                this.viewСписокСырьяTableAdapter.Fill(this.сырьеDataSet.ViewСписокСырья);
            }
            catch (Exception)
            {

                MessageBox.Show("Заполните корректно текстовое поле!", "Предупреждение");
            }
        }
    }
}
