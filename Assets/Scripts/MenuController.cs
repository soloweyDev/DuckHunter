using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public UnityEngine.UI.Button Duck1;
    public UnityEngine.UI.Button Duck2;
    public UnityEngine.UI.Text TopScoreText;
    public static int TopScore = 0;
    public static int DuckNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        Duck1.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Hunter");
            DuckNumber = 1;
        });

        Duck2.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Hunter");
            DuckNumber = 2;
        });
    }

    // Update is called once per frame
    void Update()
    {
        TopScoreText.text = $"TOP SCORE = {TopScore}";
    }
}
