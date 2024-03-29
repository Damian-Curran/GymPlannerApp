﻿using System;
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
    public sealed partial class SavedPlans : Page
    {
        public SavedPlans()
        {
            this.InitializeComponent();
            CreateGrid();
        }

        private void CreateGrid()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            int counter = 0;
            int arrayPos = 0;

            Grid DynamicGrid = new Grid();
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            DynamicGrid.BorderThickness = new Windows.UI.Xaml.Thickness(2, 2, 2, 2);
            DynamicGrid.BorderBrush = new SolidColorBrush(Colors.Black);

            var height = new GridLength(1, GridUnitType.Star);
            var width = new GridLength(1, GridUnitType.Star);

            for (int i = 0; i <= 1; i++)
            {
                if (i == 0)
                {
                    DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = width
                    });
                }
            }

            for (int i = 0; i <= 7; i++)
            {

                DynamicGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = height
                });

            }

            Button btn = new Button();
            btn.Name = "return";
            btn.Content = "Back";
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.Click += returnButton;

            Grid.SetColumn(btn, 0);
            Grid.SetRow(btn, 0);
            DynamicGrid.Children.Add(btn);

            Button btn2 = new Button();
            btn2.Name = "clear";
            btn2.Content = "Clear Plans";
            btn2.HorizontalAlignment = HorizontalAlignment.Right;
            btn2.VerticalAlignment = VerticalAlignment.Top;
            btn2.Click += btnDelete_Settings_Click;

            Grid.SetColumn(btn2, 0);
            Grid.SetRow(btn2, 0);
            DynamicGrid.Children.Add(btn2);

            counter = 0;
            string[] getPlan = new string[8];
            int j = 0;
            int rowNo = 1;

            while (localSettings.Values["someSettingInStorage" + "" + counter] != null)
            {
                getPlan[arrayPos] = localSettings.Values["someSettingInStorage" + "" + counter].ToString();
                string what = getPlan[arrayPos];
                if (localSettings.Values["someSettingInStorage" + "" + counter].ToString() == "1")
                {
                    for (int i = 0; i <= arrayPos; i++)
                    {
                        if (j != (arrayPos * 10))
                        {
                            Border myBorder1 = new Border();
                            myBorder1.BorderBrush = new SolidColorBrush(Colors.Black);
                            myBorder1.BorderThickness = new Thickness(1);

                            TextBlock planExercise = new TextBlock();
                            planExercise.Text = " " + (i + 1) + " " + getPlan[i];
                            planExercise.FontSize = 10;
                            planExercise.Margin = new Thickness(0, j, 0, 0);
                            planExercise.HorizontalAlignment = HorizontalAlignment.Left;

                            myBorder1.Child = planExercise;
                            planExercise.Tapped += GetRow;
                            Grid.SetColumn(planExercise, 0);
                            Grid.SetRow(planExercise, rowNo);

                            Grid.SetColumn(myBorder1, 0);
                            Grid.SetRow(myBorder1, rowNo);
                            DynamicGrid.Children.Add(myBorder1);

                            j = j + 10;
                        }
                    }

                    getPlan = new string[8];
                    string agh = getPlan[0];
                    arrayPos = 0;
                    rowNo++;
                    j = 0;
                }
                else
                {
                    arrayPos++;
                }

                counter++;
            }

            SavedPlansLayout.Children.Add(DynamicGrid);
        }

        private void GetRow(object sender, TappedRoutedEventArgs args)
        {
            var obj = App.Current as App;
            TextBlock blockCopy = (TextBlock)sender;
            int rowNo = Grid.GetRow(blockCopy);

            obj.planPicked = rowNo;
            Frame.Navigate(typeof(PlanExercises));
        }

        private void returnButton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void btnDelete_Settings_Click(object sender, RoutedEventArgs e)
        {
            await Windows.Storage.ApplicationData.Current.ClearAsync();
            Frame.Navigate(typeof(SavedPlans));
        }
    }
}
