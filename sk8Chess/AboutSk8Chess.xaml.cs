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

namespace sk8Chess
{
    public partial class AboutSk8Chess : Window
    {
        public AboutSk8Chess()
        {
            InitializeComponent();
        }

        private void CloseAbout(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
