using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy2 : MonoBehaviour
{
    public Transform PosSpawner;
    private float nexEnemy = 0f;
    public float nexEnemyRate = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nexEnemy)
            {
                nexEnemy = Time.time + nexEnemyRate;
                 GameObject Enemy2 = ObjectPooler.Instance.SpawnFromPool("Enemy2", PosSpawner.position, Quaternion.identity);
            }
    }
}
