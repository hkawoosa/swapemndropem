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
    }


    // Update is called once per frame
    void Update () {

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0,0);

        mover.SetDirection(direction);

        if (Input.GetButtonDown("Jump"))
        {

        }

        ///////////////////
        //Enable Force Push
        ///////////////////
        if (Input.GetButtonDown(""))
        {
            
        }
        ///////////////////
        //Enable Hook
        ///////////////////
        if (Input.GetButtonDown(""))
        {
            
        }
    }
}
