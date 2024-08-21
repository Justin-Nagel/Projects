using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Application_System
{
    /// <summary>
    /// inherits from Loan 
    /// </summary>
    internal class CreateLoan : Loan
    {
        /// <summary>
        /// create loan constructor that only takes in the nessasary parameters
        /// </summary>
        /// <param name="interestRate"></param>
        /// <param name="custLastname"></param>
        /// <param name="custFirstname"></param>
        public CreateLoan(double interestRate, string custLastname, string custFirstname) : base(interestRate, custLastname, custFirstname)
        {
        }
        /// <summary>
        /// calculates the total interest due after loan term
        /// </summary>
        /// <returns></returns>
        protected double CalculateInterest()
        {
            double interest=0;
            //Interest rate is devided by 100 since the input is given as a percentage
            interest = LoanAmount * InterestRate/100 * Term;
            return interest;
        }

    }

}
