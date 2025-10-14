using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

        public static GameManager Instance;

    void Awake()
 {
     if (Instance != null && Instance != this) 
     {
         Destroy(this);
     }
     else 
     { 
         Instance = this;
     }
 }
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        UIController.Instance.gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");

    }

    public void Pause()
    {

    }

    public void QuitGame()
    {

    }

    public void GoToMainMenu()
    {

    }



}
