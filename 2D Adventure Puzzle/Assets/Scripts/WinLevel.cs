using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLevel : MonoBehaviour
{

    [SerializeField] string stageName;
    public GameManager starEnd;
    public Image star1;
    public Image star2;
    public Image star3;
    public Sprite star;
    public Sprite emptyStar;
   // public string levelToLoad;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStarImage();
    }


    public void NextLevel()
    {
        //SceneManager.LoadScene(stageName);
    }

    public void UpdateStarImage()
    {
        switch (starEnd.starCount)
        {
            case 1:
                star1.sprite = star;
                star2.sprite = emptyStar;
                star3.sprite = emptyStar;
                return;
            case 2:
                star1.sprite = star;
                star2.sprite = star;
                star3.sprite = emptyStar;
                return;
            case 3:
                star1.sprite = star;
                star2.sprite = star;
                star3.sprite = star;
                return;
                          
        }
    }

}
