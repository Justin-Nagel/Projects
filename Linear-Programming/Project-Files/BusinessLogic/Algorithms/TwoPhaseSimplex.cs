using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Algorithms
{
    public class TwoPhaseSimplex : Algorithm
    {
        private int numberOfArtificialVars = 0; // Tracks the number of artificial variables used in the problem

        /// <summary>
        /// Converts the problem into canonical form and sets up the two-phase simplex tableau.
        /// </summary>
        /// <param name="model">The optimization problem to be transformed.</param>
        public override void PutModelInCanonicalForm(Problem model)
        {
            // Convert constraints with negative right-hand sides to positive
            for (int i = 0; i < model.Constraints.Count; i++)
            {
                if (model.Constraints[i].RightHandSide < 0)
                {
                    for (int j = 0; j < model.Constraints[i].DecisionVariables.Count; j++)
                    {
                        model.Constraints[i].DecisionVariables[j].Coefficient *= -1;
                    }

                    model.Constraints[i].RightHandSide *= -1;

                    // Flip the inequality sign
                    model.Constraints[i].InequalitySign = model.Constraints[i].InequalitySign == InequalitySign.LessThanOrEqualTo
                        ? InequalitySign.GreaterThanOrEqualTo
                        : InequalitySign.LessThanOrEqualTo;
                }
            }

            // Initialize the tableau
            List<List<double>> tableZero = new List<List<double>>();

            // Objective function row (negated for minimization)
            tableZero.Add(new List<double>());
            foreach (var decVar in model.ObjectiveFunction.DecisionVariables)
            {
                tableZero[0].Add(decVar.Coefficient * -1);
            }

            // Add placeholders for slack, surplus, and artificial variables
            foreach (var constraint in model.Constraints)
            {
                if (constraint.InequalitySign == InequalitySign.LessThanOrEqualTo ||
                    constraint.InequalitySign == InequalitySign.GreaterThanOrEqualTo)
                {
                    tableZero[0].Add(0); // Slack/Surplus variables
                }

                if (constraint.InequalitySign == InequalitySign.EqualTo ||
                    constraint.InequalitySign == InequalitySign.GreaterThanOrEqualTo)
                {
                    tableZero[0].Add(0); // Artificial variables
                }
            }

            // Add a zero for the right-hand side of the constraints
            tableZero[0].Add(0);

            // Add constraints to the tableau
            for (int i = 0; i < model.Constraints.Count; i++)
            {
                List<double> constraintValues = new List<double>();

                // Add coefficients for decision variables
                foreach (var decVar in model.Constraints[i].DecisionVariables)
                {
                    constraintValues.Add(decVar.Coefficient);
                }

                // Add slack/surplus and artificial variables
                for (int j = 0; j < model.Constraints.Count; j++)
                {
                    if (model.Constraints[j].InequalitySign == InequalitySign.LessThanOrEqualTo)
                    {
                        constraintValues.Add(j == i ? 1 : 0); // Slack variable
                    }
                    else if (model.Constraints[j].InequalitySign == InequalitySign.GreaterThanOrEqualTo)
                    {
                        constraintValues.Add(j == i ? -1 : 0); // Surplus variable
                    }
                }

                constraintValues.Add(model.Constraints[i].RightHandSide);

                // Add artificial variables if needed
                for (int j = 0; j < model.Constraints.Count; j++)
                {
                    if (model.Constraints[j].InequalitySign == InequalitySign.EqualTo ||
                        model.Constraints[j].InequalitySign == InequalitySign.GreaterThanOrEqualTo)
                    {
                        constraintValues.Insert(constraintValues.Count - 1, j == i ? 1 : 0);
                    }
                }

                tableZero.Add(constraintValues);
            }

            // Count the number of artificial variables
            numberOfArtificialVars = model.Constraints.Count(c =>
                c.InequalitySign == InequalitySign.EqualTo || c.InequalitySign == InequalitySign.GreaterThanOrEqualTo);

            // Set up the objective function row for the artificial variables phase
            List<double> wRow = new List<double>(new double[tableZero[0].Count]);
            for (int i = 1; i < tableZero.Count; i++)
            {
                if (model.Constraints[i - 1].InequalitySign == InequalitySign.EqualTo ||
                    model.Constraints[i - 1].InequalitySign == InequalitySign.GreaterThanOrEqualTo)
                {
                    for (int j = 0; j < (tableZero[i].Count - numberOfArtificialVars - 1); j++)
                    {
                        wRow[j] += tableZero[i][j];
                    }
                    wRow[wRow.Count - 1] += tableZero[i][tableZero[i].Count - 1];
                }
            }

            tableZero.Insert(0, wRow);
            model.Result.Add(tableZero);
        }

        /// <summary>
        /// Solves the optimization problem using the Two-Phase Simplex method.
        /// </summary>
        /// <param name="model">The optimization problem to be solved.</param>
        public override void Solve(Problem model)
        {
            Iterate(model);

            var lastTable = model.Result[model.Result.Count - 1];

            // Check for infeasibility based on the objective function value in the last tableau
            if (lastTable[0][lastTable[0].Count - 1] > 0)
            {
                throw new InfeasibleException("The problem is infeasible");
            }

            bool allArtificialsNonBasic = true;

            // Check if all artificial variables are non-basic
            for (int i = lastTable[0].Count - (numberOfArtificialVars + 1); i < lastTable[0].Count - 1; i++)
            {
                if (IsVariableBasic(i, lastTable))
                {
                    allArtificialsNonBasic = false;
                    break;
                }
            }

            if (allArtificialsNonBasic)
            {
                // Remove the artificial variable rows and columns if they are non-basic
                lastTable.RemoveAt(0);
                for (int i = 0; i < lastTable.Count; i++)
                {
                    for (int j = 0; j < numberOfArtificialVars; j++)
                    {
                        lastTable[i].RemoveAt(lastTable[i].Count - 2);
                    }
                }
            }
            else
            {
                // Remove non-basic variables from the tableau
                for (int i = 0; i < model.ObjectiveFunction.DecisionVariables.Count; i++)
                {
                    if (lastTable[0][i] < 0)
                    {
                        for (int j = 0; j < lastTable.Count; j++)
                        {
                            lastTable[j].RemoveAt(i);
                        }
                    }
                }

                for (int i = lastTable[0].Count - (numberOfArtificialVars + 1); i < lastTable[0].Count - 1; i++)
                {
                    if (!IsVariableBasic(i, lastTable))
                    {
                        for (int j = 0; j < lastTable.Count; j++)
                        {
                            lastTable[j].RemoveAt(i);
                        }
                    }
                }

                lastTable.RemoveAt(0);
            }

            // Solve the problem using the Primal Simplex method
            var primalSimplex = new PrimalSimplex();
            primalSimplex.Solve(model);
        }

        /// <summary>
        /// Checks if the current solution is optimal.
        /// </summary>
        /// <param name="model">The optimization problem model.</param>
        /// <returns>True if the solution is optimal; otherwise, false.</returns>
        private bool IsOptimal(Problem model)
        {
            bool isOptimal = true;
            var table = model.Result[model.Result.Count - 1];

            // Check for optimality based on the objective function row
            for (int i = 0; i < table[0].Count - 1; i++)
            {
                if (table[0][i] > 0)
                {
                    isOptimal = false;
                    break;
                }
            }

            return isOptimal;
        }

        /// <summary>
        /// Performs iterations of the simplex method until an optimal solution is found.
        /// </summary>
        /// <param name="model">The optimization problem to be solved.</param>
        private void Iterate(Problem model)
        {
            if (IsOptimal(model))
                return;

            int pivotColumn = GetPivotColumn(model);
            int pivotRow = GetPivotRow(model, pivotColumn);

            if (pivotRow == -1)
                throw new InfeasibleException("There is no suitable row to pivot on - the problem is infeasible");

            Pivot(model, pivotRow, pivotColumn);

            Iterate(model);
        }

        /// <summary>
        /// Performs the pivot operation on the tableau.
        /// </summary>
        /// <param name="model">The optimization problem model.</param>
        /// <param name="pivotRow">The index of the pivot row.</param>
        /// <param name="pivotColumn">The index of the pivot column.</param>
        private void Pivot(Problem model, int pivotRow, int pivotColumn)
        {
            var previousTable = model.Result[model.Result.Count - 1];
            var newTable = new List<List<double>>();

            // Copy the previous tableau
            for (int i = 0; i < previousTable.Count; i++)
            {
                newTable.Add(new List<double>(previousTable[i]));
            }

            // Normalize the pivot row
            double factor = 1 / newTable[pivotRow][pivotColumn];
            for (int i = 0; i < newTable[pivotRow].Count; i++)
            {
                newTable[pivotRow][i] *= factor;
            }

            // Update other rows
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

            model.Result.Add(newTable);
        }

        /// <summary>
        /// Finds the pivot column by selecting the most positive coefficient in the objective function row.
        /// </summary>
        /// <param name="model">The optimization problem model.</param>
        /// <returns>The index of the pivot column.</returns>
        private int GetPivotColumn(Problem model)
        {
            int colIndex = -1;
            var table = model.Result[model.Result.Count - 1];
            double mostPositive = 0;

            // Find the most positive coefficient in the objective function row
            for (int i = 0; i < table[0].Count - 1; i++)
            {
                if (table[0][i] > 0 && table[0][i] > mostPositive)
                {
                    mostPositive = table[0][i];
                    colIndex = i;
                }
            }

            return colIndex;
        }

        /// <summary>
        /// Finds the pivot row by selecting the row with the minimum ratio.
        /// </summary>
        /// <param name="model">The optimization problem model.</param>
        /// <param name="pivotColumn">The index of the pivot column.</param>
        /// <returns>The index of the pivot row.</returns>
        private int GetPivotRow(Problem model, int pivotColumn)
        {
            int rowIndex = -1;
            var table = model.Result[model.Result.Count - 1];

            double lowestRatio = double.MaxValue;
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

        /// <summary>
        /// Determines if a variable is a basic variable.
        /// </summary>
        /// <param name="index">The index of the variable.</param>
        /// <param name="table">The tableau.</param>
        /// <returns>True if the variable is basic; otherwise, false.</returns>
        private bool IsVariableBasic(int index, List<List<double>> table)
        {
            bool isBasic = true;

            for (int i = 0; i < table.Count; i++)
            {
                int numberOfOnes = 0;

                if (table[i][index] == 1)
                    numberOfOnes++;

                if ((table[i][index] != 0 && table[i][index] != 1) || numberOfOnes > 1)
                {
                    isBasic = false;
                    break;
                }
            }

            return isBasic;
        }
    }
}
