using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivate : MonoBehaviour
{
    [SerializeField] GameObject fire;


    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            fire.SetActive(true);
        }
    }
}
