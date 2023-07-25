using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace RoboticsNewMembers
{
    /// <summary>
    /// Interaction logic for Auto.xaml
    /// </summary>
    public partial class Auto : UserControl, INotifyPropertyChanged
    {
        private string FileName = @"C:\Users\101060665\Documents\repos\RoboticsNewMembers\NewMemberList.txt";

        public string firstName = null;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }
        public string lastName = null;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        public string email = null;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }

        public List<string> EmailList = new List<string>();
        public Thread ProcessLoop;
        public Auto()
        {
            InitializeComponent();
            DataContext = this;

            Email = "Example.Name@mines.sdsmt.edu";

            ProcessLoop = new Thread(ProcessLoopFunction);
            ProcessLoop.IsBackground = true;
            ProcessLoop.Start();

            ConfirmButton.Visibility = Visibility.Collapsed;
        }

        private void ProcessLoopFunction()
        {
            while (true)
            {
                if (FirstName != null && LastName != null)
                {
                    Email = FirstName + "." + LastName + "@mines.sdsmt.edu\n";
                }
                Thread.Sleep(100);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnEnterClick(object sender, RoutedEventArgs e)
        {
            if(Email != "Example.Name@mines.sdsmt.edu")
                ConfirmButton.Visibility = Visibility.Visible;
        }

        private void OnComfirmClick(object sender, RoutedEventArgs e)
        {
            EmailList.Add(Email);
            File.AppendAllText(FileName, Email);
            FirstName = null;
            LastName = null;
            Email = "Example.Name@mines.sdsmt.edu";
            ConfirmButton.Visibility = Visibility.Collapsed;
        }
    }
}
