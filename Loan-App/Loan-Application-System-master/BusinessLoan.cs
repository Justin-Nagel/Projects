using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Application_System
{
    /// <summary>
    /// Class that inherits from CreateLoan Class to store and work with Buisiness Loans
    /// </summary>
    internal class BusinessLoan : CreateLoan
    {
        /// <summary>
        /// Constructor that takes neceary info and stores it in a buisnessLoan object
        /// </summary>
        /// <param name="interestRate"></param>
        /// <param name="custLastname"></param>
        /// <param name="custFirstname"></param>
        public BusinessLoan(double interestRate, string custLastname, string custFirstname) :
            base(interestRate, custLastname, custFirstname)
        {
            calcInterestRate();
        }
        /// <summary>
        /// calculates the interestrate of a buines loan
        /// </summary>
        private void calcInterestRate()
        {
            InterestRate = InterestRate + 1d;
        }
        /// <summary>
        /// calculates the total amount due at the end of the term
        /// </summary>
        /// <returns>double</returns>
        public double calcBuisnessTotalAmountDue()
        {
            double totalAmountDue = 0;
            totalAmountDue = LoanAmount + CalculateInterest();
            return totalAmountDue;
        }
        /// <summary>
        /// overrides ToString method to be more fitting
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $" Loan Number: {LoanNumber} \n Customer: {CustLastname} {CustFirstname} \n Loan Amount: R{LoanAmount} \n Loan Type: Business\n Interest Rate:  {InterestRate}% \n Term: {Term} year(s) \n Total Amount Due: R{calcBuisnessTotalAmountDue()}";
        }
    }
}
