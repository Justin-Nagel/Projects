using BusinessLogic;
using BusinessLogic.Algorithms;
using Common;
using DataAccess;
using Models;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Presentation
{
    public class MainMenu
    {
        // P/Invoke to get screen dimensions
        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        private const int SM_CXSCREEN = 1920;
        private const int SM_CYSCREEN = 1080;

        /// <summary>
        /// Main entry point for the application. Handles the menu and file selection process.
        /// </summary>
        public static void Run()
        {

            while (true) // Infinite loop to keep the application running until the user decides to exit
            {
                
                Problem model = new Problem(); // Initialize a new Model instance

                try
                {
                    Console.Clear();
                    // Display welcome messages with typewriter effect
                    TypewriterEffect("LPR Solve");
                    TypewriterEffect("=========================================================================================================");
                    TypewriterEffect("Choose a text file with Pre-written problems or create your own");

                    Thread.Sleep(1000); // Pause for a moment before displaying the file dialog

                    // Open file dialog for user to select a text file
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Filter = "Text files (*.txt)|*.txt",
                        Title = "Select a Model File"
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK) // Check if user selected a file
                    {
                        string modelPath = openFileDialog.FileName; // Get the selected file path
                        TypewriterEffect($"Selected file: {modelPath}");
                        TypewriterEffect("=========================================================================================================");
                        model = InputReader.ReadModelFromFile(modelPath); // Read model from file

                        SolveModelUsingAlgorithm(model); // Proceed to solve the model using the selected algorithm
                    }
                    else
                    {
                        // Prompt user if they want to try selecting a file again or exit
                        TypewriterEffect("No file selected.");
                        TypewriterEffect("Do you want to try again? (Y/N)");
                        string userResponse = Console.ReadLine().Trim().ToUpper();

                        if (userResponse != "Y")
                        {
                            TypewriterEffect("Exiting...");
                            Environment.Exit(0);
                            break; // Exit the loop if the user chooses not to try again
                        }
                    }
                }
                catch (CustomException ex)
                {
                    HandleException(ex, model); // Handle and display any custom exceptions
                }
                catch (InfeasibleException ex)
                {
                    HandleException(ex, model); // Handle and display infeasible exceptions
                }
                catch (Exception ex)
                {
                    HandleException(ex, model); // Handle and display general exceptions
                }
            }
        }


        /// <summary>
        /// Sets the Console to fullscreen.
        /// </summary>
        private static void SetConsoleFullscreen()
        {
            int screenWidth = GetSystemMetrics(SM_CXSCREEN);
            int screenHeight = GetSystemMetrics(SM_CYSCREEN);

            Console.SetWindowSize(screenWidth / Console.LargestWindowWidth, screenHeight / Console.LargestWindowHeight);
            Console.SetBufferSize(screenWidth, screenHeight);
        }

        /// <summary>
        /// Handles and logs exceptions that occur during processing.
        /// </summary>
        /// <param name="ex">The exception to handle.</param>
        /// <param name="model">The model being processed.</param>
        private static void HandleException(Exception ex, Problem model)
        {
            TypewriterEffect($"There was an error. Details: {ex.Message}.");
            TypewriterEffect("\nHere are the tables that were calculated before we ran into that error:");
            SolutionPrinter.Print(model); // Print the results up to the point of error
            TypewriterEffect("\n\nPress any key to return to the menu...");
            Console.ReadKey(); // Wait for user input before returning to the menu
        }

        /// <summary>
        /// Prompts the user to select an algorithm and solves the model using the selected algorithm.
        /// </summary>
        /// <param name="model">The model to solve.</param>
        private static void SolveModelUsingAlgorithm(Problem model)
        {
            Console.Clear();
            TypewriterEffect("Choose the Algorithm you want to use");
            TypewriterEffect("These are the available algorithms you can use:");
            TypewriterEffect("=========================================================================================================");

            // Variables to store user input and the chosen algorithm
            string userInput;
            Algorithm algorithm = null;

            // Determine which algorithms are applicable based on the model's properties
            if (model.SignRestrictions.Contains(SignRestriction.Binary) || model.SignRestrictions.Contains(SignRestriction.Integer))
            {
                TypewriterEffect("1.) Branch and Bound Simplex Algorithm");
                TypewriterEffect("2.) Cutting Plane Algorithm");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        algorithm = new BranchAndBoundSimplex();
                        break;
                    case "2":
                        algorithm = new CuttingPlane();
                        break;
                    default:
                        throw new CustomException("Invalid selection made");
                }
            }
            else if (model.ProblemType == ProblemType.Minimization)
            {
                TypewriterEffect("1.) Dual Simplex Algorithm");
                TypewriterEffect("2.) Two Phase Simplex Algorithm");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        algorithm = new DualSimplex();
                        break;
                    case "2":
                        algorithm = new TwoPhaseSimplex();
                        break;
                    default:
                        throw new CustomException("Invalid selection made");
                }
            }
            else
            {
                // Decide which simplex algorithm to use based on the model's constraints
                if (!(model.Constraints.Any(c => c.InequalitySign == InequalitySign.EqualTo) ||
                      model.Constraints.Any(c => c.InequalitySign == InequalitySign.GreaterThanOrEqualTo)))
                {
                    TypewriterEffect("1.) Primal Simplex");
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            algorithm = new PrimalSimplex();
                            break;
                        default:
                            throw new CustomException("Invalid selection made");
                    }
                }
                else
                {
                    TypewriterEffect("1.) Dual Simplex Algorithm");
                    TypewriterEffect("2.) Two Phase Simplex Algorithm");
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            algorithm = new DualSimplex();
                            break;
                        case "2":
                            algorithm = new TwoPhaseSimplex();
                            break;
                        default:
                            throw new CustomException("Invalid selection made");
                    }
                }
            }


            // Solve the model using the chosen algorithm
            Solver.Solve(model, algorithm);

            // Print results and write to file based on the type of algorithm used
            if (algorithm is BranchAndBoundSimplex bnbAlgorithm)
            {
                SolutionPrinter.Print(bnbAlgorithm);
                SolutionWriter.WriteResultsToFile(bnbAlgorithm);
            }
            else
            {
                SolutionPrinter.Print(model);
                SolutionWriter.WriteResultsToFile(model);
            }

            TypewriterEffect("\n\nPress any key to return to the menu...");
            Console.ReadKey(); // Wait for user input before returning to the menu
        }

        /// <summary>
        /// Simulates a typewriter effect for displaying text on the console.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="delay">The delay in milliseconds between each character.</param>
        private static void TypewriterEffect(string text, int delay = 15)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Delay to simulate typing effect
            }
            Console.WriteLine(); // Move to the next line after finishing the text
        }
    }
}
