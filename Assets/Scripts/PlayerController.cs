using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed;
    [SerializeField] private Transform cameraTransform;

    private Rigidbody _rigidbody;

    private Vector3 _direction;
    [SerializeField] private float moveSpeedVelocity;

    private Touch _touch;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveForward();

        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                _direction = new Vector3(_touch.deltaPosition.x, 0, _touch.deltaPosition.y);
            }

            if (_touch.phase == TouchPhase.Ended)
            {
                _direction = Vector3.zero;
                _rigidbody.velocity = _direction;
            }
        }
    }

    private void FixedUpdate()
    {
        MoveWithRigidbody();
    }

    private void MoveForward()
    {
        transform.position += transform.forward * (forwardSpeed * Time.deltaTime);
        cameraTransform.position += Vector3.forward * (forwardSpeed * Time.deltaTime);
    }

    private void MoveWithRigidbody()
    {
        _rigidbody.velocity = _direction * (moveSpeedVelocity * Time.fixedDeltaTime);
    }
}
