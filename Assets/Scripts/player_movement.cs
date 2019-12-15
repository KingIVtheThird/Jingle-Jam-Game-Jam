using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_movement : MonoBehaviour
{

    public float Displacment_x;
    public float Displacment_y;
    public float MoveSpeed;
    public float MoveSpeedNow;
    public bool IsMoving;


    private Animator anim;
    private Rigidbody2D myRigidbody;
    private Vector2 lastMove;
    private static bool playerExists;


    void Start()
    {

        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {
        IsMoving = false;

        int Vertical = 0;
        int Horizontal = 0;

        Vertical = (int)Input.GetAxisRaw("Vertical");
        Horizontal = (int)Input.GetAxisRaw("Horizontal");


        {

            if (Horizontal > 0.5 || Horizontal < -0.5)
            {
                MoveSpeedNow -= Time.deltaTime;
                if (MoveSpeedNow <= 0.0f)
                {
                    transform.Translate(Horizontal * Displacment_x, 0.0f, 0.0f);
                    anim.SetFloat("MoveHorizontal", Horizontal);
                    MoveSpeedNow = 1 / MoveSpeed;
                }

                Vertical = 0;
                IsMoving = true;
                anim.SetFloat("MoveHorizontal", Horizontal);
                anim.SetFloat("MoveVertical", 0);
                lastMove = new Vector2(Horizontal, 0.0f);
            }

            if (Vertical > 0.5 || Vertical < -0.5)
            {
                MoveSpeedNow -= Time.deltaTime;
                if (MoveSpeedNow <= 0.0f)
                {
                    transform.Translate(0.0f, Vertical * Displacment_y, 0.0f);
                    anim.SetFloat("MoveVertical", Vertical);
                    MoveSpeedNow = 1 / MoveSpeed;
                }

                Horizontal = 0;
                IsMoving = true;
                anim.SetFloat("MoveVertical", Vertical);
                anim.SetFloat("MoveHorizontal", 0);
                lastMove = new Vector2(0.0f, Vertical);
            }

            if (Horizontal == 0.0f)
            {
                myRigidbody.velocity = new Vector2(0.0f, myRigidbody.velocity.y);
                //MoveSpeedNow = 1 / MoveSpeed;
            }

            if (Vertical == 0.0f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.0f);
                //MoveSpeedNow = 1 / MoveSpeed;
            }

        }



        anim.SetBool("IsMoving", IsMoving);

        anim.SetFloat("LastMoveVert", lastMove.y);

        anim.SetFloat("LastMoveHoriz", lastMove.x);

    }
}