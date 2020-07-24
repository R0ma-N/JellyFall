using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Vector3 _mousePosition;
    [SerializeField] Vector3 _rotation;

    void Start()
    {
        //_rotation = new Vector3(1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePosition = Input.mousePosition;
            _mousePosition.z = 10f;
            transform.position = Camera.main.ScreenToWorldPoint(_mousePosition);
        }

        transform.Rotate(_rotation);
    }
}
