using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform _object;
    private Vector3 _secondPosition;

    private void Start()
    {
        _secondPosition = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(_object, transform.position, Quaternion.identity);
            //_secondPosition.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            Instantiate(_object, transform.position + _secondPosition, Quaternion.identity);
        }
    }
}
