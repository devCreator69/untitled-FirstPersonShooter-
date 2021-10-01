using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
   

    public float speed;
    private int waypointIndex;
    private float distance;

    [SerializeField] float turnSpeed;
  
    void Start()
    {
        waypointIndex = 0;
    }

    void LookAtDestiation()
    {
        transform.LookAt(waypoints[waypointIndex].position); 
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(distance < 1f)
        {
            IncreaseIndex();
        }
        Mover();
    }
    void Mover()
    {
       GetComponent<Animator>().SetTrigger("walk");
       transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        LookAtDestiation();
    }      
}
 
    



    


