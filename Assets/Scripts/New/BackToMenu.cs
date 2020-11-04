using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Fire1"))
            SceneManager.LoadScene("MainMenu");
    }
}
