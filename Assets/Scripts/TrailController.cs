using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    [SerializeField]Transform trail;
    [SerializeField]GameObject trailPrefab;
    Vector3 position;

   
    public void StartTrail(){
        trail.gameObject.SetActive(true);
    }

    public void DropTrail(){
        trail = Instantiate(trailPrefab,transform.position,trailPrefab.transform.rotation).transform;
        trail.gameObject.SetActive(false);
    }
    RaycastHit hit;
    void Update()
    {
       position.Set(transform.position.x,0.6f,transform.position.z);
        trail.position = position; 

    }
}
