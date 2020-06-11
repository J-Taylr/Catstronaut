using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGravityBody : MonoBehaviour
{
    public PlanetScript attractorPlanet;
    private Transform enemyTransform;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        enemyTransform = transform;
    }

    void FixedUpdate()
    {
        if (attractorPlanet)
        {
            attractorPlanet.EnemyAttract(enemyTransform);
        }
    }
}
