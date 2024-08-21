# **Programming Project - Year 2**

This was a second-year group project for a programming class. The objective was to create an application that determines two types of loans for a company.

## **Instructions**

Unique Building Services Loan Company provides loans of up to R100,000 for construction projects. There are two categories of loans:

- **Business loans**
- **Individual loans**

Write a C# Console application that tracks all new construction loans. The application must calculate the total amount owed at the due date (original loan amount + loan fee). The application should include the following classes:

- **Loan**: A public abstract class that implements the `LoanConstants` interface. A Loan includes:
  - Loan number
  - Customer last name
  - Customer first name
  - Loan amount
  - Interest rate
  - Term
  - The constructor requires data for each field except the interest rate.
  - Do not allow loan amounts greater than R100,000.
  - Force any loan term that is not one of the three defined in the `LoanConstants` class to a short-term, 1-year loan.

- **LoanConstants**: A public interface class that includes:
  - Constant values for short term (1 year), medium-term (3 years), and long-term (5 years) loans.
  - Constants for the company name and the maximum loan amount.

- **BusinessLoan**: A public class that extends `Loan`. The `BusinessLoan` constructor sets the interest rate to 1% more than the current prime interest rate.

- **PersonalLoan**: A public class that extends `Loan`. The `PersonalLoan` constructor sets the interest rate to 2% more than the current prime interest rate.

- **CreateLoans**: An application that:
  - Creates an array of five Loans.
  - Prompts the user for the current prime interest rate.
  - Uses a loop to prompt the user for a loan type and all relevant information for that loan.
  - When data entry is complete, displays all the loans.
