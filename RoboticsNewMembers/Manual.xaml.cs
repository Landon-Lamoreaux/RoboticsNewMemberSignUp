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
    /// Interaction logic for Manual.xaml
    /// </summary>
    public partial class Manual : UserControl, INotifyPropertyChanged
    {
        private string FileName = @"C:\Users\101060665\Documents\repos\RoboticsNewMembers\NewMemberList.txt";

        public string email = null;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string emailName = null;
        public string EmailName
        {
            get { return emailName; }
            set { emailName = value; OnPropertyChanged(nameof(EmailName)); }
        }

        public List<string> EmailList = new List<string>();
        public Manual()
        {
            InitializeComponent();
            DataContext = this;

            Email = "Example.Name@mines.sdsmt.edu";

            ConfirmButton.Visibility = Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnEnterClick(object sender, RoutedEventArgs e)
        {
            if(EmailName != null)
            {
                Email = EmailName + "\n";
                ConfirmButton.Visibility = Visibility.Visible;
            }
        }

        private void OnComfirmClick(object sender, RoutedEventArgs e)
        {
            EmailList.Add(Email);
            File.AppendAllText(FileName, Email);
            Email = "Example.Name@mines.sdsmt.edu";
            ConfirmButton.Visibility = Visibility.Collapsed;
            EmailName = null;
        }
    }
}
