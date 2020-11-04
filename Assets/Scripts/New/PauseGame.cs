using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject PausedPopup;
    public AudioSource Source;
    public AudioClip PauseSound;
    public GameObject PausedText;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            StaticVars.paused = !StaticVars.paused;

            if (StaticVars.paused)
            {
                Source.PlayOneShot(PauseSound);
                PausedPopup.SetActive(true);
                PausedText.SetActive(true);
            }
            else if (!StaticVars.paused)
            {
                PausedPopup.SetActive(false);
                PausedText.SetActive(false);
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            StaticVars.paused = !StaticVars.paused;

            if (StaticVars.paused)
            {
                Source.PlayOneShot(PauseSound);
                PausedPopup.SetActive(true);
                PausedText.SetActive(true);
            }
            else if (!StaticVars.paused)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }

            if (StaticVars.paused)
            {
                Time.timeScale = 0;
            }
            else if (!StaticVars.paused)
            {
                Time.timeScale = 1;
            }
        }
    }
}
