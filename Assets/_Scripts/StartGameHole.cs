using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartGameHole : MonoBehaviour
{
    void Update()
    {
        if(Goal.goalMet == true){
            SceneManager.LoadScene("Scene_0_");
            
            }
        
    }
}
