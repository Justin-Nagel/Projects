using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Represents the objective function in an optimization problem.
    /// The objective function consists of multiple decision variables, each with a coefficient.
    /// </summary>
    public class ObjectiveFunction
    {
        /// <summary>
        /// A list of decision variables that make up the objective function.
        /// Each decision variable has an associated coefficient that contributes to the value of the objective function.
        /// </summary>
        public List<DecisionVariable> DecisionVariables { get; set; } = new List<DecisionVariable>();
    }
}
