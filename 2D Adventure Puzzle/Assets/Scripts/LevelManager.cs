using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] Button levelButton;
    [SerializeField] string levelToLoad;

    [SerializeField] Image lockedImage;

    private bool levelIsUnlocked;

    private int unlockedLevel;

    private void Awake() {
      unlockedLevel = PlayerPrefs.GetInt("currentUnlockedLevel");
    }

    void Start()
    {
        string levelsToLoad = GetLevelsToLoad();
        SetUnlockedLevels(unlockedLevel, levelsToLoad);
    }
    string GetLevelsToLoad() {
      return levelToLoad.Substring(levelToLoad.Length - 1);
    }

    void SetUnlockedLevels(int currentlyUnlocked, string levelsToLoad) {
      if (int.TryParse(levelsToLoad, out int number)) {
        if (currentlyUnlocked >= number) {
          Debug.Log("UNLOCKED: " + levelsToLoad);
          levelIsUnlocked = true;
          lockedImage.gameObject.SetActive(false);
        } else {
          Debug.Log("LOCKED: " + levelsToLoad);
          levelIsUnlocked = false;
          levelButton.interactable = false;
        }
      } else {
        Debug.Log("Cannot convert " + levelsToLoad);
      }   
    }

    public void SelectStage()
    {
      if (levelIsUnlocked) {
        SceneManager.LoadScene(levelToLoad);
      }
    }

}
