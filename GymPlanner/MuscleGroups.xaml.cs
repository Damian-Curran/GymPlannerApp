using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class MuscleGroups : Page
    {
        public MuscleGroups()
        {
            this.InitializeComponent();
            ComboBox();
        }

        private void ComboBox()
        {
            string[] employees = new string[]{"Biceps", "Triceps",
            "Legs", "Shoulders", "Chest",
            "Abs", "Back"};

            for (int i = 0; i < 7; i++)
            {
                Exercise1.Items.Add(employees[i]);
                Exercise2.Items.Add(employees[i]);
            }
        }

        private void btn5_click(object sender, RoutedEventArgs e)
        {
            string var = "", var2 = "";
            DupBox.Text = "";

            if (Exercise1.SelectedItem != Exercise2.SelectedItem && Exercise1.SelectedItem != null && Exercise2.SelectedItem != null)
            {
                var = Exercise1.SelectedItem.ToString();
                var2 = Exercise2.SelectedItem.ToString();

                var obj = App.Current as App;
                obj.exercise1 = var;
                obj.exercise2 = var2;

                if (obj.pagePath == 3)
                {
                    Frame.Navigate(typeof(PlanExercises));
                }
                else if (obj.pagePath == 2)
                {
                    Frame.Navigate(typeof(MuscleExercises));
                }
            }
            else if (Exercise1.SelectedItem == null || Exercise2.SelectedItem == null)
            {
                DupBox.Text = "Select items in \n both drop down boxes";
            }
            else
            {
                DupBox.Text = "Both options \n picked are the same";
            }
        }

        private void returnButton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
