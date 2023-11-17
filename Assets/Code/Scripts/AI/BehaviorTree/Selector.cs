using System.Collections.Generic;

namespace AI.BehaviorTree
{
    public class Selector : Node
    {
        protected List<Node> m_Children = new List<Node>();

        public Selector(List<Node> children) : base()
        {
            m_Children = children;
        }

        public override NodeState Evaluate()
        {
            foreach (Node child in m_Children)
            {
                var result = child.Evaluate();
                switch (result)
                {
                    case NodeState.Success:
                        m_State = NodeState.Success;
                        return m_State;
                    case NodeState.Failure:
                        continue;
                    case NodeState.Running:
                        m_State = NodeState.Running;
                        return m_State;
                }
            }

            m_State = NodeState.Failure;
            return m_State;
        }
    }
}
