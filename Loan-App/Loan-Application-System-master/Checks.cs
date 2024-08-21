using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Application_System
{
    internal class Checks
    {
        /// <summary>
        /// Checks if string is a double value
        /// </summary>
        /// <param name="value">string that must be converted to double</param>
        /// <returns>boolean and lets user know about the mistake</returns>
        public static bool isDouble(string value)
        {
            double result;

            try
            {
                double.Parse(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("Value enterd is not a double.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if a string contains special characters or numbers.
        /// </summary>
        /// <param name="inputText">string that must be checked for special charectors</param>
        /// <returns>boolean and lets user know about the mistake</returns>
        public static bool hasSpecialCharector(string inputText)
        {
            int counter = 0;
            string[] numbersArray = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] specialArray = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "=", "~", ",", "<", ">", ".", "/", "?", "|", ";", ":", "[", "]" };

            for (int i = 0; i < inputText.Length; i++)
            {
                if (numbersArray.Contains(inputText[i].ToString()) || specialArray.Contains(inputText[i].ToString()))
                {
                    counter++;
                }
            }
            if (counter > 0)
            {
                Console.WriteLine("There is an invalid character in this string.");
                return true;
            }
            return false;

        }
        /// <summary>
        /// Checks if string length falls in given parameters.
        /// </summary>
        /// <param name="inputText">string to check</param>
        /// <param name="min">minnimum amount of charecters allowed</param>
        /// <param name="max">maximum charectors allowed</param>
        /// <returns>boolean value and information on ehat is wrong is displayed</returns>
        public static bool stringLengthCheck(string inputText, int min, int max)
        {

            if (inputText.Length > max)
            {
                Console.WriteLine("String can be no more than 50 charecters.");
                return false;
            }
            if (inputText.Length < min)
            {
                Console.WriteLine("String can be no less than 2 charecters.");
                return false;
            }
            return true;

        }
        /// <summary>
        /// Checks if string is a integer if not asks for another value
        /// </summary>
        /// <param name="value">string to be checked</param>
        /// <returns>boolean and lets user know about mistake</returns>
        public static bool isInt(string value)
        {
            try
            {

                int.Parse(value);

            }
            catch (FormatException)
            {
                Console.WriteLine("Value enterd is not a integer.");
                return false;
            }
            return true;
        }


        /// <summary>
        /// Checks whether the value given is more than 100% or lower than 0%.
        /// Checks whether the value given is more than 100% or lower than 0%.
        /// </summary>
        /// <param name="value">double to be checked</param>
        /// <returns>boolean and lets user know about mistake</returns>
        public static bool isPercentage(double value)
        {
            if (value > 100)
            {
                Console.WriteLine("Percentage can't be more than 100.");
                return false;
            }
            if (value < 0)
            {
                Console.WriteLine("Percentage can't be less than 0.");
                return false;
            }
            return true;
        }

        public static bool checkLoanType(string value)
        {
            value = value.ToUpper();
            try
            {
                char.Parse(value);
            }
            catch
            {
                Console.WriteLine("Value enterd is not a charector.");
                return false;
            }
            char inputText = char.Parse(value);

            if (inputText == 'P' || inputText == 'B' )
            {
                return true;
            }
            return false;
        }

    }
}
