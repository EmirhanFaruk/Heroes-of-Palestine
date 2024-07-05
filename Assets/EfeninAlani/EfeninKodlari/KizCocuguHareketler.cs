using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KizCocuguHareketler : MonoBehaviour
{
    public Animator animatorum;
    public Transform t1, t2, t3, cocukTransform;
    public float hareketHizi = 1.0f;
    public bool hareket = false;
    public float threshold = 0.1f; // Pozisyonlarýn eþit olup olmadýðýný kontrol etmek için eþik deðeri
    private int currentTargetIndex = 0; // Þu anki hedefi takip eden indeks
    public float sayac;

    private void Update()
    {
        if (hareket)
        {
            
            sayac -= Time.deltaTime;
            if(sayac < 0)
            {
                AnimasyonHareket();
                animatorum.SetBool("komut", true);
            }
        }
    }

    private void AnimasyonHareket()
    {
        Transform currentTarget = GetCurrentTarget();

        if (currentTarget != null && Vector3.Distance(cocukTransform.position, currentTarget.position) > threshold)
        {
            cocukTransform.position = Vector3.MoveTowards(cocukTransform.position, currentTarget.position, hareketHizi * Time.deltaTime);

            // Hedefe ulaþýldýðýnda, bir sonraki hedefe geç
            if (Vector3.Distance(cocukTransform.position, currentTarget.position) <= threshold)
            {
                currentTargetIndex++;
            }
        }
    }

    // Þu anki hedefi döndüren yardýmcý fonksiyon
    private Transform GetCurrentTarget()
    {
        switch (currentTargetIndex)
        {
            case 0:
                return t1;
            case 1:
                return t2;
            case 2:
                return t3;
            default:
                return null; // Tüm hedeflere ulaþýldýðýnda null döner
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kizCocugu"))
        {
            hareket = true;
            
            if (sayac < 0)
            {
                
                
            }
            currentTargetIndex = 0; // Hedef dizinini sýfýrla

        }
    }
}
