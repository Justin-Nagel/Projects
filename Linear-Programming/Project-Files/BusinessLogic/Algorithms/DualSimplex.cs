using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Algorithms
{
    public class DualSimplex : Algorithm
    {
        /// <summary>
        /// Converts the given problem into its canonical form for the Dual Simplex method.
        /// </summary>
        /// <param name="problem">The optimization problem to be transformed into canonical form.</param>
        public override void PutModelInCanonicalForm(Problem problem)
        {
            List<List<double>> tableZero = new List<List<double>>();

            // Initialize the objective function row in the tableau
            tableZero.Add(new List<double>());
            foreach (var decVar in problem.ObjectiveFunction.DecisionVariables)
            {
                tableZero[0].Add(decVar.Coefficient * -1); // Objective function coefficients (negated for minimization)
            }

            // Add placeholders for slack/surplus variables and RHS values
            for (int i = 0; i < problem.Constraints.Count; i++)
            {
                tableZero[0].Add(0); // For slack/surplus variables
                if (problem.Constraints[i].InequalitySign == InequalitySign.EqualTo)
                    tableZero[0].Add(0); // For equality constraints
            }

            tableZero[0].Add(0); // RHS of the objective function row

            // Convert equality constraints into two inequalities
            var equalsConstraints = problem.Constraints.Where(c => c.InequalitySign == InequalitySign.EqualTo).ToList();
            if (equalsConstraints?.Count() > 0)
            {
                for (int i = 0; i < equalsConstraints.Count(); i++)
                {
                    // Change equality constraints to <= and add >= constraints
                    problem.Constraints[problem.Constraints.FindIndex(c => c == equalsConstraints[i])].InequalitySign = InequalitySign.LessThanOrEqualTo;
                    var newConstraint = new Constraint
                    {
                        InequalitySign = InequalitySign.GreaterThanOrEqualTo,
                        RightHandSide = equalsConstraints[i].RightHandSide
                    };

                    foreach (var decVar in equalsConstraints[i].DecisionVariables)
                    {
                        newConstraint.DecisionVariables.Add(new DecisionVariable() { Coefficient = decVar.Coefficient });
                    }

                    problem.Constraints.Add(newConstraint); // Add the new constraint to the model
                }
            }

            // Construct the tableau from the constraints
            for (int i = 0; i < problem.Constraints.Count; i++)
            {
                List<double> constraintValues = new List<double>();

                foreach (var decVar in problem.Constraints[i].DecisionVariables)
                {
                    // Add coefficients for slack/surplus variables
                    if (problem.Constraints[i].InequalitySign == InequalitySign.LessThanOrEqualTo)
                    {
                        constraintValues.Add(decVar.Coefficient);
                    }
                    else
                    {
                        constraintValues.Add(decVar.Coefficient * -1);
                    }
                }

                // Add identity matrix part (slack/surplus variables)
                for (int j = 0; j < problem.Constraints.Count; j++)
                {
                    if (j == i)
                    {
                        constraintValues.Add(1);
                    }
                    else
                    {
                        constraintValues.Add(0);
                    }
                }

                // Add RHS values (considering sign of the constraint)
                if (problem.Constraints[i].InequalitySign == InequalitySign.LessThanOrEqualTo)
                {
                    constraintValues.Add(problem.Constraints[i].RightHandSide);
                }
                else
                {
                    constraintValues.Add(problem.Constraints[i].RightHandSide * -1);
                }

                tableZero.Add(constraintValues); // Add the constraint row to the tableau
            }

            problem.Result.Add(tableZero); // Store the initial tableau in the model's results
        }

        /// <summary>
        /// Solves the optimization problem using the Dual Simplex method.
        /// </summary>
        /// <param name="problem">The optimization problem to be solved.</param>
        public override void Solve(Problem problem)
        {
            Iterate(problem); // Perform the Dual Simplex iterations
            var primalSimplex = new PrimalSimplex();
            primalSimplex.Solve(problem); // Solve the problem using Primal Simplex after Dual Simplex
        }

        /// <summary>
        /// Iteratively performs pivot operations until no further pivoting is needed.
        /// </summary>
        /// <param name="problem">The optimization problem to be solved.</param>
        private void Iterate(Problem problem)
        {
            if (!CanPivot(problem)) // Check if pivoting is needed
                return;

            int pivotRow = GetPivotRow(problem); // Determine the row to pivot on
            int pivotColumn = GetPivotColumn(problem, pivotRow); // Determine the column to pivot on

            if (pivotColumn == -1)
                throw new InfeasibleException("There is no suitable column to pivot on - the problem is infeasible");

            Pivot(problem, pivotRow, pivotColumn); // Perform the pivot operation
            Iterate(problem); // Continue iterating
        }

        /// <summary>
        /// Determines if there are any rows that require pivoting (i.e., infeasibility).
        /// </summary>
        /// <param name="problem">The optimization problem model.</param>
        /// <returns>True if pivoting is needed; otherwise, false.</returns>
        private bool CanPivot(Problem problem)
        {
            bool canPivot = false;
            var table = problem.Result[problem.Result.Count - 1]; // Get the latest tableau

            // Check for negative values in the RHS column (indicative of infeasibility)
            for (int i = 1; i < table.Count; i++)
            {
                if (table[i][table[i].Count - 1] < -0.000000000001)
                {
                    canPivot = true;
                    break;
                }
            }

            return canPivot;
        }

        /// <summary>
        /// Finds the row with the most negative RHS value (for pivoting).
        /// </summary>
        /// <param name="problem">The optimization problem model.</param>
        /// <returns>The index of the pivot row.</returns>
        private int GetPivotRow(Problem problem)
        {
            int pivotRow = -1;
            var table = problem.Result[problem.Result.Count - 1]; // Get the latest tableau
            double mostNegative = 0;

            // Find the row with the most negative RHS value
            for (int i = 1; i < table.Count; i++)
            {
                if (table[i][table[i].Count - 1] < 0 && table[i][table[i].Count - 1] < mostNegative)
                {
                    mostNegative = table[i][table[i].Count - 1];
                    pivotRow = i;
                }
            }

            return pivotRow;
        }

        /// <summary>
        /// Finds the column to pivot on based on the minimum ratio test.
        /// </summary>
        /// <param name="problem">The optimization problem model.</param>
        /// <param name="pivotRow">The index of the pivot row.</param>
        /// <returns>The index of the pivot column.</returns>
        private int GetPivotColumn(Problem problem, int pivotRow)
        {
            int pivotColumn = -1;
            var table = problem.Result[problem.Result.Count - 1]; // Get the latest tableau

            double lowestRatio = double.MaxValue;
            // Compute the ratio for each column to find the minimum
            for (int i = 0; i < table[0].Count - 1; i++)
            {
                if (table[pivotRow][i] < 0)
                {
                    double ratio = Math.Abs(table[0][i] / table[pivotRow][i]);
                    if (ratio < lowestRatio)
                    {
                        lowestRatio = ratio;
                        pivotColumn = i;
                    }
                }
            }

            return pivotColumn;
        }

        /// <summary>
        /// Performs the pivot operation on the tableau.
        /// </summary>
        /// <param name="problem">The optimization problem model.</param>
        /// <param name="pivotRow">The index of the pivot row.</param>
        /// <param name="pivotColumn">The index of the pivot column.</param>
        private void Pivot(Problem problem, int pivotRow, int pivotColumn)
        {
            var previousTable = problem.Result[problem.Result.Count - 1]; // Get the current tableau
            var newTable = new List<List<double>>();

            // Clone the current tableau
            for (int i = 0; i < previousTable.Count; i++)
            {
                newTable.Add(new List<double>());
                for (int j = 0; j < previousTable[i].Count; j++)
                {
                    newTable[i].Add(previousTable[i][j]);
                }
            }

            // Normalize the pivot row
            double factor = 1 / newTable[pivotRow][pivotColumn];
            for (int i = 0; i < newTable[pivotRow].Count; i++)
            {
                newTable[pivotRow][i] *= factor;
            }

            // Update other rows based on the new pivot row
            double pivotColumnValue;
            for (int i = 0; i < newTable.Count; i++)
            {
                pivotColumnValue = newTable[i][pivotColumn];
                if (i != pivotRow && pivotColumnValue != 0)
                {
                    for (int j = 0; j < newTable[i].Count; j++)
                    {
                        newTable[i][j] += (-1 * pivotColumnValue * newTable[pivotRow][j]);
                    }
                }
            }

            problem.Result.Add(newTable); // Store the updated tableau in the model's results
        }
    }
}
