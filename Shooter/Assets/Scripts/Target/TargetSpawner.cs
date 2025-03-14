using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    public static TargetSpawner Instance;
    public int numOfTarget = 0;
    [SerializeField] GameObject target;
    [SerializeField] Vector3 spawnPos = Vector3.zero;
    [SerializeField] bool isSpawning = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void gameLaunch()
    {
        Debug.Log("launching targets");
        StartCoroutine(SpawnTarget());
    }//called when game is started

    public void TargetDestroyed()
    {
        numOfTarget--;
        Debug.Log("target destroyed");

        if (numOfTarget < 3 && !isSpawning)
            StartCoroutine(SpawnTarget());
    }


    IEnumerator SpawnTarget()
    {
        isSpawning = true;
        while (numOfTarget < 3)
        {
            yield return new WaitForSeconds(0.5f);
            spawnPos = new Vector3(Random.Range(-185.3f, -195.3f), Random.Range(34.5f, 38f), Random.Range(-30f, -38f));
            Quaternion LookRotation = Quaternion.LookRotation(playerPos.position);
            Quaternion finalRotation = LookRotation * Quaternion.Euler(0f, -30f, 90f);
            Instantiate(target, spawnPos, finalRotation);
            numOfTarget++;
        }
        isSpawning = false;
    }
}
