using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Labryinth : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject ballPrefab;
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject[] boards;
    [Header("Set Dynamically")]
    public int level;
    public int levelMax;
    public int lives;
    public int[] highScores;
    public int[] times;
    public GameObject board;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        levelMax = boards.Length;
        lives = 3;
        highScores = new int[levelMax];
        times = new int[levelMax];
        StartLevel();
    }
    void StartLevel(){
        if(Fail.failMet == true){
            lives--;
        }
        Goal.goalMet = false;
        Fail.failMet = false;
        winUI.SetActive(false);
        loseUI.SetActive(false);
        if(board != null){
            Destroy(board);
        }
        board = Instantiate<GameObject>(boards[level]);
        if(gameObject.transform.rotation.eulerAngles.z != 0){
            transform.Rotate(0,0,-.2f);
        }
        GameObject tBall = Instantiate<GameObject>(ballPrefab);
    }
    public void ResetLevel(){
        StartLevel();
    }
    public void NextLevel(){
        level++;
        if(level == levelMax){
            SceneManager.LoadScene("GameOver");
        }else{
            StartLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Goal.goalMet == true){
            //SceneManager.LoadScene("Level"+level);
            print("hit goal hole");
            winUI.SetActive(true);
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Ball");
            foreach(GameObject pTemp in gos){
                Destroy(pTemp);
            }
        }
        if(Fail.failMet == true){
            if(lives == 0){
                SceneManager.LoadScene("GameOver");
            }
            print("hit a fail hole");
            loseUI.SetActive(true);
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Ball");
            foreach(GameObject pTemp in gos){
                Destroy(pTemp);
            }
        }
    }
}
