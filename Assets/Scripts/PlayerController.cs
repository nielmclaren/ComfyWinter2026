using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  public float moveSpeed;
  public Transform spriteTransform;

  private SpriteRenderer _spriteRenderer;
  private Rigidbody2D _rb;
  private Vector2 _moveInput;
  private bool _isFlipped;

  private void Start()
  {
    _spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();

    _rb = GetComponent<Rigidbody2D>();
    _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
  }

  private void Update()
  {
    _spriteRenderer.flipX = _isFlipped;
  }

  private void OnMove(InputValue value)
  {
    _moveInput = value.Get<Vector2>();
    if (_moveInput.x != 0)
    {
        _isFlipped = _moveInput.x > 0;
    }
  }

  private void FixedUpdate()
  {
    _rb.linearVelocity = _moveInput * moveSpeed;
  }
}
