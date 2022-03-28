using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
    {
        Stopped,
        Grounded,
        Flying,
        Dead,
        Win
    }
public class CharacterController : MonoBehaviour
{
    [SerializeField] float xSpeed,zSpeed,sensitivity,groundSize,meltAmmount,hotMeltMult,pickUpSize,tiltMult;
    [SerializeField] TrailController trailController;
    [SerializeField] Transform stick;
    Tweener_Scale stickScale;
    [SerializeField]ParticleSystem burnParticles;

    public CharacterState characterState = CharacterState.Flying;
    Vector3 velocity,downPosition;
    Rigidbody rb;   

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stickScale = stick.GetComponent<Tweener_Scale>();
        StartCoroutine(LerpSize(-0.25f,0));

    }

    private void OnTriggerEnter(Collider other) {
        if(characterState != CharacterState.Dead ){
            if(other.gameObject.CompareTag("Hot")){
                    meltAmmount *=hotMeltMult;
                    if(characterState != CharacterState.Dead){
                        burnParticles.Play();
                    }
            }
            else if(other.gameObject.CompareTag("Pickable")){
                    Destroy(other.gameObject);
                    GameManager.Instance.Score++;
                    StartCoroutine(LerpSize(stick.localScale.y+pickUpSize,.1f));
            }
            else if(other.gameObject.CompareTag("End")){
                    characterState = CharacterState.Win;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(characterState != CharacterState.Dead){
            if(other.gameObject.CompareTag("Hot")){
                    meltAmmount /=hotMeltMult;
                    burnParticles.Stop();
            }
            
        }
    }

    private void OnCollisionEnter(Collision other) {

        if(characterState != CharacterState.Dead&&characterState != CharacterState.Win){

            if(other.gameObject.CompareTag("Ground")){
                characterState = CharacterState.Grounded;
                trailController.StartTrail();
            } 
        }
    }

    private void Movement(){
        velocity = rb.velocity;
        if(Input.GetMouseButton(0)&& characterState != CharacterState.Win ){
            velocity.x = (Mathf.Clamp((Input.mousePosition.x -Screen.width/2 )/Screen.width*2,-1/sensitivity,1/sensitivity)*sensitivity - rb.position.x/(groundSize/2))*xSpeed;
        }

        if(Input.GetMouseButtonUp(0)){
                velocity.x = 0;
        }

        if(characterState != CharacterState.Stopped ){
            velocity.z =zSpeed;
        }



        transform.eulerAngles = new Vector3(0,0,-rb.position.x*tiltMult);

        rb.velocity = velocity;
    }

    IEnumerator LerpSize(float endValue, float duration)
    {
        float time = 0;
        float startValue =  stick.localScale.y;
        if(duration>0){
            while (time < duration)
            {
            stick.localScale = new Vector3(stick.localScale.x,Mathf.Lerp(startValue,endValue,time/duration),stick.localScale.z);
            time += Time.deltaTime;
            yield return null;
            }
        }

        else{
            while (  stick.localScale.y != endValue)
            {
                stick.localScale = new Vector3(stick.localScale.x,Mathf.Lerp(  stick.localScale.y,endValue,meltAmmount),stick.localScale.z);
                time += Time.deltaTime;
                yield return null;
            }
        }
        
    }


    void Die(){
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        burnParticles.Stop();
        Destroy(trailController.gameObject);
        if(characterState == CharacterState.Win){
           StartCoroutine(GameManager.Instance.LevelManager(next: true));
        }
        else{
            StartCoroutine(GameManager.Instance.LevelManager(restart: true));
        }
                characterState = CharacterState.Dead;


    }
    
    private void FixedUpdate() {
        if(characterState != CharacterState.Dead){
            Movement(); 

            if(stick.localScale.y <-.20f || transform.position.y <0 && characterState != CharacterState.Win){
                Die();
            }
        }
    }
   
}
