using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Dialog dialog;
    private DialogManager dialogManager;
    public GameObject interactionButton; // Buton referans�
    public float interactionDistance = 3f; // NPC'ye yakla�ma mesafesi
    private Transform player; // Oyuncu referans�

    void Start()
    {
        // Oyuncuyu tag ile buluyoruz
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // DialogManager'� buluyoruz
        dialogManager = FindObjectOfType<DialogManager>();
    }

    void Update()
    {
        // Oyuncu ile NPC aras�ndaki mesafeyi hesapl�yoruz
        float distance = Vector3.Distance(player.position, transform.position);

        // E�er mesafe belirlenen mesafeden k���kse butonu g�steriyoruz
        if (distance < interactionDistance)
        {
            interactionButton.SetActive(true);
        }
        else
        {
            // Mesafe fazla ise butonu gizliyoruz
            interactionButton.SetActive(false);
        }
    }

    public void OnInteractionButtonClicked()
    {
        // Butona t�klan�ld���nda dialog ba�lat�l�yor
        dialogManager.StartDialog(dialog);
    }
}
