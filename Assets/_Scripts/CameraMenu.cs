
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMenu : MonoBehaviour
{
    public float tiltAmount = 5f;
    public float smoothSpeed = 5f;
    public float edgeThreshold = 50f;

    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float tiltX = 0f;
        float tiltY = 0f;

        if (mousePos.x < edgeThreshold)
            tiltY = -tiltAmount;
        else if (mousePos.x > screenWidth - edgeThreshold)
            tiltY = tiltAmount;

        if (mousePos.y < edgeThreshold)
            tiltX = tiltAmount;
        else if (mousePos.y > screenHeight - edgeThreshold)
            tiltX = -tiltAmount;

        Quaternion targetRotation = originalRotation * Quaternion.Euler(tiltX, tiltY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
