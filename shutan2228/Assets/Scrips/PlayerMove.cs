
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _Movespeed = 5f;
    private Rigidbody2D rb;
    public Animator anim;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
        bool isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;

       
        anim.SetBool("run", isMoving);
    }

    void FixedUpdate()
    {
        float _moveHorizontal = Input.GetAxis("Horizontal");
        float _moveVertical = Input.GetAxis("Vertical");
        

        Vector2 _movement = new Vector2(_moveHorizontal,_moveVertical);
        rb.velocity = _movement * _Movespeed;
        
    }
}
