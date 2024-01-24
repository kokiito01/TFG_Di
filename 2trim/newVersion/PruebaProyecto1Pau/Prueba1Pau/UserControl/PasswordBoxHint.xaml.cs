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

namespace Prueba1Pau.UserControl
{
    /// <summary>
    /// Lógica de interacción para PasswordBoxHint.xaml
    /// </summary>
    public partial class PasswordBoxHint : System.Windows.Controls.UserControl
    {
        public PasswordBoxHint()
        {
            InitializeComponent();
            HintTextBlock.Visibility = string.IsNullOrEmpty(SearchTermPasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
            DataContext = this;
        }
        public string Texto { get; set; }
        public int MaxLength { get; set; }
        public string Password
        {
            get { return SearchTermPasswordBox.Password; }
            set { SearchTermPasswordBox.Password = value; }
        }
        private void SearchTermPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                HintTextBlock.Visibility = string.IsNullOrEmpty(passwordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        public Brush BorderColor
        {
            get { return SearchTermPasswordBox.BorderBrush; }
            set { SearchTermPasswordBox.BorderBrush = value; }
        }


        //BOTONES
        private void tbOpenEye_Click(object sender, RoutedEventArgs e)
        {
            tbOpenEye.Visibility = Visibility.Collapsed;
            tbClosedEye.Visibility = Visibility.Visible;
            //SearchTermPasswordBox.PasswordChar = '\0'; // Mostrar caracteres
        }

        private void tbClosedEye_Click(object sender, RoutedEventArgs e)
        {
            tbOpenEye.Visibility = Visibility.Visible;
            tbClosedEye.Visibility = Visibility.Collapsed;
            //SearchTermPasswordBox.PasswordChar = '•'; // Ocultar caracteres
        }
    }
}
