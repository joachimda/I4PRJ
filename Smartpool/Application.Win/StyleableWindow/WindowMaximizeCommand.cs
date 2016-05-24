using System;
using System.Windows;
using System.Windows.Input;

namespace WpfStyleableWindow.StyleableWindow
{
    public class WindowMaximizeCommand :ICommand
    {     

        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning disable 67

        public void Execute(object parameter)
        {
            var window = parameter as Window;

            if (window != null)
            {
                if(window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                }                
            }
        }
    }
}
