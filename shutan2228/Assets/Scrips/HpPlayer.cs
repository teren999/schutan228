
using UnityEngine;
using UnityEngine.UI;

public class HpPlayer : MonoBehaviour
{
    public float maxHp;
    public float currentHp;
    public Image fillImage;
    public Text textHp;
     public Color lowHpColor = Color.red;
    public Color highHpColor = Color.white;

    
    void Start()
    {
        
    }

   
    void Update()
    {
        textHp.text= currentHp.ToString() ;
         float fillAmount = currentHp / maxHp;
            
            fillImage.fillAmount = fillAmount;

            
        if (fillAmount <= 0.3f)
        {
            fillImage.color = lowHpColor; 
        }
        else
        {
            fillImage.color = highHpColor; 
        }
    }
}
