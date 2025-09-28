using System;
using UnityEngine;


public class ScroreChecker : MonoBehaviour
{
    [SerializeField] private Rigidbody target;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var nameOfSide = other.gameObject.tag;
        var last = nameOfSide;
        if (target.linearVelocity.magnitude < 0.1f)
        {
            Debug.Log(last);
        }
        else
        {
            Debug.Log(last);
        }
    }
    
    
}
