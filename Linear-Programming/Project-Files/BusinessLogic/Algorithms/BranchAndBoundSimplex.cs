using Common;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Algorithms
{
    /// <summary>
    /// An implementation of the Branch-and-Bound algorithm combined with the Simplex method.
    /// This class solves integer programming problems using a branch-and-bound approach.
    /// </summary>
    public class BranchAndBoundSimplex : Algorithm
    {
        private Problem problem;
        public BinaryTree Results { get; set; } = new BinaryTree();
        private DualSimplex dualSimplex = new DualSimplex();
        private List<List<List<double>>> candidateSolutions = new List<List<List<double>>>();

        /// <summary>
        /// Transforms the given problem into its canonical form using the Dual Simplex method.
        /// Adds the canonical form result to the binary tree.
        /// </summary>
        /// <param name="problem">The optimization problem to be transformed.</param>
        public override void PutModelInCanonicalForm(Problem problem)
        {
            dualSimplex.PutModelInCanonicalForm(problem);
            Results.Add(problem.Result);
        }

        /// <summary>
        /// Solves the optimization problem using a branch-and-bound approach.
        /// Iterates through levels of the binary tree, solving and branching as needed.
        /// </summary>
        /// <param name="problem">The optimization problem to be solved.</param>
        public override void Solve(Problem problem)
        {
            this.problem = problem;

            int level = 1;
            // Iterate through levels of the binary tree
            while (level <= Results.GetHeight(Results.Root))
            {
                SolveCurrentLevel(Results.Root, level);
                level++;
            }
        }

        /// <summary>
        /// Solves the current level of the binary tree and branches if necessary.
        /// </summary>
        /// <param name="root">The root node of the current level.</param>
        /// <param name="level">The current level in the binary tree.</param>
        private void SolveCurrentLevel(BinaryTreeNode root, int level)
        {
            if (root == null)
                return;

            if (level == 1)
            {
                try
                {
                    Solve(root);
                    Branch(root);
                }
                catch (InfeasibleException)
                {
                    // If the solution is infeasible, no further branching is done from this node
                    return;
                }
            }
            else if (level > 1)
            {
                SolveCurrentLevel(root.LeftNode, level - 1);
                SolveCurrentLevel(root.RightNode, level - 1);
            }
        }

        /// <summary>
        /// Finds the best candidate solution among the collected solutions.
        /// </summary>
        /// <returns>The best solution based on the problem type (maximization or minimization).</returns>
        public List<List<double>> GetBestCandidate()
        {
            double bestRHS = candidateSolutions[0][0][candidateSolutions[0][0].Count - 1];
            List<List<double>> bestSolution = candidateSolutions[0];

            for (int i = 1; i < candidateSolutions.Count; i++)
            {
                if (problem.ProblemType == ProblemType.Maximization)
                {
                    if (candidateSolutions[i][0][candidateSolutions[i][0].Count - 1] > bestRHS)
                    {
                        bestRHS = candidateSolutions[i][0][candidateSolutions[i][0].Count - 1];
                        bestSolution = candidateSolutions[i];
                    }
                }
                else
                {
                    if (candidateSolutions[i][0][candidateSolutions[i][0].Count - 1] < bestRHS)
                    {
                        bestRHS = candidateSolutions[i][0][candidateSolutions[i][0].Count - 1];
                        bestSolution = candidateSolutions[i];
                    }
                }
            }

            return bestSolution;
        }

        /// <summary>
        /// Solves a given node using the Dual Simplex method.
        /// </summary>
        /// <param name="root">The node containing the problem data.</param>
        private void Solve(BinaryTreeNode root)
        {
            var model = new Problem() { ProblemType = this.problem.ProblemType, Result = root.Data };
            dualSimplex.Solve(model);
        }

        /// <summary>
        /// Branches the current node into sub-problems based on the branching variable.
        /// </summary>
        /// <param name="root">The node to branch from.</param>
        private void Branch(BinaryTreeNode root)
        {
            // Check if branching is needed
            if (CanBranch(root).Count == 0)
            {
                // If no further branching is needed, add the solution to candidate solutions
                candidateSolutions.Add(root.Data[root.Data.Count - 1]);
            }
            else
            {
                // Determine the variable to branch on
                int branchVariableIndex = GetBranchVariable(root.Data[root.Data.Count - 1], CanBranch(root));
                // Create sub-problems and add them to the binary tree
                AddSubProblems(root, branchVariableIndex);
            }
        }

        /// <summary>
        /// Adds sub-problems to the binary tree based on the branching variable.
        /// </summary>
        /// <param name="root">The current node from which to branch.</param>
        /// <param name="branchVariableIndex">The index of the variable to branch on.</param>
        private void AddSubProblems(BinaryTreeNode root, int branchVariableIndex)
        {
            var table = root.Data[root.Data.Count - 1];
            double rhs = GetRhsOfVariable(branchVariableIndex, table);

            int constraintOneRhs;
            int constraintTwoRhs;

            constraintOneRhs = (int)Math.Truncate(rhs);
            constraintTwoRhs = constraintOneRhs + 1;

            var subProblemOneTable = ListCloner.CloneList(table);
            var subProblemTwoTable = ListCloner.CloneList(table);

            // Add new rows for the constraints
            subProblemOneTable.Add(new List<double>());
            subProblemTwoTable.Add(new List<double>());

            for (int i = 0; i < subProblemOneTable[0].Count - 1; i++)
            {
                if (i == branchVariableIndex)
                {
                    subProblemOneTable[subProblemOneTable.Count - 1].Add(1);
                    subProblemTwoTable[subProblemTwoTable.Count - 1].Add(-1);
                }
                else
                {
                    subProblemOneTable[subProblemOneTable.Count - 1].Add(0);
                    subProblemTwoTable[subProblemTwoTable.Count - 1].Add(0);
                }
            }

            subProblemOneTable[subProblemOneTable.Count - 1].Add(constraintOneRhs);
            subProblemTwoTable[subProblemTwoTable.Count - 1].Add(constraintTwoRhs * -1);

            // Adjust the objective function row
            for (int i = 0; i < subProblemOneTable.Count; i++)
            {
                var tempOne = subProblemOneTable[i][subProblemOneTable[i].Count - 1];
                var tempTwo = subProblemTwoTable[i][subProblemTwoTable[i].Count - 1];

                if (i == subProblemOneTable.Count - 1)
                {
                    subProblemOneTable[i][subProblemOneTable[i].Count - 1] = 1;
                    subProblemTwoTable[i][subProblemTwoTable[i].Count - 1] = 1;
                }
                else
                {
                    subProblemOneTable[i][subProblemOneTable[i].Count - 1] = 0;
                    subProblemTwoTable[i][subProblemTwoTable[i].Count - 1] = 0;
                }

                subProblemOneTable[i].Add(tempOne);
                subProblemTwoTable[i].Add(tempTwo);
            }

            int subProblemBasicRow = GetBasicRow(table, branchVariableIndex);

            for (int i = 0; i < subProblemOneTable[subProblemBasicRow].Count; i++)
            {
                subProblemOneTable[subProblemOneTable.Count - 1][i] -= subProblemOneTable[subProblemBasicRow][i];
                subProblemTwoTable[subProblemTwoTable.Count - 1][i] += subProblemTwoTable[subProblemBasicRow][i];
            }

            // Add the sub-problems to the binary tree
            Results.Add(new List<List<List<double>>>() { subProblemOneTable }, root.Data);
            Results.Add(new List<List<List<double>>>() { subProblemTwoTable }, root.Data);
        }

        /// <summary>
        /// Finds the row in the table that corresponds to the basic variable.
        /// </summary>
        /// <param name="table">The table representing the problem.</param>
        /// <param name="branchVariableIndex">The index of the variable to find.</param>
        /// <returns>The index of the basic row.</returns>
        private int GetBasicRow(List<List<double>> table, int branchVariableIndex)
        {
            int basicRow = -1;

            for (int i = 1; i < table.Count; i++)
            {
                if (table[i][branchVariableIndex] == 1)
                {
                    basicRow = i;
                    break;
                }
            }

            return basicRow;
        }

        /// <summary>
        /// Determines the variable to branch on based on the fractional part of the right-hand side value.
        /// </summary>
        /// <param name="table">The table representing the problem.</param>
        /// <param name="intBinVarIndexes">The indexes of integer or binary variables.</param>
        /// <returns>The index of the variable to branch on.</returns>
        private int GetBranchVariable(List<List<double>> table, List<int> intBinVarIndexes)
        {
            if (intBinVarIndexes.Count == 1)
                return intBinVarIndexes[0];

            int branchVariableIndex = -1;
            decimal smallestFractionalPart = 1;

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
        /// Identifies which variables can be used for branching.
        /// </summary>
        /// <param name="root">The current node in the binary tree.</param>
        /// <returns>A list of variable indexes that can be branched on.</returns>
        private List<int> CanBranch(BinaryTreeNode root)
        {
            var intBinVarIndexes = new List<int>();
            var indexesToDiscard = new List<int>();

            // Identify integer and binary variables
            for (int i = 0; i < problem.SignRestrictions.Count; i++)
            {
                if (problem.SignRestrictions[i] == SignRestriction.Integer || problem.SignRestrictions[i] == SignRestriction.Binary)
                {
                    intBinVarIndexes.Add(i);
                }
            }

            var table = root.Data[root.Data.Count - 1];

            foreach (var intBinVar in intBinVarIndexes)
            {
                if (!IsVariableBasic(intBinVar, table))
                {
                    indexesToDiscard.Add(intBinVar);
                }
                else
                {
                    double rhs = GetRhsOfVariable(intBinVar, table);

                    if (rhs - Math.Truncate(rhs) < 0.00001)
                    {
                        indexesToDiscard.Add(intBinVar);
                    }
                }
            }

            intBinVarIndexes.RemoveAll(v => indexesToDiscard.Contains(v) == true);

            return intBinVarIndexes;
        }

        /// <summary>
        /// Retrieves the right-hand side value of a variable from the table.
        /// </summary>
        /// <param name="intBinVar">The index of the integer or binary variable.</param>
        /// <param name="table">The table representing the problem.</param>
        /// <returns>The right-hand side value of the variable.</returns>
        private double GetRhsOfVariable(int intBinVar, List<List<double>> table)
        {
            if (!IsVariableBasic(intBinVar, table))
                return 0;

            double rhs = 0;

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
        /// Checks if a variable is a basic variable in the table.
        /// </summary>
        /// <param name="intBinVar">The index of the variable to check.</param>
        /// <param name="table">The table representing the problem.</param>
        /// <returns>True if the variable is basic, otherwise false.</returns>
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
                    isBasic = false;
                    break;
                }
            }

            return isBasic;
        }
    }
}
