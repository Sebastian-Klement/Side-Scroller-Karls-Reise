using UnityEngine;

class BulletControllerScript : MonoBehaviour
{
  public float SpeedX = 0.0f;

  private float speedY = 0.0f;

  new Rigidbody2D rigidbody;

  private void Start()
  {
    rigidbody = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    rigidbody.velocity = new Vector2(SpeedX, speedY);

    Destroy(gameObject, 5f);
  }
}
