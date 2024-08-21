using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Represents a problem that includes an objective function, constraints, sign restrictions, and results.
    /// </summary>
    public class Problem
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Problem() { }

        /// <summary>
        /// Copy constructor that creates a deep copy of an existing Problem object.
        /// This is used to clone Problem objects without reference issues.
        /// </summary>
        /// <param name="problem">The Problem object to clone.</param>
        public Problem(Problem problem)
        {
            // Copy the type of the problem (e.g., maximization or minimization)
            this.ProblemType = problem.ProblemType;

            // Copy the objective function of the problem
            this.ObjectiveFunction = problem.ObjectiveFunction;

            // Copy the list of constraints for the problem
            this.Constraints = problem.Constraints;

            // Copy the list of sign restrictions
            this.SignRestrictions = problem.SignRestrictions;

            // Copy the results of the problem
            this.Result = problem.Result;
        }

        /// <summary>
        /// Specifies the type of problem, such as maximization or minimization.
        /// </summary>
        public ProblemType ProblemType { get; set; }

        /// <summary>
        /// Represents the objective function of the problem.
        /// This includes the coefficients and other relevant details for the objective function.
        /// </summary>
        public ObjectiveFunction ObjectiveFunction { get; set; } = new ObjectiveFunction();

        /// <summary>
        /// A list of constraints that apply to the problem.
        /// Each constraint is represented by an instance of the Constraint class.
        /// </summary>
        public List<Constraint> Constraints { get; set; } = new List<Constraint>();

        /// <summary>
        /// A list of sign restrictions for the problem's decision variables.
        /// This specifies whether variables are positive, negative, unrestricted, integer, or binary.
        /// </summary>
        public List<SignRestriction> SignRestrictions { get; set; } = new List<SignRestriction>();

        /// <summary>
        /// Stores the results of the problem's solution process.
        /// The results are represented as a nested list of doubles.
        /// </summary>
        public List<List<List<double>>> Result { get; set; } = new List<List<List<double>>>();
    }
}
