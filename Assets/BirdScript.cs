using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapForce = 7;
    public LogicScript logic;
    public bool birdIsAlive = true;

    private float gameScreenTopY = 6;

    private float gameScreenBottomY = -6;
    AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        // Check for keyboard input (Space key)
        bool shouldFlap = Keyboard.current.spaceKey.wasPressedThisFrame;

        // Check for touch input (iPad/mobile)
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            shouldFlap = true;
        }

        // Check for mouse click (for testing on computer)
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            shouldFlap = true;
        }

        if (shouldFlap && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapForce;
        }

        if ((transform.position.y > gameScreenTopY || transform.position.y < gameScreenBottomY) && birdIsAlive)
        {
            logic.gameOver();
            birdIsAlive = false;
            audioManager.PlaySFX(audioManager.hit_pipe);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        audioManager.PlaySFX(audioManager.hit_pipe);

    }
}