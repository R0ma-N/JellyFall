using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField] Vector3 _rotation;
    Collider collider;
    float timer, time;

    private void Start()
    {
        time = 0;
        timer = 1;
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (time <= timer)
        {
            time += Time.deltaTime;
        }

        print(time);
        transform.Rotate(_rotation);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    control.MeetAPart();
    //    Destroy(gameObject, 1f);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (time >= timer)
        {
            if (collision.collider.TryGetComponent<Control>(out Control target))
            {
                collider.enabled = false;
                target.MeetAPart();
                Destroy(gameObject, 0.3f);
            }
        }
        
    }
}
