using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerController : MonoBehaviour
{
  [SerializeField] private float moveSpeed = 5f;

  private Rigidbody rb;

  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void FixedUpdate()
  {
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");

    Vector3 move = new Vector3(h, 0, v).normalized * (moveSpeed * Time.fixedDeltaTime);

    rb.MovePosition(transform.position + move);
  }
}
