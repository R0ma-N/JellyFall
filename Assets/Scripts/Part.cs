using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField] Vector3 _rotation;
    Control control;

    private void Start()
    {
        control = GameObject.FindObjectOfType<Control>();
    }

    private void Update()
    {
        //transform.Rotate(_rotation);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    control.MeetAPart();
    //    Destroy(gameObject, 1f);
    //}
}
