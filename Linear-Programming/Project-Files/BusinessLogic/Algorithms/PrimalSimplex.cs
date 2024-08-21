using Common;
using Models;
using System.Collections.Generic;

namespace BusinessLogic.Algorithms
{
    public class PrimalSimplex : Algorithm
    {
        /// <summary>
        /// Converts the given problem into its canonical form for the Primal Simplex method.
        /// </summary>
        /// <param name="model">The optimization problem to be transformed into canonical form.</param>
        public override void PutModelInCanonicalForm(Problem model)
        {
            List<List<double>> tableZero = new List<List<double>>();

            // Initialize the objective function row in the tableau
            tableZero.Add(new List<double>());
            foreach (var decVar in model.ObjectiveFunction.DecisionVariables)
            {
                tableZero[0].Add(decVar.Coefficient * -1); // Objective function coefficients (negated for minimization)
            }

            // Add placeholders for slack variables and RHS values
            for (int i = 0; i <= model.Constraints.Count; i++)
            {
                tableZero[0].Add(0); // Placeholder for slack variables and RHS
            }

            // Construct the tableau from the constraints
            for (int i = 0; i < model.Constraints.Count; i++)
            {
                List<double> constraintValues = new List<double>();

                // Add coefficients for decision variables
                foreach (var decVar in model.Constraints[i].DecisionVariables)
                {
                    constraintValues.Add(decVar.Coefficient);
                }

                // Add identity matrix part (slack variables)
                for (int j = 0; j < model.Constraints.Count; j++)
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

                // Add RHS values for the constraint
                constraintValues.Add(model.Constraints[i].RightHandSide);

                tableZero.Add(constraintValues); // Add the constraint row to the tableau
            }

            model.Result.Add(tableZero); // Store the initial tableau in the model's results
        }

        /// <summary>
        /// Solves the optimization problem using the Primal Simplex method.
        /// </summary>
        /// <param name="model">The optimization problem to be solved.</param>
        public override void Solve(Problem model)
        {
            Iterate(model); // Perform the Primal Simplex iterations
        }

        /// <summary>
        /// Checks if the current solution is optimal.
        /// </summary>
        /// <param name="model">The optimization problem model.</param>
        /// <returns>True if the solution is optimal; otherwise, false.</returns>
        private bool IsOptimal(Problem model)
        {
            bool isOptimal = true;
            var table = model.Result[model.Result.Count - 1]; // Get the latest tableau

            // Check if the current solution satisfies optimality conditions
            if (model.ProblemType == ProblemType.Maximization)
            {
                for (int i = 0; i < table[0].Count - 1; i++)
                {
                    if (table[0][i] < 0)
                    {
                        isOptimal = false;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < table[0].Count - 1; i++)
                {
                    if (table[0][i] > 0)
                    {
                        isOptimal = false;
                        break;
                    }
                }
            }

            return isOptimal;
        }

        /// <summary>
        /// Iteratively performs pivot operations until an optimal solution is found.
        /// </summary>
        /// <param name="model">The optimization problem to be solved.</param>
        private void Iterate(Problem model)
        {
            if (IsOptimal(model)) // Check if the solution is already optimal
                return;

            int pivotColumn = GetPivotColumn(model); // Determine the column to pivot on
            int pivotRow = GetPivotRow(model, pivotColumn); // Determine the row to pivot on

            if (pivotRow == -1)
                throw new InfeasibleException("There is no suitable row to pivot on - the problem is infeasible");

            Pivot(model, pivotRow, pivotColumn); // Perform the pivot operation

            Iterate(model); // Continue iterating
        }

        /// <summary>
        /// Performs the pivot operation on the tableau.
        /// </summary>
        /// <param name="model">The optimization problem model.</param>
        /// <param name="pivotRow">The index of the pivot row.</param>
        /// <param name="pivotColumn">The index of the pivot column.</param>
        private void Pivot(Problem model, int pivotRow, int pivotColumn)
        {
            var previousTable = model.Result[model.Result.Count - 1]; // Get the current tableau
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

            model.Result.Add(newTable); // Store the updated tableau in the model's results
        }

        /// <summary>
        /// Determines the column to pivot on based on the objective function's coefficients.
        /// </summary>
        /// <param name="model">The optimization problem model.</param>
        /// <returns>The index of the pivot column.</returns>
        private int GetPivotColumn(Problem model)
        {
            int colIndex = -1;
            var table = model.Result[model.Result.Count - 1]; // Get the latest tableau

            if (model.ProblemType == ProblemType.Maximization)
            {
                double mostNegative = 0;

                // Find the column with the most negative coefficient in the objective function (for maximization)
                for (int i = 0; i < table[0].Count - 1; i++)
                {
                    if (table[0][i] < 0 && table[0][i] < mostNegative)
                    {
                        mostNegative = table[0][i];
                        colIndex = i;
                    }
                }
            }
            else
            {
                double mostPositive = 0;

                // Find the column with the most positive coefficient in the objective function (for minimization)
                for (int i = 0; i < table[0].Count - 1; i++)
                {
                    if (table[0][i] > 0 && table[0][i] > mostPositive)
                    {
                        mostPositive = table[0][i];
                        colIndex = i;
                    }
                }
            }

            return colIndex;
        }

        /// <summary>
        /// Determines the row to pivot on based on the minimum ratio test.
        /// </summary>
        /// <param name="model">The optimization problem model.</param>
        /// <param name="pivotColumn">The index of the pivot column.</param>
        /// <returns>The index of the pivot row.</returns>
        private int GetPivotRow(Problem model, int pivotColumn)
        {
            int rowIndex = -1;
            var table = model.Result[model.Result.Count - 1]; // Get the latest tableau

            double lowestRatio = double.MaxValue;
            // Compute the ratio for each row to find the minimum
            for (int i = 1; i < table.Count; i++)
            {
                if (table[i][pivotColumn] > 0)
                {
                    double ratio = table[i][table[i].Count - 1] / table[i][pivotColumn];
                    if (ratio < lowestRatio && ratio >= 0)
                    {
                        lowestRatio = ratio;
                        rowIndex = i;
                    }
                }
            }

            return rowIndex;
        }
    }
}
