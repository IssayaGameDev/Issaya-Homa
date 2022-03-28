using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartLevel(int level){
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
