using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Transform target;

    
    void Update()
    {
        float moveSpeed = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
    }

    private void OnParticleCollision (GameObject other)
    {
        print("hit");
        
    }
    
    
}
