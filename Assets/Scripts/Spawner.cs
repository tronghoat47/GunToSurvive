using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 0.5f;
    public GameObject[] enemyPrefab;
    public bool canSpawn = true;
    private Camera mainCamera;
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Spawners());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawners()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;

             int rand = Random.Range(0, enemyPrefab.Length);
            GameObject enemySpawn = enemyPrefab[rand];

            Vector3 randomPosition = GetRandomPositionOutsideCamera();

            Instantiate(enemySpawn, randomPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPositionOutsideCamera()
    {
        float cameraHeight = 1.5f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Calculate random position outside the camera view
        Vector3 playerPosition = player.position;
        float x = Random.Range(playerPosition.x - cameraWidth, playerPosition.x + cameraWidth)*1.5f;
        float y = Random.Range(playerPosition.y - cameraHeight, playerPosition.y + cameraHeight)*1.5f;

        Vector3 randomPosition = new Vector3(x, y, 0f);
        return randomPosition;
    }
}
