namespace AI.BehaviorTree
{
    public class ActionNode : Node
    {
        public delegate  NodeState ActionNodeDelegate();
        private ActionNodeDelegate m_Action;

        public ActionNode(ActionNodeDelegate action)
        {
            m_Action = action;
        }

        public override NodeState Evaluate()
        {
            var result = m_Action();
            return result;
        }
    }
}

