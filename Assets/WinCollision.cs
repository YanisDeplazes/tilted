
using UnityEngine;

public class WinCollision : MonoBehaviour
{
    public GameObject leaderboardCanvas;
    public GameObject scoreCanvas; // Reference to the score canvas
    public SpriteRenderer playerRenderer; // Reference to the player character's SpriteRenderer
    public float fadeDuration = 3f; // Duration over which the player character fades out
    private bool isColliding = false;
    private float collisionStartTime;
    private bool gamePaused = false;

    private Color originalColor;
    private bool fading = false;
    private float fadeTimer = 0f;

    private void Start()
    {
        // Deactivate the leaderboard canvas at the start
        leaderboardCanvas.SetActive(false);

        // Store the original color of the player character
        originalColor = playerRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isColliding && !gamePaused) // Start timing only if not already colliding and game isn't paused
            {
                isColliding = true;
                collisionStartTime = Time.time; // Record the start time
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float collisionDuration = Time.time - collisionStartTime; // Calculate duration

            if (collisionDuration >= fadeDuration && !gamePaused) // Check if the collision duration exceeds the fade duration
            {
                // Display leaderboard canvas if collision lasted at least fadeDuration seconds and game isn't paused
                leaderboardCanvas.SetActive(true);
                scoreCanvas.SetActive(false); // Deactivate the score canvas
                Time.timeScale = 0f; // Pause the game
                gamePaused = true;

                // Ensure the character is completely faded out
                FadeOutCharacter();
            }
            else if (!fading && !gamePaused) // If fading hasn't started yet and the game isn't paused, start fading
            {
                float normalizedTime = Mathf.Clamp01(collisionDuration / fadeDuration); // Normalize the time

                // Calculate the new alpha value based on normalized time
                float newAlpha = Mathf.Lerp(originalColor.a, 0f, normalizedTime);

                // Apply the new color with updated alpha
                playerRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            }
        }
    }

    private void FadeOutCharacter()
    {
        fading = true;
        fadeTimer = 0f;
        // You can initiate any additional effects or actions when the character starts to fade out
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = false;
            // Reset the player character's color to its original color when the collision ends
            playerRenderer.color = originalColor;
        }
    }

    private void Update()
    {
        if (gamePaused && fading)
        {
            fadeTimer += Time.deltaTime;
            float normalizedFadeTime = fadeTimer / fadeDuration;

            // Interpolate the alpha value from the original to 0 over time
            float newAlpha = Mathf.Lerp(originalColor.a, 0f, normalizedFadeTime);

            // Apply the new color with updated alpha
            playerRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);

            if (fadeTimer >= fadeDuration)
            {
                fading = false;
            }
        }

        if (gamePaused && leaderboardCanvas.activeSelf)
        {
            playerRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        }
    }
}



