using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deform;

public class boom : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 0F);
        }

        MagnetDeformer[] magnets = GameObject.FindObjectsOfType<MagnetDeformer>();
        Transform target = FindObjectOfType<Control>().transform;

        foreach (var item in magnets)
        {
            item.Center = target;
        }

        Destroy(this.gameObject);
    }
}
