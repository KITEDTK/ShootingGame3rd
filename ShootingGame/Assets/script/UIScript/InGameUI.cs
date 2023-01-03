using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class InGameUI : MonoBehaviour
{
    // Start is called before the first frame update
 
    public TMP_Text waveCountDownText;
    public TMP_Text enemyLeftText;
    public TMP_Text scoreText;

    public int score;
    public int enemyCount;
    public int waveCountDown;

    public GameObject[] normalWave;
    public GameObject waveCountDownObj;

    private AsunaController asuna;
    void Start()
    {
        score = 0;
        asuna = GameObject.FindGameObjectWithTag("Player").GetComponent<AsunaController>();
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length - 2;
        float a = GameObject.FindGameObjectWithTag("WaveSpawn").GetComponent<WaveSpawner>().getWaveCountdown();
        waveCountDown = (int)a;

        waveCountDownText.text = waveCountDown.ToString();

        enemyLeftText.text = enemyCount.ToString();

        scoreText.text = score.ToString();

        PlayerPrefs.SetInt("score", score);
        if (waveCountDown > 0)
        {
            waveCountDownObj.SetActive(true);
        }
        else
        {
            waveCountDownObj.SetActive(false);
        }
        if(asuna.gethealth() == 0)
        {
            //Do end game here
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
