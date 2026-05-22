
using UnityEngine;
using UnityEngine.AI;

public class SoulMovement : MonoBehaviour
{
    //move on land
    
    
    NavMeshAgent agent;
   
    [SerializeField] private GameObject player;
    [SerializeField] private float distanceMove;
    [SerializeField] private float distanceIdle;


    [SerializeField] private float moveSpeed = 8f;
    //animator smth smth

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
      
        agent.speed = moveSpeed;
    }
    private void FixedUpdate()
    {
        if (player == null) return;
        Move();
    }

    void Move()
    {
       Vector3 direction = player.transform.position + (-player.transform.forward * distanceMove);
            agent.SetDestination(direction);

        if (Vector3.Distance(transform.position, player.transform.position) < distanceIdle) agent.isStopped = true;
        else agent.isStopped = false;
    }

}
