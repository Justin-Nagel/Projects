using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Application_System
{
    /// <summary>
    /// inherits from CreateLoan and has methods specific for personal loans
    /// </summary>
    internal class PersonalLoan : CreateLoan
    {

        /// <summary>
        /// constructor for personal accepting only neccesary parameters and automatically calculate the 
        /// personal loan interest rate on creation
        /// </summary>
        /// <param name="interestRate"></param>
        /// <param name="custLastname"></param>
        /// <param name="custFirstname"></param>
        public PersonalLoan(double interestRate,string custLastname, string custFirstname) : 
            base(interestRate, custLastname, custFirstname)
        {
            calcInterestRate();
        }
        /// <summary>
        /// calculates the personal loan interest rate with the fee as well
        /// </summary>
        private void calcInterestRate()
        {
            InterestRate = InterestRate + 2d;
        }
        /// <summary>
        /// Calculate the total amount due keeping the fee and term in mind
        /// </summary>
        /// <returns></returns>
        public double calcPersonalTotalAmountDue()
        {
            double totalAmountDue = 0;
            totalAmountDue = LoanAmount + CalculateInterest();
            return totalAmountDue;
        }
        /// <summary>
        /// Personal to string function displaying a summary of the personal loan after all calculations
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $" Loan Number: {LoanNumber} \n Customer: {CustLastname} {CustFirstname} \n Loan Amount: R{LoanAmount}\n  Loan Type: Personal\n Interest Rate:  {InterestRate}% \n Term: {Term} year(s) \n Total Amount Due: R{calcPersonalTotalAmountDue()}";
        }
    }

}
