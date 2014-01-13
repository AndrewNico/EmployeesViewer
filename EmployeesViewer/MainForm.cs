using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmployeesViewer
{
    public partial class MainForm : Form
    {
        //Список столбцов для отображения списка сотрудников
        private const string empListHeader = "ФИО;Статус;Департамент;Должность;Принят;Уволен";
        //Список столбцов для отображения статистики по сотрудникам
        private const string statsListHeader = "Дата;Количество";
        //DbContext базы данных
        private testEntities te;
        //Вспомогательные функции для ListView
        private ListViewHelper lvdc;

        /// <summary>
        /// Конструктор формы по-умолчанию 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            setIcons();
            te = new testEntities();
            lvdc = new ListViewHelper(this.listView);
            checkDBConnection();
            dataGetterEnable();
        }

        /// <summary>
        /// Установка иконок для элементов панели инструментов
        /// </summary>
        private void setIcons()
        {
            //Иконки тулбара
            buttonDBConnection.Image = ((Bitmap)mainImageList32.Images["database-info"]);
            buttonShowEmployees.Image = ((Bitmap)mainImageList32.Images["report-user"]);
            buttonShowStats.Image = ((Bitmap)mainImageList32.Images["calendar_selection"]);
            buttonDataFilter.Image = ((Bitmap)mainImageList32.Images["filter"]);

        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Отобразить список сотрудников"
        /// </summary>
        private void buttonShowEmployees_Click(object sender, EventArgs e)
        {
            showEmployeesInfo();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Фильтр данных"
        /// </summary>
        private void buttonDataFilter_Click(object sender, EventArgs e)
        {
            if (lvdc.Headers.Count() > 0)
            {
                FilterForm frm = new FilterForm(lvdc.Headers);

                if (buttonDataFilter.Checked)
                {
                    //lvdc.FilterOn(1, "Статус 1");
                    frm.RegisterFilterFunc(lvdc.FilterOn);
                    frm.ShowDialog(this);
                }
                else
                    lvdc.FilterOff();
            }

        }

        /// <summary>
        /// Включает доступ к кнопке фильтрации данных, в зависимости от наличия данных в ListView
        /// </summary>
        private void filterEnable()
        {
            buttonDataFilter.Enabled = lvdc.HasData();
        }

        /// <summary>
        /// Включает доступ к кнопкам отображения данных, в зависимости от подключения к БД
        /// </summary>
        private void dataGetterEnable()
        {
            //buttonShowEmployees.Enabled = buttonShowStats.Enabled = te.Database.Exists();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Отобразить статистику по сотрудникам"
        /// </summary>
        private void buttonShowStats_Click(object sender, EventArgs e)
        {
            try
            {
                string[] values = (from c in te.status
                                   select c.name).ToArray();
                StatParamsChooseForm param = new StatParamsChooseForm(values);
                param.RegisterOpenDataFunc(showStats);
                param.ShowDialog(this);
            }
            catch (Exception ex)
            {
                showErrStack(ex);
            }

        }

        /// <summary>
        /// Функция отображения статистики по сотрудникм
        /// </summary>
        /// <param name="b_period">Дата начала периода</param>
        /// <param name="e_period">Дата окончания периода</param>
        /// <param name="status">Статус</param>
        /// <param name="hireStatus">Действующие/уволенные сотрудники</param>
        private void showStats(DateTime b_period, DateTime e_period, string status, int hireStatus)
        {
            try
            {
                lvdc.Headers = statsListHeader;
                var data = (from c in te.GetEmpsStats(b_period, e_period, status, hireStatus)
                            select c).ToArray();

                List<ListViewItem> items = new List<ListViewItem>();

                foreach (var rec in data)
                {
                    ListViewItem lvi = new ListViewItem(rec.date_per);
                    lvi.ImageKey = "user_id";
                    lvi.SubItems.Add(rec.emp_cou.ToString());
                    items.Add(lvi);
                }

                lvdc.Show(items);
                filterEnable();
            }
            catch (Exception e)
            {
                showErrStack(e);
            }
        }

        /// <summary>
        /// Функция отображения информации по сотрудникм
        /// </summary>
        private void showEmployeesInfo()
        {
            try
            {
                lvdc.Headers = empListHeader;
                var data = (from c in te.GetEmployeesList()
                            select c).ToArray();

                List<ListViewItem> items = new List<ListViewItem>();

                foreach (var rec in data)
                {
                    ListViewItem lvi = new ListViewItem(rec.emp_fullname);
                    lvi.ImageKey = "user_id";
                    lvi.SubItems.Add(rec.emp_status);
                    lvi.SubItems.Add(rec.emp_dept);
                    lvi.SubItems.Add(rec.emp_post);
                    lvi.SubItems.Add(rec.date_emp);
                    lvi.SubItems.Add(rec.date_unemp);
                    items.Add(lvi);
                }

                lvdc.Show(items);
                filterEnable();
            }
            catch (Exception e)
            {
                showErrStack(e);
            }
        }

        /// <summary>
        /// Проверка соединения с базой данных
        /// </summary>
        /// <returns></returns>
        private bool checkDBConnection()
        {
            bool result = te.Database.Exists();
            if (!result)
            {
                MessageBox.Show("Соединение с базой данных отсутствует." + Environment.NewLine
                    + "Проверьте состояние сервера базы данных" + Environment.NewLine
                    + "или исправьте строку подключения.", "Просмотр данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Изменить строку подключения"
        /// </summary>
        private void buttonDBConnection_Click(object sender, EventArgs e)
        {
            DBConnectionString frm = new DBConnectionString(te);
            frm.ShowDialog(this);
            te.Database.Initialize(true);
        }

        /// <summary>
        /// Отображает сообщения об ошибке по всему стеку 
        /// </summary>
        /// <param name="e">Объект ошибки</param>
        private void showErrStack(Exception e)
        {
            string err = e.Message + Environment.NewLine;
            Exception tmp = e;

            while (tmp.InnerException != null)
            {
                tmp = tmp.InnerException;
                err = err + tmp.Message + Environment.NewLine;
            }

            MessageBox.Show(err, "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
