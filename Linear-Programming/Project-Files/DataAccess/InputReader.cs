using Common;
using Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataAccess
{
    public class InputReader
    {
        /// <summary>
        /// Reads a model from a file specified by the path and converts it to a Model object.
        /// </summary>
        /// <param name="path">The path of the file to read.</param>
        /// <returns>A Model object representing the data read from the file.</returns>
        public static Problem ReadModelFromFile(string path)
        {
            // Initialize a list to store lines read from the file
            List<string> lines = new List<string>();

            try
            {
                // Open the file and read its contents line by line
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }
                }

                // Convert the list of lines into a Model object
                return ConvertToModel(lines);
            }
            catch (FileNotFoundException)
            {
                throw new CustomException("Could not find the specified file");
            }
            catch (DirectoryNotFoundException)
            {
                throw new CustomException("Could not find the specified directory");
            }
            catch (ArgumentException)
            {
                throw new CustomException("The specified path was invalid");
            }
            catch (IOException)
            {
                throw new CustomException("There was an error reading the specified file");
            }
        }

        /// <summary>
        /// Converts a list of lines from a file into a Model object.
        /// </summary>
        /// <param name="lines">A list of lines read from the file.</param>
        /// <returns>A Model object populated with the data from the lines.</returns>
        private static Problem ConvertToModel(List<string> lines)
        {
            // Create a new Model object
            Problem model = new Problem();

            try
            {
                // Check if the file is empty
                if (lines.Count < 1)
                {
                    throw new CustomException("The specified file is empty");
                }

                // Parse the objective function line
                string[] objectiveFunction = lines[0].Split(' ');

                // Determine the problem type (maximize or minimize)
                if (!(objectiveFunction[0].ToLower().Equals("max") || objectiveFunction[0].ToLower().Equals("min")))
                {
                    throw new CustomException("The given problem does not specify whether to maximize or minimize the objective function");
                }

                model.ProblemType = objectiveFunction[0].ToLower().Equals("max") ? ProblemType.Maximization : ProblemType.Minimization;

                // Add objective function coefficients
                for (int i = 1; i < objectiveFunction.Length; i++)
                {
                    model.ObjectiveFunction.DecisionVariables.Add(new DecisionVariable() { Coefficient = double.Parse(objectiveFunction[i]) });
                }

                // Check if there are constraints
                if (lines.Count < 2)
                {
                    throw new CustomException("The given problem does not contain any constraints");
                }

                // Parse each constraint line
                for (int i = 1; i < lines.Count - 1; i++)
                {
                    string[] constraintArr = lines[i].Split(' ');
                    Constraint constraint = new Constraint();

                    // Add constraint coefficients
                    for (int j = 0; j < constraintArr.Length - 2; j++)
                    {
                        constraint.DecisionVariables.Add(new DecisionVariable() { Coefficient = double.Parse(constraintArr[j]) });
                    }

                    // Set the inequality sign
                    switch (constraintArr[constraintArr.Length - 2])
                    {
                        case "=":
                            constraint.InequalitySign = InequalitySign.EqualTo;
                            break;
                        case "<=":
                            constraint.InequalitySign = InequalitySign.LessThanOrEqualTo;
                            break;
                        case ">=":
                            constraint.InequalitySign = InequalitySign.GreaterThanOrEqualTo;
                            break;
                        default:
                            throw new CustomException($"Constraint {model.Constraints.Count + 1} does not have a valid inequality symbol");
                    }

                    // Set the right-hand side value
                    constraint.RightHandSide = double.Parse(constraintArr[constraintArr.Length - 1]);
                    model.Constraints.Add(constraint);
                }

                // Parse the sign restrictions
                string[] signRestrictions = lines[lines.Count - 1].Split(' ');

                foreach (var restriction in signRestrictions)
                {
                    switch (restriction.ToLower())
                    {
                        case "+":
                            model.SignRestrictions.Add(SignRestriction.Positive);
                            break;
                        case "-":
                            model.SignRestrictions.Add(SignRestriction.Negative);
                            break;
                        case "urs":
                            model.SignRestrictions.Add(SignRestriction.Unrestricted);
                            break;
                        case "int":
                            model.SignRestrictions.Add(SignRestriction.Integer);
                            break;
                        case "bin":
                            model.SignRestrictions.Add(SignRestriction.Binary);
                            break;
                        default:
                            throw new CustomException("Invalid sign restriction found");
                    }
                }
            }
            catch (FormatException)
            {
                throw new CustomException("One of the decision variables has an invalid coefficient");
            }

            return model;
        }
    }
}
