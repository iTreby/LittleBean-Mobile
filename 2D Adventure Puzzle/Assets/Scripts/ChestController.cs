using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestController : MonoBehaviour
{

    [SerializeField] Animator anime;
    [SerializeField] GameObject chestEffect;
    [SerializeField] GameObject cupOfLife;


    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        cupOfLife.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            StartCoroutine("Chest");

        }
    }

    IEnumerator Chest()
    {
        anime.SetBool("PlayerReach", true);
        yield return new WaitForSeconds(1.5f);
        cupOfLife.SetActive(true);
        chestEffect.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(14);
    }

}
