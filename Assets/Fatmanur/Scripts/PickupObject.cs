using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform oyuncuTransform;
    public Camera Kamera;
    public GameObject alinanKutu = null;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(oyuncuTransform.position, Kamera.transform.forward, Color.red);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (alinanKutu == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(oyuncuTransform.position, Kamera.transform.forward, out hit, 100.0f))
                {
                    Debug.Log(hit.collider.name);
                    if (hit.collider.gameObject.CompareTag("Box"))
                    {
                        GameObject box = hit.collider.gameObject;
                        Renderer renderer = box.GetComponent<Renderer>();
                        renderer.enabled = false;
                        box.transform.SetParent(oyuncuTransform);
                        box.transform.localPosition = Vector3.zero;
                        alinanKutu = box;
                    }
                }
            }
            else
            {
                Renderer renderer = alinanKutu.GetComponent<Renderer>();
                renderer.enabled = true;
                alinanKutu.transform.SetParent(null);
                alinanKutu = null;
            }
        }
    }
}
