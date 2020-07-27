using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Vector3 _mousePosition;
    Vector3 _scaleChange;
    public static int PartsCount;

    [SerializeField] Vector4 _rotation = new Vector4(0,0,0,0);
    [SerializeField] Transform other;

    float _currentScale = 25;

    void Start()
    {
        _scaleChange = new Vector3(0.3f, 0.3f, 0.3f);
        PartsCount = 0;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePosition = Input.mousePosition;
            _mousePosition.z = 10f;
            transform.position = Camera.main.ScreenToWorldPoint(_mousePosition);
        }
        //print(_partsCount);

        transform.Rotate(_rotation);

        if (PartsCount == 1 && transform.localScale.x <= _currentScale + 13.75)
        {
            transform.localScale += _scaleChange;
        }

        if (PartsCount == 2 && transform.localScale.x < _currentScale + 13.75 + 13.75)
        {
            transform.localScale += _scaleChange;
        }

        if (PartsCount == 3 && transform.localScale.x < _currentScale + 13.75 + 13.75 + 13.75)
        {
            transform.localScale += _scaleChange;
        }

        if (PartsCount == 4 && transform.localScale.x < _currentScale + 13.75 + 13.75 + 13.75 + 13.75)
        {
            transform.localScale += _scaleChange;
        }
    }

    public void MeetAPart()
    {
        PartsCount ++;
    }
}
