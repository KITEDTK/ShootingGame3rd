using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveSpawner : MonoBehaviour
{
    public enum spawnState { SPAWNING, WAITING, COUNTING};
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    [SerializeField]
    private int nextWave = 0;
    public float timeBetweenWave = 5f;
    public float waveCountDown = 0f;

    public spawnState state = spawnState.COUNTING;

    private float searchCountdown = 1f;


    void Start()
    {
        waveCountDown = timeBetweenWave;
        
    }
    //Update is called once per frame
    void Update()
    {
   
        if (state == spawnState.WAITING)
        {
            //check if enemy alive
            if (!enemyIsAlive())
            {
                //Begin a new round
                waveCompleted();
            }
            else
            {
                return;
            }
        }    
        if (waveCountDown <= 0)
        {
            if (state != spawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }
    void waveCompleted()
    {
        state = spawnState.COUNTING;
        waveCountDown = timeBetweenWave;
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        waves[0].count++;
    }
    bool enemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 2)
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {

        state = spawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = spawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, transform.position, Quaternion.identity); 
    }
    void addMoreEnemy(int count)
    {
        count++;
    }
    public float getWaveCountdown()
    {
        return waveCountDown;
    }
}
