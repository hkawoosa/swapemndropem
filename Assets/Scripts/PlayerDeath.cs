using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public float knockback = 100f;
    public float knockbackTime = 1f;

    Rigidbody rb;

    bool isDead = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Spikes") && !isDead) {
            StartCoroutine(Death(col));
        }
    }

    IEnumerator Death(Collision col)
    {
        isDead = true;
        Vector3 direction = col.impulse.normalized + Vector3.up;
        rb.AddForce(direction * knockback);
        for (float t = 0; t < knockbackTime; t += Time.deltaTime)
        {
            transform.Rotate(0, 0, Mathf.Lerp(0, 180, t / knockbackTime));
            yield return null;
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
