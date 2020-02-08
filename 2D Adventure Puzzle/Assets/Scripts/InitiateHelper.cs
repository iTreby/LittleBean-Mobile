using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InitiateHelper : MonoBehaviour
{

    [SerializeField] GameObject panel;


    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey) {
          panel.SetActive(false);
        }
    }
}
