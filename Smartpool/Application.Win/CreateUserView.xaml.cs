using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Smartpool.Application.Win;

namespace Application.Win
{
    /// <summary>
    /// Interaction logic for CreateUserView.xaml
    /// </summary>
    public partial class CreateUserView : Window
    {
        public CreateUserView()
        {
            InitializeComponent();
            ThemeProperties.SetPlaceholderText(NameTextBox, "Name");
            ThemeProperties.SetPlaceholderText(EmailTextBox, "E-mail");
            ThemeProperties.SetPlaceholderText(PasswordTextBox, "Password");
            ThemeProperties.SetPlaceholderText(RepeatPasswordTextBox, "Repeat password");

        }
    }
}
