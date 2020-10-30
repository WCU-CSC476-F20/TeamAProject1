using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            if(gameObject.transform.rotation.eulerAngles.x > 330 || gameObject.transform.rotation.eulerAngles.x <= 31){
                transform.Rotate(-speed,0,0);
            }
        }
        if(Input.GetKey(KeyCode.D)){
            if(gameObject.transform.rotation.eulerAngles.x < 30 || gameObject.transform.rotation.eulerAngles.x >= 329){
                transform.Rotate(speed,0,0);
            }
        }
        if(Input.GetKey(KeyCode.W)){
            if(gameObject.transform.rotation.eulerAngles.z < 30 || gameObject.transform.rotation.eulerAngles.z >= 329){
                transform.Rotate(0,0,speed);
            }
        }
        if(Input.GetKey(KeyCode.S)){
            if(gameObject.transform.rotation.eulerAngles.z > 330 || gameObject.transform.rotation.eulerAngles.z <= 31){
                transform.Rotate(0,0,-speed);
            }
        }
/*        if(!Input.anyKey){
            if(gameObject.transform.rotation.eulerAngles.x > 50){
                if(gameObject.transform.rotation.eulerAngles.x != 0){
                    transform.Rotate(.2f,0,0);
                }
            }
            if(gameObject.transform.rotation.eulerAngles.x < 50){
                if(gameObject.transform.rotation.eulerAngles.x != 0){
                    transform.Rotate(-.2f,0,0);
                }
            }
            if(gameObject.transform.rotation.eulerAngles.z > 50){
                if(gameObject.transform.rotation.eulerAngles.z != 0){
                    transform.Rotate(0,0,.2f);
                }
            }
            if(gameObject.transform.rotation.eulerAngles.z < 50){
                if(gameObject.transform.rotation.eulerAngles.z != 0){
                    transform.Rotate(0,0,-.2f);
                }
            }
        }*/
        
    }
}
