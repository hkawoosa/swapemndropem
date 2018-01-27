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

    

    void Awake()
    {
        mover = this.GetComponent<Movement>();
        forceBox.SetActive(false);
    }


    // Update is called once per frame
    void Update () {

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0,0);

        mover.SetDirection(direction);

        if (Input.GetButtonDown("Jump"))
        {
            //Movement.Jump();
        }

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
        
        
        yield return new WaitForSeconds(.5f);
        StartCoroutine(pullHook());
    }
    public IEnumerator pullHook()
    {
        yield return new WaitForSeconds(0f);
    }

    //Stun
    public IEnumerator setStunned(float stunTime)
    {
        stunned = true;
        yield return new WaitForSeconds(stunTime);
        stunned = false;
    }
}
