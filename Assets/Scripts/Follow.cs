using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deform;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float time;
    [SerializeField] SquashAndStretchDeformer deformer;

    void Start()
    {
        deformer = GameObject.FindObjectOfType<SquashAndStretchDeformer>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, time);
        transform.LookAt(target);
        
        if (Vector3.Distance(target.position, transform.position) <= 0.2)
        {
            deformer.Factor = 0;
        }
        else
        {
            deformer.Factor = 0.2f;
        }
    }
}
