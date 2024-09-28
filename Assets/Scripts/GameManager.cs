using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int coin = 0;
    [HideInInspector] public bool isGameOver = false;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject gameOverPanel;

    // start보다 일찍 실행됨
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());
        return coin;
    }

    public void SetGameOver()
    {
        isGameOver = true;
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
        }
        Invoke("ShowGameOverPanel", 1f);
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
