using UnityEngine.SceneManagement;
using UnityEngine;

public class EndUI : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
