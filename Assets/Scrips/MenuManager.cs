using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour {

    Text lblMaxScore;
    public void goToGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void exit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
		        Application.Quit();
        #endif
    }

    void Start(){
        getMaxScore();
    }

    public void getMaxScore(){
        float maxScore = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().GetMaxScore();
        lblMaxScore.text = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().getFormart(maxScore);
  
        
    }



}
