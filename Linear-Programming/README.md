# **Linear and Integer Programming Solver Project**

Create a program that solves Linear Programming (LP) and Integer Programming (IP) Models and then analyzes how changes in an LP’s parameters affect the optimal solution. 

## **Project Requirements**

Supply the source code as a Visual Studio project. Any .NET programming language may be used. The project should build an executable (`solve.exe`) that is menu-driven with the following features:

- The program should be able to accept an input text file with the mathematical model and export all results to an output text file.

### **Minimum Requirements Criteria**

- The program should accept a random amount of decision variables.
- The program should accept a random amount of constraints.
- Use comments within the code.
- Follow programming best practices.

### **Input Text File Criteria**

The first line should contain the following, separated by spaces:

- The word `max` or `min`, to indicate whether it is a maximization or a minimization problem.
- For each decision variable, an operator to represent whether the objective function coefficient is positive or negative.
- For each decision variable, a number to represent its objective function coefficient.

A line for each constraint should include:

- The operator for the technological coefficients for the decision variables, in the same order as in the objective function on line 1, to indicate whether the coefficient is positive or negative.
- The technological coefficients for the decision variables, in the same order as in the objective function on line 1.
- The relation used in the constraint (`=`, `<=`, or `>=`), indicating an inequality relative to the constraint's right-hand side.
- The right-hand side of the constraint.

### **Sign Restrictions**

- Sign restrictions should be listed below all the constraints, separated by spaces. Use `+`, `-`, `urs`, `int`, `bin`, in the same order as in the specification of the objective function on line 1.

**Note:** The Linear Programming Model or the Integer Programming Model should be entered into the file, not the canonical forms of the different algorithms or the Relaxed Linear Programming Model.

### **Example of Input File**


