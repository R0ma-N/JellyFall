using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _object;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(_object, transform.position, Quaternion.identity);
        }
    }
}
