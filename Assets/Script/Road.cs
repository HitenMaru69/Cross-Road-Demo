using System.Collections;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] Transform[] spwanPoint;
    [SerializeField] GameObject[] cars;

    float delay = 4f;
    float nextTimeToSpwan = 0f;

    private void Update()
    {
        if(nextTimeToSpwan <= Time.time)
        {
            SpwanCar();
            int nextdelay = Random.Range(3, 5);
            nextTimeToSpwan = Time.time + nextdelay;
        
            
        }
    }

    void SpwanCar()
    {

        int index = Random.Range(0, cars.Length);
        int spwanIndex =  Random.Range(0, spwanPoint.Length);
        Instantiate(cars[index], spwanPoint[spwanIndex].position, spwanPoint[spwanIndex].rotation);

      
    }

}
