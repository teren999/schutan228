using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
  
    public SpriteRenderer SpriteWepon;
    public Sprite[] SkinsSprite;
    public int IndexSkin;
    
    void Start()
    {
        SpriteWepon.sprite = SkinsSprite[IndexSkin];
        
    }

    
    
}
