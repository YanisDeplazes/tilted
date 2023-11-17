using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject canvasObject; // Reference to your canvas GameObject
    private bool isGameFrozen = true;

    void Start()
    {
        Time.timeScale = 0f; // Freeze the game when it starts
        canvasObject.SetActive(true); // Show the canvas
    }

    void Update()
    {
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
        canvasObject.SetActive(false); // Hide the canvas
        isGameFrozen = false;
    }
}





