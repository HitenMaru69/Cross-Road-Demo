using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Animator animator;

    private Rigidbody rb;
    private float horizontal;
    private float vertical;
    

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GameManager.instance.PlayerHit += OnPlayerDie;
    }

    private void OnPlayerDie(object sender, EventArgs e)
    {
        Debug.Log("Player Die");
        SpwanRoadManager spwanRoadManager = FindObjectOfType<SpwanRoadManager>();
        spwanRoadManager.enabled = false;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(vertical) > 0) PlayAnimation(false, true,false,false);
        else if(Mathf.Abs(horizontal) > 0)
        {
            if(horizontal > 0)
            {
                PlayAnimation(false, false, false, true);
            }
            else PlayAnimation(false, false, true, false);
        }
        else PlayAnimation(true, false,false,false);

    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {

        transform.Translate(new Vector3(horizontal * moveSpeed * Time.fixedDeltaTime, 0, vertical * moveSpeed*Time.fixedDeltaTime));

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
