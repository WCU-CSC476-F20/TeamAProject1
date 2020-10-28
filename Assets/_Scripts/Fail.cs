using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{
    static public bool failMet = false;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Ball"){
            Fail.failMet = true;
            
        }
    }

}
