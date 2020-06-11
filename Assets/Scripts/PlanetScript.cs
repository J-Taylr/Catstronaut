using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour {

    public float playerGravity = -12;
    public float enemyGravity = -6;

    public void PlayerAttract(Transform playerTransform)
    {
        Vector3 gravityUp = (playerTransform.position - transform.position).normalized;
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * playerGravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }

    public void EnemyAttract(Transform enemyTransform)
    {
        Vector3 gravityUp = (enemyTransform.position - transform.position).normalized;
        Vector3 localUp = enemyTransform.up;

        enemyTransform.GetComponent<Rigidbody>().AddForce(gravityUp * enemyGravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * enemyTransform.rotation;
        enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
