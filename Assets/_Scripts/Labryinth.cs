using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Labryinth : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Text uitLevel;
    public Text uitLives;
    public Text uitBestTime;
    public Text uitTimer;
    public Text uitHighLevel;
    public GameObject ballPrefab;
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject[] boards;
    [Header("Set Dynamically")]
    public int level;
    public int levelMax;
    public int lives;
    public int highScore;
    public float[] times;
    public GameObject board;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        levelMax = boards.Length;
        lives = 3;
        times = new float[levelMax];
        if(PlayerPrefs.HasKey("HighScore")){
            highScore = PlayerPrefs.GetInt("HighScore");
        }else{
            highScore = 1;
        }
        StartLevel();
    }
    void StartLevel(){
        Time.timeScale = 1f;
        timer = 0;
        if(Fail.failMet == true){
            lives--;
        }
        if((level+1) > highScore){
            PlayerPrefs.SetInt("HighScore", level+1);
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        if(PlayerPrefs.HasKey("BestTime"+level)){
            times[level] = PlayerPrefs.GetFloat("BestTime"+level);
        }else{
            times[level] = 60.00f;
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
        UpdateGUI();
        //GameObject tBall = Instantiate<GameObject>(ballPrefab);
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
    void UpdateGUI(){
        uitLevel.text = "Level: " +(level+1)+" of " + levelMax;
        uitLives.text = "Lives Left: " + lives;
        uitHighLevel.text = "Highest level reached: " + highScore;
        uitBestTime.text = times[level].ToString("F2");
        //uitTimer.text = "Time: " + timer;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        uitTimer.text = timer.ToString("F2");
        UpdateGUI();
        if(Goal.goalMet == true){
            Time.timeScale = 0.0f;
            if(timer < times[level]){
                PlayerPrefs.SetFloat("BestTime"+level, timer);
            }
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
