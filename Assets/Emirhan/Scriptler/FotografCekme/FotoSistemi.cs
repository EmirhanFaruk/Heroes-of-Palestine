using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoSistemi : MonoBehaviour
{

    public Camera kamera;

    public float kameraYakinlikLimiti = 10.0f;



    public LayerMask islenecekMaske;

    public List<List<string>> uygulanacakTagler = new List<List<string>>();

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
    bool IsinUlasti(Transform bas)
    {
        if (bas != null)
        {
            Ray isin = new Ray(kamera.transform.position, bas.position - kamera.transform.position);
            RaycastHit sonuc;

            if (Physics.Raycast(isin, out sonuc))
            {
                if (sonuc.transform == bas)
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
    bool ObjeKontrol(string tag)
    {
        Vector3 kameraMerkezi = kamera.transform.position;

        Collider[] colliderlar = Physics.OverlapSphere(kameraMerkezi, kameraYakinlikLimiti, islenecekMaske);


        foreach (Collider collider in colliderlar)
        {
            GameObject obje = collider.gameObject;

            if (obje.CompareTag(tag))
            {
                Transform objeninBasi = obje.transform.Find("mixamorig:Head");

                if (KareninIcinde(objeninBasi) && IsinUlasti(objeninBasi))
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
        foreach (string tag in uygulanacakTagler[gorevNum])
        {
            if (!ObjeKontrol(tag))
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
        return GorevKontrol(gorevNumarasi);
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            bool sonuc = FotoCek();
            Debug.Log(sonuc);
        }
    }
}
