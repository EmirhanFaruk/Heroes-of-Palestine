using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Dialog dialog;
    private DialogManager dialogManager;
    public GameObject interactionButton; // Buton referansý
    public float interactionDistance = 3f; // NPC'ye yaklaþma mesafesi
    private Transform player; // Oyuncu referansý

    void Start()
    {
        // Oyuncuyu tag ile buluyoruz
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // DialogManager'ý buluyoruz
        dialogManager = FindObjectOfType<DialogManager>();
    }

    void Update()
    {
        // Oyuncu ile NPC arasýndaki mesafeyi hesaplýyoruz
        float distance = Vector3.Distance(player.position, transform.position);

        // Eðer mesafe belirlenen mesafeden küçükse butonu gösteriyoruz
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
        // Butona týklanýldýðýnda dialog baþlatýlýyor
        dialogManager.StartDialog(dialog);
    }
}
