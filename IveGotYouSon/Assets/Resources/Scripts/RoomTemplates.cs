using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour 
{
	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	public float waitTime;
	private bool spawnedBoss;
	public GameObject boss;
	public GameObject teddyBear;

	void Update()
	{
		if (waitTime <= 0 && spawnedBoss == false)
		{
			for (int i = 0; i < rooms.Count; i++) 
			{
				if (i == rooms.Count - 1)
				{
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;

                    for (int i2 = 0; i2 < 3; i2++)
                    {
						GameObject pickedRoom = rooms[Random.Range(0, rooms.Count)];
						Debug.Log(pickedRoom);
						Instantiate(teddyBear, pickedRoom.transform.position + pickedRoom.GetComponent<ContentRandomzier>().spawnPoints[Random.Range(0, pickedRoom.GetComponent<ContentRandomzier>().spawnPoints.Count)].transform.position, Quaternion.identity);
                    }
				}
			}
		} 
		else 
		{
			waitTime -= Time.deltaTime;
		}
	}
}
