using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float speed = 25f;
   public static int Damage;
    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}