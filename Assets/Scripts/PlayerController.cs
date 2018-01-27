using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Movement mover;

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
    }
}
