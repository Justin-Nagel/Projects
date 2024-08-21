using BusinessLogic.Algorithms;
using Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms; // Add reference to System.Windows.Forms for SaveFileDialog

namespace Presentation
{
    public class SolutionWriter
    {
        /// <summary>
        /// Writes the results of a model to a text file, allowing the user to specify the file location.
        /// </summary>
        /// <param name="model">The model containing the results to write.</param>
        public static void WriteResultsToFile(Problem model)
        {
            // Create a SaveFileDialog to allow the user to specify the file location
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Save Results As"
            })
            {
                // Show the dialog and check if the user clicked Save
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    // Create and open a file stream to write the results
                    using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        int iteration = 0;

                        // Iterate over each table in the model results
                        foreach (var table in model.Result)
                        {
                            writer.WriteLine($"\n\nTable {iteration}:");

                            // Write each row of the table
                            foreach (var row in table)
                            {
                                writer.WriteLine(string.Join("\t", row.Select(value => $"{value:0.###}")));
                            }

                            iteration++;
                        }
                    }

                    // Notify the user and attempt to open the file
                    Console.WriteLine($"\n\nYour solution is saved in: {fileName}");
                    OpenFile(fileName);
                }
                else
                {
                    Console.WriteLine("No file was saved.");
                }
            }
        }

        /// <summary>
        /// Writes the results of a BranchAndBoundSimplex algorithm to a text file, allowing the user to specify the file location.
        /// </summary>
        /// <param name="branchAndBoundSimplex">The BranchAndBoundSimplex instance containing the results.</param>
        public static void WriteResultsToFile(BranchAndBoundSimplex branchAndBoundSimplex)
        {
            // Create a SaveFileDialog to allow the user to specify the file location
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Save Results As"
            })
            {
                // Show the dialog and check if the user clicked Save
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    // Create and open a file stream to write the results
                    using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        // Write branch results recursively
                        var tree = branchAndBoundSimplex.Results;
                        WriteBranchResults(tree.Root, writer);

                        // Write the best candidate solution
                        var bestCandidate = branchAndBoundSimplex.GetBestCandidate();
                        writer.WriteLine("\n\nThis is the best solution of all the candidates:\n");
                        foreach (var row in bestCandidate)
                        {
                            writer.WriteLine(string.Join("\t", row.Select(value => $"{value:0.###}")));
                        }
                    }

                    // Notify the user and attempt to open the file
                    Console.WriteLine($"\n\nThe results have been written to the file: {fileName}");
                    OpenFile(fileName);
                }
                else
                {
                    Console.WriteLine("No file was saved.");
                }
            }
        }

        /// <summary>
        /// Recursively writes the results of each branch of the binary tree to the stream.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <param name="writer">The stream writer to output results to.</param>
        /// <param name="previousProblem">Identifier for the sub-problems.</param>
        private static void WriteBranchResults(BusinessLogic.BinaryTreeNode root, StreamWriter writer, string previousProblem = "0")
        {
            if (root == null)
                return;

            // Write the current problem's data
            writer.WriteLine($"\n\nSub-Problem {previousProblem}");
            foreach (var matrix in root.Data)
            {
                foreach (var row in matrix)
                {
                    writer.WriteLine(string.Join("\t", row.Select(value => $"{value:0.###}")));
                }
                writer.WriteLine();
            }

            // Recursively write the left and right branches
            WriteBranchResults(root.LeftNode, writer, $"{previousProblem}.1");
            WriteBranchResults(root.RightNode, writer, $"{previousProblem}.2");
        }

        /// <summary>
        /// Attempts to open the specified file using the default application.
        /// </summary>
        /// <param name="fileName">The name of the file to open.</param>
        private static void OpenFile(string fileName)
        {
            try
            {
                // Open the file with the default application
                Process.Start(new ProcessStartInfo
                {
                    FileName = fileName,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur when opening the file
                Console.WriteLine($"An error occurred while trying to open the file: {ex.Message}");
            }
        }
    }
}
