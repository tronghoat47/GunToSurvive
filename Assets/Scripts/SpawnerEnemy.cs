using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemyPrefab;
    public bool canSpawn = true;
    private int EnemyCount;
    private Camera mainCamera;
    public Transform player;
    float duration = 0;

    List<GameObject> Enemies;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Constants.spawnEnemyRateDefault;
        EnemyCount = Constants.countEnemyRateDefault;

        Enemies = new List<GameObject>();

        for (int i = 0; i < EnemyCount; i++) {
            int randEnemy = Random.Range(0, enemyPrefab.Length);
            GameObject enemyObject = Instantiate(enemyPrefab[randEnemy]);

            enemyObject.SetActive(false);

            Enemies.Add(enemyObject);
        }

        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //StartCoroutine(Spawners());
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;

        if (duration >= Constants.spawnEnemyRateDefault) {
            GameObject enemy = getFreeEnemy();
            if (enemy != null) {
                Vector3 randomPosition = GetRandomPositionOutsideCamera();
                enemy.transform.position = randomPosition;
                enemy.SetActive(true);
                duration = 0;
            }
        }
    }

    private IEnumerator Spawners()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        GameObject enemy = getFreeEnemy();
        while (enemy != null)
        {
            yield return wait;
            enemy.SetActive(true);
            Vector3 randomPosition = GetRandomPositionOutsideCamera();
            gameObject.transform.position = randomPosition;
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

    private GameObject getFreeEnemy() {
        foreach (GameObject g in Enemies) {
            if (!g.activeSelf) {
                return g;
            }
        }
        return null;
    }
}
