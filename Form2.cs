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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сырьеDataSet.ViewСписокСырья". При необходимости она может быть перемещена или удалена.
            this.viewСписокСырьяTableAdapter.Fill(this.сырьеDataSet.ViewСписокСырья);

            this.view_Поступление_сырья_с_наименованиемTableAdapter.Fill(this.сырьеDataSet.View_Поступление_сырья_с_наименованием);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id;
                DataRowView dt;
                dt = (DataRowView)this.viewПоступлениесырьясНаименованиемBindingSource.Current;
                if (dt != null)
                {
                    id = (int)dt["Код_сырья"];
                    comboBox1.SelectedValue = id;
                }
            }
            catch (Exception)
            {
                //Что-то пошло не так
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //добавить
            try
            {
                int idRM = (int)comboBox1.SelectedValue;
                double Plan = Convert.ToDouble(textBox2.Text);
                double Actual = Convert.ToDouble(textBox3.Text);

                queriesTableAdapter1.ПоступлениеСырья_Insert(idRM, Plan, Actual);
                this.view_Поступление_сырья_с_наименованиемTableAdapter.Fill(this.сырьеDataSet.View_Поступление_сырья_с_наименованием);

            }
            catch (Exception)
            {
                MessageBox.Show("Заполните корректно текстовые поля!", "Предупреждение");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //Удалить
            int id;
            DataRowView dt;

            dt = (DataRowView)this.viewПоступлениесырьясНаименованиемBindingSource.Current;
            id = (int)dt["Код_поставки"];
            try
            {
                queriesTableAdapter1.ПоступлениеСырья_Delete(id);
                this.view_Поступление_сырья_с_наименованиемTableAdapter.Fill(this.сырьеDataSet.View_Поступление_сырья_с_наименованием);
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

            dt = (DataRowView)this.viewПоступлениесырьясНаименованиемBindingSource.Current;
            id = (int)dt["Код_поставки"];
            try
            {
                int idRM = (int)comboBox1.SelectedValue;
                double Plan = Convert.ToDouble(textBox2.Text);
                double Actual = Convert.ToDouble(textBox3.Text);
                queriesTableAdapter1.ПоступлениеСырья_Update(id, idRM, Plan, Actual);
                this.view_Поступление_сырья_с_наименованиемTableAdapter.Fill(this.сырьеDataSet.View_Поступление_сырья_с_наименованием);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение");
            }
        }
    }
}
