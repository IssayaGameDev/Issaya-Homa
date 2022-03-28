using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CharacterController player;
    public static GameManager Instance { get; private set; }

    [SerializeField] Text scoreText;
    public int score;
   public int Score
    {
        get { return score; }
        set
        {   
            score = value;   
            ReflectValue(score);   
        }
    }

    void ReflectValue(int value){
        scoreText.text = value.ToString();
    }
    public IEnumerator LevelManager(bool restart = false,bool next = false,int level = 0){                                    
                                        Debug.Log(next); 

        yield return new WaitForSeconds(3);
        if(next){
                                        Debug.Log(SceneManager.GetActiveScene().buildIndex+1); 

                if(SceneManager.GetActiveScene().buildIndex+1 <3){

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single);
                }
                
                else if(level<3){
                    SceneManager.LoadScene(level, LoadSceneMode.Single);
                }
        }
        else if(restart){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
         
        yield break;
    }

    void Awake()
     {
                                                 Debug.Log(SceneManager.GetActiveScene().buildIndex+1); 

         if (Instance != null && Instance != this)
             Destroy(gameObject);
         Instance = this;
     }

}
