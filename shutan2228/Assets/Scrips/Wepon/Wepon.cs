
using UnityEngine;

public class Wepon : MonoBehaviour
{
  
    public SpriteRenderer SpriteWepon;
    public Sprite[] SkinsSprite;
    public static int IndexSkin;
    
    void Start()
    {
        IndexSkin = PlayerPrefs.GetInt("indexxskin");
        SpriteWepon.sprite = SkinsSprite[IndexSkin];
        
    }

    public void ChangeSkin(int index)
    {
        IndexSkin = index;
        SpriteWepon.sprite = SkinsSprite[IndexSkin];
    }

    



    
    
}
