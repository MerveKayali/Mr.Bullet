using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount = 1;
    [HideInInspector]
    public bool gameover;

    public int blackBullets = 3;
    public int goldenBullets=1;
    public GameObject blackBullet, goldenbullet;
    private int levelNumber;
    

    
    void Awake()
    {

        levelNumber = PlayerPrefs.GetInt("Level", 1);
        FindObjectOfType<PlayerController>().ammo = blackBullets + goldenBullets; //PlayerController scriptinde oluþturdugumuz mermi sayýsýna atadýk
        for (int i=0;i<blackBullets;i++)
        {
            GameObject bbTemps = Instantiate(blackBullet);// geçici obje oluþturduk
            bbTemps.transform.SetParent(GameObject.Find("Bullets").transform);//bu objeyi Bullets gameobjectinin childi olacak þekilde ayarladýk
        }

        for (int i = 0; i < goldenBullets; i++)
        {
            GameObject gbTemps = Instantiate(goldenbullet);
            gbTemps.transform.SetParent(GameObject.Find("Bullets").transform);
        }
    }

   
    void Update()
    {
        
        if (!gameover && FindObjectOfType<PlayerController>().ammo <= 0 && enemyCount > 0
            && GameObject.FindGameObjectsWithTag("Bullet").Length <= 0)
        {
            gameover = true;
            GameUI.instace.GameOverScreen();
        }
    }

    public void CheckEnemyCount()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemyCount<=0)
        {
            GameUI.instace.WinScreen();
            if(levelNumber>=SceneManager.GetActiveScene().buildIndex)
            {
                PlayerPrefs.SetInt("Level", levelNumber + 1);
            }
        }
    }

    public void CheckBullet()
    {
        if(goldenBullets>0)
        {
            goldenBullets--;
            GameObject.FindGameObjectWithTag("GoldenBullet").SetActive(false);
            
        }else if(blackBullets>0)
        {
            blackBullets--;
            GameObject.FindGameObjectWithTag("BlackBullet").SetActive(false);
            
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//o an açýk olan sahneyi tekrar oynat
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
        
    }
}
