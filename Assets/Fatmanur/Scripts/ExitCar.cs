using UnityEngine;

public class ExitCar : MonoBehaviour
{
    public Transform exitPosition; // Arabadan çýkýþ pozisyonu

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // G tuþuna basarak arabadan in
        {
            DriveCar driveCarScript = GetComponent<DriveCar>();
        }
    }
}