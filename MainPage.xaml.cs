
using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Color = Windows.UI.Color;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        ObservableCollection<ObservableCollection<ButtonData>> data = new ObservableCollection<ObservableCollection<ButtonData>>();
        // List<List<ButtonData>> data = new List<List<ButtonData>>();
        static Random random = new Random();
        static int gridSize = 10;
        static int roundMove = 0;
        static int exitValue = 1;
        HighLander fightWinner = null;
        static int moveActionRandom1;
        static int moveActionRandom2;
        static int currentX1 = random.Next(0, gridSize);
        static int currentY1 = random.Next(0, gridSize);
        static int currentX2 = random.Next(0, gridSize);
        static int currentY2 = random.Next(0, gridSize);

        HighLander hl1 = new HighLander(1, "hl1", 50, "Good", currentX1, currentY1);
        HighLander hl2 = new HighLander(2, "hl2", 80, "Bad", currentX2, currentY2);
        public Button startGameButton;

        public MainPage()
        {

            this.InitializeComponent();
            //this.Frame.Navigate(typeof(HighlanderInfo));
            CreateStartGameButton();
            setGrid(10, 10);
       

        }
        private SolidColorBrush GetRandomColorBrush(Random random)
        {
            byte[] rgb = new byte[3];
            random.NextBytes(rgb);

            Color randomColor = Color.FromArgb(255, rgb[0], rgb[1], rgb[2]);

            // Create a SolidColorBrush using the random color
            return new SolidColorBrush(randomColor);
        }
        private void  setGrid(int row, int col)
        {
          
            Random random = new Random();
            LinkedList<HighLander>[,] grid = new LinkedList<HighLander>[row, col];
        
            int targetRow = hl1.getX();
            int targetCol = hl1.getY();


            for (int i = 0; i < row; i++)
            {
                
                String number = null;
                SolidColorBrush colorBrush = null;

                ObservableCollection<ButtonData> rowButtonData = new ObservableCollection<ButtonData>();

                for (int j = 0; j < col; j++)
                {
                    // Set the background color based on whether the row or column is odd/even
                    if (i % 2 == 0) // Even row
                    {
                        if (j % 2 == 0) // Even column
                        {
                            colorBrush = new SolidColorBrush(Windows.UI.Colors.DarkBlue);
                        }
                        else // Odd column
                        {
                            colorBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
                        }
                    }
                    else // Odd row
                    {
                        if (j % 2 == 0) // Even column
                        {
                            colorBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
                        }
                        else // Odd column
                        {
                            colorBrush = new SolidColorBrush(Windows.UI.Colors.DarkBlue);
                        }
                    }
                    rowButtonData.Add(new ButtonData { Number = number, Background = colorBrush,ForeGround=colorBrush });



                }

                data.Add(rowButtonData);


            }
          
            // Calculate the desired width and height for the ItemsControl
            double itemsControlWidth = col * 50; // Adjust the width based on your button size
            double itemsControlHeight = row * 50; // Adjust the height based on your button size

            // Set the size of the ItemsControl
       lst.Width = double.NaN; // Auto width
    lst.Height = double.NaN; // Auto height
            
           
            lst.ItemsSource = data;
        
            lst.Margin = new Thickness(100, 10, 100, 0); // Adjust the margin as needed
            lst.HorizontalAlignment = HorizontalAlignment.Center;

            // Check if the indices are within the range
            if (targetRow >= 0 && targetRow < data.Count && targetCol >= 0 && targetCol < data[targetRow].Count)
            {
                // Set the background color of the specified ButtonData
                data[targetRow][targetCol].Background = new SolidColorBrush(Windows.UI.Colors.Orange);
                data[targetRow][targetCol].Number = "\u2764" + hl1.getName();
                data[hl2.getX()][hl2.getY()].Background = new SolidColorBrush(Windows.UI.Colors.Red); ;
                data[hl2.getX()][hl2.getY()].Number = "\u2660" + hl2.getName();
            }

          
       
        }
        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                int targetRow = Grid.GetRow(button);
                int targetCol = Grid.GetColumn(button);

                TranslateTransform translateTransform = button.RenderTransform as TranslateTransform;

                if (translateTransform != null)
                {
                    DoubleAnimation animationX = new DoubleAnimation
                    {
                        To = targetCol * 70, 
                        Duration = TimeSpan.FromSeconds(1),
                        AutoReverse = true
                    };

                    Storyboard.SetTarget(animationX, translateTransform);
                    Storyboard.SetTargetProperty(animationX, "X");

                    Storyboard storyboard = new Storyboard();
                    storyboard.Children.Add(animationX);

                    storyboard.Begin();
                }
            }
        }
     

   
        private void ItemsControl_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // ItemsControl is loaded, show the "Start Game" button

        }
        public class ButtonData : INotifyPropertyChanged
        {
            private string _number;
            public string Number
            {
                get { return _number; }
                set
                {
                    if (_number != value)
                    {
                        _number = value;
                        OnPropertyChanged(nameof(Number));
                    }
                }
            }

            private SolidColorBrush _background;
            public SolidColorBrush ForeGround { get; set; }
            public SolidColorBrush Background
            {
                get { return _background; }
                set
                {
                    if (_background != value)
                    {
                        _background = value;
                        OnPropertyChanged(nameof(Background));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        private void CreateStartGameButton()
        {
            startGameButton = new Button
            {
                Content = "Start Game",
                Background= new SolidColorBrush(Windows.UI.Colors.DarkBlue),
            HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 10),
                Name="start",
               FontFamily = new Windows.UI.Xaml.Media.FontFamily("Century Gothic"),
            Foreground = new SolidColorBrush(Windows.UI.Colors.White),
                Width = 200,
                Height = 50,
                ClickMode = ClickMode.Press, 
                CornerRadius = new CornerRadius(10)

        };
            startGameButton.Click += Button_Click;
            myStackPanel.Children.Add(startGameButton);
        

    }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            startGameButton.IsEnabled = false;

            int roundMove = 1;

            while (exitValue == 1) 
            {
                data[hl1.getX()][hl1.getY()].Number = null;
                data[hl2.getX()][hl2.getY()].Number = null;
                // Assuming moveActionRandom1 and moveActionRandom2 are obtained from your Movement class
                int moveActionRandom1 = Movement.moveActionRandom(hl1.getX(), hl1.getY(), random, gridSize);
                int moveActionRandom2 = Movement.moveActionRandom(hl2.getX(), hl2.getY(), random, gridSize);

                Movement.moveAction(moveActionRandom1, hl1);
                Movement.moveAction(moveActionRandom2, hl2);
             //   Button button1 = GetButtonByPosition(hl1.getX(), hl1.getY());
              //  Button button2 = GetButtonByPosition(hl2.getX(), hl2.getY());
                // Update the buttons to reflect the new positions

                /// Animate the movement

                data[hl1.getX()][hl1.getY()].Background = new SolidColorBrush(Windows.UI.Colors.Orange);
                data[hl1.getX()][hl1.getY()].Number = "\u2764" + hl1.getName();
                data[hl2.getX()][hl2.getY()].Background = new SolidColorBrush(Windows.UI.Colors.Red);
                data[hl2.getX()][hl2.getY()].Number = "\u2660" + hl2.getName();

                // NotifyPropertyChanged for the updated properties
               
                // Delay or wait for a short duration to make the movement visible
                await Task.Delay(500);

                if (hl1.getX() == hl2.getX() && hl1.getY() == hl2.getY())
                {
                    fightWinner = Fight.fightWinner(hl1, hl2);
                    winner.Text = fightWinner.getName() + " " + fightWinner.getX() + "Position" + fightWinner.getY() + " Movement:" + roundMove;
                    // Show the ContentDialog defined in XAML
                    ContentDialogResult result = await myContentDialog.ShowAsync();

                    // Process the result if needed
                    if (result == ContentDialogResult.Primary)
                    {
                        // User clicked Primary button (OK)
                        // Add your logic here
                    }
                    else if (result == ContentDialogResult.Secondary)
                    {
                        // User clicked Secondary button (Cancel) or pressed the system back button
                        // Add your logic here
                    }
                    exitValue = 0;

                }
                roundMove++;
            }
          



            Console.WriteLine("Winner is {0}, he is in the location - x:{1} y:{2}", fightWinner.getName(), fightWinner.getX(), fightWinner.getY());
        }
        
        
     

        
    }

    }
