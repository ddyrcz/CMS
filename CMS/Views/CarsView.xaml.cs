using CMS.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CMS.Views
{
    /// <summary>
    /// Interaction logic for CarsView.xaml
    /// </summary>
    public partial class CarsView : Window
    {
        public CarsView()
        {
            InitializeComponent();
            var window = new Window();

            FixDatePickersBackground();
        }

        private void FixDatePickersBackground()
        {
            TechnicalResearchDatePicker.Loaded += delegate
            {
                var textBox = (TextBox)TechnicalResearchDatePicker.Template.FindName("PART_TextBox", TechnicalResearchDatePicker);
                textBox.Background = TechnicalResearchDatePicker.Background;
            };
            TachoLegalizationDatePicker.Loaded += delegate
            {
                var textBox = (TextBox)TachoLegalizationDatePicker.Template.FindName("PART_TextBox", TachoLegalizationDatePicker);
                textBox.Background = TachoLegalizationDatePicker.Background;
            };
            LiftUDTDatePicker.Loaded += delegate
            {
                var textBox = (TextBox)LiftUDTDatePicker.Template.FindName("PART_TextBox", LiftUDTDatePicker);
                textBox.Background = LiftUDTDatePicker.Background;
            };
            OCDatePicker.Loaded += delegate
            {
                var textBox = (TextBox)OCDatePicker.Template.FindName("PART_TextBox", OCDatePicker);
                textBox.Background = OCDatePicker.Background;
            };
            ACDatePicker.Loaded += delegate
            {
                var textBox = (TextBox)ACDatePicker.Template.FindName("PART_TextBox", ACDatePicker);
                textBox.Background = ACDatePicker.Background;
            };
        }       

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e == null) return;

            // Close application
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }      
    }
}