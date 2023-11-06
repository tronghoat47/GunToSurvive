using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 0.5f;
    public GameObject[] enemyPrefab;
    public bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
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

            Instantiate(enemySpawn, transform.position, Quaternion.identity);
        }
    }
}
