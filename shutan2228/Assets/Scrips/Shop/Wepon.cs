using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Weapon
{
    public string name;
    public int price;
    public bool isPurchased;
    public Button button;
    public GameObject priceText;
    public int index;
    public int UpdatePrice;
    public int lvlUpdate;
    public Text lvlText;
    public int IndexWeapon;
    public Color defaultColor;
}
