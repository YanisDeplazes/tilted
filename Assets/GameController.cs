
/*
using UnityEngine;
using TMPro;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject canvasObject; // Reference to your start canvas GameObject
    public GameObject scoreCanvas; // Reference to your score canvas GameObject
    public TextMeshProUGUI playtimeText; // Reference to TextMeshPro for playtime display
    private bool isGameFrozen = true;
    private float startTime;

    void Start()
    {
        Time.timeScale = 0f; // Freeze the game when it starts
        canvasObject.SetActive(true); // Show the start canvas
        scoreCanvas.SetActive(false); // Hide the score canvas initially
    }

    void Update()
    {
        if (!isGameFrozen)
        {
            UpdatePlayTime();
        }

        if (isGameFrozen)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(UnfreezeGameAfterDelay(0.0f)); // Start coroutine to unfreeze after 0.5 seconds
            }
        }
    }

    IEnumerator UnfreezeGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Wait for the specified delay
        StartGame(); // Call the method to unfreeze the game
    }

    void StartGame()
    {
        Time.timeScale = 1f; // Unfreeze the game
        canvasObject.SetActive(false); // Hide the start canvas
        scoreCanvas.SetActive(true); // Show the score canvas
        isGameFrozen = false;
        startTime = Time.time; // Record the start time
    }

    void UpdatePlayTime()
    {
        float playTime = Time.time - startTime;
        playtimeText.text = "Time: " + playTime.ToString("F2"); // Display playtime formatted with 2 decimal places
    }
}*/

using UnityEngine;
using TMPro;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject canvasObject; // Reference to your start canvas GameObject
    public GameObject scoreCanvas; // Reference to your score canvas GameObject
    public TextMeshProUGUI playtimeText; // Reference to TextMeshPro for playtime display on Score Canvas
    public TextMeshProUGUI leaderboardPlaytimeText; // Reference to TextMeshPro for playtime display on Leaderboard Canvas
    private bool isGameFrozen = true;
    private float startTime;

    void Start()
    {
        Time.timeScale = 0f; // Freeze the game when it starts
        canvasObject.SetActive(true); // Show the start canvas
        scoreCanvas.SetActive(false); // Hide the score canvas initially
    }

    void Update()
    {
        if (!isGameFrozen)
        {
            UpdatePlayTime();
        }

        if (isGameFrozen)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(UnfreezeGameAfterDelay(0.0f)); // Start coroutine to unfreeze after 0.5 seconds
            }
        }
    }

    IEnumerator UnfreezeGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Wait for the specified delay
        StartGame(); // Call the method to unfreeze the game
    }

    void StartGame()
    {
        Time.timeScale = 1f; // Unfreeze the game
        canvasObject.SetActive(false); // Hide the start canvas
        scoreCanvas.SetActive(true); // Show the score canvas
        isGameFrozen = false;
        startTime = Time.time; // Record the start time

        // Update playtime text on score canvas
        UpdatePlaytimeText(playtimeText);

        // Update playtime text on leaderboard canvas
        UpdatePlaytimeText(leaderboardPlaytimeText);
    }

    void UpdatePlayTime()
    {
        float playTime = Time.time - startTime;
        playtimeText.text = "Time: " + playTime.ToString("F2"); // Display playtime formatted with 2 decimal places
        leaderboardPlaytimeText.text = "Time: " + playTime.ToString("F2"); // Update playtime text on leaderboard canvas
    }

    // Function to update playtime text
    void UpdatePlaytimeText(TextMeshProUGUI textComponent)
    {
        float playTime = Time.time - startTime;
        textComponent.text = "Time: " + playTime.ToString("F2");
    }
}












