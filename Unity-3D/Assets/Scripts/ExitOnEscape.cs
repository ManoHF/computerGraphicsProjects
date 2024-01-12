using UnityEngine;

public class ExitOnEscape : MonoBehaviour
{
    public Canvas exitCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the exit canvas initially
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "Escape" key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the visibility of the exit canvas
            ToggleExitCanvas();
        }
    }

    // Function to toggle the visibility of the exit canvas
    void ToggleExitCanvas()
    {
        if (exitCanvas != null)
        {
            // Toggle the visibility of the exit canvas
            exitCanvas.gameObject.SetActive(!exitCanvas.gameObject.activeSelf);
        }
    }

    // Function to handle the "Yes" button click
    public void OnYesButtonClick()
    {
        // This function is called when the "Yes" button is clicked in the UI
        Application.Quit();
    }

    // Function to handle the "No" button click
    public void OnNoButtonClick()
    {
        // This function is called when the "No" button is clicked in the UI
        if (exitCanvas != null)
        {
            // Disable the exit canvas
            exitCanvas.gameObject.SetActive(false);
        }
    }
}

