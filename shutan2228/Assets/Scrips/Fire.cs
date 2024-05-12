using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform directionPoint;
    public float fireRate = 0.5f;
    private float nextFire = 0f;

    public int damage;
    public int lvl;
    public int ScaleLvlDamage;

    void Start()
    {
        damage=damage+(lvl*ScaleLvlDamage);
         Bullet.Damage=damage;
    }
    

    void Update()
    {
        
       
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
            
        }
    }

    void Shoot()
{
    GameObject bullet = ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);
    if (bullet != null)
    {
        // Получаем базовое направление от firePoint к directionPoint
        Vector2 direction = directionPoint.position - firePoint.position;

        // Добавляем случайное смещение к направлению
        float offsetX = Random.Range(-0.03f, 0.03f);
        float offsetY = Random.Range(-0.03f, 0.03f);
        direction.x += offsetX;
        direction.y += offsetY;

        // Устанавливаем направление пули
        bullet.transform.right = direction.normalized;
    }
}

   
}




