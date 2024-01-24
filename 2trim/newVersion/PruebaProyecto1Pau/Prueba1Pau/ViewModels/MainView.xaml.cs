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
using System.Drawing;
//FUNCIÓN NATIVA DEL S.O
// El mensaje con estos valores INTEROP notifica al controlador de mensajes de la ventana que debe ser arrastrado cuando se 
// hace click en el panel y se mueva el mouse sin mover el botón
using System.Runtime.InteropServices;
using System.Runtime;         // <-- // 
using System.Windows.Interop; // <-- //
using Prueba1Pau.Modl;
using static Prueba1Pau.Modl.SlideInfo;

namespace Prueba1Pau.View
{ 
    public partial class MainView : Window
    {

        private SlideManager _slideManager;
        private SlideType _actualSlideType;
        public MainView()
        {
            InitializeComponent();
           _slideManager = new SlideManager();
           _actualSlideType = SlideType.Slide1;
            mostrarDiapositiva(_actualSlideType);
        }

        // Importamos la bilioteca externa. Nos permitirá usar los eventos y métodos del S.O.
        // En este caso, capturar las señales del mouse y enviar mensajes para mover y arrastrar la ventana

        [DllImport("user32.dll")]
        //Definimos el método externo de la librería "user32". En tipo, espicificamos PUNTERO. Requiere como parámetros: El identificador
        //de la ventana, un mensaje y dos parámtros más para la info adicional del mensaje.
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Para poder mover la ventana : Dragmove();

            //Definimos el identificador de la ventana. Para ello, usamos la clase WindowInteroHelper y luego llamamos al método externo.
            WindowInteropHelper helper = new WindowInteropHelper(this); 
            //Este mensaje se genera cada vez que movemos cualquier ventana del S.O. Así que simplemente estamos aprovechando esa función.
            SendMessage(helper.Handle, 161, 2, 0);

        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            //Esta función es para que el maximizado de la ventana sea adecuado en cualquier monitor con cualquier resolución debemos de actualizar
            //el alto máximo antes de maximizar la ventana, para eso vamos a suscribir el evento MouseEnter y actualizar el alto máximo de la ventana
        
        
            //Para que la pantalla se maximize sin tapar la barra de tareas
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal) {
                this.WindowState = WindowState.Maximized;
            } else {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            //Comprobar el estado de los RadioButtons y ocultar btnMasMoneda en caso de que no esté seleccionado

            RadioButton clickedRadioButton = sender as RadioButton;

            if (clickedRadioButton.IsChecked == true)
            {
                if (masMoneda.Visibility == Visibility.Visible)
                {
                    masMoneda.Visibility = Visibility.Collapsed;
                    svNavigationMenu.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                }
            }

            if (clickedRadioButton.Name == "ComercioEconomia") {
                mostrarDiapositiva(SlideType.Slide1);
            }

            if (clickedRadioButton.Name == "BienesServicios")
            {
                mostrarDiapositiva(SlideType.Slide4);
            }

            if (clickedRadioButton.Name == "Moneda")
            {
                mostrarDiapositiva(SlideType.Slide6);
            }

            if (clickedRadioButton.Name == "Moneda2")
            {
                mostrarDiapositiva(SlideType.Slide7);
            }

        }

        private void btnMasMoneda_Click(object sender, RoutedEventArgs e)
        {
            if (Moneda.IsChecked == true) {
                if (masMoneda.Visibility == Visibility.Visible)
                {
                    masMoneda.Visibility = Visibility.Collapsed;
                    svNavigationMenu.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                }
                else
                {
                    masMoneda.Visibility = Visibility.Visible;
                    svNavigationMenu.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                }
            }
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            int nextSlideIndex = (int)_actualSlideType + 1;
            if (Enum.IsDefined(typeof(SlideType), nextSlideIndex))
            {
                _actualSlideType = (SlideType)nextSlideIndex;
                mostrarDiapositiva(_actualSlideType);
            }
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            int prevSlideIndex = (int)_actualSlideType - 1;
            if (Enum.IsDefined(typeof(SlideType), prevSlideIndex))
            {
                _actualSlideType = (SlideType)prevSlideIndex;
                mostrarDiapositiva(_actualSlideType);
            }
        }

        // SLIDES

        private void mostrarDiapositiva(SlideType type)
        {
            System.Windows.Controls.UserControl slide = _slideManager.GetSlide(type);
            slideContainer.Content = slide;
            _actualSlideType = type;

            if (_actualSlideType == SlideType.Slide1 || _actualSlideType == SlideType.Slide2 || _actualSlideType == SlideType.Slide3)
            {
                ComercioEconomia.IsChecked = true;
            } else if (_actualSlideType == SlideType.Slide4 || _actualSlideType == SlideType.Slide5)
            {
                BienesServicios.IsChecked = true;
            } else if (_actualSlideType == SlideType.Slide6 || _actualSlideType == SlideType.Slide7)
            {
                Moneda.IsChecked = true;
            }

        }   

    }
}
