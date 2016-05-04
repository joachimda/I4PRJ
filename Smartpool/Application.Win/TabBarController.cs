﻿//========================================================================
// DESCR.   :   Controller/Presenter for the TabBar
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  EN      Initial version with functions
//========================================================================

using System.ComponentModel.Design;
using System.Linq;
using System.Windows;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    public class TabBarController
    {
        internal static void ShowStatButtonPressed(object sender, RoutedEventArgs e)
        {
            Window activeWindow = GetActiveWindow();
            Window view = new WinStatView();
            
            view.Left = activeWindow.Left;
            view.Top = activeWindow.Top;
            view.Show();

            activeWindow.Close();
        }

        internal static void ShowHistoryButtonPressed(object sender, RoutedEventArgs e)
        {
            Window activeWindow = GetActiveWindow();
            /*Window view = new WinAddPoolView();

            view.Left = activeWindow.Left;
            view.Top = activeWindow.Top;
            view.Show();*/
            MessageBox.Show("Show Historyl\nFix this in TabBarController.cs");
            activeWindow.Close();
        }

        internal static void ShowAddPoolButtonPressed(object sender, RoutedEventArgs e)
        {
            Window activeWindow = GetActiveWindow();
            Window view = new WinAddPoolView();

            view.Left = activeWindow.Left;
            view.Top = activeWindow.Top;
            view.Show();
            activeWindow.Close();
        }

        internal static void ShowEditPoolButtonPressed(object sender, RoutedEventArgs e)
        {
            Window activeWindow = GetActiveWindow();
            /*Window view = new WinAddPoolView();

            view.Left = activeWindow.Left;
            view.Top = activeWindow.Top;
            view.Show();*/
            MessageBox.Show("Show Edit Pool\nFix this in TabBarController.cs");
            activeWindow.Close();
        }

        private static Window GetActiveWindow()
        {
            return System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        }
    }
}