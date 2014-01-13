using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmployeesViewer
{
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Тип делегата функции фильтрации данных
        /// </summary>
        /// <param name="columnNum">Номер столбца</param>
        /// <param name="value">Шаблон текста для поиска</param>
        public delegate void FilterFunc(int columnNum, string value);

        /// <summary>
        /// Переменная делегата
        /// </summary>
        private FilterFunc listOfFilterFunc;

        /// <summary>
        /// Конструктор формы по-умолчанию 
        /// </summary>
        /// <param name="statusList">Список названий колонок с данными</param>
        public FilterForm(string columnList)
        {
            InitializeComponent();
            if (columnList != null)
            {
                string[] values = columnList.Split(';');
                comboBoxColumnList.Items.AddRange(values);
                comboBoxColumnList.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// Регистрация функций обратного вызова
        /// </summary>
        /// <param name="od">Функция обратного вызова</param>
        public void RegisterFilterFunc(FilterFunc ff)
        {
            listOfFilterFunc += ff;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "ОK"
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxValue.Text.Length > 0)
            {
                if (listOfFilterFunc != null)
                {
                    listOfFilterFunc(comboBoxColumnList.SelectedIndex, textBoxValue.Text);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Введите значение для фильтрации данных", "Фильтр данных", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
