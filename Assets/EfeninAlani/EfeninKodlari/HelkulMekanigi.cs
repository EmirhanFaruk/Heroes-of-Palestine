using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelkulMekanigi : MonoBehaviour
{
    public Transform tasTransform , tasHedefi;
    private float gecis;
    private void Update()
    {
        Ray isin = new Ray(transform.position, transform.forward);
        RaycastHit temas;
        if(Physics.Raycast(isin, out temas, 5f))
        {
            if(temas.collider.gameObject.name == "Retopo_Cube.119_cell.003")
            {
                gecis += Time.deltaTime;
                float Razor = gecis / 5;
                tasTransform.position = Vector3.Lerp(tasTransform.position, tasHedefi.position, Razor * Time.deltaTime);
                tasTransform.rotation = Quaternion.Slerp(tasTransform.rotation, tasHedefi.rotation, Razor * Time.deltaTime);
            }
        }
        Debug.DrawRay(transform.position, transform.forward, Color.red);


    }

    private void isinTemasi()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
