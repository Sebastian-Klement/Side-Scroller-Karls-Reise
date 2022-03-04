using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeScript : MonoBehaviour
{
  public int LevelIndex;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      SceneManager.LoadScene(LevelIndex);
    }
  }
}
