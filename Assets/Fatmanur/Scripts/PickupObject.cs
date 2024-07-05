using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform handPos;
    public GameObject box = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && box == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
            {
                if (hit.collider.gameObject.CompareTag("Box"))
                {
                    box = hit.collider.gameObject;
                    box.transform.SetParent(handPos);
                    box.transform.localPosition = Vector3.zero;
                }
            }
        }
        else if (box != null) // box deðiþkeni null deðilse
        {
            box.transform.SetParent(null);
            box = null;
        }
    }
}
