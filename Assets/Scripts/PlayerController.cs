using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    InputAction movement;

    // Start is called before the first frame update
    void Start() { }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = .1f;
        float newXPosition = transform.localPosition.x + xOffset;

        transform.localPosition = new Vector3(
            newXPosition,
            transform.localPosition.y,
            transform.localPosition.z
        );
    }
}
