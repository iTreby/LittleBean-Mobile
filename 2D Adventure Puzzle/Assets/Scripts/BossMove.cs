using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMove : MonoBehaviour
{

    public Animator bossAnime;
    [SerializeField] Transform zPoint;
    [SerializeField] CutSceneOne player;
    [SerializeField] GameObject space;
    public Text message;

    // Start is called before the first frame update
    void Start()
    {
        bossAnime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x == zPoint.position.x)
        {

            //player.anime.SetBool("Reach", true);
            StartCoroutine("Wait");
            bossAnime.SetBool("Moving", true);
            StartCoroutine("Vortex");
            
        }
    }

    IEnumerator Vortex()
    {
        yield return new WaitForSeconds(3f);
        space.SetActive(true);
       
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }

}
