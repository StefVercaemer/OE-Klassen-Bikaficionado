using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls.Primitives;

namespace Bikaficionado.Wpf
{
    public partial class MainWindow
    {

        void MarkeerTextBox(TextBox teMarkeren, bool juistIngevuld = false)
        {
            if (juistIngevuld)
            {
                teMarkeren.Background = Brushes.White;
                teMarkeren.BorderBrush = Brushes.Gray;
                teMarkeren.BorderThickness = new Thickness(1);
            }
            else
            {
                teMarkeren.Background = Brushes.LightPink;
                teMarkeren.BorderBrush = Brushes.Red;
                teMarkeren.BorderThickness = new Thickness(3);
            }
        }

        void ToonMelding(string boodschap, bool isSucces = false)
        {
            tbkFeedBack.Visibility = Visibility.Visible;
            tbkFeedBack.Text = boodschap;
            tbkFeedBack.Background = isSucces == false ? Brushes.Red : Brushes.Green;
        }

        bool InputIsGeldigGetal(TextBox textBox, Type getalType)
        {
            bool isGeldigGetal = true;
            string input;
            string typeNaam = getalType.Name;
            string naamGetalType = "";
            input = textBox.Text;
            try
            {
                switch (typeNaam)
                {
                    case "Int32":
                        naamGetalType = "geheel getal";
                        int.Parse(input);
                        break;
                    case "Single":
                        naamGetalType = "kommagetal";
                        float.Parse(input);
                        break;
                    case "Decimal":
                        naamGetalType = "decimaal getal";
                        decimal.Parse(input);
                        break;
                    default:
                        break;
                }
                tbkFeedBack.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                isGeldigGetal = false;
                ToonMelding($"{input} is geen correct {naamGetalType}");
            }
            return isGeldigGetal;
        }

        public void ClearPanel(Panel toClear)
        {
            
            foreach (object control in toClear.Children)
            {
                Console.WriteLine(control.ToString());
                if (control is TextBox)
                {
                    TextBox castedControl = (TextBox)control;
                    castedControl.Text = string.Empty;
                }
                else if (control is Label)
                {
                    Label castedControl = (Label)control;
                    if (castedControl.Name.Length > 0)
                    {
                        castedControl.Content = "";
                    }
                }
                else if (control is TextBlock)
                {
                    TextBlock castedControl = (TextBlock)control;
                    if (castedControl.Name.Length > 0)
                    {
                        castedControl.Text = "";
                    }
                }
                else if (control is Selector)
                {
                    Selector castedControl = (Selector)control;
                    castedControl.SelectedIndex = -1;
                }
                else if (control is DatePicker)
                {
                    DatePicker castedControl = (DatePicker)control;
                    castedControl.SelectedDate = DateTime.Today;
                }
                else if (control is Slider)
                {
                    Slider castedControl = (Slider)control;
                    castedControl.Value = castedControl.Minimum;
                }
                else if (control is CheckBox)
                {
                    CheckBox castedControl = (CheckBox)control;
                    castedControl.IsChecked = false;
                }
            }
            cmbAantalWielen.SelectedItem = 2;
        }

    }
}
