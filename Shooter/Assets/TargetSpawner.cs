using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] int numOfTarget = 0;
    [SerializeField] GameObject target;
    [SerializeField] Vector3 spawnPos = Vector3.zero;

    private void start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (numOfTarget < 3)
        {
            yield return new WaitForSeconds(1);
            spawnPos = new Vector3(Random.Range(-185.3f, -195.3f), Random.Range(34.5f, 38f), Random.Range(-30f, -38f));
            Instantiate(target, spawnPos, Quaternion.identity);
            numOfTarget++;
        }
    }
}
