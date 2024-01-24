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
    /// Lógica de interacción para TextBoxHint.xaml
    /// </summary>

    public partial class TextBoxHint : System.Windows.Controls.UserControl
    {
        public TextBoxHint()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Texto { get; set; }
        public int MaxLength { get; set; }
        public string Text
        {
            get { return SearchTermTextBox.Text; }
            set { SearchTermTextBox.Text = value; }
        }
        public Brush BorderColor
        {
            get { return SearchTermTextBox.BorderBrush; }
            set { SearchTermTextBox.BorderBrush = value; }
        }
    }
}
