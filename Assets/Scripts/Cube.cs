using Deform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float force;
    public float shakeTime;
    private RadialSkewDeformer _shake;
    Rigidbody _rigidbody;
    float _timer;
    bool _isShaking;

    Vector3 _mousePosition;
    Vector3 direction;
    float moveSpeed = 100f;

    private void Start()
    {
        _shake = GetComponentInChildren<RadialSkewDeformer>();
        _rigidbody = GetComponent<Rigidbody>();
        //_rigidbody.AddForce(new Vector3(force,0,0), ForceMode.Impulse);
        _shake.update = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _timer = 0;
        _isShaking = true;
    }

    private void Update()
    {
        if (_isShaking)
        {
            Shake();
        }

        
        if (Input.GetMouseButtonDown(0))
        {
            _mousePosition = Input.mousePosition;
            _mousePosition.z = 5f;
            transform.position = Camera.main.ScreenToWorldPoint(_mousePosition);
        }
    }

    void Shake()
    {
        _timer += Time.deltaTime;
        if (_timer < shakeTime)
        {
            _shake.update = true;
        }
        else
        {
            _shake.update = false;
            _isShaking = false;
        }

    }
}
