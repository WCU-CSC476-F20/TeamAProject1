using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCam : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject myCamera;
    [Header("Set Dynamically")]
    public GameObject theBall;
    public Vector3 ballPos;
    void Awake(){
        Invoke("GetBall", 5);
    }
    void GetBall(){
        theBall = GameObject.FindGameObjectWithTag("Ball");
        ballPos = theBall.transform.position;
    }
    void Update(){
        if(ballPos != null){
            myCamera.transform.position = ballPos + new Vector3(0,10,0);
            GetBall();
        }else{
            Invoke("GetBall",5);
        }
    }

}
