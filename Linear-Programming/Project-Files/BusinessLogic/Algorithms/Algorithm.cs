using Common;

namespace BusinessLogic.Algorithms
{
    /// <summary>
    /// An abstract base class representing a general optimization algorithm.
    /// Derived classes must implement specific algorithms to process optimization problems.
    /// </summary>
    public abstract class Algorithm
    {
        /// <summary>
        /// Transforms the given problem into its canonical form.
        /// This is a preparatory step before solving the optimization problem.
        /// </summary>
        /// <param name="model">The optimization problem to be transformed.</param>
        public abstract void PutModelInCanonicalForm(Problem model);

        /// <summary>
        /// Solves the optimization problem.
        /// This method applies the specific algorithm to the problem to find a solution.
        /// </summary>
        /// <param name="model">The optimization problem to be solved.</param>
        public abstract void Solve(Problem model);
    }
}
