using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed;
    [SerializeField] private Transform cameraTransform;

    private Rigidbody _rigidbody;

    private Vector3 _direction;
    [SerializeField] private float moveSpeedVelocity;

    private Touch _touch;

    public GameObject playerBody;
    public GameObject playerPieces;

    public CameraShake cameraShake;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        cameraShake = FindObjectOfType<CameraShake>();
    }

    private void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        if(GameManager.Instance.isFinish) return;
        
        MoveForward();

        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            
            if (_touch.phase == TouchPhase.Began)
            {
                if(GameManager.Instance.isStart) return;
                GameManager.Instance.isStart = true;
                UIManager.Instance.CloseTopToStart();
            }
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
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Obctacle Collsion");
            CollisionObstacle();
        }
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.isFinish || !GameManager.Instance.isStart) return;
        
        MoveWithRigidbody();
    }

    private void MoveForward()
    {
        if(!GameManager.Instance.isStart) return;

        transform.position += transform.forward * (forwardSpeed * Time.deltaTime);
        cameraTransform.position += Vector3.forward * (forwardSpeed * Time.deltaTime);
    }

    private void MoveWithRigidbody()
    {
        _rigidbody.velocity = _direction * (moveSpeedVelocity * Time.fixedDeltaTime);
    }

    private void CollisionObstacle()
    {
        GameManager.Instance.isFinish = true;
        _rigidbody.velocity = Vector3.zero;
        
        playerPieces.SetActive(true);
        playerBody.SetActive(false);
        
        UIManager.Instance.OpenFailImage();
        
        cameraShake.ShakeCamera();
        
        StartCoroutine(UIManager.Instance.OpenRestartButton());
    }
}
