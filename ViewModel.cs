using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
     class ViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<string> gender=new ObservableCollection<string>();
        private ObservableCollection<string> activity=new ObservableCollection<string>();
        private Model currentAccount;
        private DataTable User;
        private bool isEnabled;
        #region
        public bool IsEnabled
        {
            get { return isEnabled; }
        }
        public Model CurrentAccount
        {
            get { return currentAccount; }
        }
        public ObservableCollection<string> Gender
        {
            get { return gender; }
        }public ObservableCollection<string> Activity
        {
            get { return activity; }
        }
        #endregion gettrs
        public ICommand Save { set; get; }
        public ICommand Change { set; get; }
        public ICommand Ok { set; get; }
        private async void Command_Execute_Save(object parameter)
        {
            isEnabled = false;
            currentAccount.WhatTypeOfBody();
            User = Select("UPDATE [dbo].[Users0] SET age = '" + currentAccount.Age + "', height = '" + currentAccount.Height + "', weight = '" + currentAccount.Weight + "',bodyType = '"
                + currentAccount.BodyType + "', calories = '" + currentAccount.Calories + "', gender='" + currentAccount.Gender + "', activity='" + currentAccount.Activity + "' WHERE login='"+ User.Rows[0][0] + "';");
            OnPropertyChanged("IsEnabled");
            OnPropertyChanged("CurrentAccount");
        }
        private async void Command_Execute_Ok(object parameter)
        {
            currentAccount.HowManyCalories();
            currentAccount.GetEattingPlan();
            OnPropertyChanged("CurrentAccount");
        }
        private async void Command_Execute_Change(object parameter)
        {
            isEnabled = true;
            OnPropertyChanged("IsEnabled");
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
        public ViewModel(DataTable dt_user)
        {
            Ok = new RelayCommand(Command_Execute_Ok);
            Save = new RelayCommand(Command_Execute_Save);
            Change = new RelayCommand(Command_Execute_Change);
            User = dt_user;
            string Name = (string)dt_user.Rows[0][2];
            int Age= int.Parse((string)dt_user.Rows[0][3]);
            double Height= double.Parse((string)dt_user.Rows[0][4]);
            double Weight= double.Parse((string)dt_user.Rows[0][5]);
            string bodyType = (string)dt_user.Rows[0][6];
            double calories = double.Parse((string)dt_user.Rows[0][7]);
            string gender0 = (string)dt_user.Rows[0][8];
            string activity0 = (string)dt_user.Rows[0][9];
            currentAccount =new Model(Name,Age,Height,Weight,bodyType,calories,gender0,activity0);
            
            isEnabled = true;
            gender.Add("Мужской");
            gender.Add("Женский");
            activity.Add("Низкая");
            activity.Add("Средняя");
            activity.Add("Высокая");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
