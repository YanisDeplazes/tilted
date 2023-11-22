using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    public Tilemap[] tilemaps; // Array to hold your tilemaps
    public float initialDelay = 2.5f; // Initial delay before starting the sequence
    public float toggleDelay = 5f; // Delay for toggling tilemaps
    public float breakDelay = 5f; // Delay before reactivating tilemaps

    private void Start()
    {
        StartCoroutine(ToggleTilemaps());
    }

    private System.Collections.IEnumerator ToggleTilemaps()
    {
        while (true) // Infinite loop
        {
            yield return new WaitForSeconds(initialDelay); // Wait for the initial delay

            foreach (Tilemap tilemap in tilemaps)
            {
                tilemap.gameObject.SetActive(true); // Enable the tilemap

                yield return new WaitForSeconds(toggleDelay); // Wait for the toggle delay

                tilemap.gameObject.SetActive(false); // Disable the tilemap
            }

            yield return new WaitForSeconds(breakDelay); // Wait for the break delay before reactivating
        }
    }
}




