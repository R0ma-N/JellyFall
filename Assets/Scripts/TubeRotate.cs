using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeRotate : MonoBehaviour
{
    public float speedRotation;

    void Update()
    {
        transform.Rotate(Vector3.forward, speedRotation);
    }
}
