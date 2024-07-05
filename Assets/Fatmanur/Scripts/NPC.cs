using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    public Dialog dialog;
    public DialogManager dialogManager;
    public GameObject interactionButton;
    public float interactionDistance = 3f;
    private GameObject player;
    void Start()
    {
        interactionButton.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        dialogManager = FindObjectOfType<DialogManager>();
    }
    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance <= interactionDistance)
            {
                interactionButton.SetActive(true); // Butonu göster
            }
            else
            {
                interactionButton.SetActive(false); // Butonu gizle
            }
        }
    }
    public void OnMouseDown()
    {
        dialogManager.StartDialog(dialog);
    }
   
}
