using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] float speed = 500f;
    
    [SerializeField] GameObject ParticlePrefab;
    public float bulletDamage = 10f;

    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.velocity = transform.up * Time.fixedDeltaTime * speed;
    }

   

    private void OnTriggerEnter(Collider other)
    {
        
        Instantiate(ParticlePrefab, transform.position, Quaternion.identity);        
        Destroy(ParticlePrefab, 0.5f);
        Destroy(gameObject);
    }
}
