using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  [Header("Score Elements")]
  public int score;
  public Text scoreText;
  public int highscore;
  public Text highscoreText;

  //[Header("Gameover Elements")]
  //public GameObject gameOverPanel;

  private void Awake()
  {
    //gameOverPanel.SetActive(false);
    GetHighscore();
  }
  private void GetHighscore()
  {
    highscore = PlayerPrefs.GetInt("Highscore");
    highscoreText.text = "Best: " + highscore;
  }
  public void IncreaseScore(int num)
  {
    score += num;
    scoreText.text = score.ToString();

    if (score > highscore)
    {
      PlayerPrefs.SetInt("Highscore", score);
      highscoreText.text = "Best: " + score.ToString();
    }
  }
  public void RestartGame()
  {
    score = 0;
    scoreText.text = "0";

    //gameOverPanel.SetActive(false);

    foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
    {
      Destroy(g);
    }

    GetHighscore();

    Time.timeScale = 1;
  }
}
