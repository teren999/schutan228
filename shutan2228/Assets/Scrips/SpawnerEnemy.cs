
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
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
                 GameObject Enemy1 = ObjectPooler.Instance.SpawnFromPool("Enemy1", PosSpawner.position, Quaternion.identity);
            }
    }
}
