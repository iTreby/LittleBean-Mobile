using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneOne : MonoBehaviour
{
    [SerializeField] AudioSource introSong;
    
    //The platform
    [SerializeField] GameObject movingObject;
    //Position of both point
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] Transform zPoint;
    //Speed for moving the brick
    [SerializeField] float moveSpeed = 5f;
    //To save the current position of the platform/object
    private Vector3 currentTarget;
    public Animator anime;
    public bool eventOne = false;
    [SerializeField] GameObject textSurprise;
    [SerializeField] GameObject panelText;
    public Text message;
    bool check = false;
    bool afterMessage = false;
    //private bool a;



    // Start is called before the first frame update
    void Start()
    {
        introSong.Play();
        textSurprise.SetActive(false);
        anime = GetComponent<Animator>();
        currentTarget = endPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Moving to the end point
        movingObject.transform.position = Vector2.MoveTowards(movingObject.transform.position, currentTarget, moveSpeed * Time.deltaTime);


        if (movingObject.transform.position.y == startPoint.position.y)
        {
            currentTarget = endPoint.position;
        }
        if (movingObject.transform.position.y == endPoint.position.y)
        {
            anime.SetBool("Reach", true);
            eventOne = true;
            StartCoroutine("Emote");
        }
        
        if(!check && movingObject.transform.position.x == zPoint.position.x)
        {
            check = true;
            Debug.Log(check);
            textSurprise.SetActive(false);
            panelText.SetActive(true);
            StartCoroutine("Message");                                   
        }
      
    }

    IEnumerator Emote()
    {
        yield return new WaitForSeconds(1.5f);
        textSurprise.SetActive(true);
        introSong.Stop();
        if(movingObject.transform.position.y == endPoint.position.y)
        {
            currentTarget = zPoint.position;
            anime.SetBool("Reach", false);
        }
    }

   

    IEnumerator Message()
    {
        message.text = "Human ...";
        yield return new WaitForSeconds(1f);
        message.text = "";
        yield return new WaitForSeconds(0.5f);
        message.text = "With the last of my power, find my treasure";    
        yield return new WaitForSeconds(3.5f);
        message.text = "Only then you can return home";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(4);
    }

   


}
