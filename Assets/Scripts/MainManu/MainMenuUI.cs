using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject Play, LevelSelection;

    public void PlayGame()
    {
        Play.SetActive(false);
        LevelSelection.SetActive(true);
    }
}
