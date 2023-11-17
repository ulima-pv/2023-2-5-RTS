namespace AI.BehaviorTree
{
    public class ConditionalNode : Node
    {
        public delegate bool ConditionalNodeDelegate();
        private ConditionalNodeDelegate m_Condition; 

        public ConditionalNode(ConditionalNodeDelegate predicate)
        {
            m_Condition = predicate;
        }

        public override NodeState Evaluate()
        {
            var result = m_Condition();
            if (result == true)
            {
                return NodeState.Success;
            }else
            {
                return NodeState.Failure;
            }
        }
    }
}
