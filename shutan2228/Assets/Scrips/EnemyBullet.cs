using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 15f; // Скорость пули врага
    public int damage = 10; // Урон, который наносит пуля врага

    void Update()
    {
        // Двигаем пулю вперед по направлению
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        // Если пуля врага сталкивается с игроком, наносим урон и отключаем пулю
        if (collision.CompareTag("Player"))
        {
            HpPlayer.currentHp-=damage;
            gameObject.SetActive(false);
        }
    }

    
}
