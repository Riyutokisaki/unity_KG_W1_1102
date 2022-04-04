using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemContor : MonoBehaviour
{
    private bool gameStop = false;
    private AudioSource ad;
    public AudioClip bgm;
    public GameObject UI;
    private void Start()
    {
        ad = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))Stop();
    }
    private void Stop()
    {
        if (gameStop)
        {
            Time.timeScale = 1;
            ad.PlayOneShot(bgm);
            UI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            ad.Stop();
            UI.SetActive(true);
        }
        gameStop = !gameStop;
    }
   

}
