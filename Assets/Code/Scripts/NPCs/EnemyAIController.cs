using System.Collections;
using System.Collections.Generic;
using AI.BehaviorTree;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;

    private Node m_Root;
    private Unit m_Unit = null;

    private void Awake() {
        // 1. Creamos BT
        m_Root = new Selector(new List<Node>() {
            new Sequence(new List<Node>() {
                new ConditionalNode(MustAttack),
                new ActionNode(Attack)
            }),
            new Sequence(new List<Node>() {
                new ConditionalNode(MustFollow),
                new ActionNode(Follow)
            }),
            new ActionNode(Patrol)
        });
    }

    private void Update() 
    {
        m_Root.Evaluate();
    }

    public bool MustAttack()
    {
        var colliders = Physics.OverlapSphere(transform.position, 1f);

        foreach (var col in colliders)
        {
            var unit = col.GetComponent<Unit>();
            if (unit != null)
            {
                m_Unit = unit;
                return true;
            }
        }

        return false;
    }

    public NodeState Attack()
    {
        Debug.Log("Ataque!");
        return NodeState.Success;
    }

    public bool MustFollow()
    {
        var colliders = Physics.OverlapSphere(transform.position, 8f);

        foreach (var col in colliders)
        {
            var unit = col.GetComponent<Unit>();
            if (unit != null)
            {
                m_Unit = unit;
                return true;
            }
        }

        return false;
    }

    public NodeState Follow()
    {
        var dir = (m_Unit.transform.position - transform.position).normalized;
        dir.y = 0f;

        transform.position += dir * Time.deltaTime * m_Speed;

        return NodeState.Success;
    }

    public NodeState Patrol()
    {
        Debug.Log("Patrullando...");
        return NodeState.Success;
    }
}
