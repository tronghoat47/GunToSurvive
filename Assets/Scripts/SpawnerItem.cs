using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    public float spawnItem = 5f;
    public GameObject[] itemPrefab;
    public bool canSpawnItem = true;
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
        WaitForSeconds wait = new WaitForSeconds(spawnItem);
        while (canSpawnItem)
        {
            yield return wait;

            int randItem = Random.Range(0, itemPrefab.Length);
            GameObject itemSpawn = itemPrefab[randItem];

            Vector3 randomPosition = GetRandomPositionOutsideCamera();

            Instantiate(itemSpawn, randomPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPositionOutsideCamera()
    {
        float cameraHeight = 1.5f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Calculate random position outside the camera view
        Vector3 playerPosition = player.position;
        float x = Random.Range(playerPosition.x - cameraWidth, playerPosition.x + cameraWidth) * 1.5f;
        float y = Random.Range(playerPosition.y - cameraHeight, playerPosition.y + cameraHeight) * 1.5f;

        Vector3 randomPosition = new Vector3(x, y, 0f);
        return randomPosition;
    }
}
