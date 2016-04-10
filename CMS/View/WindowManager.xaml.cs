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
using System.Windows.Shapes;

namespace CMS.View
{
    /// <summary>
    /// Interaction logic for WindowManager.xaml
    /// </summary>
    public partial class WindowManager : Window
    {
        private UserControl _content;

        public WindowManager(UserControl content)
        {
            InitializeComponent();
            //content.Content = content;
        }
    }
}
