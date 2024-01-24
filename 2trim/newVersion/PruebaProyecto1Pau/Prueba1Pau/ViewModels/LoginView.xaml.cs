using Prueba1Pau.Model;
using Prueba1Pau.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using Prueba1Pau.UserControl;
using FontAwesome.WPF;
using System.Globalization;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;

namespace Prueba1Pau.View
{

    public partial class LoginView : Window
    {
        private MyDataAccess dataAccess;
        public LoginView()
        {
            InitializeComponent();
            dataAccess = new MyDataAccess("localhost", "pruebapepa", "root", "1234");
            getAndKeepCountries();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Barra de título personalizada. El form se podrá arrastrar y mover desde
            //cualquier parte del form.
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        // BOTONES FUNCIONEN CON LAS TECLAS
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        //BOTONES

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //------------------------------------- LOG IN -------------------------------------

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string password = txtPass.Password;
            MD5 password2 = MD5.Create();
            var mainview = new MainView();
            var loginview = new LoginView();

            if(txtUser.Text == "admin" && password == "1234")
            {
                this.Close();
                mainview.Show();
            } else
            {
                miMessageBox customMessageBox = new miMessageBox();
                customMessageBox.ShowDialog();
            }
        }

        private void btnRegisterAccess_Click(object sender, RoutedEventArgs e)
        {
            loginView.Visibility = Visibility.Collapsed;
            registerView.Visibility = Visibility.Visible;
        }

        //------------------------------------- REGISTRO -------------------------------------

        //BOTONES
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                MessageBox.Show("Okey");

            }
            else
            {
                // Muestra un mensaje al usuario indicando que debe corregir los campos
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            registerView.Visibility = Visibility.Collapsed;
            loginView.Visibility = Visibility.Visible;
        }

        //VALIDACION CAMPOS

        private bool ValidateFields()
        {

            if (!dpBirthday.SelectedDate.HasValue)
            {
                dpBirthday.SelectedDate = DateTime.Now;
            }
            DateTime dateBirthday = dpBirthday.SelectedDate.Value;

            bool isCheckBoxChecked = cbTerms.IsChecked.HasValue ? cbTerms.IsChecked.Value : false;
            UserValidator userValidator = new UserValidator();
            List<string> errors;
            List<string> validationResult = userValidator.ValidateUser(tbName.Text, tbLastName.Text, tbEmail.Text, pbPass.Password, pbConfirmPass.Password, dateBirthday, isCheckBoxChecked, out errors);

            if (validationResult.Contains("valid"))
            {
                Console.WriteLine("Usuario válido.");
                return true;
            }
            else
            {
                if (validationResult.Contains("tbName"))
                {
                    tbName.BorderColor = Brushes.Red;
                }
                else if (validationResult.Contains("tbLastName"))
                {
                    tbLastName.BorderColor = Brushes.Red;
                }
                else if (validationResult.Contains("tbEmail"))
                {
                    tbEmail.BorderColor = Brushes.Red;
                }
                else if (validationResult.Contains("tbCountry") || validationResult.Contains("tbCity"))
                {
                    //cbCountry.BorderColor = Brushes.Red;
                    //tbCity.BorderColor = Brushes.Red;

                }
                else if (validationResult.Contains("pbPass"))
                {
                    pbPass.BorderColor = Brushes.Red;
                    pbConfirmPass.BorderColor = Brushes.Red;
                }
                else if (validationResult.Contains("pbConfirmPass"))
                {
                    pbPass.BorderColor = Brushes.Red;
                    pbConfirmPass.BorderColor = Brushes.Red;
                }
                else if (validationResult.Contains("cbTerms"))
                {
                    alertTerms.Visibility = Visibility.Visible;
                }
                return false;
            }

        }

        //COMBOBOX
        private void getAndKeepCountries()
        {
            List<string> allCountries = dataAccess.GetTableData("country", "CountryName");
            comboBoxCountries.ItemsSource = allCountries;
        }

        private void comboBoxCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxCountries.SelectedItem != null)
            {
                string selectedCountry = comboBoxCountries.SelectedItem.ToString();
                getAndKeepCities(selectedCountry);
            }
        }

        private void getAndKeepCities(string country)
        {
            string countryName = country;
            string query = "SELECT city.CityName FROM city JOIN country ON city.CountryCode = country.idCountry WHERE country.CountryName = @CountryName;";
            List<string> citiesInCountry = dataAccess.ExecuteQuery(query, new MySqlParameter("@CountryName", countryName));
            comboBoxCities.ItemsSource = citiesInCountry;
        }


    }

}
