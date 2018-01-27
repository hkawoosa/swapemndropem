using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Movement mover;

    public GameObject forceBox;
    public GameObject hookBox;

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
            Movement.Jump();
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
    
    IEnumerator ForcePush()
    {
        forceBox.SetActive(true);
        yield return new WaitForSeconds(1f);
        forceBox.SetActive(false);
    }

}
