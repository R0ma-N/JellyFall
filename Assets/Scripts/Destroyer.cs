using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Destroy");
        if (other.CompareTag("Object"))
        {
            Destroy(other.GetComponentInParent<Donut>().gameObject);
        }
    }
}
