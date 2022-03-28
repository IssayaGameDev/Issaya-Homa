using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] Vector3 offset,sideOffset,velocity ;

    private void FixedUpdate() {
         if(GameManager.Instance.player.characterState == CharacterState.Dead || GameManager.Instance.player.characterState == CharacterState.Win ){
            transform.position =  Vector3.SmoothDamp(transform.position, (target.position) + offset + sideOffset,ref velocity,speed);
            transform.LookAt(target.position);
        }
        else{
            transform.position =  Vector3.SmoothDamp(transform.position, (target.position) + offset,ref velocity,speed);
        }
    }

}
