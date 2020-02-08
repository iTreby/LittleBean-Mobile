using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStar : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] int addStart;
    [SerializeField] AudioSource starCollect;
    private bool pickUp = false;


    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0,5,0 * 10 * Time.deltaTime,0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!pickUp)
            {
                pickUp = true;
                starCollect.Play();
                Destroy(gameObject);
                gm.GiveStar();
            }
            
        }
    }

}
