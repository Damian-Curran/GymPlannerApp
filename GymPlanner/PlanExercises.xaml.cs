using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GymPlanner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlanExercises : Page
    {
        string randomMuscle1 = "";
        string randomMuscle2 = "";

        string[,] reee = new string[43, 5];

        public PlanExercises()
        {
            this.InitializeComponent();

            var obj = App.Current as App;

            Array.Copy(obj.GlobalExerciseArray, 0, reee, 0, obj.GlobalExerciseArray.Length);

            randomMuscle1 = obj.exercise1;
            randomMuscle2 = obj.exercise2;

            if (obj.pagePath == 3)
            {
                CreateGridRandom();
            }
            else if (obj.pagePath == 2)
            {
                
            }
            else if (obj.pagePath == 1)
            {
                
            }
        }

        private void CreateGridRandom()
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            DynamicGrid.BorderThickness = new Windows.UI.Xaml.Thickness(2, 2, 2, 2);
            DynamicGrid.BorderBrush = new SolidColorBrush(Colors.Black);

            var height = new GridLength(1, GridUnitType.Star);
            var width = new GridLength(1, GridUnitType.Star);

            var width2 = new GridLength(2, GridUnitType.Star);

            int counter = 0;

            for (int i = 0; i <= 1; i++)
            {
                if (i == 0)
                {
                    DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = width
                    });
                }
                if (i == 1)
                {
                    DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = width2
                    });
                }
            }

            for (int i = 0; i <= 8; i++)
            {

                DynamicGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = height
                });

            }

            for (int i = 0; i <= 42; i++)
            {
                if (randomMuscle1 == reee[i, 0] || randomMuscle2 == reee[i, 0])
                {
                    counter++;
                    for (int j = 0; j <= 4; j++)
                    {
                        Border myBorder1 = new Border();
                        myBorder1.BorderBrush = new SolidColorBrush(Colors.Black);
                        myBorder1.BorderThickness = new Thickness(1);

                        Image img = new Image();
                        BitmapImage tmp = new BitmapImage(new Uri(reee[i, 2], UriKind.Absolute));
                        img.Source = tmp;
                        img.Stretch = Stretch.Fill;
                        Grid.SetRow(img, counter);
                        Grid.SetColumn(img, 0);
                        DynamicGrid.Children.Add(img);

                        TextBlock label1 = new TextBlock();
                        label1.Text = reee[i, 1];
                        label1.FontSize = 10;
                        label1.VerticalAlignment = VerticalAlignment.Top;
                        label1.HorizontalAlignment = HorizontalAlignment.Center;
                        Grid.SetColumn(label1, 1);
                        Grid.SetRow(label1, counter);
                        DynamicGrid.Children.Add(label1);

                        TextBlock label2 = new TextBlock();
                        label2.Text = reee[i, 3];
                        label2.FontSize = 10;
                        label2.VerticalAlignment = VerticalAlignment.Center;
                        Grid.SetColumn(label2, 1);
                        Grid.SetRow(label2, counter);
                        DynamicGrid.Children.Add(label2);

                        Run run1 = new Run();
                        run1.Text = "For a link to a YouTube video click here";

                        Hyperlink hyperlink = new Hyperlink()
                        {
                            NavigateUri = new Uri(reee[i, 4])
                        };

                        Border myBorder3 = new Border();
                        myBorder3.BorderBrush = new SolidColorBrush(Colors.Black);
                        myBorder3.BorderThickness = new Thickness(1);

                        TextBlock label3 = new TextBlock();
                        //label3.Text = reee[i, 4];
                        label3.FontSize = 10;
                        label3.VerticalAlignment = VerticalAlignment.Bottom;

                        hyperlink.Inlines.Add(run1);
                        label3.Inlines.Add(hyperlink);

                        myBorder3.Child = label3;

                        Grid.SetColumn(myBorder3, 1);
                        Grid.SetRow(myBorder3, counter);
                        DynamicGrid.Children.Add(myBorder3);
                    }
                }
            }

            ExerciseLayout.Children.Add(DynamicGrid);
        }
    }
}
