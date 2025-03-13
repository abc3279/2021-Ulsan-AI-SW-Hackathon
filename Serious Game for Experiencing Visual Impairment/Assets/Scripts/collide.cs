using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collide : MonoBehaviour
{
    public GameObject map;
    public GameObject sfx;
    public GameObject stranger1;
    public GameObject stranger2;
    public GameObject stranger3;
    public GameObject stranger4;
    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;
    public GameObject comment1;
    public GameObject comment2;
    public GameObject comment3;
    public GameObject comment4;

    public AudioClip bbib;
    public AudioClip BusCard;
    public AudioClip Car;
    public AudioClip City;
    public AudioClip Alert;

    private AudioSource MapAudioSource;
    private AudioSource spcAudioSource;


    private bool TF = true; // 버스 카드
    private bool TF1 = false; //ending
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        l1.SetActive(false);
        l2.SetActive(false);
        l3.SetActive(false);
        l4.SetActive(false);

        comment1.SetActive(false);
        comment2.SetActive(false);
        comment3.SetActive(false);
        comment4.SetActive(false);

        MapAudioSource = map.GetComponent<AudioSource>();
        spcAudioSource = sfx.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 7 && TF1)
        {
            SceneManager.LoadScene("End");
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "NPC")
        {
            if (col.gameObject == stranger1)
            {
                comment1.SetActive(true);
                l1.SetActive(true);
            }
            else if (col.gameObject == stranger2)
            {
                comment2.SetActive(true);
                l2.SetActive(true);
            }
            else if (col.gameObject == stranger3)
            {
                comment3.SetActive(true);
                l3.SetActive(true);
            }
            else if (col.gameObject == stranger4)
            {
                comment4.SetActive(true);
                l4.SetActive(true);
            }
        }
        else if (col.gameObject.tag == "Bus")
        {
            time = 0;
            spcAudioSource.Stop();
            MapAudioSource.Stop();
            
            spcAudioSource.PlayOneShot(Alert);
            TF1 = true;
        }
       

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "NPC")
        {
            if (col.gameObject == stranger1)
            {
                comment1.SetActive(true);
                l1.SetActive(true);
            }
            else if (col.gameObject == stranger2)
            {
                comment2.SetActive(true);
                l2.SetActive(true);
            }
            else if (col.gameObject == stranger3)
            {
                comment3.SetActive(true);
                l3.SetActive(true);
            }
            else if (col.gameObject == stranger4)
            {
                comment4.SetActive(true);
                l4.SetActive(true);
            }
        }
        else if (col.gameObject.tag == "Bus")
        { 
            //aduio
            SceneManager.LoadScene("End");
        }
       

    }
    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "NPC")
        {       
            if (col.gameObject == stranger1)
            {
                comment1.SetActive(false);
                l1.SetActive(false);
            }
            else if (col.gameObject == stranger2)
            {
                comment2.SetActive(false);
                l2.SetActive(false);
            }
            else if (col.gameObject == stranger3)
            {
                comment3.SetActive(false);
                l3.SetActive(false);
            }
            else if (col.gameObject == stranger4)
            {
                comment4.SetActive(false);
                l4.SetActive(false);
            }
        }
        else if(col.gameObject.tag == "Bus")
        {
            ;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "card" && TF)
        {
            spcAudioSource.PlayOneShot(BusCard);
            spcAudioSource.PlayOneShot(bbib);

            TF = false;
        }
        else if (col.gameObject.tag == "ignd")
        {
            MapAudioSource.PlayOneShot(City);
        }
    }
}
