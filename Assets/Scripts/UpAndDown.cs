using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    [SerializeField] Vector3 ammount;
    Tweener_Position tweener;

    void Start()
    {
        tweener = GetComponent<Tweener_Position>();
        tweener.m_States[1].m_Position = new Vector3(transform.localPosition.x + ammount.x,transform.localPosition.y + ammount.y,transform.localPosition.z+  ammount.z);
    }


}
