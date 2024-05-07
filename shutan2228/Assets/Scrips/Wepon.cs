using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public int damage;
    public int RateOfFire;
    public SpriteRenderer SpriteWepon;
    public Sprite[] SkinsSprite;
    public int IndexSkin;
    
    void Start()
    {
        SpriteWepon.sprite = SkinsSprite[IndexSkin];
        
    }

    
    void Update()
    {
        
    }
}
