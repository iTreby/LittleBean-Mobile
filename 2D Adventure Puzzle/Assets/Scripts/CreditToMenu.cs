using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SwitchMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SwitchMenu()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(1);
    }


}
