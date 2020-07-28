using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deform;

public class Control : MonoBehaviour
{
    Vector3 _mousePosition;
    Vector3 _scaleChange;
    public static int PartsCount;

    [SerializeField] Vector4 _rotation = new Vector4(0,0,0,0);
    [SerializeField] Transform _scaleObject;
    [SerializeField] GameObject _parts;

    float _currentScale = 25;


    void Start()
    {
        _scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
        _scaleObject = GetComponentInChildren<ScaleDeformer>().transform;
        PartsCount = 0;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePosition = Input.mousePosition;
            _mousePosition.z = 20f;
            transform.position = Camera.main.ScreenToWorldPoint(_mousePosition);
        }
        //print(_partsCount);

        transform.Rotate(_rotation);

        if (PartsCount == 1 && _scaleObject.localScale.x <= 0.7)
        {
            _scaleObject.localScale += _scaleChange;
        }

        if (PartsCount == 2 && _scaleObject.localScale.x < 0.8)
        {
            _scaleObject.localScale += _scaleChange;
        }

        if (PartsCount == 3 && _scaleObject.localScale.x < 0.9)
        {
            _scaleObject.localScale += _scaleChange;
        }

        if (PartsCount == 4 && _scaleObject.localScale.x < 1)
        {
            _scaleObject.localScale += _scaleChange;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_parts, transform.position, Quaternion.identity);
           
        }
    }

    public void MeetAPart()
    {
        PartsCount ++;
    }
}
