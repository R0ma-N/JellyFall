using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField] Vector3 _rotation;
    private Collider _collider;
    private Animator _animator;
    float timer, time;

    private void Start()
    {
        time = 0;
        timer = 1;
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (time <= timer)
        {
            time += Time.deltaTime;
        }

        transform.Rotate(_rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (time >= timer)
        {
            if (collision.collider.TryGetComponent<Control>(out Control target))
            {
                _collider.enabled = false;
                target.MeetAPart();
                Destroy(gameObject, 0.3f);
            }
        }

        if (collision.collider.CompareTag("Wall"))
        {
            _animator.SetTrigger("Blow");
        }
    }
}
