using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 = bottom door, 2 = top door, 3 = left door, 4 = right door

    private RoomTemplates templates;
    private int rand;
    public int deadends;
    public bool spawned = false;
    private float waitTime = 10f;


    // Start is called before the first frame update
    void Start()
    {
        deadends = 0;
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.35f);
    }

    // Update is called once per frame
    void Spawn()
    {

        if (!spawned && !templates.generationStopped())
        {
            switch (openingDirection)
            {
                case 1:
                    do
                    {
                        rand = Random.Range(0, templates.bottomRooms.Length);
                        
                    } while (!templates.bottomRooms[rand].GetComponent<AddRoom>().getAllowed());

                    

                    if (!templates.getItemSpawned() && templates.bottomRooms[rand].GetComponent<AddRoom>().isDeadend)
                    {
                        Instantiate(templates.itemRooms[0], transform.position, templates.itemRooms[0].transform.rotation);
                        templates.setItemSpawned(true);
                        Debug.Log("Item room spawned new");
                    }
                    else
                    {
                        //Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                        GameObject selectedRoom = templates.bottomRooms[rand];
                        Instantiate(pickBottomRoom(selectedRoom), transform.position, pickBottomRoom(selectedRoom).transform.rotation);
                    }


                    break;
                case 2:
                    do
                    {
                        rand = Random.Range(0, templates.topRooms.Length);
                    } while (!templates.topRooms[rand].GetComponent<AddRoom>().getAllowed());


                    

                    if (!templates.getItemSpawned() && templates.topRooms[rand].GetComponent<AddRoom>().isDeadend)
                    {
                        Instantiate(templates.itemRooms[1], transform.position, templates.itemRooms[1].transform.rotation);
                        templates.setItemSpawned(true);
                        Debug.Log("Item room spawned new");
                    }
                    else
                    {
                        //Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                        GameObject selectedRoom = templates.topRooms[rand];
                        Instantiate(pickBottomRoom(selectedRoom), transform.position, pickBottomRoom(selectedRoom).transform.rotation);
                    }

                    break;
                case 3:
                    do
                    {
                        rand = Random.Range(0, templates.leftRooms.Length);
                    } while (!templates.leftRooms[rand].GetComponent<AddRoom>().getAllowed());

                   
                    if (!templates.getItemSpawned() && templates.leftRooms[rand].GetComponent<AddRoom>().isDeadend)
                    {
                        Instantiate(templates.itemRooms[2], transform.position, templates.itemRooms[2].transform.rotation);
                        templates.setItemSpawned(true);
                        Debug.Log("Item room spawned new");
                    }
                    else
                    {
                        //Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                        GameObject selectedRoom = templates.leftRooms[rand];
                        Instantiate(pickBottomRoom(selectedRoom), transform.position, pickBottomRoom(selectedRoom).transform.rotation);
                    }
                    break;
                case 4:
                    do
                    {
                        rand = Random.Range(0, templates.rightRooms.Length);
                    } while (!templates.rightRooms[rand].GetComponent<AddRoom>().getAllowed());

                    
                    if (!templates.getItemSpawned() && templates.rightRooms[rand].GetComponent<AddRoom>().isDeadend)
                    {
                        Instantiate(templates.itemRooms[3], transform.position, templates.itemRooms[3].transform.rotation);
                        templates.setItemSpawned(true);
                        Debug.Log("Item room spawned new");
                    }
                    else
                    {
                        //Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                        GameObject selectedRoom = templates.rightRooms[rand];
                        Instantiate(pickBottomRoom(selectedRoom), transform.position, pickBottomRoom(selectedRoom).transform.rotation);
                    }
                    break;

            }
            spawned = true;
        }

        if(!spawned && templates.generationStopped())
        {
            switch (openingDirection)
            {
                case 1:
                    if (templates.getBossSpawned() && templates.getItemSpawned())
                    {
                        rand = Random.Range(0, templates.B.Length);
                        Instantiate(templates.B[rand], transform.position, templates.B[rand].transform.rotation);
                        Debug.Log("Deadend spawned");
                        break;
                    }
                    else if(templates.getBossSpawned() && !templates.getItemSpawned())
                    {
                        Instantiate(templates.itemRooms[0], transform.position, templates.itemRooms[0].transform.rotation);
                        templates.setItemSpawned(true);
                        Debug.Log("Item room spawned old");
                        break;
                    }
                    else
                    {
                        Instantiate(templates.bossRooms[0], transform.position, templates.bossRooms[0].transform.rotation);
                        templates.setBossSpawned(true);
                        Debug.Log("Boss room spawned");
                        break;
                    }
                    
                case 2:
                    if (templates.getBossSpawned() && templates.getItemSpawned())
                    {
                        rand = Random.Range(0, templates.T.Length);
                        Instantiate(templates.T[rand], transform.position, templates.T[rand].transform.rotation);
                        Debug.Log("Deadend spawned");
                        break;
                    }
                    else if (templates.getBossSpawned() && !templates.getItemSpawned())
                    {
                        Instantiate(templates.itemRooms[1], transform.position, templates.itemRooms[1].transform.rotation);
                        templates.setItemSpawned(true);
                        Debug.Log("Item room spawned old");
                        break;
                    }
                    else
                    {
                        Instantiate(templates.bossRooms[1], transform.position, templates.bossRooms[1].transform.rotation);
                        templates.setBossSpawned(true);
                        Debug.Log("Boss room spawned");
                        break;
                    }

                case 3:
                    if (templates.getBossSpawned() && templates.getItemSpawned())
                    {
                        rand = Random.Range(0, templates.L.Length);
                        Instantiate(templates.L[rand], transform.position, templates.L[rand].transform.rotation);
                        Debug.Log("Deadend spawned");
                        break;
                    }
                    else if (templates.getBossSpawned() && !templates.getItemSpawned())
                    {
                        Instantiate(templates.itemRooms[2], transform.position, templates.itemRooms[2].transform.rotation);
                        templates.setItemSpawned(true);
                        Debug.Log("Item room spawned old");
                        break;
                    }
                    else
                    {
                        Instantiate(templates.bossRooms[2], transform.position, templates.bossRooms[2].transform.rotation);
                        templates.setBossSpawned(true);
                        Debug.Log("Boss room spawned");
                        break;
                    }

                case 4:
                    if (templates.getBossSpawned() && templates.getItemSpawned())
                    {
                        rand = Random.Range(0, templates.R.Length);
                        Instantiate(templates.R[rand], transform.position, templates.R[rand].transform.rotation);
                        Debug.Log("Deadend spawned");
                        break;
                    }
                    else if (templates.getBossSpawned() && !templates.getItemSpawned())
                    {
                        Instantiate(templates.itemRooms[3], transform.position, templates.itemRooms[3].transform.rotation);
                        templates.setItemSpawned(true);
                        Debug.Log("Item room spawned old");
                        break;
                    }
                    else
                    {
                        Instantiate(templates.bossRooms[3], transform.position, templates.bossRooms[3].transform.rotation);
                        templates.setBossSpawned(true);
                        Debug.Log("Boss room spawned");
                        break;
                    }

            }
            
        }
        
    }

    GameObject pickBottomRoom(GameObject selectedRoom)
    {
        //GameObject room = new GameObject();
        int num;
        switch (selectedRoom.GetComponent<AddRoom>().getName())
        {
            case "B":
                num = Random.Range(0, templates.B.Length);
                //room = templates.B[num];
                return templates.B[num];
                

            case "BL":
                num = Random.Range(0, templates.BL.Length);
                //room = templates.BL[num];
                return templates.BL[num];
                

            case "BR":
                num = Random.Range(0, templates.BR.Length);
                //room = templates.BR[num];
                return templates.BR[num];
                

            case "TB":
                num = Random.Range(0, templates.TB.Length);
                //room = templates.TB[num];
                return templates.TB[num];
                

            case "LRB":
                num = Random.Range(0, templates.LRB.Length);
                //room = templates.LRB[num];
                return templates.LRB[num];
                

            case "LTB":
                num = Random.Range(0, templates.LTB.Length);
                //room = templates.LTB[num];
                return templates.LTB[num];
                

            case "RTB":
                num = Random.Range(0, templates.RTB.Length);
                //room = templates.RTB[num];
                return templates.RTB[num];
                

            case "L":
                num = Random.Range(0, templates.L.Length);
                //room = templates.L[num];
                return templates.L[num];
                

            case "LR":
                num = Random.Range(0, templates.LR.Length);
                //room = templates.LR[num];
                return templates.LR[num];
                

            case "LRT":
                num = Random.Range(0, templates.LRT.Length);
                //room = templates.LRT[num];
                return templates.LRT[num];
                

            case "R":
                num = Random.Range(0, templates.R.Length);
                //room = templates.R[num];
                return templates.R[num];
                

            case "T":
                num = Random.Range(0, templates.T.Length);
                //room = templates.T[num];
                return templates.T[num];
                

            case "TL":
                num = Random.Range(0, templates.TL.Length);
                //room = templates.TL[num];
                return templates.TL[num];
                

            case "TR":
                num = Random.Range(0, templates.TR.Length);
                //room = templates.TR[num];
                return templates.TR[num];
                

            default:
                break;


        }

        return gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if(collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedWall, transform.position, templates.closedWall.transform.rotation);
                
                Destroy(gameObject);
            }
            spawned = true;
            
        }
    }
}
