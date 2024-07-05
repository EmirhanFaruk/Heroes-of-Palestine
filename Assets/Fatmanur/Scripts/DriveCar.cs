using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    public GameObject player;
    public Transform driverSeat;
    public bool isDriving = false;
    public Camera Kamera;
   

    void Start()
    {
        if (Kamera != null)
        {
            Kamera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(transform.position, player.transform.position) < 10.0f) 
        {
            if (!isDriving)
            {
                player.transform.SetParent(driverSeat);
                player.transform.localPosition = Vector3.zero;
                player.SetActive(false);
                isDriving = true;
                Kamera.enabled = true;
            }
            else 
            {
                player.transform.SetParent(null);
                player.SetActive(true); 
                isDriving = false;
                Kamera.enabled = false;
            }
        }
        if (isDriving) 
        {
            float move = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;
            float turn = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f;

            transform.Translate(0, 0, move);
            transform.Rotate(0, turn, 0);

        }
    }
}
