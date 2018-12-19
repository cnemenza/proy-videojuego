using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public AudioClip bombTimeSound;
    public AudioClip gameOverSound;
    public AudioSource audioSource;


    public GameObject UI_Pausa;
    public GameObject UI_GameOver;
    public Text labelTimeBom;

    public float timeBomb;
    public float timeTotal = 0;
    public Text labelCurrentTime;
    public Text labelBestTime;

    private bool isRed = false;
    
    void Start()
    {
        Time.timeScale = 1;
    }
    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void ResetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        UI_Pausa.SetActive(false);
    }

    public void lessTime()
    {
        if (timeBomb>=0)
        {
            timeBomb -= Time.deltaTime;
            RefreshLabel();
            if (timeBomb<=6)
            {
                //Verificar si es mas de 6 antes de entrar al if
                if (!isRed)
                {
                    isRed = true;
                    labelTimeBom.color = Color.red;
                    audioSource.clip = bombTimeSound;
                    audioSource.Play();                
                }
            }
        }
        else
        {
                labelTimeBom.text = "Time : 0";
                audioSource.clip = gameOverSound;
                audioSource.Play();
                Time.timeScale = 0;
                UI_GameOver.SetActive(true);
        }
        
    }

    public void RefreshLabel()
    {
        labelTimeBom.text = "Time : " + Mathf.FloorToInt(timeBomb).ToString();
    }

    public void Update()
    {
        lessTime();
        ObtenerPuntaje();
        
    }

    public void addTime(int variable)
    {
        timeBomb += variable;
        RefreshLabel();
        if (timeBomb >= 6)
        {
            isRed = false;
            labelTimeBom.color = Color.black;
            audioSource.Stop();
        }
    }

    public void ObtenerPuntaje(){
        timeTotal += Time.deltaTime;
        string currentTime = getFormart(timeTotal);
        labelCurrentTime.text = currentTime;
        float maxScore = GetMaxScore();
        labelBestTime.text = getFormart(maxScore);
        if(UI_GameOver.activeInHierarchy){
            if(timeTotal>=maxScore){
                SavedScore(timeTotal);
            }
        }

    }


    public string getFormart(float tiempo){
        int minutes = Mathf.FloorToInt(tiempo / 60F);
        int seconds = Mathf.FloorToInt(tiempo - minutes * 60);
        string currentTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        return currentTime;
    }

    
    public void SavedScore(float score){
        PlayerPrefs.SetFloat("Max Points", score);
        PlayerPrefs.Save();
    }

    public  float GetMaxScore(){
        return PlayerPrefs.GetFloat("Max Points", 0);
    }

}
