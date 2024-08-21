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

### **Processing**

- Your program should provide the option to select which algorithm to use to solve the programming model.
- Your program should provide options to perform sensitivity analysis operations after the programming model has been solved.

### **Programming Model Criteria**

- Ability to solve normal max Linear Programming Models (specifically the given Knapsack IP).
- Ability to solve binary Integer Programming Models (specifically the given Knapsack IP).

### **Algorithms to be Available**

- Primal Simplex Algorithm and Revised Primal Simplex Algorithm.
- Branch and Bound Simplex Algorithm or Revised Branch and Bound Simplex Algorithm.
- Cutting Plane Algorithm or Revised Cutting Plane Algorithm.
- Branch and Bound Knapsack Algorithm.

### **Algorithm Criteria**

- Display the Canonical Form and solve using the Primal Simplex Algorithm. Display all tableau iterations.
- Display the Canonical Form and solve using the Revised Primal Simplex Algorithm. Display all Product Form and Price Out iterations.
- Display the Canonical Form and solve using the Branch & Bound Simplex Algorithm.
  - Implement backtracking.
  - Create all possible sub-problems to branch on.
  - Fathom all possible nodes of sub-problems.
  - Display all the tableau iterations of the mentioned sub-problems.
  - Display the best candidate.
- Display the Canonical Form and solve using the Cutting Plane Algorithm. Display all Product Form and Price Out iterations.
- Solve using the Branch and Bound Knapsack Algorithm.

### **Output File Format**

The output file should contain the Canonical form and all the tableau iterations of the algorithm selected to solve the Programming Model. All decimal values should be rounded to three decimal places.

### **Sensitivity Analysis Criteria**

Your program should have options to perform the following sensitivity analysis operations:

- Display the range of a selected Non-Basic Variable.
- Apply and display a change of a selected Non-Basic Variable.
- Display the range of a selected Basic Variable.
- Apply and display a change of a selected Basic Variable.
- Display the range of a selected constraint right-hand-side value.
- Apply and display a change of a selected constraint right-hand-side value.
- Display the range of a selected variable in a Non-Basic Variable column.
- Apply and display a change of a selected variable in a Non-Basic Variable column.
- Add a new activity to an optimal solution.
- Add a new constraint to an optimal solution.
- Display the shadow prices.
- **Duality**:
  - Apply Duality to the programming model.
  - Solve the Dual Programming Model.
  - Verify whether the Programming Model has Strong or Weak Duality.

### **Special Case Requirements**

- The program should be able to identify and resolve infeasible or unbounded programming models.


