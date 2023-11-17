namespace AI.BehaviorTree
{
    public enum NodeState
    {
        Running, Success, Failure
    }

    public abstract class Node
    {
        protected NodeState m_State;

        public Node()
        {
            m_State = NodeState.Running; // Estado por defecto
        }

        public abstract NodeState Evaluate();
    }
}
