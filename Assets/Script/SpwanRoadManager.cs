using System.Collections.Generic;
using UnityEngine;

public class SpwanRoadManager : MonoBehaviour
{

    [SerializeField] GameObject roadPrefeb;
    [SerializeField] float roadPrefebLength;
    [SerializeField] GameObject playerref;
    [SerializeField] List<GameObject> activeObjectList;
    [SerializeField] List<GameObject> poolObjectList;

    [SerializeField] int numOfObjectinStart;


    private GameObject lastObject;
    private int Count = 0;

    private void Start()
    {

        SpwanObjectUsingObjectPooling();
        ActiveObjectFromThePoolList();


    }

    private void Update()
    {
        ActiveNextObject();
    }

    void SpwanObjectUsingObjectPooling()
    {
        for (int i = 0; i < numOfObjectinStart; i++)
        {
            GameObject spwanObject = Instantiate(roadPrefeb);
            spwanObject.SetActive(false);
            poolObjectList.Add(spwanObject);

        }
    }

    void ActiveObjectFromThePoolList()
    {
        if (activeObjectList != null)
        {

            GameObject temp = poolObjectList[Count];
            temp.SetActive(true);

            activeObjectList.Add(temp);


            temp.transform.position = new Vector3(lastObject.transform.position.x,
                lastObject.transform.position.y,
                lastObject.transform.position.z + roadPrefebLength);

            lastObject = temp;

            if (Count >= poolObjectList.Count - 1) { Count = 0; }
            else Count++;

            if (activeObjectList.Count > 7)
            {
                activeObjectList[0].SetActive(false);
                activeObjectList.RemoveAt(0);

            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject temp = poolObjectList[i];
                temp.SetActive(true);

                activeObjectList.Add(temp);

                if (lastObject == null)
                {
                    temp.transform.position = Vector3.zero;
                }

                else
                {
                    temp.transform.position = new Vector3(lastObject.transform.position.x,
                        lastObject.transform.position.y,
                        lastObject.transform.position.z + roadPrefebLength);
                }

                lastObject = temp;
                Count++;


            }
        }


    }

    void ActiveNextObject()
    {
        float distance = Vector3.Distance(lastObject.transform.position, playerref.transform.position);

        if (distance < 30)
        {

            ActiveObjectFromThePoolList();
        }
    }



}
