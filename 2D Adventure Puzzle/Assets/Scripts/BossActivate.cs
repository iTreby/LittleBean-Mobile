﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] AudioSource entryMusic;

    // Start is called before the first frame update
    void Start()
    {
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            entryMusic.Stop();
            boss.SetActive(true);
        }
    }



}
