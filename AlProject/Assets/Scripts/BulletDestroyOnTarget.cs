using UnityEngine;

class BulletDestroyOnTarget : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag.Equals("TargetCat"))
    {
      Destroy(collision.gameObject);
    }
    Destroy(gameObject, 0.0f);
  }
}
