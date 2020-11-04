using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public Text RoundText;
    public Text ScoreText;
    public Text WindowRoundText;
    public Image WindowRound;
    public GameObject Duck;
    public GameObject Dog;
    public GameObject DogUp1;
    public GameObject DogUp2;
    public Image[] Shouts = new Image[3];
    public AudioClip AudioShout;
    public Image[] RedDucks = new Image[10];

    public int Round = 0;
    public int Score = 0;

    private RaycastHit _hit;

    private int _countShouts = 3;
    private int _countDucks = 0;
    private float _curTime;
    private bool _dogInst = true;
    private bool _shot = false;
    private bool _newRound = false;

    // Start is called before the first frame update
    void Start()
    {
        _curTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.time - _curTime;
        if (delta > 3.0f) WindowRound.gameObject.SetActive(false);

        if (duck.IsDuck)
        {
            if (duck.IsDuckDie)
            {
                if (_dogInst)
                {
                    Instantiate(DogUp1, new Vector3(0.0f, -2.3f), Quaternion.identity);
                    _dogInst = false;
                }
            }
            else
            {
                if (_newRound)
                {
                    _curTime = Time.time;
                    Round++;
                    WindowRoundText.text = Round.ToString();
                    WindowRound.gameObject.SetActive(true);

                    foreach (var redDuck in RedDucks)
                    {
                        redDuck.gameObject.SetActive(false);
                    }
                    _countDucks = 0;
                    _shot = true;

                    Instantiate(Dog, new Vector3(-8.4f, -3.3f), Quaternion.identity);
                    _newRound = false;
                }
                else
                {
                    for (; _countShouts < 3;)
                    {
                        Shouts[_countShouts++].gameObject.SetActive(false);
                    }

                    Instantiate(Duck, new Vector3(-3.0f, -4.2f), Quaternion.identity);
                    duck.IsDuck = false;
                    _dogInst = true;
                    _shot = true;
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && _shot)
        {
            if (_countShouts > 0)
            {
                _countShouts--;
                Shouts[_countShouts].gameObject.SetActive(true);

                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(AudioShout);

                Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, Color.red, 3.0f);
                if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward,
                    out _hit, Mathf.Infinity))
                {
                    if (_hit.transform.tag == "Duck")
                    {
                        Score += 50;
                        duck.Duck.Fly = false;
                        RedDucks[_countDucks++].gameObject.SetActive(true);
                    }
                }

                if (_countDucks == 10)
                {
                    _newRound = true;
                    duck.IsDuck = false;
                }
            }
        }

        RoundText.text = $"{Round}";
        ScoreText.text = $"{Score}";
        WindowRoundText.text = $"{Round}";
    }
}
