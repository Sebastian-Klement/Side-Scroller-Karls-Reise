using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [Header("Move Settings")]
  public float Speed = 10f;
  public float JumpForce = 10f;
  Rigidbody2D myRigidbody;

  private float direction;
  private Vector3 localScale;
  private bool faceRight = true;

  [Header("Ground Settings")]
  public float GroundCheckRadius;
  public bool isGrounded = false;
  public Transform GroundCheckPoint;
  public LayerMask LayerMask;
  BoxCollider2D myCrounchCollider2D;

  [Header("Ceiling Settings")]
  public float CeilingCheckRadius;
  public bool isOnCeiling = false;
  public Transform CeilingCheckPoint;

  [Header("Fire Settings")]
  public GameObject BulletLeft;
  public GameObject BulletRight;
  public float FireRate = 0.5f;
  private float nextFire = 0.0f;
  Vector2 bulletPosition;

  void Start()
  {
    myRigidbody = GetComponent<Rigidbody2D>();

    myCrounchCollider2D = GameObject.Find("Player").GetComponent<BoxCollider2D>();

    localScale = transform.localScale;
  }

  void Update()
  {
    isGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, GroundCheckRadius, LayerMask);

    isOnCeiling = Physics2D.OverlapCircle(CeilingCheckPoint.position, CeilingCheckRadius, LayerMask);

    direction = Input.GetAxis("Horizontal");

    moveHorizontalMethod(direction);

    jumpMethod();

    fireMethod();

    crouchMethod();
  }
  void LateUpdate()
  {
    if (direction > 0)
    {
      faceRight = true;
    }

    else if (direction < 0)
    {
      faceRight = false;
    }

    if (((faceRight) && (localScale.x < 0)) || ((!faceRight) && (localScale.x > 0)))
    {
      localScale.x *= -1;
    }

    transform.localScale = localScale;
  }

  private void crouchMethod()
  {
    if (Input.GetKey(KeyCode.S))
    {
      myCrounchCollider2D.enabled = false;
    }
    else if (!Input.GetKey(KeyCode.S) && !isOnCeiling)
    {
      myCrounchCollider2D.enabled = true;
    }
  }

  private void jumpMethod()
  {
    if (Input.GetButtonDown("Jump") && isGrounded && !isOnCeiling)
    {
      myRigidbody.velocity += JumpForce * Vector2.up;
    }
  }

  private void fireMethod()
  {
    if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
    {
      nextFire = Time.time + FireRate;
      fire();
    }
  }

  private void fire()
  {
    bulletPosition = transform.position;
    if (faceRight)
    {
      bulletPosition += new Vector2(+1f, 1.5f);
      Instantiate(BulletRight, bulletPosition, Quaternion.identity);
    }
    else
    {
      bulletPosition += new Vector2(-1f, 1.5f);
      Instantiate(BulletLeft, bulletPosition, Quaternion.identity);
    }
  }

  private void moveHorizontalMethod(float horizontalInput)
  {
    Vector2 moveVelocity = myRigidbody.velocity;

    moveVelocity.x = Speed * horizontalInput;

    myRigidbody.velocity = moveVelocity;
  }
}
