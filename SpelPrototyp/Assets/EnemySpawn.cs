//NOT IN USE
//Caspian

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Collider coll;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    public  int enemyCount = 0;

    public Collider spawnRadius;

    public bool safe = false;


    private void Start() {
        spawnRadius = GameObject.FindGameObjectWithTag("Player").GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            safe = true;
        }
        else safe = false;
    }

    public Vector3 spawnpoint(Bounds bounds)
    {
        return  new Vector3(
            Random.Range(5, bounds.max.x),
            Random.Range(3, 5),
            Random.Range(5, bounds.max.z)
        );
    }


    private void Update() 
    {
        if(safe == false)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(enemyCount < 10)
        {
            Instantiate(enemy, spawnpoint(spawnRadius.bounds), Quaternion.identity);
            yield return new WaitForSeconds(1);
            Debug.Log("Enemy spawned");
            enemyCount += 1;
        }
           
        
    }
}
