using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Movement mover;
    public GameObject forceBox;
    public GameObject hookBox;
    //public vars
    public float forceTime;
    public float hookDist;

    //bools
    bool stunned = false;
    bool usingHook = false;
    
    Vector3 hookStart;
    

    void Awake()
    {
        mover = this.GetComponent<Movement>();
        forceBox.SetActive(false);
        
    }


    // Update is called once per frame
    void Update () {

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0,0);

        mover.SetDirection(direction);

        ///////////////////
        //Enable Force Push
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(ForcePush());
        }
        //Enable Hook
        if (Input.GetButtonDown("Fire3"))
        {
            
        }
        ///////////////////
    }
    

    //Activate forcePush
    IEnumerator ForcePush()
    {
        forceBox.SetActive(true);
        yield return new WaitForSeconds(forceTime);
        forceBox.SetActive(false);
    }

    //Using Hook
    public IEnumerator throwHook()
    {
        mover.SetUsingHook(true);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 angle = new Vector3(x, y, 0).normalized;
        angle *= hookDist;
        hookStart = hookBox.transform.position;
        while (hookBox.transform.position != hookBox.transform.position + angle)
        {
            hookBox.transform.position = Vector3.Lerp(hookBox.transform.position, hookStart + angle, Time.deltaTime);
        }
        yield return new WaitForSeconds(.5f);
        StartCoroutine(pullHook());
    }
    public IEnumerator pullHook()
    {
        while (hookBox.transform.position != hookStart)
        {
            hookBox.transform.position = Vector3.Lerp(hookBox.transform.position, hookStart, Time.deltaTime);
        }
        yield return new WaitForSeconds(0f);
        mover.SetUsingHook(false);
    }

    //Stun
    public IEnumerator setStunned(float stunTime)
    {
        mover.SetStunned(true);
        yield return new WaitForSeconds(stunTime);
        mover.SetStunned(false);
    }
}
