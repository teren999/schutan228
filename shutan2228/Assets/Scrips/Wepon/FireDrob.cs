using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireDrob : MonoBehaviour
{
    
    public Transform firePoint;
    public Transform directionPoint1;
    public Transform directionPoint2;
    public Transform directionPoint3;
    public Transform directionPoint4;
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
            Vector2 direction1 = directionPoint1.position - firePoint.position;
            // Устанавливаем направление пули
            bullet.transform.right = direction1.normalized;
        }

        GameObject bullet1 = ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);
        if (bullet1 != null)
        {
            Vector2 direction2 = directionPoint2.position - firePoint.position;
            // Устанавливаем направление пули
            bullet1.transform.right = direction2.normalized;
        }

        GameObject bullet2 = ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);
        if (bullet2 != null)
        {
            // Получаем базовое направление от firePoint к directionPoint
            Vector2 direction3 = directionPoint3.position - firePoint.position;
            // Устанавливаем направление пули
            bullet2.transform.right = direction3.normalized;
        }

        GameObject bullet3 = ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);
        if (bullet3 != null)
        {
            // Получаем базовое направление от firePoint к directionPoint
            Vector2 direction4 = directionPoint4.position - firePoint.position;
            // Устанавливаем направление пули
            bullet3.transform.right = direction4.normalized;
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
