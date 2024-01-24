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

namespace Prueba1Pau.ViewModels
{
    /// <summary>
    /// Lógica de interacción para miMessageBox.xaml
    /// </summary>
    public partial class miMessageBox : Window
    {
        public miMessageBox()
        {
            InitializeComponent();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        // BOTONES FUNCIONEN CON LAS TECLAS
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Accept_Click(sender, e);
            }
        }
    }
}
