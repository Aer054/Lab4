using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab4
{
     class RegisterViewModel: INotifyPropertyChanged
    {
        public ICommand Register { set; get; }
        public ICommand Cancel { set; get; }
        RegisterWindow registerWindow;
        public RegisterViewModel(RegisterWindow RegisterWindow)
        {
            registerWindow = RegisterWindow;
            Register = new RelayCommand(Command_Execute_Register);
            Cancel=new RelayCommand(Command_Execute_Cancel);
        }
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=LAPTOP-SH450TIA\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=TEST;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }
        private async void Command_Execute_Cancel(object parameter)
        { 
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            registerWindow.Close();
        }
            private async void Command_Execute_Register(object parameter)
        {
            if (registerWindow.LoginTextBox.Text.Length > 0) // проверяем логин
               {
                if (registerWindow.PasswordBox.Password.Length > 0) // проверяем пароль
	            {
                    string login = registerWindow.LoginTextBox.Text;
                    string password = registerWindow.PasswordBox.Password;
                    string name=registerWindow.NameTextBox.Text;
                    DataTable dt_user = Select("INSERT INTO [dbo].[Users0] VALUES ('" + login+"', '"+password+"','"+name+"','0','0','0','','0','','')");
                    dt_user = Select("SELECT * FROM [dbo].[Users0] WHERE [login] = '" + login + "' AND [password] = '" + password + "'");
                    Window1 Window = new Window1(dt_user);
                    Window.Show();
                    registerWindow.Close();
                }
                else MessageBox.Show("Укажите пароль");
            }else MessageBox.Show("Укажите логин");

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
