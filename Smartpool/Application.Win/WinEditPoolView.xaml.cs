//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  EN      Initial version with GUI
// 1.1  EN      Implemented presenter
// 1.11 EN      Fixed comboBox bugs
//========================================================================

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Smartpool.Application.Presentation;
using Smartpool.Connection.Client;
using Smartpool.Connection.Model;

//ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    /// <summary>
    /// Interaction logic for WinEditPoolView.xaml
    /// </summary>
    public partial class WinEditPoolView : Window, IEditPoolView
    {
        public WinEditPoolView()
        {
            InitializeComponent();
            PoolComboBox.ItemsSource = AvailablePoolsList;

            //UI related. Sets placeholder text
            ThemeProperties.SetPlaceholderText(NameTextBox, "Pool name");
            ThemeProperties.SetPlaceholderText(VolumeTextBox, "Volume in m^3");
            ThemeProperties.SetPlaceholderText(LengthTextBox, "Width");
            ThemeProperties.SetPlaceholderText(WidthTextBox, "Length");
            ThemeProperties.SetPlaceholderText(DepthTextBox, "Depth");

            //Sets up the tabBars event handlers
            SpTabControl1.OnShowStatButtonClicked += TabBarController.ShowStatButtonPressed;
            SpTabControl1.OnShowHistoryButtonClicked += TabBarController.ShowHistoryButtonPressed;
            SpTabControl1.OnShowAddPoolButtonClicked += TabBarController.ShowAddPoolButtonPressed;
            //SpTabControl1.OnShowEditPoolButtonClicked += TabBarController.ShowEditPoolButtonPressed;
            SpTabControl1.OnShowEditUserButtonClicked += TabBarController.ShowEditUserButtonPressed;

            string Ip = System.IO.File.ReadAllText("IpTextFile.txt");
            //Controller
            var clientMessager = new ClientMessenger(new SynchronousSocketClient(Ip));
            Controller = new EditPoolViewController(this, clientMessager);
            Controller.ViewDidLoad();
        }

        //IView Interface Implementation
        public IViewController Controller { get; set; }

        private IEditPoolViewController _specializedController => Controller as IEditPoolViewController;

        //UI Related. Allows user to enter pool properties
        private void PropertiesRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            VolumeTextBox.IsEnabled = false;
            LengthTextBox.IsEnabled = true;
            WidthTextBox.IsEnabled = true;
            DepthTextBox.IsEnabled = true;
        }

        //UI Related. Allows user to enter pool volume
        private bool _isStartup = true;
        private void VolumeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //Window crashes if the event is called during initialization
            if (_isStartup)
            {
                _isStartup = false;
                return;
            }
            VolumeTextBox.IsEnabled = true;
            LengthTextBox.IsEnabled = false;
            WidthTextBox.IsEnabled = false;
            DepthTextBox.IsEnabled = false;
        }

        //IEditPoolView implementation
        public void DisplayAlert(string title, string content)
        {
            MessageBox.Show(content, title);
        }

        public void SetNameText(string text)
        {
            NameTextBox.Text = text;
        }

        public void SetVolumeText(string volume)
        {
            VolumeTextBox.Text = volume;
        }

        public void SetSerialNumberText(string text)
        {
            SerialTextBlock.Text = "Moniter unit serial number: " + text;
        }

        public void ClearDimensionText()
        {
            LengthTextBox.Text = "";
            WidthTextBox.Text = "";
            DepthTextBox.Text = "";
        }

        public void SetSaveButtonEnabled(bool enabled)
        {
            EditButton.IsEnabled = enabled;
        }

        public void SetDeleteButtonEnabled(bool enabled)
        {
            DeleteButton.IsEnabled = enabled;
        }

        public void PoolUpdated()
        {
            MessageBox.Show("Pool edited succesfully", "Smartpool");
        }

        public void SetSelectedPoolIndex(int index)
        {
            PoolComboBox.SelectedIndex = index;
        }

        public List<string> AvailablePoolsList { get; set; } = new List<string>();
        public void SetAvailablePools(List<Tuple<string, bool>> pools)
        {
            PoolComboBox.ItemsSource = null;
            AvailablePoolsList.Clear();

            foreach (var pool in pools)
            {
                AvailablePoolsList.Add(pool.Item1);
            }
            PoolComboBox.ItemsSource = AvailablePoolsList;
        }

        //Events that call controller
        public void PoolComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = PoolComboBox.SelectedIndex;

            if (selected != -1)
            {
                _specializedController?.DidSelectPool(selected);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textField = sender as TextBox;

            if (textField != null && textField.Name == NameTextBox.Name)
            {
                _specializedController.DidChangeText(EditPoolTextField.PoolName, textField.Text);
            }
            else if (textField != null && textField.Name == VolumeTextBox.Name)
            {
                _specializedController.DidChangeText(EditPoolTextField.Volume, textField.Text);
            }
            else if (textField != null && textField.Name == LengthTextBox.Name)
            {
                _specializedController.DidChangeText(EditPoolTextField.Length, textField.Text);
            }
            else if (textField != null && textField.Name == WidthTextBox.Name)
            {
                _specializedController.DidChangeText(EditPoolTextField.Width, textField.Text);
            }
            else if (textField != null && textField.Name == DepthTextBox.Name)
            {
                _specializedController.DidChangeText(EditPoolTextField.Depth, textField.Text);
            }
        }

        private void EditButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            _specializedController.SaveButtonPressed();
        }

        private void DeleteButton_OnClickButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            _specializedController.DeleteButtonPressed();
        }

    }
}
