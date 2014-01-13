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
    public partial class StatParamsChooseForm : Form
    {
        /// <summary>
        /// Тип делегата функции отображения данных
        /// </summary>
        /// <param name="b_period">Начало периода</param>
        /// <param name="e_period">Окончание периода</param>
        /// <param name="status">Статус</param>
        /// <param name="hireStatus">Действующие/уволенные сотрудники</param>
        public delegate void OpenData(DateTime b_period, DateTime e_period, string status, int hireStatus);

        /// <summary>
        /// Переменная делегата
        /// </summary>
        private OpenData listOfOpenData;

        /// <summary>
        /// Конструктор формы по-умолчанию 
        /// </summary>
        /// <param name="statusList">Список возможных статусов</param>
        public StatParamsChooseForm(string[] statusList)
        {
            InitializeComponent();
            if (statusList != null)
            {
                comboBoxStatus.Items.AddRange(statusList);
                comboBoxStatus.SelectedIndex = 0;
                comboBoxHire.SelectedIndex = 0;
                beginPeriod.Value = DateTime.Parse("1990-01-01");
                endPeriod.Value = DateTime.Now;
            }

        }

        /// <summary>
        /// Регистрация функций обратного вызова
        /// </summary>
        /// <param name="od">Функция обратного вызова</param>
        public void RegisterOpenDataFunc(OpenData od)
        {
            listOfOpenData += od;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "ОK"
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (listOfOpenData != null)
            {
                listOfOpenData(beginPeriod.Value, endPeriod.Value,
                    comboBoxStatus.Text, comboBoxHire.SelectedIndex);
                this.Close();
            }
        }


    }
}
