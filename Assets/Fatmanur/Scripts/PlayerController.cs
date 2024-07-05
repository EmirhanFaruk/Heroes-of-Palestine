using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket hýzý

    void Update()
    {
        MovePlayer(); // Oyuncu hareket fonksiyonu
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Saða/sola hareket için input deðeri
        float moveVertical = Input.GetAxis("Vertical"); // Ýleri/geri hareket için input deðeri

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed * Time.deltaTime; // Hareket vektörü

        transform.Translate(movement, Space.Self); // Hareketi uygula (yerel koordinatlarla)

        // Karakterin yönünü hareket yönüne çevir (sadece yatay eksen)
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}
