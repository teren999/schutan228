using UnityEngine.SceneManagement;
using UnityEngine;

public class MenyManager : MonoBehaviour
{
    public GameObject _ShopWeapon;
    public GameObject _ShopHiro;
    public GameObject Shop;
    public GameObject  Buttons;

    public void StartGame()
    {
       SceneManager.LoadScene(0);
    }

    public void shop()
    {
       Shop.SetActive(true);
       Buttons.SetActive(false);
    }

    public void BackInShop()
    {
       Buttons.SetActive(true);
       Shop.SetActive(false);
    }

    public void ShopHiro()
    {
       _ShopHiro.SetActive(true);
       _ShopWeapon.SetActive(false);
    }

    public void ShopWeapon()
    {
        _ShopHiro.SetActive(false);
        _ShopWeapon.SetActive(true);
    }
}
