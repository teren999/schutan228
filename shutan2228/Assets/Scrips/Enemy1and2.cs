using UnityEngine;

public class Enemy1and2 : MonoBehaviour
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
    private void OnEnable()
{
    hp=hpmax;
    
}
  

    void Start()
    {
         hp=hpmax;
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
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player") )
    {
        
        anim.SetBool("hit", true);
        
    }
}

void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        
        anim.SetBool("hit", false);
        
    }
}

    public void hitEnemy()
    {
        
         HpPlayer.currentHp-=damageEnemy;
    }
    
    

    void MoveTowardsPlayer()
    {
        if (target != null)
        {
            // Направляем врага к игроку
            Vector2 direction = (target.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        }
    }
}
