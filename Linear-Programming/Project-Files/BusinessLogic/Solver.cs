using BusinessLogic.Algorithms;
using Common;
using System;

namespace BusinessLogic
{
    /// <summary>
    /// Contains methods for solving a model using a specified algorithm.
    /// </summary>
    public class Solver
    {
        /// <summary>
        /// Solves the given model using the provided algorithm.
        /// </summary>
        /// <param name="model">The model to solve.</param>
        /// <param name="algorithm">The algorithm to use for solving the model.</param>
        public static void Solve(Problem model, Algorithm algorithm)
        {
            // Convert the model to its canonical form to ensure it is suitable for solving
            algorithm.PutModelInCanonicalForm(model);

            // Use the specified algorithm to solve the model
            algorithm.Solve(model);

            // Clear the console and display a header for the solution output
            Console.Clear();
            Console.WriteLine("Solution:");
            Console.WriteLine("=========================================================================================================");
        }
    }
}
