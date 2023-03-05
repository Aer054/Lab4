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
     class ProfileViewModel : INotifyPropertyChanged
    {
        private DataTable dt_user;
        private MainWindow mainWindow;
      
        public ICommand Enter { set; get; }
        public ICommand Register { set; get; }
        private async void Command_Execute_Enter(object parameter)
        {
            if (mainWindow.TextBoxLogin.Text.Length > 0) // проверяем введён ли логин     
            {
                if (mainWindow.PasswordBox.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными         
                    DataTable dt_user = Select("SELECT * FROM [dbo].[Users0] WHERE [login] = '" + mainWindow.TextBoxLogin.Text + "' AND [password] = '" + mainWindow.PasswordBox.Password + "'");
                    if (dt_user.Rows.Count > 0) // если такая запись существует       
                    {
                        Window1 Window = new Window1(dt_user);
                        Window.Show();
                        Application.Current.MainWindow.Close(); 
                    }
                    else MessageBox.Show("Пользователя не найден"); // выводим ошибку  
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку    
            }
            else MessageBox.Show("Введите логин");
        }
        private async void Command_Execute_Register(object parameter)
        {
            RegisterWindow register = new RegisterWindow();
            register.Show();
            mainWindow.Close();

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
        public ProfileViewModel(MainWindow MainWindow)
        {
           dt_user = Select("SELECT * FROM [dbo].[Users0]"); // получаем данные из таблицы
           Enter = new RelayCommand(Command_Execute_Enter);
           Register = new RelayCommand(Command_Execute_Register);
           mainWindow=MainWindow;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
