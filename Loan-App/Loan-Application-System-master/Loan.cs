using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Loan_Application_System
{
    /// <summary>
    /// Abstract class implementing the LoanConstants Interface. 
    /// This base class stores all necesary info about a loan in one object
    /// as well as have some useful functions.
    /// </summary>
    abstract class Loan : LoanConstants
    {
        /// <summary>
        /// The constant amount of years for the Short Term 
        /// </summary>
        public int shortTerm { get { return 1; } }
        /// <summary>
        /// The constant amount of years for the Medium Term 
        /// </summary>
        public int mediumTerm { get { return 3; } }
        /// <summary>
        /// The constant amount of years for the Long Term 
        /// </summary>
        public int longTerm { get { return 5; } }
        /// <summary>
        /// The company name as a constant value
        /// </summary>
        public string companyName { get { return "Loan Sharks"; } }
        /// <summary>
        /// The max amount you may borrow as a constant
        /// </summary>
        public double maxLoanAmount { get { return 100000d; } }
        /// <summary>
        /// The min amount you may borrow as a constant
        /// </summary>
        public double minLoanAmount { get { return 500d; } }
        /// <summary>
        /// Constructor for a Loan that generates a random loan number
        /// </summary>
        /// <param name="interestRate"></param>
        /// <param name="custLastname"></param>
        /// <param name="custFirstname"></param>
        public Loan(double interestRate, string custLastname, string custFirstname)
        {
            LoanNumber = randomInteger();
            CustLastname = custLastname;
            CustFirstname = custFirstname;
            InterestRate = interestRate;
        }
        /// <summary>
        /// constructor overload that accepts only customer names
        /// </summary>
        /// <param name="custLastname"></param>
        /// <param name="custFirstname"></param>
        protected Loan(string custLastname, string custFirstname)
        {
            CustLastname = custLastname;
            CustFirstname = custFirstname;
        }

        /// <summary>
        /// Loan number is randomly generated thus it only gets a get function
        /// </summary>
        public int LoanNumber { get; }
        /// <summary>
        /// Getter or Setter function for Customer Last Name
        /// </summary>
        public string CustLastname { get; set; }
        /// <summary>
        /// Getter or Setter function for Customer Last Name
        /// </summary>
        public string CustFirstname { get; set; }
        /// <summary>
        /// Getter or Setter for the amount that is being lent
        /// </summary>
        public double LoanAmount { get; set; }
        /// <summary>
        /// The interset rate in double format.
        /// </summary>
        public double InterestRate { get; set; }
        /// <summary>
        /// The amount of years before loan is payed back
        /// </summary>
        public int Term { get; set; }
        /// <summary>
        /// Loan to string function
        /// </summary>
        /// <returns>summary of loan</returns>
        public override string ToString()
        {
            return $"Loan Number: {LoanNumber} \n Customer lastname: {CustLastname} \n Customer Name:{CustFirstname} \n Loan Amount: {LoanAmount} \n Interest Rate:  {InterestRate} \n Term: {Term}";
        }


        /// <summary>
        /// Checks wether the amount of years are one of the choices given
        /// </summary>
        public void loanTermValid()
        {
            
            if (Term != shortTerm && Term != mediumTerm && Term != longTerm)
            {
                Console.WriteLine($"Term duration is not one of the options given. Term amount will be set to {shortTerm}");
                Term = shortTerm;
                Thread.Sleep(3000);
            }
        }
        /// <summary>
        /// Creates a random interger between 0 and 10000
        /// </summary>
        /// <returns>Random integer</returns>
        private int randomInteger()
        {

            var random = new Random();
            return random.Next(0, 10000);

        }
        /// <summary>
        /// asks for name until the name given is valid
        /// </summary>
        /// <param name="name"></param>
        /// <returns>string</returns>
        public static string nameCheck(string name)
        {
            while (!Checks.stringLengthCheck(name, 2, 50) || Checks.hasSpecialCharector(name))
            {
                Console.WriteLine("Please re-enter:");
                name = Console.ReadLine();
            }
            return name;
        }
        /// <summary>
        /// asks for loan amount untill value given is valid
        /// </summary>
        /// <param name="loanAmount"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>double</returns>
        public static double loanAmountCheck(string loanAmount, double min, double max)
        {
            //keep asking to re-enter the value until it is a double value
            while (!Checks.isDouble(loanAmount))
            {
                Console.WriteLine("Please re-enter:");
                loanAmount = Console.ReadLine();
            }
            //after being sure it is a double value we can savely parse it into a doubl
            double loanAmountAsDouble = double.Parse(loanAmount);
            //keep asking to re-enter the value until it is value that is above the min amount required
            while (loanAmountAsDouble < min)
            {
                Console.WriteLine($"Loan Amount can't be less than {min}.\nPlease re-enter:");
                loanAmount = Console.ReadLine();
                //to make sure we don't pass this test but sneak past a previous check we recall
                //the method to check all the check sagain
                loanAmountAsDouble= loanAmountCheck(loanAmount, min, max);
            }
            //keep asking to re-enter the value until it is value that is above the max amount required
            while (loanAmountAsDouble > max)
            {
                Console.WriteLine($"Loan Amount can't be more than {max}.\nPlease re-enter:");
                loanAmount = Console.ReadLine();
                //to make sure we don't pass this test but sneak past a previous check we recall
                //the method to check all the check sagain
                loanAmountAsDouble = loanAmountCheck(loanAmount, min, max);
            }
            //after being sure all checks are passed we return the final correct 
            return loanAmountAsDouble;
        }
        /// <summary>
        /// asks for prime interest rate untill value given is valid
        /// </summary>
        /// <param name="interestRate"></param>
        /// <returns>double</returns>
        public static double interestRateCheck(string interestRate)
        {
            //keep asking to re-enter the value until it is a double
            while (!Checks.isDouble(interestRate))
            {
                Console.WriteLine("Please re-enter:");
                interestRate = Console.ReadLine();
            }
            //after being sure it is a double value we can savely parse it into a doubl
            double interestRateAsDouble = double.Parse(interestRate);
            //keep asking to re-enter the value until it is a valid percentage
            while (!Checks.isPercentage(interestRateAsDouble))
            {
                Console.WriteLine($"Please re-enter:");
                interestRate = Console.ReadLine();
                //to make sure we don't pass this test but sneak past a previous check we recall
                //the method to check all the check sagain
                interestRateAsDouble = interestRateCheck(interestRate);
            }
            //after being sure all checks are passed we return the final correct
            return interestRateAsDouble;
        }
    }


}
