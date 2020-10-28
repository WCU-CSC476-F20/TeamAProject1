using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Ball"){
            Goal.goalMet = true;
            
        }
    }

}
