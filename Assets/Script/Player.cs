using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

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
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {

        transform.Translate(new Vector3(horizontal * moveSpeed * Time.fixedDeltaTime, 0, vertical * moveSpeed*Time.fixedDeltaTime));

    }
}
