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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SWDStatView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WinStatView : Window
    {
        public WinStatView()
        {
            InitializeComponent();
        }

        private void StatViewer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Do you want set target value?\nPress 'Yes' to enter settings.", "Target value", MessageBoxButton.YesNo);
        }
    }
}
