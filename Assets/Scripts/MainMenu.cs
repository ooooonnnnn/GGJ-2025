using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function for the Start button
    public void StartGame()
    {
        SceneManager.LoadScene("Game"); // Replace with the name of the main game scene
    }

    // Function for the Tutorial button
    public void OpenTutorial()
    {
        SceneManager.LoadScene("Tutorial"); // Replace with the name of the tutorial scene
    }

    // Function for the Quit button
    public void QuitGame()
    {
        Application.Quit(); // Exits the game
        Debug.Log("Game is exiting..."); // This will only appear in the Unity Editor
    }
}