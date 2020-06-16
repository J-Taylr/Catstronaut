using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] float speed = 500f;
    
    [SerializeField] GameObject ParticlePrefab;
    public float bulletDamage = 10f;
    PlayerController playerController;

    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 6);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.velocity = transform.up * Time.fixedDeltaTime * speed;        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {            
            other.GetComponent<EnemyManager>().TakeDamage(bulletDamage);           
            Instantiate(ParticlePrefab, transform.position, Quaternion.identity);
           // Destroy(ParticlePrefab.gameObject, 0.5f);
            Destroy(gameObject);

        }
        
    }
}
