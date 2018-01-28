using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public float knockback = 100f;
    public float knockbackTime = 1f;

	public AudioClip deathvar2;

	private AudioSource source;
	private float volume = 1f;


    Rigidbody rb;
    CapsuleCollider cc;
    
    public LayerMask Moving;

    bool isDead = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
		source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        
      
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Spikes") && !isDead) {
            StartCoroutine(Death(col));
        }
        
    }

   void OnCollisionStay(Collision col)
    {
        RaycastHit hit;
        if (col.collider.CompareTag("Wall") && !isDead)
        {
            if (Physics.SphereCast(this.transform.position, .2f, Vector3.right, out hit, cc.bounds.extents.y, Moving))
            {
                
                StartCoroutine(Death(col));
            }
            else if (Physics.SphereCast(this.transform.position, .2f, Vector3.left, out hit, cc.bounds.extents.y, Moving))
            {
                StartCoroutine(Death(col));
            }
        }
    }

    IEnumerator Death(Collision col)
    {
		source.PlayOneShot(deathvar2,volume);
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
