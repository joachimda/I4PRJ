using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MvvmFoundation.Wpf;

namespace Client
{
    public class LoginHandle : INotifyPropertyChanged
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool _loggedIn = false;

        public bool LoggedIn
        {
            get { return _loggedIn; }
            set { _loggedIn = value; }
        }

        private ClientCommands _clientCommands = new ClientCommands();


        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(LoginCommand_Execute)); }
        }

        private void LoginCommand_Execute()
        {
            LoggedIn = _clientCommands.Login(Username, Password);
        }

        private ICommand _getTempCommand;

        public ICommand GetTempCommand
        {
            get
            {
                return _getTempCommand ??
                       (_getTempCommand = new RelayCommand(GetTempCommand_Execute, GetTempCommand_CanExecute));
            }
        }

        private void GetTempCommand_Execute()
        {
            MessageBox.Show(_clientCommands.GetTemp());
        }

        private bool GetTempCommand_CanExecute()
        {
            return LoggedIn;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}