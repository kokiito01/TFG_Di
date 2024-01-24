using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prueba1Pau.Model
{
    public class UserValidator
    {

        public List<string> ValidateUser(string name, string lastName, string email, string pass, string confirmPass, DateTime birthday, bool isCheckBoxChecked, out List<string> errors)
        {
            errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add("tbName");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                errors.Add("tbLastName");
            }

            if (!IsValidEmail(email))
            {
                errors.Add("tbEmail");
            }

            if (!IsValidPassword(pass))
            {
                errors.Add("pbPass");
            } else {
                if (pass != confirmPass)
                {
                    errors.Add("pbConfirmPass");
                }
            }

            if (!isInRange(birthday))
            {
                errors.Add("dpBirthday");
            }

            if(isCheckBoxChecked ==  false)
            {
                errors.Add("cbTerms");
            }

            if (errors.Count == 0) 
            {
                errors.Add("valid");
            }

            return errors;
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.(com|es)$";
            // Regex.IsMatch --> verifica si la cadena email coincide con el patrón definido en emailPattern
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 8 && ContainsUppercaseAndNumber(password);
        }

        private bool ContainsUppercaseAndNumber(string password)
        {
            return password.Any(char.IsUpper) && password.Any(char.IsDigit);
        }

        private bool isInRange(DateTime fechaNacimiento)
        {
            // Calcular la edad actual
            int edad = DateTime.Today.Year - fechaNacimiento.Year;

            // Ajustar la edad si aún no ha llegado el cumpleaños
            if (fechaNacimiento > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            // Validar que sea mayor de edad
            return edad >= 7;
        }
    }
}
