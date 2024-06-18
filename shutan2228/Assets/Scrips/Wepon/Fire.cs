using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public string weaponName;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform directionPoint;
    public float fireRate = 0.5f;
    private float nextFire = 0f;

    public float reloadTime = 2f; // Время перезарядки
    private bool isReloading = false; // Флаг для определения, идет ли перезарядка
    private float reloadStartTime; // Время начала перезарядки

    public int damage;
    public int lvl;
    public int ScaleLvlDamage;
    public int ammo = 30;
    public int ammomax = 30;
    public Text ammoText;
    public GameObject reloutext;

    void Start()
    {
        lvl = PlayerPrefs.GetInt(weaponName + "_level");
        damage = damage + (lvl * ScaleLvlDamage);
        Bullet.Damage = damage;
    }


    void Update()
    {
        ammoText.text = ammo.ToString() + "/" + ammomax;
        if (ammo > 0 && !isReloading)
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Shoot();
                ammo--;

                if (ammo == 0)
                {
                    StartReload();
                }
            }
        }
        else if (isReloading)
        {
            if (Time.time >= reloadStartTime + reloadTime)
            {
                FinishReload();
            }
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

    void StartReload()
    {
        reloutext.SetActive(true);
        isReloading = true;
        reloadStartTime = Time.time;
        // Здесь можно добавить анимацию или другие действия, связанные с началом перезарядки
    }

    void FinishReload()
    {
        reloutext.SetActive(false);
        isReloading = false;
        ammo = ammomax; // Полная перезарядка
        // Здесь можно добавить анимацию или другие действия, связанные с завершением перезарядки
    }

     
}
