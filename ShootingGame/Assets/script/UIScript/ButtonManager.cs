using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("Quit!!!");
    }
    public void playButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
