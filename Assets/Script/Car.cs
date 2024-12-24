using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(new Vector3(0,-1*speed*Time.deltaTime,0));
        Destroy(gameObject, 10);
    }

}
