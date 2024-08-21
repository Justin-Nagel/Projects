using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Algorithms
{
    public class CuttingPlane : Algorithm
    {
        private DualSimplex dualSimplex = new DualSimplex();

        /// <summary>
        /// Transforms the given optimization problem into its canonical form and solves it using DualSimplex.
        /// </summary>
        /// <param name="problem">The optimization problem to be transformed and solved.</param>
        public override void PutModelInCanonicalForm(Problem problem)
        {
            dualSimplex.PutModelInCanonicalForm(problem); // Transform the model into canonical form
            dualSimplex.Solve(problem); // Solve the transformed model
        }

        /// <summary>
        /// Solves the optimization problem using the Cutting Plane method.
        /// Iteratively adds cutting planes and solves the problem until no more cuts are needed.
        /// </summary>
        /// <param name="problem">The optimization problem to be solved.</param>
        public override void Solve(Problem problem)
        {
            // Continue the process while there are variables that need cutting
            while (CanCut(problem).Count > 0)
            {
                Cut(problem); // Add a cutting plane
                dualSimplex.Solve(problem); // Solve the problem with the new cutting plane
            }
        }

        /// <summary>
        /// Adds a cutting plane to the problem's current solution.
        /// </summary>
        /// <param name="problem">The optimization problem to be modified.</param>
        private void Cut(Problem problem)
        {
            var table = problem.Result[problem.Result.Count - 1]; // Get the last tableau from the results

            int cutVariableIndex = GetCutVariable(table, CanCut(problem)); // Determine which variable to cut
            int basicRow = GetBasicRow(table, cutVariableIndex); // Find the basic row associated with the variable

            List<double> cutConstraint = GetCutConstraint(table, basicRow); // Create the cut constraint

            var newTable = ListCloner.CloneList(table); // Clone the current tableau
            newTable.Add(cutConstraint); // Add the new constraint to the tableau

            // Update the tableau to include the new constraint
            for (int i = 0; i < newTable.Count; i++)
            {
                if (i == newTable.Count - 1) // For the newly added constraint
                {
                    newTable[i].Insert(newTable[i].Count - 1, 1); // Add a 1 in the last column
                }
                else
                {
                    newTable[i].Insert(newTable[i].Count - 1, 0); // Add a 0 in the last column for other rows
                }
            }

            problem.Result.Add(newTable); // Add the modified tableau to the model's results
        }

        /// <summary>
        /// Constructs the cut constraint for a given basic row.
        /// </summary>
        /// <param name="table">The current tableau.</param>
        /// <param name="basicRow">The index of the basic row.</param>
        /// <returns>A list representing the cut constraint.</returns>
        private List<double> GetCutConstraint(List<List<double>> table, int basicRow)
        {
            List<double> cutConstraint = new List<double>();

            for (int i = 0; i < table[basicRow].Count; i++)
            {
                if (table[basicRow][i] == Math.Truncate(table[basicRow][i]))
                {
                    cutConstraint.Add(0); // No fractional part, add 0
                }
                else
                {
                    // Calculate the fractional part and add its negative to the cut constraint
                    double fractionalPart = Math.Abs(Math.Floor(table[basicRow][i]) - table[basicRow][i]);
                    cutConstraint.Add(-1 * fractionalPart);
                }
            }

            return cutConstraint;
        }

        /// <summary>
        /// Determines which variables can be cut based on their current solution.
        /// </summary>
        /// <param name="problem">The optimization problem model.</param>
        /// <returns>A list of indices of variables that are eligible for cutting.</returns>
        private List<int> CanCut(Problem problem)
        {
            List<int> intBinVarIndexes = new List<int>(); // List to hold indices of integer and binary variables
            List<int> indexesToDiscard = new List<int>(); // List to hold indices of variables that should not be cut

            var lastTable = problem.Result[problem.Result.Count - 1]; // Get the last tableau from the results

            // Identify integer and binary variables
            for (int i = 0; i < problem.SignRestrictions.Count; i++)
            {
                if (problem.SignRestrictions[i] == SignRestriction.Integer || problem.SignRestrictions[i] == SignRestriction.Binary)
                {
                    intBinVarIndexes.Add(i);
                }
            }

            // Check each variable to see if it can be cut
            foreach (var intBinVar in intBinVarIndexes)
            {
                if (!IsVariableBasic(intBinVar, lastTable))
                {
                    indexesToDiscard.Add(intBinVar); // Discard variables that are not basic
                }
                else
                {
                    double rhs = GetRhsOfVariable(intBinVar, lastTable);

                    if (rhs - Math.Truncate(rhs) < 0.00001)
                    {
                        indexesToDiscard.Add(intBinVar); // Discard variables with integer right-hand side values
                    }
                }
            }

            // Remove discarded indices from the list of variables to cut
            intBinVarIndexes.RemoveAll(v => indexesToDiscard.Contains(v));

            return intBinVarIndexes;
        }

        /// <summary>
        /// Retrieves the right-hand side (RHS) value of a given variable from the tableau.
        /// </summary>
        /// <param name="intBinVar">The index of the integer or binary variable.</param>
        /// <param name="table">The current tableau.</param>
        /// <returns>The RHS value of the variable.</returns>
        private double GetRhsOfVariable(int intBinVar, List<List<double>> table)
        {
            if (!IsVariableBasic(intBinVar, table))
                return 0; // Variable is not basic, hence RHS is 0

            double rhs = 0;

            // Find the RHS value for the variable
            for (int i = 1; i < table.Count; i++)
            {
                if (table[i][intBinVar] == 1)
                {
                    rhs = table[i][table[i].Count - 1];
                    break;
                }
            }

            return rhs;
        }

        /// <summary>
        /// Checks if a given variable is a basic variable in the tableau.
        /// </summary>
        /// <param name="intBinVar">The index of the variable to check.</param>
        /// <param name="table">The current tableau.</param>
        /// <returns>True if the variable is basic; otherwise, false.</returns>
        private bool IsVariableBasic(int intBinVar, List<List<double>> table)
        {
            bool isBasic = true;

            for (int i = 0; i < table.Count; i++)
            {
                int numberOfOnes = 0;

                if (table[i][intBinVar] == 1)
                    numberOfOnes++;

                if ((table[i][intBinVar] != 0 && table[i][intBinVar] != 1) || numberOfOnes > 1)
                {
                    isBasic = false; // Variable is not basic if it is not 0 or 1, or if there are multiple ones
                    break;
                }
            }

            return isBasic;
        }

        /// <summary>
        /// Determines the variable to cut based on the fractional part of the right-hand side values.
        /// </summary>
        /// <param name="table">The current tableau.</param>
        /// <param name="intBinVarIndexes">The list of indices of integer and binary variables.</param>
        /// <returns>The index of the variable to cut.</returns>
        private int GetCutVariable(List<List<double>> table, List<int> intBinVarIndexes)
        {
            if (intBinVarIndexes.Count == 1)
                return intBinVarIndexes[0]; // Only one variable to cut

            int branchVariableIndex = -1;
            decimal smallestFractionalPart = 1;

            // Find the variable with the fractional part closest to 0.5
            foreach (var intBinVar in intBinVarIndexes)
            {
                var rhs = (Decimal)GetRhsOfVariable(intBinVar, table);
                decimal fractionalPart = rhs - Math.Truncate(rhs);
                if (Math.Abs(0.5m - fractionalPart) < smallestFractionalPart)
                {
                    smallestFractionalPart = Math.Abs(0.5m - fractionalPart);
                    branchVariableIndex = intBinVar;
                }
            }

            return branchVariableIndex;
        }

        /// <summary>
        /// Finds the basic row for a given variable in the tableau.
        /// </summary>
        /// <param name="table">The current tableau.</param>
        /// <param name="variableIndex">The index of the variable.</param>
        /// <returns>The index of the basic row for the variable.</returns>
        private int GetBasicRow(List<List<double>> table, int variableIndex)
        {
            int basicRow = -1;

            // Find the row where the variable is basic (i.e., its coefficient is 1)
            for (int i = 1; i < table.Count; i++)
            {
                if (table[i][variableIndex] == 1)
                {
                    basicRow = i;
                    break;
                }
            }

            return basicRow;
        }
    }
}
