using System;
using System.Windows.Forms;
using System.Data.Entity;
using System.Configuration;
using System.Data.EntityClient;

namespace EmployeesViewer
{
    public partial class DBConnectionString : Form
    {
        //DbContext базы данных
        private DbContext db;

        /// <summary>
        /// Конструктор формы по-умолчанию 
        /// </summary>
        /// <param name="statusList">Контекст текущей базы данных</param>
        public DBConnectionString(DbContext db)
        {
            InitializeComponent();
            this.db = db;
            textBoxValue.Text = db.Database.Connection.ConnectionString;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "ОK"
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            string oldConn = db.Database.Connection.ConnectionString;

            DbContext newDB = new DbContext(textBoxValue.Text);

            if (!newDB.Database.Exists())
            {
                MessageBox.Show("Подключение к базе данных, " + Environment.NewLine
                    + "с помощью введенной вами строки невозможно." + Environment.NewLine
                    + "Проверьте состояние сервера базы данных" + Environment.NewLine
                    + "или исправьте строку подключения.", "Просмотр данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                db.Database.Connection.ConnectionString = oldConn;
                return;
            }

            db.Database.Connection.ConnectionString = newDB.Database.Connection.ConnectionString;
            db.Database.Connection.Open();
            db.Database.Initialize(true);

            setNewConnectionString("testEntities", newDB.Database.Connection.ConnectionString);

            this.Close();
        }

        /// <summary>
        /// Сохранение строки подключения в файл конфигурации
        /// </summary>
        /// <param name="connStringName">Имя строки подключения</param>
        /// <param name="connString">Строка подключения</param>
        private static void setNewConnectionString(string connStringName, string connString)
        {
            // open config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // create new connectionString
            EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();
            ecb.Metadata = "res://*/EmpsModel.csdl|res://*/EmpsModel.ssdl|res://*/EmpsModel.msl";
            ecb.Provider = "System.Data.SqlClient";
            ecb.ProviderConnectionString = connString;
            
            // set new connectionstring in config
            config.ConnectionStrings.ConnectionStrings[connStringName].ConnectionString = ecb.ConnectionString;

            // save and refresh the config file
            config.Save(ConfigurationSaveMode.Minimal);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
