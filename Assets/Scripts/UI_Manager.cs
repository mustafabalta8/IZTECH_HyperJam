using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private TextMeshProUGUI scoreText; 
    private void Start()
    {
        Singelton();
        scoreText.text = Score.totalScore.ToString();
    }
    private void Singelton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartGame()
    {
        PlayerMovement.instance.IsPlaying = true;
        Player.characterAnimator.SetBool("isRunning", true);
        inGamePanel.SetActive(true);
    }

    public void OpenNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator OpenWinPanelWithDelay()
    {
        yield return new WaitForSeconds(1);
        winPanel.SetActive(true);

    }
    public void OpenWinPanel()
    {
        StartCoroutine(OpenWinPanelWithDelay());
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}
