using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * 0.8f;
        agent.updateRotation = false;
        
        target = newTarget.interactionTransform;
    }
    
    public void StopFollowTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        
        target = null;
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    void FaceTarget() 
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * 5f);
    }
}
