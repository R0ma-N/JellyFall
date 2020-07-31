using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deform;

public class Control : MonoBehaviour
{
    [SerializeField] Camera controlCamera;
    [SerializeField] float yPos;

    Vector3 _mousePosition;
    Vector3 _scaleChange;
    Vector3 initPosition;
    public static int PartsCount;

    [SerializeField] Vector4 _rotation = new Vector4(0,0,0,0);
    [SerializeField] Transform _scaleObject;
    [SerializeField] GameObject _parts;

    private Animator animator;

    bool stop;

    void Start()
    {
        animator = GetComponent<Animator>();
        _scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
        _scaleObject = GetComponentInChildren<ScaleDeformer>().transform;
        initPosition = new Vector3(0, 0, yPos);
        PartsCount = 0;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Cursor.visible = false;
            _mousePosition = Input.mousePosition;
            _mousePosition.z = yPos;
            _mousePosition = controlCamera.ScreenToWorldPoint(_mousePosition);
            //Vector3 AllowPos = _mousePosition - initPosition;
            //AllowPos = Vector3.ClampMagnitude(AllowPos, 10);
            //transform.position = initPosition + AllowPos;
            //_mousePosition = Vector3.ClampMagnitude(Vector3.zero, 10);
            transform.position = Vector3.MoveTowards(transform.position, _mousePosition, 0.7f);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 5), transform.position.y, Mathf.Clamp(transform.position.z, -5, 5));
            //transform.position = Vector3.ClampMagnitude(transform.position, 10);
        }

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
            TearApart();
        }
    }

    private void TearApart()
    {
        animator.SetTrigger("FastBlink");
        Instantiate(_parts, transform.position, Quaternion.identity);
        _scaleObject.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        PartsCount = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            print("stop");
            stop = true;
        }
        if (collision.collider.CompareTag("Object"))
        {
            print("Donut!");
            TearApart();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            stop = false;
        }
    }

    public void MeetAPart()
    {
        PartsCount ++;
    }
}
