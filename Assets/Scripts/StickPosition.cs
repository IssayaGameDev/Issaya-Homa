using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPosition : MonoBehaviour
{
    [SerializeField] Transform stickPosition;
    [SerializeField] Transform stickRotation;


    void Update()
    {
        transform.position = stickPosition.position;
       // transform.rotation = stickRotation.rotation;
    }
}
