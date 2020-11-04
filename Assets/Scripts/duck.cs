using UnityEngine;

public class duck : MonoBehaviour
{
    public AudioClip Audio;
    public float Speed;
    public bool Fly = true;
    public static bool IsDuck = false;
    public static bool IsDuckDie = false;

    public static duck Duck;

    private Animator _anim;
    private float _curTime;

    // Start is called before the first frame update
    void Start()
    {
        Duck = this;
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Fly)
        {
            float x = gameObject.transform.position.x + 0.5f * Speed;
            float y = gameObject.transform.position.y + 0.5f * Speed;
            gameObject.transform.position = new Vector3(x, y, 0);
            _curTime = Time.time;
        }
        else
        {
            if (Time.time - _curTime < 1.0f)
            {
                _anim.SetBool("IsFly", false);
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.Stop();
            }
            else
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y - 0.5f * duck.Duck.Speed;
                gameObject.transform.position = new Vector3(x, y, 0);

                _anim.SetBool("IsDie", true);

                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(Audio, 0.3f);

                if (y < -3.0f)
                {
                    Destroy(gameObject);
                    IsDuckDie = true;
                    IsDuck = true;
                }
            }
        }
    }
}
