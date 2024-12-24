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
        transform.position =  targrtToFollow.position + offSet;

       // Vector3 targetPosition = targrtToFollow.transform.position;  // Old Code  //new Vector3(targrtToFollow.position.x , targrtToFollow.position.y + offSet.y, targrtToFollow.position.z + offSet.z);
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);  // Old Code //Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(NameTag.player))
        {
            Debug.Log("collide gameobject With " + other.gameObject.name);
        }
    }


}
