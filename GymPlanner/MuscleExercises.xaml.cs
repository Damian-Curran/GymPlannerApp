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
    public sealed partial class MuscleExercises : Page
    {
        public MuscleExercises()
        {
            this.InitializeComponent();
            ComboBox();
        }

        private void ComboBox()
        {
            var obj = App.Current as App;
            string exer1 = "";
            string exer2 = "";

            string[,] reee = new string[43, 5];

            Array.Copy(obj.GlobalExerciseArray, 0, reee, 0, obj.GlobalExerciseArray.Length);

            exer1 = obj.exercise1;
            exer2 = obj.exercise2;

            for (int i = 0; i <= 42; i++)
            {
                if (exer1 == reee[i, 0] || exer2 == reee[i, 0])
                {
                    Exercise1.Items.Add(reee[i, 1]);
                    Exercise2.Items.Add(reee[i, 1]);
                    Exercise3.Items.Add(reee[i, 1]);
                    Exercise4.Items.Add(reee[i, 1]);
                    Exercise5.Items.Add(reee[i, 1]);
                    Exercise6.Items.Add(reee[i, 1]);
                }
            }
        }

        private void btn5_click(object sender, RoutedEventArgs e)
        {
            string var = "", var2 = "", var3 = "", var4 = "", var5 = "", var6 = "";
            DupBox.Text = "";

            if (Exercise1.SelectedItem == null)
            {
                var = " ";
            }
            else if (Exercise1.SelectedItem != null)
            {
                var = Exercise1.SelectedItem.ToString();
            }

            if (Exercise2.SelectedItem == null)
            {
                var2 = " ";
            }
            else if (Exercise2.SelectedItem != null)
            {
                var2 = Exercise2.SelectedItem.ToString();
            }

            if (Exercise3.SelectedItem == null)
            {
                var3 = " ";
            }
            else if (Exercise3.SelectedItem != null)
            {
                var3 = Exercise3.SelectedItem.ToString();
            }

            if (Exercise4.SelectedItem == null)
            {
                var4 = " ";
            }
            else if (Exercise4.SelectedItem != null)
            {
                var4 = Exercise4.SelectedItem.ToString();
            }

            if (Exercise5.SelectedItem == null)
            {
                var5 = " ";
            }
            else if (Exercise5.SelectedItem != null)
            {
                var5 = Exercise5.SelectedItem.ToString();
            }

            if (Exercise6.SelectedItem == null)
            {
                var6 = " ";
            }
            else if (Exercise6.SelectedItem != null)
            {
                var6 = Exercise6.SelectedItem.ToString();
            }

            if (var != var2 && var != var3 && var != var4 && var != var5 && var != var6 && var2 != var3 && var2 != var4 && var2 != var5 && var2 != var6 && var3 != var4 && var3 != var5 && var3 != var6
                && var4 != var5 && var4 != var6 && var5 != var6)
            {
                var obj = App.Current as App;
                obj.exercise1 = " ";
                obj.exercise2 = " ";

                obj.muscleExer1 = var;
                obj.muscleExer2 = var2;
                obj.muscleExer3 = var3;
                obj.muscleExer4 = var4;
                obj.muscleExer5 = var5;
                obj.muscleExer6 = var6;

                Frame.Navigate(typeof(PlanExercises));
            }
            else
            {
                DupBox.Text = "Fill all boxes \n No duplicates";
            }
        }

        private void returnButton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MuscleGroups));
        }
    }
}
