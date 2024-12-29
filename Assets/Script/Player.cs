using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Animator animator;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] SoundManager soundManager;

    private Rigidbody rb;
    private float horizontal;
    private float vertical;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }


    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        if (Mathf.Abs(vertical) > 0 || Mathf.Abs(joystick.Vertical )> 0) PlayAnimation(false, true,false,false);
        else if(Mathf.Abs(horizontal) > 0 || Mathf.Abs(joystick.Horizontal) > 0)
        {
           
            if(horizontal > 0 || joystick.Horizontal > 0)
            {
                PlayAnimation(false, false, false, true);
            }
            else PlayAnimation(false, false, true, false);
        }
        else PlayAnimation(true, false,false,false);
        

        // Update Player Score
        if((vertical > 0 || joystick.Vertical > 0) && !GameManager.instance.isPlayerDie)
        {
            GameManager.instance.Score += 1;
        }

    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        // For KeyBord Input
        transform.Translate(new Vector3(horizontal * moveSpeed * Time.fixedDeltaTime, 0, vertical * moveSpeed*Time.fixedDeltaTime));
        // For Mobile Input
        transform.Translate(new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, 0, joystick.Vertical * moveSpeed*Time.fixedDeltaTime));

    }

    void PlayAnimation(bool isIdle,bool isRun,bool isLeftSide, bool isRightSide)
    {
        animator.SetBool(NameTag.Idle,isIdle);
        animator.SetBool (NameTag.Run,isRun);
        animator.SetBool(NameTag.LeftSide,isLeftSide);
        animator.SetBool(NameTag.RightSide,isRightSide);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(NameTag.Car))
        {
            GameManager.instance.CallPlayerHitEvent();
        }
    }
   
}
