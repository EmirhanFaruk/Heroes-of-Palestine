using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform oyuncuTransform;
    public Camera Kamera;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(oyuncuTransform.position, Kamera.transform.forward, Color.red);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Birinci if");
            RaycastHit hit;
            
            if (Physics.Raycast(oyuncuTransform.position, Kamera.transform.forward, out hit, 10000.0f))
            {
                Debug.Log("ikinci if");
                Debug.Log(hit.collider.name);
                // var a = hit.GetComponent<ScriptIsmi>();
                if (hit.collider.gameObject.CompareTag("Box"))
                {
                    Debug.Log("ucuncu if");
                    GameObject box = hit.collider.gameObject;
                    box.transform.SetParent(oyuncuTransform);
                    box.transform.localPosition = Vector3.zero;
                }
            }
        }
    }
}
