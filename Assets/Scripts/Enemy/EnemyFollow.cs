using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed=1.0f;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
    }
}
