using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour {

    public float playerGravity = -12;
    public float enemyGravity = -6;
    [SerializeField] Animator animator;
    [SerializeField] Animator turretAnimator;
    

    public void PlayerAttract(Transform playerTransform)
    {
        Vector3 gravityUp = (playerTransform.position - transform.position).normalized;
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * playerGravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject;            
            Destroy(enemy);
            animator.Play("SadCat");
            turretAnimator.Play("HeartBreak");
            GameManager.Instance.SetHealth();
        }

    }

}
