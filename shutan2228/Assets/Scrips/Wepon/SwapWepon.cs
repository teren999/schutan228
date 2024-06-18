
using UnityEngine;

public class SwapWepon : MonoBehaviour
{
    public GameObject[] wepons;
    public int index;
    public int indexSkin;
    // Start is called before the first frame update
    void Start()
    {  
        index=ShopManager.indexWeapon;
        Wepon.IndexSkin = indexSkin;
        for(int i = 0;i < wepons.Length;i++)
        {
            wepons[i].SetActive(false);
        }
        wepons[index].SetActive(true);
    }

    

    
}
