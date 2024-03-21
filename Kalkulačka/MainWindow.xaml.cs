using System;
using System.Windows;
using System.Windows.Controls;

namespace Kalkulačka
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VypocitatButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double operand1 = double.Parse(operand1TextBox.Text);
                double operand2 = double.Parse(operand2TextBox.Text);
                string operace = ((ComboBoxItem)operaceComboBox.SelectedItem).Content.ToString();

                double vysledek = 0;

                switch (operace)
                {
                    case "+":
                        vysledek = operand1 + operand2;
                        break;
                    case "-":
                        vysledek = operand1 - operand2;
                        break;
                    case "*":
                        vysledek = operand1 * operand2;
                        break;
                    case "/":
                        if (operand2 != 0)
                            vysledek = operand1 / operand2;
                        else
                            throw new DivideByZeroException("Nelze dělit nulou.");
                        break;
                }

                vysledekTextBlock.Text = vysledek.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Neplatný vstup. Zadejte prosím platná čísla.");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Nelze dělit nulou.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo k chybě: " + ex.Message);
            }
        }

        private void OperaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Vyčistit výsledek při změně operace
            vysledekTextBlock.Text = "0";
        }
    }
}
