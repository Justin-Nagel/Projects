using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Application_System
{
    /// <summary>
    /// Interface that forces Loan Constants
    /// </summary>
    public interface LoanConstants
    {
        int shortTerm { get; }
        int mediumTerm { get; }
        int longTerm { get; }
        string companyName { get; }
        double maxLoanAmount { get; }
        double minLoanAmount { get; }
    }
}
