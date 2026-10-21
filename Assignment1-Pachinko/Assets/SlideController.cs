using System;
using System.Buffers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlideController : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject = null;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float slideLimit;

    private float center;
    private PlayerControls playerInput = null;
    private InputAction moveAction = null;
    private InputAction spawnAction = null;
    private float minSlide;
    private float maxSlide;
    private Vector3 newPosition;

    private float cooldown;

    void Awake()
    {
        playerInput = new();
        moveAction = playerInput.Movement.Move;
        spawnAction = playerInput.Movement.Spawn;
        spawnAction.performed += SpawnHeart;

        center = transform.position.x;
        minSlide = center - slideLimit;
        maxSlide = center + slideLimit;

        newPosition = transform.position;

        cooldown = 0.0f;
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    void Update()
    {
        float direction = moveAction.ReadValue<float>();
        if (direction == 0) { return; }

        newPosition = transform.position;

        float newX = newPosition.x + direction * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newX,
            minSlide, maxSlide);
        transform.position = newPosition;
    }

    void SpawnHeart(InputAction.CallbackContext ctx)
    {
        if (Time.time >= cooldown)
        {
            cooldown = Time.time + 0.4f;
            Vector3 newPosition = transform.position;
            newPosition.y = 3.21f;
            newPosition.z = 0;
            Instantiate(spawnObject, newPosition, Quaternion.identity);
        }
    }
}
