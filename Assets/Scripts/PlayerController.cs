using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [SerializeField]
    [Tooltip("For SystemInput(New)")]
    InputAction movement;

    [SerializeField]
    InputAction firingLaser;

    [SerializeField]
    float controlSpeed = 10f;

    [SerializeField]
    float xRange = 5f;

    [SerializeField]
    float yRange = 5f;

    [Header("Lasers gun array")]
    [SerializeField]
    GameObject[] lasers;

    [Header("Screen position based tuning")]
    [SerializeField]
    float positionPitchFactor = -2f;

    [SerializeField]
    float positionYawFactor = 3f;

    [Header("Player input based tuning")]
    [SerializeField]
    float controlPitchFactor = -15f;

    [SerializeField]
    float controlRollFactor = -15f;

    float yThrow,
        xThrow;

    void Start() { }

    private void OnEnable()
    {
        movement.Enable();
        firingLaser.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        firingLaser.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessTranslation()
    {
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControlThrow = xThrow * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = yawDueToPosition;
        float roll = rollDueToControlThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (firingLaser.ReadValue<float>() > 0.5) // 押す動作＝0-1の変化があるから
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers) // lasersはArray名として決めたが、laserの部分は何でも良い、lとかで良い
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
            // laser.SetActive(true);
        }
    }
}
