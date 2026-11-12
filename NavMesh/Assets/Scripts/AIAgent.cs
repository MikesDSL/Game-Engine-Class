using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    [SerializeField]
    private AIAgentTarget target = null;

    private NavMeshAgent agent = null;

    private Vector3 prevTarget = Vector3.zero;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if ((prevTarget - target.transform.position).sqrMagnitude > 0.0f)
        {
            agent.SetDestination(target.transform.position);
            prevTarget = target.transform.position;
        }
    }
}
