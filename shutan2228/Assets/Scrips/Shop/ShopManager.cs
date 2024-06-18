using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text balanceText;
    public Button buyButton;
    public Button equipButton;
    public Button upgradeButton;
    public Button[] skinButtons;
    public Weapon[] weapons;  // Массив оружий
    private int playerBalance = 1000;
    private Weapon selectedWeapon;
    public GameObject[] wepons;
    public static int indexWeapon = 0;
     private Color selectedColor = Color.yellow;
     public static int indexSkin;


    void Start()
    {
        indexSkin= PlayerPrefs.GetInt("indexxskin");
       // LoadData();
       indexWeapon= PlayerPrefs.GetInt("indexWeapon");
        UpdateUI();
        foreach (Weapon weapon in weapons)
        {
            weapon.lvlUpdate = PlayerPrefs.GetInt(weapon.name + "_level");
            if(weapon.lvlUpdate==0)
            {
                weapon.lvlText.text = "";
            }
            else
            {
                weapon.lvlText.text = "lvl: "+weapon.lvlUpdate;
            }
            weapon.button.onClick.AddListener(() => SelectWeapon(weapon));
        }
        for (int i = 0; i < skinButtons.Length; i++)
        {
            int index = i; // Захватываем индекс для использования в лямбде
            skinButtons[i].onClick.AddListener(() => ChangeSkin(index));
        }
        
    }

    void SelectWeapon(Weapon weapon)
    {
        ResetButtonColors();
        selectedWeapon = weapon;
        selectedWeapon.lvlUpdate = PlayerPrefs.GetInt(selectedWeapon.name + "_level");
         selectedWeapon.button.image.color = selectedColor;
        UpdateUI();
    }

    private void ResetButtonColors()
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.button.image.color = Color.white ;
        }
    }
    

    public void BuyWeapon()
    {
        if (selectedWeapon != null && playerBalance >= selectedWeapon.price && !selectedWeapon.isPurchased)
        {
            playerBalance -= selectedWeapon.price;
            selectedWeapon.isPurchased = true;
          //  SaveData();
            UpdateUI();
        }
    }

    public void EquipWeapon()
    {
        if (selectedWeapon != null && selectedWeapon.isPurchased)
        {
            for(int i = 0;i < wepons.Length;i++)
            {
                wepons[i].SetActive(false);
            }
             wepons[selectedWeapon.index].SetActive(true);
             indexWeapon=selectedWeapon.IndexWeapon;
             PlayerPrefs.SetInt("indexWeapon",indexWeapon);
            Debug.Log("Weapon equipped: " + selectedWeapon.name);
        }
    }

    public void UpgradeWeapon()
    {
        if (selectedWeapon != null && selectedWeapon.isPurchased)
        {
             playerBalance -= selectedWeapon.UpdatePrice;
             selectedWeapon.lvlUpdate++;
             PlayerPrefs.SetInt(selectedWeapon.name + "_level", selectedWeapon.lvlUpdate);
             PlayerPrefs.SetInt(selectedWeapon.name + "_level", selectedWeapon.lvlUpdate);
             selectedWeapon.lvlText.text = "lvl: "+selectedWeapon.lvlUpdate;
             
             UpdateUI();


            Debug.Log("Weapon upgraded: " + selectedWeapon.name);
        }
    }

    private void ChangeSkin(int index)
    {
        Wepon.IndexSkin = index;

        foreach (var wepon in wepons)
        {
            var weponComponent = wepon.GetComponent<Wepon>();
            if (weponComponent != null)
            {
                weponComponent.ChangeSkin(index);
            }
        }
        PlayerPrefs.SetInt("indexxskin", index);
    }

    private void UpdateUI()
    {
        balanceText.text = playerBalance.ToString();

        foreach (Weapon weapon in weapons)
        {
            weapon.priceText.gameObject.SetActive(!weapon.isPurchased);
        }

        if (selectedWeapon != null)
        {
            buyButton.gameObject.SetActive(!selectedWeapon.isPurchased);
            equipButton.gameObject.SetActive(selectedWeapon.isPurchased);
            upgradeButton.gameObject.SetActive(selectedWeapon.isPurchased);
        }
        else
        {
            buyButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(false);
            upgradeButton.gameObject.SetActive(false);
        }
    }

  //  private void SaveData()
  //  {
   //     PlayerPrefs.SetInt("PlayerBalance", playerBalance);
   //     for (int i = 0; i < weapons.Length; i++)
    //    {
    //        PlayerPrefs.SetInt("WeaponPurchased_" + weapons[i].name, weapons[i].isPurchased ? 1 : 0);
    //    }
    //    PlayerPrefs.Save();
  //  }

   // private void LoadData()
   // {
   //     playerBalance = PlayerPrefs.GetInt("PlayerBalance", 1000);
   //     for (int i = 0; i < weapons.Length; i++)
   //     {
    //        weapons[i].isPurchased = PlayerPrefs.GetInt("WeaponPurchased_" + weapons[i].name, 0) == 1;
   //     }
   // }
}
