using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoSistemi : MonoBehaviour
{

    public Camera kamera;

    public float kameraYakinlikLimiti = 8.5f;



    public LayerMask islenecekMaske;

    public List<List<string>> uygulanacakIsimler = new List<List<string>>();

    [SerializeField]
    public List<string> ilkGorev = new List<string>();
    public List<string> ikinciGorev = new List<string>();
    public List<string> ucuncuGorev = new List<string>();


    public int gorevNumarasi = 0;



    // Start is called before the first frame update
    /**
     * Gorev taglerinin eklendigi yer.
     */
    void Start()
    {
        // 3 gorev icin 3 tane "fotograf gereksinimi"
        uygulanacakIsimler.Add(ilkGorev);
        uygulanacakIsimler.Add (ikinciGorev);
        uygulanacakIsimler.Add(ucuncuGorev);
        


        // Ilk gorev: Cocuga su vermek.
        uygulanacakIsimler[0].Add("Cocuk");


        // Ikinci gorev: Bomba sonrasi enkaz.
        uygulanacakIsimler[1].Add("Enkaz");


        // Ucuncu gorev: Yardim edilen insan.
        uygulanacakIsimler[2].Add("Kadin");
    }


    /**
     * Verilen obje ekranda mi diye kontrol eder.
     * 
     */
    bool KareninIcinde(Transform obje)
    {
        Vector3 viewportPoint = kamera.WorldToViewportPoint(obje.position);
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 &&
               viewportPoint.y >= 0 && viewportPoint.y <= 1 &&
               viewportPoint.z > 0;
    }


    /**
     * Isin istenen yere ulasti mi diye kontrol eder.
     * 
     */
    bool IsinUlasti(BoxCollider kutuCollider)
    {

        if (kutuCollider != null)
        {
            Ray isin = new Ray(kamera.transform.position, kutuCollider.bounds.center - kamera.transform.position);
            RaycastHit sonuc;

            if (Physics.Raycast(isin, out sonuc))
            {
                if (sonuc.collider == kutuCollider)
                {
                    return true;
                }
            }
        }

        return false;
    }


    /**
     * Verilen tag'e gore objeleri KareninIcinde ve IsinUlasti fonksiyonundan gecirir.
     * Eger bir obje bu fonksiyonlardan gecerse true degerini gonderir.
     * 
     */
    bool ObjeKontrol(string objeIsmi)
    {
        Vector3 kameraMerkezi = kamera.transform.position;

        Collider[] colliderlar = Physics.OverlapSphere(kameraMerkezi, kameraYakinlikLimiti, islenecekMaske);


        foreach (Collider collider in colliderlar)
        {
            GameObject obje = collider.gameObject;

            if (obje.name == objeIsmi)
            {
                BoxCollider kutuCollider = obje.GetComponent<BoxCollider>();

                if (KareninIcinde(kutuCollider.transform) && IsinUlasti(kutuCollider))
                {
                    return true;
                }
            }
        }

        return false;
    }


    /**
     * Verilen gorev numarasina gore cekilen fotografta istenenler var mi diye kontrol eder.
     * 
     */
    bool GorevKontrol(int gorevNum)
    {
        foreach (string isim in uygulanacakIsimler[gorevNum])
        {
            if (!ObjeKontrol(isim))
            {
                return false;
            }
        }


        return true;
    }


    /**
     * Fotograf cekme fonksiyonu.
     * 
     */
    bool FotoCek()
    {
        bool sonuc = GorevKontrol(gorevNumarasi);
        if (sonuc)
        {
            gorevNumarasi++;
        }
        return sonuc;
    }
}
