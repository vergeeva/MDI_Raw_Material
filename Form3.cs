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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сырьеDataSet.ViewСписокСырья". При необходимости она может быть перемещена или удалена.
            this.viewСписокСырьяTableAdapter.Fill(this.сырьеDataSet.ViewСписокСырья);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "сырьеDataSet.View_Прошлый_год_с_наименованием". При необходимости она может быть перемещена или удалена.
            this.view_Прошлый_год_с_наименованиемTableAdapter.Fill(this.сырьеDataSet.View_Прошлый_год_с_наименованием);

        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Сохранить
            int id;
            DataRowView dt;

            dt = (DataRowView)this.viewПрошлыйгодсНаименованиемBindingSource.Current;
            id = (int)dt["Код"];
            try
            {
                int idRM = (int)comboBox1.SelectedValue;
                double Postuplenie = Convert.ToDouble(textBox1.Text);

                queriesTableAdapter1.ПрошлыйГод_Update(id, idRM, Postuplenie);
                this.view_Прошлый_год_с_наименованиемTableAdapter.Fill(this.сырьеDataSet.View_Прошлый_год_с_наименованием);

            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id;
                DataRowView dt;
                dt = (DataRowView)this.viewПрошлыйгодсНаименованиемBindingSource.Current;
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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //Добавить
            try
            {
                int idRM = (int)comboBox1.SelectedValue;
                double Postuplenie = Convert.ToDouble(textBox1.Text);

                queriesTableAdapter1.ПрошлыйГод_Insert(idRM, Postuplenie);
                this.view_Прошлый_год_с_наименованиемTableAdapter.Fill(this.сырьеDataSet.View_Прошлый_год_с_наименованием);


            }
            catch (Exception)
            {
                MessageBox.Show("Заполните корректно текстовые поля!", "Предупреждение");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Удалить
            int id;
            DataRowView dt;

            dt = (DataRowView)this.viewПрошлыйгодсНаименованиемBindingSource.Current;
            id = (int)dt["Код"];
            try
            {
                queriesTableAdapter1.ПрошлыйГод_Delete(id);
                this.view_Прошлый_год_с_наименованиемTableAdapter.Fill(this.сырьеDataSet.View_Прошлый_год_с_наименованием);
            }
            catch (Exception)
            {
                MessageBox.Show("Выделите строку!", "Предупреждение");
            }
        }
    }
}
