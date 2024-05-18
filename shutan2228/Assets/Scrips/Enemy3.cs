using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public int hp;
    public int hpmax;
    
    public int damageEnemy;
    public float speed; // Скорость движения врага
    private Transform target; // Цель (игрок)
    private Rigidbody2D rb; // Ссылка на Rigidbody2D
    public SpriteRenderer spriteEnemy;
    //public Transform posPlayer;
    public Animator anim;
    private bool ismoving=true;
    public Transform firePoint;
  


private void OnEnable()
{
    hp=hpmax;
    
}
    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока при старте
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
    }

    void Update()
    {
         Vector3 cursorPosition = target.position;

       
        if (transform.position.x < cursorPosition.x)
        {
            
            spriteEnemy.flipX = false;
        }
        else
        {
            
            spriteEnemy.flipX = true;
        }
    
        if (hp <= 0)
        {
             GameObject coins = ObjectPooler.Instance.SpawnFromPool("coins", transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            GameManager.scoreEnemy++;
            GameManager.liveEnemy--;
        }
        else
        {
            MoveTowardsPlayer(); 
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hp -= Bullet.Damage;
        }
        if (collision.CompareTag("oblast") )
        {
            ismoving=false;
        
            anim.SetBool("hit", true);
        
        }
        
        
    }

    


private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("oblast"))
    {
        ismoving=true;
        anim.SetBool("hit", false);
        
    }
}



  public void hitEnemy()
{
    GameObject enemyBullet = ObjectPooler.Instance.SpawnFromPool("EnemyBullet", firePoint.position, Quaternion.identity);
    if (enemyBullet != null)
    {
        // Направляем пулю в сторону игрока
        Vector2 direction = (target.position - firePoint.position).normalized;
        enemyBullet.transform.right = direction; // Устанавливаем направление взгляда пули в сторону игрока
        enemyBullet.GetComponent<Rigidbody2D>().velocity = direction * enemyBullet.GetComponent<EnemyBullet>().speed;
    }
}


    
    

    void MoveTowardsPlayer()
    {
        if (target != null && ismoving==true)
        {
            // Направляем врага к игроку
            Vector2 direction = (target.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        }
    }
}
