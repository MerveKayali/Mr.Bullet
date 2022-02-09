using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private Button levelButton;

    public int levelReq;
    void Start()
    {
        levelButton = GetComponent<Button>();

        if(PlayerPrefs.GetInt("Level",1)>= levelReq)
        {
            levelButton.onClick.AddListener(() => LoadLevel());
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = .5f;
        }
    }

    // Update is called once per frame
    public void LoadLevel()
    {
        SceneManager.LoadScene(gameObject.name);
    }
}
