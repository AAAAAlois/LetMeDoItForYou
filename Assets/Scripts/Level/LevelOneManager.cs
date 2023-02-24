using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOneManager : MonoBehaviour
{
    public NoseCollision noseCollision;
    public bool isGameOver;

    [Header("UI")]
    [SerializeField] Button startButton;
    [SerializeField] GameObject startPanel;

    [SerializeField] Button restartButton;
    [SerializeField] GameObject restartPanel;
    // Start is called before the first frame update
    void Start()
    {
        noseCollision = FindObjectOfType<NoseCollision>();

        Time.timeScale = 0f;

        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        if (noseCollision.isGameOver)
        {
            Time.timeScale = 0f;
            restartPanel.SetActive(true);
        }
        else if (noseCollision.isReachExit)
        {
            SceneManager.LoadScene(2);
        }
    }

    void StartGame()
    {
        Time.timeScale = 1f;
        startPanel.SetActive(false);
    }

    void Restart()
    {
        SceneManager.LoadScene(1);
        restartPanel.SetActive(false);
    }
}
