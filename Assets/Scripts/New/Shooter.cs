using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    private RaycastHit _hit;
    private float _volMin = 0.7f;
    private float _volMax = 0.9f;
    private Text _scoreText;
    private int _score;
    private Text _roundText;
    private int _bulletAmount;
    private Animator _animator;
    private int _duckShotNum;

    public AudioClip Shot;
    public AudioSource Source;
    public AudioClip Win;
    public AudioClip Lose;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public GameObject ScoreObject;
    public GameObject RoundObject;
    public int MaxBullets;
    public GameObject[] RedDuck;
    public GameObject WhiteDuck;

    void Start()
    {
        _animator = WhiteDuck.GetComponent<Animator>();

        _scoreText = ScoreObject.GetComponent<Text>();
        _roundText = RoundObject.GetComponent<Text>();
        StaticVars.duckNum = 1;
        _duckShotNum = 0;
        StaticVars.duckNum = 1;

        MaxBullets = 3;
        _bulletAmount = 50;

        GameManager.OnSpawnDucks += ResetBullets;
        GameManager.OnSpawnDucks += ClickOn;
        GameManager.OnSpawnDucks += DuckGUI;
        GameManager.OnDuckMiss += DuckGUIStop;
        GameManager.OnDuckShot += DuckGUIStop;
        GameManager.OnNewRound += ResetRound;
        GameManager.OnNewRound += ResetBullets;
        GameManager.OnNewRound += RoundNum;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (StaticVars.onClick == false)
            {
                _bulletAmount--;
                BulletGUI(_bulletAmount);

                if (_bulletAmount < 0)
                {
                    _bulletAmount = 20;
                    StaticVars.roundNum++;
                    StaticVars.onClick = true;
                    GameManager.OnDuckMiss();
                }

                if (0 <= _bulletAmount && _bulletAmount <= 3)
                {
                    float vol = Random.Range(_volMin, _volMax);
                    Source.PlayOneShot(Shot, vol);
                }

                if (_bulletAmount == 0)
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = Camera.main.transform.position.z;

                    Debug.DrawRay(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward, Color.red, 3.0f);

                    if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward,
                        out _hit, Mathf.Infinity))
                    {
                        if (_hit.transform.tag == "Duck")
                        {
                            StaticVars.onClick = true;
                            DuckHealth health = _hit.transform.GetComponent<DuckHealth>();
                            health.KillDuck();
                            SetScore();
                            _duckShotNum++;
                            DuckGUIShot();
                            StaticVars.duckNum++;
                        }
                    }
                    else
                    {
                        StaticVars.duckNum++;
                        StaticVars.onClick = true;
                        GameManager.OnDuckMiss();
                    }
                }
            }
            else
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Camera.main.transform.position.z;

                Debug.DrawRay(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward, Color.red, 3.0f);

                if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward,
                    out _hit, Mathf.Infinity))
                {
                    if (_hit.transform.tag == "Duck")
                    {
                        StaticVars.onClick = true;
                        DuckHealth health = _hit.transform.GetComponent<DuckHealth>();
                        health.KillDuck();
                        SetScore();
                        _duckShotNum++;
                        DuckGUIShot();
                        StaticVars.duckNum++;
                    }
                }
            }
        }
    }

    public void SetScore()
    {
        _score += 500;
        _scoreText.text = _score.ToString().PadLeft(6, '0');
    }

    public void ResetRound()
    {
        for (int i = 0; i < 10; i++)
        {
            RedDuck[i].SetActive(false);
        }
        StaticVars.duckNum = 1;
    }

    public void DuckGUIShot()
    {
        RedDuck[StaticVars.duckNum - 1].SetActive(true);
    }

    public void DuckGUI()
    {
        print("duckNum = " + StaticVars.duckNum);
        switch (StaticVars.duckNum)
        {
            case 1:
                _animator.Play("1"); break;
            case 2:
                _animator.Play("2"); break;
            case 3:
                _animator.Play("3"); break;
            case 4:
                _animator.Play("4"); break;
            case 5:
                _animator.Play("5"); break;
            case 6:
                _animator.Play("6"); break;
            case 7:
                _animator.Play("7"); break;
            case 8:
                _animator.Play("8"); break;
            case 9:
                _animator.Play("9"); break;
            case 10:
                _animator.Play("10"); break;
            default: break;
        }
    }

    public void DuckGUIStop()
    {
        _animator.Play("no flash");
    }

    public void ResetBullets()
    {
        _bulletAmount = MaxBullets;
        Bullet3.SetActive(true);
        Bullet2.SetActive(true);
        Bullet1.SetActive(true);
    }

    public void BulletGUI(int bullets)
    {
        if (bullets == 2)
        {
            Bullet3.SetActive(false);
        }
        else if (bullets == 1)
        {
            Bullet3.SetActive(false); Bullet2.SetActive(false);
        }
        else if (bullets <= 0)
        {
            Bullet3.SetActive(false); Bullet2.SetActive(false); Bullet1.SetActive(false);
        }
        else
        {
            Bullet3.SetActive(true); Bullet2.SetActive(true); Bullet1.SetActive(true);
        }
    }

    public void RoundNum()
    {
        if (_duckShotNum > 6)
        {
            Source.PlayOneShot(Win, 1);
            StaticVars.roundNum++;
            _roundText.text = "R = " + StaticVars.roundNum.ToString();
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
        _duckShotNum = 0;
    }

    public void ClickOn()
    {
        StaticVars.onClick = false;
    }
}
