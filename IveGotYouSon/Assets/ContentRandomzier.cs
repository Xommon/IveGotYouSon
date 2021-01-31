using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentRandomzier : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> obstacles = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public int numberOfSpawnsUsable;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            numberOfSpawnsUsable = Random.Range(4, 6);

            for (int i = 0; i < numberOfSpawnsUsable; i++)
            {
                int enemyIndex = Random.Range(0, enemies.Count);
                int obstacleIndex = Random.Range(0, obstacles.Count);
                int spawnIndex = Random.Range(0, spawnPoints.Count);

                if (i == 0)
                {
                    GameObject createObstacleOrEnemy = Instantiate(enemies[enemyIndex], transform.position + spawnPoints[spawnIndex].transform.position, Quaternion.identity);
                    createObstacleOrEnemy.GetComponent<EnemyRenderer>().room = gameObject;
                    enemies.RemoveAt(enemyIndex);
                    spawnPoints.RemoveAt(spawnIndex);
                }
                else
                {
                    if (Random.Range(0, 3) == 0)
                    {
                        GameObject createObstacleOrEnemy = Instantiate(enemies[enemyIndex], transform.position + spawnPoints[spawnIndex].transform.position, Quaternion.identity);
                        createObstacleOrEnemy.GetComponent<EnemyRenderer>().room = gameObject;
                        enemies.RemoveAt(enemyIndex);
                        spawnPoints.RemoveAt(spawnIndex);
                    }
                    else
                    {
                        GameObject createObstacleOrEnemy = Instantiate(obstacles[obstacleIndex], transform.position + spawnPoints[spawnIndex].transform.position, Quaternion.identity);
                        createObstacleOrEnemy.GetComponent<FurnitureRenderer>().room = gameObject;
                        obstacles.RemoveAt(obstacleIndex);
                        spawnPoints.RemoveAt(spawnIndex);
                    }
                }
            }
        }
        catch (System.ArgumentOutOfRangeException e){
            print(e + ": this is fine probably");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
