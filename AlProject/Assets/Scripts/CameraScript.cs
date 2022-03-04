using UnityEngine;

public class CameraScript : MonoBehaviour
{
  public GameObject CameraTrackPoint;

  public float Speed = 2.0F;
  private void Update()
  {
    float interpolation = Speed * Time.deltaTime;

    Vector3 position = transform.position;

    position.y = Mathf.Lerp(transform.position.y, CameraTrackPoint.transform.position.y, interpolation);

    position.x = Mathf.Lerp(transform.position.x, CameraTrackPoint.transform.position.x, interpolation);

    transform.position = position;
  }
}
