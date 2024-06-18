using UnityEngine;

public class SwapSkinmeny : MonoBehaviour
{
    public SpriteRenderer SpriteWepon;
    public Sprite[] SkinsSprite;
    public static int IndexSkin;
    
    void Update()
    {
        SpriteWepon.sprite = SkinsSprite[IndexSkin];
        
    }
}
