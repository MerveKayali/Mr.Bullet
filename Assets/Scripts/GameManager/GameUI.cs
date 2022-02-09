using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI instace;

    private GameManager gameManager;

    private int startBB;
    [Header("WinScreen")]
    public Text goodJobText;
    public GameObject winPanel;
    public Image star1, star2, star3;
    public Sprite shineStar, darkStar;

    [Header("GameOver")]
    public GameObject GameOverPanel;
    void Awake()
    {
        instace = this;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        startBB = gameManager.blackBullets;
    }

   public void GameOverScreen()
   {

        GameOverPanel.SetActive(true);
   }

    public void WinScreen()
    {
        winPanel.SetActive(true);
        if(gameManager.blackBullets>=startBB)
        {
            goodJobText.text = "FANTASTIC!";
            StartCoroutine(Stars(3));
        }
        else if(gameManager.blackBullets>=startBB - (gameManager.blackBullets/2))
        {
            goodJobText.text = "AWESOME!";
            StartCoroutine(Stars(2));
        }
        else if(gameManager.blackBullets>0)
        {
            goodJobText.text = "WELL DONE!";
            StartCoroutine(Stars(1));
        }
        else
        {
            goodJobText.text = "GOOD";
            StartCoroutine(Stars(0));
        }
    }

    private IEnumerator Stars(int shineNumber)
    {
        yield return new WaitForSeconds(0.5f);    

        switch(shineNumber)
        {
            case 3:
                yield return new WaitForSeconds(.10f);
                star1.sprite = shineStar;
                yield return new WaitForSeconds(.10f);
                star2.sprite = shineStar;
                yield return new WaitForSeconds(.10f);
                star3.sprite = shineStar;
                break;

            case 2:
                yield return new WaitForSeconds(.10f);
                star1.sprite = shineStar;
                yield return new WaitForSeconds(.10f);
                star2.sprite = shineStar;
                star3.sprite = darkStar;
                break;
            case 1:
                yield return new WaitForSeconds(.10f);
                star1.sprite = shineStar;                
                star2.sprite = darkStar;
                star3.sprite = darkStar;
                break;

            case 0:
               
                star1.sprite = darkStar;                
                star2.sprite = darkStar;
                star3.sprite = darkStar;
                break;

        }
    }
}
