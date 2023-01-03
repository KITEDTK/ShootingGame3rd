using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ButtonManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public GameObject playAgain;
    public GameObject quit;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void backButton()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void optionsButton()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void quitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void playButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void playAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 );
    }
}
