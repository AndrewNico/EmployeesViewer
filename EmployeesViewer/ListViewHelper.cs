using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmployeesViewer
{
    /// <summary>
    /// Данный класс наделяет ListView дополнительными функциями
    /// </summary>
    class ListViewHelper
    {
        //Ссылка на сам объект
        public ListView Lv { get; set; }
        //Строка со списком заголовков
        public string Headers { get; set; }
        //Ссылка на класс-сортировщик
        private ListViewColumnSorter lvwColumnSorter;
        //Теневая копия данных, для фильтрации
        private List<ListViewItem> shadowData;
        
        /// <summary>
        /// Конструктор формы по-умолчанию 
        /// </summary>
        /// <param name="lv">Ссылка на объект ListView</param>
        public ListViewHelper(ListView lv)
        {
            this.Lv = lv;
        }

        /// <summary>
        /// Отображение данных ListView пользователю
        /// </summary>
        /// <param name="data">Коллекция данных</param>
        public void Show(List<ListViewItem> data)
        {
            createStructure();
            shadowData = data;
            Lv.Items.Clear();
            Lv.Items.AddRange(data.ToArray<ListViewItem>());
            autosizeListViewColumns();
            lvwColumnSorter = new ListViewColumnSorter();
            this.Lv.ListViewItemSorter = lvwColumnSorter;
            Lv.ColumnClick += new ColumnClickEventHandler(ColumnClick);
        }

        /// <summary>
        /// Создание структуры столбцов
        /// </summary>
        private void createStructure()
        {
            if (Headers.Length > 0)
            {
                string[] hdrs = Headers.Split(';');

                Lv.Columns.Clear();

                foreach (string hdr in hdrs)
                {
                    Lv.Columns.Add(hdr);
                }
            }
        }

        /// <summary>
        /// Содержит ли ListView данные?
        /// </summary>
        public bool HasData()
        {
            return Lv.Items.Count > 0;
        }

        /// <summary>
        /// Включение фильтра данных
        /// </summary>
        /// <param name="columnNum">Номер столбца</param>
        /// <param name="value">Текстовый шаблон для поиска</param>
        public void FilterOn(int columnNum, string value)
        {
            List<ListViewItem> filteredData = new List<ListViewItem>();

            foreach (ListViewItem item in Lv.Items)
            {
                if (compareItem(columnNum, value, item))
                    filteredData.Add(item);
            }

            Lv.Items.Clear();
            Lv.Items.AddRange(filteredData.ToArray<ListViewItem>());
        }

        /// <summary>
        /// Выключение фильтра
        /// </summary>
        public void FilterOff()
        {
            if (shadowData != null)
            {
                Lv.Items.Clear();
                Lv.Items.AddRange(shadowData.ToArray<ListViewItem>());
            }
        }

        /// <summary>
        /// Сравнение данных с шаблоном
        /// </summary>
        /// <param name="columnNum">Номер колонки для сравнения</param>
        /// <param name="value">Текстовый шаблон для поиска</param>
        /// <param name="lvi">Элемент данных</param>
        /// <returns>Найдены ли совпадения</returns>
        private bool compareItem(int columnNum, string value, ListViewItem lvi)
        {
            if (columnNum == 0)
                return lvi.Text.ToLower().Contains(value.ToLower());
            else
                return lvi.SubItems[columnNum].Text.ToLower().Contains(value.ToLower());
        }

        /// <summary>
        /// Установить автоматическую ширину колонок с данными
        /// </summary>
        private void autosizeListViewColumns()
        {
            foreach (ColumnHeader ch in Lv.Columns)
            {
                ch.Width = -1;
            }
        }

        // ColumnClick event handler.
        private void ColumnClick(object o, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.Lv.Sort();
        }
    }
}
