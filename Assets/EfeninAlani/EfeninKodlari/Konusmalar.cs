using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Konusmalar : MonoBehaviour
{
    public GameObject g1, g2, g3, g4, g5;
    //public GameObject cocuk, yolSonu, saglikKutulari, tesekkur;
    public Animator anim;
    private void Start()
    {
        g1.SetActive(true);
        g2.SetActive(false);
        g3.SetActive(false);
        g4.SetActive(false);
        g5.SetActive(false);
        anim.enabled = false;
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cocuk"))
        {
            g1.SetActive(false);
            g2.SetActive(true);
        }
        if (other.CompareTag("yolSonu"))
        {
            g2.SetActive(false);
            g3.SetActive(true);
        }
        if (other.CompareTag("SaglikKutulari"))
        {
            g3.SetActive(false);
            g4.SetActive(true);
            anim.enabled = true;
        }
        
    }
}
