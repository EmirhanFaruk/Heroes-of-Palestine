using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoSistemi : MonoBehaviour
{

    public Camera Kamera;

    public float kameraYakinlikLimiti = 10.0f;



    public LayerMask islenecekMaske;

    public List<List<string>> uygulanacakTagler = new List<List<string>>();

    [SerializeField]
    public List<string> ilkGorev = new List<string>();
    public List<string> ikinciGorev = new List<string>();
    public List<string> ucuncuGorev = new List<string>();



    // Start is called before the first frame update
    void Start()
    {
        // 3 gorev icin 3 tane "fotograf gereksinimi"
        uygulanacakTagler.Add(ilkGorev);
        uygulanacakTagler.Add (ikinciGorev);
        uygulanacakTagler.Add(ucuncuGorev);


        // Ilk gorev: Cocuga su vermek.
        uygulanacakTagler[0].Add("Cocuk");
        uygulanacakTagler[0].Add("Su");


        // Ikinci gorev: Bomba sonrasi enkaz.
        uygulanacakTagler[1].Add("Enkaz");


        // Ucuncu gorev: Yardim edilen insanlar.
        uygulanacakTagler[2].Add("Anne");
        uygulanacakTagler[2].Add("Baba");
        uygulanacakTagler[2].Add("Cocuk");
    }


    bool IsinUlasti(string tag)
    {
        Vector3 kameraMerkezi = Kamera.transform.position;

        Collider[] colliderlar = Physics.OverlapSphere(kameraMerkezi, kameraYakinlikLimiti, islenecekMaske);


        foreach (Collider obje in colliderlar)
        {
            // TODO: Handle this lmao
        }

        return true;
    }

    bool GorevKontrol(int gorevNum)
    {
        foreach (string tag in uygulanacakTagler[gorevNum])
        {
            if (!IsinUlasti(tag))
            {
                return false;
            }
        }


        return true;
    }







    // Update is called once per frame
    void Update()
    {
        
    }
}
