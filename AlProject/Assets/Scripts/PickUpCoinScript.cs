using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoinScript : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    FindObjectOfType<GameManager>().IncreaseScore(5);
    if (other.gameObject.CompareTag("Player"))
    {
      Destroy(gameObject, 0.0f);
    }
  }
}
