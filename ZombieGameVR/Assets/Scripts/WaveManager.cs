using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    int zombieSpawnPerWave;
    public GameObject zombie;
    public GameObject[] spawnPoints;
    float newWaveTime = 20.0f;
    // Start is called before the first frame update]
    int spawnPosition;

    private void Start()
    {
        StartCoroutine(NewWaveCountdown(newWaveTime));
        newWaveTime = 60.0f;
    }


    private void StartWave()
    {
        for (int i = 0; i < zombieSpawnPerWave; i++)
        {
            spawnPosition = Random.Range(0, 4);
            Instantiate(zombie, spawnPoints[spawnPosition].transform);
        }

        StartCoroutine(NewWaveCountdown(newWaveTime));
    }

    private IEnumerator NewWaveCountdown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartWave();
    }

}
