using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] ObstaclesArr;

    int playerDistanceIndex = -1;
    int obstacleCount;
    int obstacleIndex = 0;
    int distanceToNext = 50;
    void Start()
    {
        obstacleCount = ObstaclesArr.Length;
        InstantiateObstacle();
    }

    void Update()
    {
        int playerDistance = (int)(player.transform.position.y / (distanceToNext));

        if(playerDistanceIndex != playerDistance)
        {
            InstantiateObstacle();
            playerDistanceIndex = playerDistance;
        }
    }

    public void InstantiateObstacle()
    {
        int randomInt = Random.Range(0, obstacleCount);
        GameObject newObstacle = Instantiate(ObstaclesArr[randomInt], new Vector3(0,obstacleIndex*distanceToNext),Quaternion.identity);
        newObstacle.transform.SetParent(transform);
        obstacleIndex++;
    }
}
