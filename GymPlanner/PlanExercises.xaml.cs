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
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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

            TextBlock label1 = new TextBlock();
            label1.Text = reee[2, 1];
            label1.FontSize = 10;
            label1.VerticalAlignment = VerticalAlignment.Top;
            label1.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(label1, 1);
            Grid.SetRow(label1, 3);
            DynamicGrid.Children.Add(label1);

            ExerciseLayout.Children.Add(DynamicGrid);
        }
    }
}
