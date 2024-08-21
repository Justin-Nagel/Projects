using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Represents a constraint in the optimization problem.
    /// A constraint defines the relationship between decision variables and the right-hand side value, including the inequality type.
    /// </summary>
    public class Constraint
    {
        /// <summary>
        /// A list of decision variables involved in this constraint.
        /// Each decision variable has a coefficient that contributes to the constraint equation.
        /// </summary>
        public List<DecisionVariable> DecisionVariables { get; set; } = new List<DecisionVariable>();

        /// <summary>
        /// The type of inequality for this constraint.
        /// Specifies whether the constraint is an equality or an inequality (less than or equal to, greater than or equal to).
        /// </summary>
        public InequalitySign InequalitySign { get; set; }

        /// <summary>
        /// The right-hand side value of the constraint equation.
        /// This is the value against which the left-hand side (formed by decision variables) is compared based on the inequality sign.
        /// </summary>
        public double RightHandSide { get; set; }
    }
}
