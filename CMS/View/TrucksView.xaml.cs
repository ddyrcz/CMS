using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CMSDatabaseConnector;
using CMS.ViewModel;
using CMS.ViewModel.Base;


namespace CMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is TrucksViewModel)
            {
                ((TrucksViewModel)this.DataContext).EditData();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is TrucksViewModel)
            {
                ((TrucksViewModel)this.DataContext).InitData();
            }
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
