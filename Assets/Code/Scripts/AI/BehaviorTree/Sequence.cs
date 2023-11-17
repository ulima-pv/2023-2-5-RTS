
using System.Collections.Generic;

namespace AI.BehaviorTree
{
    public class Sequence : Node
    {
        protected List<Node> m_Children = new List<Node>();

        public Sequence(List<Node> children) : base()
        {
            m_Children = children;
        }

        public override NodeState Evaluate()
        {
            bool isAnyNodeRunning = false;

            foreach (Node child in m_Children)
            {
                var result = child.Evaluate();
                switch (result)
                {
                    case NodeState.Success:
                        continue;
                    case NodeState.Failure:
                        m_State = NodeState.Failure;
                        return m_State;
                    case NodeState.Running:
                        isAnyNodeRunning = true;
                        break;
                }
            }
            m_State = isAnyNodeRunning ? NodeState.Running : NodeState.Success;
            return m_State;
        }
    }
}
