using UnityEngine;

public class ExitCar : MonoBehaviour
{
    public Transform exitPosition; // Arabadan ��k�� pozisyonu

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // G tu�una basarak arabadan in
        {
            DriveCar driveCarScript = GetComponent<DriveCar>();
        }
    }
}