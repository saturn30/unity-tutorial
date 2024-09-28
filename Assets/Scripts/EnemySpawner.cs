using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Utility;

public class EnemySpawner : MonoBehaviour
{
    private float[] arrPos;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject boss;
    [SerializeField] private float spawnInterval = 1.5f;
    RandomSelector randomSelector = new RandomSelector();

    // Start is called before the first frame update
    void Start()
    {
        arrPos = calcArrPos();
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        float moveSpeed = 5f;
        int spawnCount = 0;

        while (true)
        {
            int enemiesCount = Random.Range(1, arrPos.Length - 1);
            foreach (float posX in randomSelector.GetRandomElements(arrPos, enemiesCount))
            {
                int index = Random.Range(0, enemies.Length);
                SpawnEnemy(posX, index, moveSpeed + spawnCount * 0.5f);
            }
            spawnCount += 1;

            if (spawnCount >= 20)
            {
                SpawnBoss();
                break;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    float[] calcArrPos()
    {
        Camera mainCamera = Camera.main;
        float height = 2f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        float[] positions = new float[5];
        float spacing = width / 5f;

        for (int i = 0; i < 5; i++)
        {
            positions[i] = (-width / 2) + (spacing * (i + 0.5f));
        }

        return positions;
    }

    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPosition = new Vector3(posX, transform.position.y, transform.position.z);
        Enemy enemy = Instantiate(enemies[index], spawnPosition, Quaternion.identity).GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
