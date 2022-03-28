using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);

    }

    void StartLevel(){
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
