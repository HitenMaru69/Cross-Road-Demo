using System.Collections.Generic;
using UnityEngine;

public class TestSpwanScript : MonoBehaviour
{
    [SerializeField] GameObject spwanPrefeb;
    [SerializeField] float lenghtOfObject;
    [SerializeField] GameObject playerref;

    [SerializeField] List<GameObject> activeObject;
    [SerializeField] List<GameObject> poolObject;


    GameObject lastObject;


    private void Start()
    {

        SpwanObjectUsingObjectPooling();
        PoolObjectFromThePoolList();
        //for (int i = 0; i < 5; i++)
        //{
        //    SpwanObject();
        //}

    }

    private void Update()
    {
       CheckDistance();
    }


    // Normal Method 
    // Spwan and Destroy
    void SpwanObject()
    {
        GameObject spwanObject =Instantiate(spwanPrefeb);

        activeObject.Add(spwanObject);

        if(lastObject == null)
        {
            spwanObject.transform.position = Vector3.zero;
        }

        else
        {
            spwanObject.transform.position = new Vector3(lastObject.transform.position.x,
                lastObject.transform.position.y,
                lastObject.transform.position.z + lenghtOfObject); 
        }

        lastObject = spwanObject;

        if(activeObject.Count > 7)
        {
            Destroy(activeObject[0]);
            activeObject.RemoveAt(0);

        }
    }

    void CheckDistance()
    {
        float dis = Vector3.Distance(lastObject.transform.position, playerref.transform.position);

        Debug.Log("Dis is " + dis);

        if(dis < 30) {

            PoolObjectFromThePoolList();

            //SpwanObject();
        }
    }


    // Now Using Object Pooling

    [SerializeField] int numOfObjectinStart;

    int Count = 0;

    void SpwanObjectUsingObjectPooling()
    {
        for(int i = 0; i < numOfObjectinStart; i++)
        {
            GameObject spwanObject = Instantiate(spwanPrefeb);
            spwanObject.SetActive(false);
            poolObject.Add(spwanObject);

        }
    }

    void PoolObjectFromThePoolList()
    {
        if(activeObject!= null)
        {

            GameObject temp = poolObject[Count];
            temp.SetActive(true);

            activeObject.Add(temp);

            if (lastObject == null)
            {
                temp.transform.position = Vector3.zero;
            }

            else
            {
                temp.transform.position = new Vector3(lastObject.transform.position.x,
                    lastObject.transform.position.y,
                    lastObject.transform.position.z + lenghtOfObject);
            }

            lastObject = temp;

            if(Count >= poolObject.Count-1) { Count = 0; }
            else Count++;

            if (activeObject.Count > 7)
            {
                activeObject[0].SetActive(false);
                activeObject.RemoveAt(0);

            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject temp = poolObject[i];
                temp.SetActive(true);

                activeObject.Add(temp);

                if (lastObject == null)
                {
                    temp.transform.position = Vector3.zero;
                }

                else
                {
                    temp.transform.position = new Vector3(lastObject.transform.position.x,
                        lastObject.transform.position.y,
                        lastObject.transform.position.z + lenghtOfObject);
                }

                lastObject = temp;
                Count++;


            }
        }


    }

    
}
