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

    public sealed partial class HighlanderInfo : Page
    {
        public ObservableCollection<CardViewModel> Cards { get; set; }
        public HighlanderInfo()
        {
            this.InitializeComponent();
            GenerateDynamicCards();
        }
        private void CardListView_Loaded(object sender, RoutedEventArgs e)
        {
            SetupParallaxScrolling();
        }

        private void SetupParallaxScrolling()
        {
            ScrollViewer scrollViewer = GetScrollViewer(CardListView);

            if (scrollViewer != null)
            {
                var scrollProperties = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(scrollViewer);

                var translationAnimation = scrollProperties.Compositor.CreateExpressionAnimation("Clamp(-Manipulation.Translation.Y / 2, -500, 0)");
                translationAnimation.SetReferenceParameter("Manipulation", scrollProperties);

                foreach (var item in CardListView.ItemsPanelRoot.Children)
                {
                    if (item is ListViewItem listViewItem)
                    {
                        var elementVisual = ElementCompositionPreview.GetElementVisual(listViewItem);
                        elementVisual.StartAnimation("Offset.Y", translationAnimation);
                    }
                }
            }
        }

        private ScrollViewer GetScrollViewer(DependencyObject depObj)
        {
            if (depObj is ScrollViewer scrollViewer)
            {
                return scrollViewer;
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = GetScrollViewer(child);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
        private void GenerateDynamicCards()
        {
            // Ensure that Cards is not null before adding items
            if (Cards == null)
            {
                Cards = new ObservableCollection<CardViewModel>();
            }
            //information from database
            for(var i = 0; i < 20; i++)
            {
                // Sample card information
                Cards.Add(new CardViewModel { Title = "Hl" + i, Description = "Description" + i });
      
            }
            
            
          
            // Set the ObservableCollection as the data source for the ListView
            CardListView.ItemsSource = Cards;
        }

        private void CardListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
