using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject bottomLeft;
    public GameObject bottomRight;
    public GameObject topLeft;
    public GameObject topRight;
    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedEnd;
    public GameObject end;

    private void Update()
    {
        if (waitTime <= 0 && spawnedEnd == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(end, rooms[i].transform.position, Quaternion.identity);
                    spawnedEnd = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}   
