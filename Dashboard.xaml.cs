
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class Dashboard : Page
    {
        public ObservableCollection<HighLander> Cards { get; set; }
        public Dashboard()
        {
            this.InitializeComponent();
            for (int i = 1; i <= 10; i++)
            {
                cmbSize.Items.Add(new ComboBoxItem { Content = i });
            }
            for (int i = 1; i <= 10; i++)
            {
                cmbGood.Items.Add(new ComboBoxItem { Content = i });
            }
            for (int i = 1; i <= 10; i++)
            {
                cmbBad.Items.Add(new ComboBoxItem { Content = i });
            }
            for (int i = 1; i <= 10; i++)
            {
                cmbSimulation.Items.Add(new ComboBoxItem { Content = i });
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSize.SelectedItem != null)
            {
                // Handle the selection change here
                int selectedOption = (int)((ComboBoxItem)cmbSize.SelectedItem).Content;

                // Your logic here...
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HighlanderInfo));
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
           
            if (sender == rbUser )
            {
                hiddenStackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                hiddenStackPanel.Visibility = Visibility.Collapsed;
            }
        }
    }
}
