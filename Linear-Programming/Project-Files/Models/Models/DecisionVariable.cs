namespace Common
{
    /// <summary>
    /// Represents a decision variable in an optimization problem.
    /// Each decision variable has a coefficient that contributes to the objective function or constraints.
    /// </summary>
    public class DecisionVariable
    {
        /// <summary>
        /// The coefficient associated with this decision variable.
        /// This value represents the weight or influence of the decision variable in the objective function or constraints.
        /// </summary>
        public double Coefficient { get; set; }
    }
}