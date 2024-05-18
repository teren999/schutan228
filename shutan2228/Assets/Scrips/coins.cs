
using UnityEngine;
using UnityEngine.UI;

public class coins : MonoBehaviour
{
    public Text CoinsText;
    public static int Coins=0;

    // Start is called before the first frame update
    void Start()
    {
          CoinsText = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinsText.text = Coins.ToString();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        Coins++;
        gameObject.SetActive(false);
        }
    }
}
