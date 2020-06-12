using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 500f;
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

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 2f);
    }
}
