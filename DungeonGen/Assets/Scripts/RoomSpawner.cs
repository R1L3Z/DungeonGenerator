using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 > need bottom door
    //2 > top
    //3 > left
    //4 > right
    private int rand;
    private RoomTemplates templates;
    public bool spawned = false;


    public float waitTime = 4f;
    private void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", .1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            spawned = true;

            if (openingDirection == 1)
            {
                // need to spawn a room bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                // need to spawn a room top door
            }
            else if (openingDirection == 3)
            {
                // need to spawn a room left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                // need to spawn a room right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                //spawn a wall blocking the opening
                if (other.GetComponent<RoomSpawner>().openingDirection == 2 && openingDirection == 3 && other.GetComponent<RoomSpawner>().spawned == false)
                {
                    //spawn TL
                    Instantiate(templates.topLeft, transform.position, templates.topLeft.transform.rotation);
                }
                else if (other.GetComponent<RoomSpawner>().openingDirection == 2 && openingDirection == 4 && other.GetComponent<RoomSpawner>().spawned == false)
                {
                    //spawn TR
                    Instantiate(templates.topRight, transform.position, templates.topRight.transform.rotation);

                }
                else if (other.GetComponent<RoomSpawner>().openingDirection == 1 && openingDirection == 4 && other.GetComponent<RoomSpawner>().spawned == false)
                {
                    //spawn BR
                    Instantiate(templates.bottomRight, transform.position, templates.bottomRight.transform.rotation);

                }
                else if (other.GetComponent<RoomSpawner>().openingDirection == 1 && openingDirection == 3 && other.GetComponent<RoomSpawner>().spawned == false)
                {
                    //spawn BL
                    Instantiate(templates.bottomLeft, transform.position, templates.bottomLeft.transform.rotation);;

                }
                Destroy(gameObject);

            }
            spawned = true;
        }
    }
}
