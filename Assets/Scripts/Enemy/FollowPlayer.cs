using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    Vector3 positionHead;
    UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] SnakeManager snake;
    [SerializeField] float radius;

    // Start is called before the first frame update
    void Start()
    {   //Invoke("Spawn", time);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();            
    }

    // Update is called once per frame
    void Update()
    {
            positionHead = snake.PositionHead;
            float distance = Vector3.Distance(positionHead, transform.position);
            Debug.Log(positionHead);
            if (distance <= radius) {
                agent.SetDestination(positionHead);
                agent.speed = 3f;

                if (distance <= agent.stoppingDistance) {
                    FaceTarget();
                }
            }        
    }

    public void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void FaceTarget(){
        Vector3 direction = (positionHead - transform.position).normalized;
        Quaternion rotation =  Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }
}
