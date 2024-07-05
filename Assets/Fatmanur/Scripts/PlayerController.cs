using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket h�z�

    void Update()
    {
        MovePlayer(); // Oyuncu hareket fonksiyonu
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Sa�a/sola hareket i�in input de�eri
        float moveVertical = Input.GetAxis("Vertical"); // �leri/geri hareket i�in input de�eri

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed * Time.deltaTime; // Hareket vekt�r�

        transform.Translate(movement, Space.Self); // Hareketi uygula (yerel koordinatlarla)

        // Karakterin y�n�n� hareket y�n�ne �evir (sadece yatay eksen)
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}
