using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushInfo : MonoBehaviour
{

    float force;
    int dir;

    public void setDirection(int dir)
    {
        this.dir = dir;
    }
    public int getDirection()
    {
        return dir;
    }
    public void setForce(float force)
    {
        this.force = force;
    }
    public float getForce()
    {
        return force;
    }

}
