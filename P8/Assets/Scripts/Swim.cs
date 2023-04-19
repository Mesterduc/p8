using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    public float speed;
    public float range;
    public float maxDistance;

   public Vector2 waypoint; 
    
    void Start()
    {
        setNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,waypoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position,waypoint) < range)
        {
            setNewDestination(); 
        }
    }
    
    void setNewDestination()
    {
        waypoint = new Vector2(Random.Range(-maxDistance, maxDistance),Random.Range (-maxDistance, maxDistance));
    }
}
