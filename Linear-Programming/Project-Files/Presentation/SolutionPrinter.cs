using BusinessLogic;
using BusinessLogic.Algorithms;
using Common;
using System;
using System.Collections.Generic;
using ConsoleTables;

namespace Presentation
{
    public class SolutionPrinter
    {
        /// <summary>
        /// Prints the results of a model in a tabular format to the console.
        /// </summary>
        /// <param name="model">The model containing the results to be printed.</param>
        public static void Print(Problem model)
        {
            int iteration = 0;

            // Iterate over each table in the model results
            foreach (var table in model.Result)
            {
                Console.WriteLine($"\n\nTable {iteration}:");

                // Create an array for the headers using the first row of the table
                string[] headers = new string[table[0].Count];
                string temp = "";
                for (int j = 0; j < table[0].Count; j++)
                {
                    temp = table[0][j].ToString();
                    headers[j] = temp;
                }

                // Remove the header row from the table data
                table.RemoveAt(0);

                // Create a ConsoleTable with the extracted headers
                var conTable = new ConsoleTable(headers);

                // Add each row of the table to the ConsoleTable
                foreach (List<double> row in table)
                {
                    // Convert the row to an object array
                    object[] rowArray = new object[row.Count];
                    for (int i = 0; i < row.Count; i++)
                    {
                        rowArray[i] = row[i];
                    }
                    // Add the row to the ConsoleTable
                    conTable.AddRow(rowArray);
                }

                // Print the table with an alternative format
                Console.WriteLine();
                iteration++;
                conTable.Write(Format.Alternative);
            }
        }

        /// <summary>
        /// Prints the results of a BranchAndBoundSimplex algorithm, including the best candidate solution.
        /// </summary>
        /// <param name="branchAndBoundSimplex">The BranchAndBoundSimplex instance containing the results.</param>
        public static void Print(BranchAndBoundSimplex branchAndBoundSimplex)
        {
            // Print the branch results from the binary tree
            var tree = branchAndBoundSimplex.Results;
            PrintBranchResults(tree.Root);

            // Get and print the best candidate solution
            List<List<double>> bestCandidate = branchAndBoundSimplex.GetBestCandidate();
            Console.WriteLine("\n\nThis is the best solution of all the candidates:\n");
            for (int i = 0; i < bestCandidate.Count; i++)
            {
                for (int j = 0; j < bestCandidate[i].Count; j++)
                {
                    // Print each value in the best candidate solution formatted to three decimal places
                    Console.Write($"\t{bestCandidate[i][j]:0.###}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Recursively prints the results of each branch in the binary tree.
        /// </summary>
        /// <param name="root">The root node of the binary tree.</param>
        /// <param name="previousProblem">Identifier for the current sub-problem (used for formatting).</param>
        private static void PrintBranchResults(BinaryTreeNode root, string previousProblem = "0")
        {
            if (root == null)
                return;

            // Print the data for the current sub-problem
            if (previousProblem.Equals("0"))
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Sub-Problem 0");

                // Print the data in each matrix of the root node
                for (int i = 0; i < root.Data.Count; i++)
                {
                    for (int j = 0; j < root.Data[i].Count; j++)
                    {
                        for (int k = 0; k < root.Data[i][j].Count; k++)
                        {
                            Console.Write($"\t{root.Data[i][j][k]:0.###}");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n\n");
                }

                // Recursively print the left and right branches
                PrintBranchResults(root.LeftNode, "1");
                PrintBranchResults(root.RightNode, "2");
            }
            else
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"Sub-Problem {previousProblem}");

                // Print the data in each matrix of the current node
                for (int i = 0; i < root.Data.Count; i++)
                {
                    for (int j = 0; j < root.Data[i].Count; j++)
                    {
                        for (int k = 0; k < root.Data[i][j].Count; k++)
                        {
                            Console.Write($"\t{root.Data[i][j][k]:0.###}");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n\n");
                }

                // Recursively print the left and right branches with updated problem identifiers
                PrintBranchResults(root.LeftNode, previousProblem + ".1");
                PrintBranchResults(root.RightNode, previousProblem + ".2");
            }
        }
    }
}