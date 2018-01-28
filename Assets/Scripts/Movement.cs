using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //rigidbody for character physics
    Rigidbody rb;

    CapsuleCollider cc;

    PlayerDeath pd;

    public LayerMask MovingPlatform;

    //character's final run speed
    public float maxSpeed = 5;

    //speed which with character gets up to top speed
    public float acceleration = 5;

    //vertical speed character will jump with
    public float groundedJumpPower = 10;
    public float doubleJumpPower = 8;

    public float gravity = 5;

	public AudioClip doublejump;
	public AudioClip running;
	public AudioClip hookshotgrabbingon;
	public AudioClip hookshotgoingout;
	public AudioClip hookshotdrawingbackin;

	private AudioSource source1;
	private AudioSource source2;
	private AudioSource source3;
	private AudioSource source4;
	private AudioSource source5;

    string originalTag;

    int jumpsRemaining = 2;
    public float jumpBuffer = 0f;
    float stunnedFor = 0;
    public float stunLength = 1f;
    Vector3 direction;

    bool stunned = false, usingHook = false, hooked = false;
    Vector3 pushedVelocity;

    Vector3 hookedDest;
    float hookedTime;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        cc = this.GetComponent<CapsuleCollider>();
        pd = this.GetComponent<PlayerDeath>();
        originalTag = this.tag;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if(stunnedFor <= 0)
        {
                /**if(Physics.SphereCast(this.transform.position, 1f, Vector3.down, out hit, cc.bounds.extents.x, MovingPlatform))
                {
                Vector3 onPlatform = rb.velocity;
                onPlatform.x = hit.transform.position.x;
                  onPlatform.x += Input.GetAxis(this.tag + "Horizontal") * maxSpeed;
                 if (onPlatform.x >= 0)
                 {
                     onPlatform.x = Mathf.Min(onPlatform.x, maxSpeed);
                 }
                 else
                     {
                onPlatform.x = Mathf.Max(onPlatform.x, maxSpeed * -1);
                       }
                       rb.velocity = onPlatform;
                     }*/
                if (!pd.IsDead())
                {
                    Vector3 newX = rb.velocity;
                    if ((CompareTag("P1_") || CompareTag("P2_")))
                    {
                        newX.x = Input.GetAxis(this.tag + "Horizontal") * maxSpeed;
                    }
                    if (newX.x >= 0)
                    {
                        newX.x = Mathf.Min(newX.x, maxSpeed);
                    }
                    else
                    {
                        newX.x = Mathf.Max(newX.x, maxSpeed * -1);
                    }
                    rb.velocity = newX;

                    // direction = new Vector3(Input.GetAxis(this.tag + "AimX"), Input.GetAxis(this.tag + "AimY"), 0);
               }
            

            Vector3 newY = rb.velocity;
            if (Physics.SphereCast(this.transform.position, 1f, Vector3.down, out hit, cc.bounds.extents.x))
            {
                if (jumpBuffer <= 0)
                {
                    jumpsRemaining = 2;
                }
                else
                {
                    jumpBuffer -= Time.deltaTime;
                }

            }
            else
            {
                if (jumpsRemaining == 2)
                {
                    jumpsRemaining = 1;
                }
                newY.y -= gravity * Time.deltaTime;
            }

            if ((CompareTag("P1_") || CompareTag("P2_")) && Input.GetButtonDown(this.tag + "Jump"))
            {
                if (jumpsRemaining == 2)
                {
                    newY.y = groundedJumpPower;
                    jumpsRemaining--;
                    jumpBuffer = .2f;
					source1 = GetComponent<AudioSource>();
					source1.PlayOneShot(doublejump);
                }
                else if (jumpsRemaining == 1)
                {
                    newY.y = doubleJumpPower;
                    jumpsRemaining--;
                }

            }
            rb.velocity = newY;

            if ((CompareTag("P1_") || CompareTag("P2_")) && Input.GetButtonDown(this.tag + "Wavedash"))
            {
                Vector3 newDirection = rb.velocity;
                newDirection.x = Input.GetAxis(this.tag + "Horizontal") * maxSpeed;
                newDirection.y = Input.GetAxis(this.tag + "Vertical") * maxSpeed;
            }
        }
        else
        {
            if (hooked)
            {
                if (Mathf.Abs(transform.position.x - hookedDest.x) > .2f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, hookedDest, hookedTime);
					source5 = GetComponent<AudioSource>();
					source5.PlayOneShot(hookshotdrawingbackin);
                }
                else
                {
                    Debug.Log(hooked);
                    rb.useGravity = true;
                    hooked = false;
                    stunnedFor = .5f;
                }
            }
            else if(pushedVelocity.x > 0)
            {
                rb.velocity = pushedVelocity;
            }
             
            stunnedFor -= Time.deltaTime;
        }
       
        

    }

    public void SetDirection(Vector3 direction)
    {
        
    }

    public void Jump()
    {
        
    }

    public void SetStunned(bool state)
    {
        stunned = state;
    }
    public void SetUsingHook(bool state)
    {
        usingHook = state;
    }

    public void setStunTime(float length)
    {
        stunnedFor = length;
    }


    public void Swap(GameObject other)
    {
        string temp = this.tag;
        this.tag = other.tag;
        other.GetComponent<Movement>().setStunTime(stunLength);
        other.tag = temp;
    }

    public void Push(int dir, float force)
    {
        Debug.Log(dir);
        Debug.Log(force);
        stunnedFor = 2f;
        if(dir == 1)
        {
            //add left to their speed

            pushedVelocity = rb.velocity;
            pushedVelocity.x = Vector3.right.x * force;
        }
        else
        {
            //add right to their vector
            pushedVelocity = rb.velocity;
            pushedVelocity.x = Vector3.left.x * force;
        }
    }

    public void getHooked(Vector3 destination, float time)
    {
        rb.useGravity = false;
        hooked = true;
        hookedDest = destination;
        Debug.Log(hookedDest);
        hookedTime = time;
        stunnedFor = 10f;
    }
}
