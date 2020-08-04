using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public float speed = 4;
    public Vector3 rotation;
    public Transform _object;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        _object.transform.Rotate(rotation);
    }
}
