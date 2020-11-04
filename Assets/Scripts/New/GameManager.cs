using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void DuckDelegate();
    public static DuckDelegate OnSpawnDucks;
    public static DuckDelegate OnDuckShot;
    public static DuckDelegate OnDuckDeath;
    public static DuckDelegate OnDuckFlyAway;
    public static DuckDelegate OnDuckMiss;
    public static DuckDelegate OnStartGame;
    public static DuckDelegate OnNewRound;

    public GameObject FlyAwaySky;
    public GameObject RoundPopup;
    public GameObject RoundPopupNumText;

    private Text _roundPopupText;

    void Start()
    {
        GameObject shooter = GameObject.Find("Main Camera");
        _roundPopupText = RoundPopupNumText.GetComponent<Text>();

        OnDuckMiss += FlyAwaySkyOn;
        OnDuckFlyAway += FlyAwaySkyOff;
        OnSpawnDucks += FlyAwaySkyOff;
        OnNewRound += FlyAwaySkyOff;
        OnStartGame += DisplayRoundNumOn;
        OnNewRound += DisplayRoundNumOn;
        OnSpawnDucks += DisplayRoundNumOff;
    }

    public void FlyAwaySkyOn()
    {
        FlyAwaySky.SetActive(true);
    }

    public void FlyAwaySkyOff()
    {
        FlyAwaySky.SetActive(false);
    }

    public void DisplayRoundNumOn()
    {
        _roundPopupText.text = "ROUND\n" + StaticVars.roundNum;
        RoundPopup.SetActive(true);
    }

    public void DisplayRoundNumOff()
    {
        _roundPopupText.text = "ROUND\n" + StaticVars.roundNum;
        RoundPopup.SetActive(false);
    }
}
