using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBehavior : MonoBehaviour
{
    public float manSpeed = 10f;
    public float ballSpeed = 5f; // Puedes ajustar la velocidad de la bola según sea necesario
    public const float GRAVITY = -9.8f;

    public Transform cameraTransform;
    public Transform playerSkin;
    public float amplitude = 30f;
    public float rotationSpeed = 1f;

    private Quaternion cameraRotation;
    private CharacterController cc;
    private Rigidbody rb; // Agrega un Rigidbody al GameObject
    private float yVelocity;

    private PlayerStateManager playerStateManager;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>(); // Obtén el Rigidbody del GameObject
        rb.isKinematic = true; // Haz que el Rigidbody no sea afectado por la física hasta que lo necesites

        playerStateManager = FindAnyObjectByType<PlayerStateManager>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(xInput, 0, zInput);
        if (input.magnitude > 1)
        {
            input.Normalize();
        }

        AlignWithCamera();
        ApplyGravity();

        Vector3 velocity = cameraRotation * input;

        if (playerStateManager.currentNameMode == "Man")
        {
            cc.enabled = true; // Activa el CharacterController
            rb.isKinematic = true; // Desactiva el Rigidbody
            cc.Move(Vector3.up * yVelocity * Time.deltaTime + velocity * manSpeed * Time.deltaTime);

            VisualFeedback(input, velocity);
        }
        else if (playerStateManager.currentNameMode == "Ball")
        {
            cc.enabled = false; // Desactiva el CharacterController
            rb.isKinematic = false; // Activa el Rigidbody
            rb.AddForce(velocity * ballSpeed, ForceMode.Acceleration); // Aplica una fuerza al Rigidbody para mover la bola
        }
    }

    private void ApplyGravity()
    {
        if (cc.isGrounded)
        {
            yVelocity = GRAVITY;
        }
        else
        {
            yVelocity += GRAVITY * Time.deltaTime;
        }
    }

    private void AlignWithCamera()
    {
        // Player's forward is aligned with camera
        Vector3 cameraFlatForward = cameraTransform.forward;
        cameraFlatForward.y = 0f;
        cameraRotation = Quaternion.LookRotation(cameraFlatForward);
    }



    private void VisualFeedback(Vector3 input, Vector3 velocity)
    {

        if (input != Vector3.zero) //look at direction of movement
        {
            transform.rotation = Quaternion.LookRotation(velocity);
        }

        if (input.magnitude > 0)
        {
            PlayWaveAnimation();
        }
        else if (input.magnitude < 0.5f)
        {
            playerSkin.rotation = Quaternion.LookRotation(transform.forward);
        }
    }

    private void PlayWaveAnimation()
    {
        float rotationAngle = Mathf.Sin(Time.time * rotationSpeed) * amplitude;
        playerSkin.rotation = Quaternion.Euler(0f, rotationAngle, 0f) * transform.rotation;
    }
}
