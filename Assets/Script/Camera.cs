using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform targrtToFollow;
    [SerializeField] Vector3 offSet;
    [SerializeField] float moveSpeed;


    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {

        Vector3 targetPosition = new Vector3(targrtToFollow.position.x + offSet.x, targrtToFollow.position.y + offSet.y, targrtToFollow.position.z + offSet.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed);
    }


}
