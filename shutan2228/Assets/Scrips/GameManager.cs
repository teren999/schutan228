using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int scoreEnemy=0;
    public int maxScoreEnemy=50;
    public Text textEnemyScore;
     public GameObject Boss;
     public GameObject allSpawners;
     public GameObject canvaseScore;

    void Update()
    {
        textEnemyScore.text=scoreEnemy.ToString()+"/"+maxScoreEnemy.ToString();
        if(scoreEnemy>=maxScoreEnemy && boss1.curentHpBoss>0)
        {
            canvaseScore.SetActive(false);

            Boss.SetActive(true);
            allSpawners.SetActive(false);

        }

    }
}
