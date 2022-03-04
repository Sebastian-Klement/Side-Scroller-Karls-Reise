using UnityEngine;

public class ObjectDestroyController : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D obj)
  {
    if (obj.gameObject.CompareTag("Player"))
    {
      Destroy(gameObject);
    }
  }
}
