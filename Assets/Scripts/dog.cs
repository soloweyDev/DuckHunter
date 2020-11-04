using UnityEngine;

public class dog : MonoBehaviour
{
    public float Speed;
    public AudioClip Audio;

    private Animator _anim;
    private float _curTime;
    private bool _audio = true;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _curTime = Time.time;
        duck.IsDuck = false;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.time - _curTime;
        if (delta > 3.2f && delta < 4.89f)
        {
            _anim.SetBool("IsRunner", true);
        }
        else if (delta > 8.2f && delta < 9.0f)
        {
            _anim.SetBool("IsRunner", true);
        }
        else if (delta > 9.0f && delta < 10.2f)
        {
            _anim.SetBool("IsFound", true);
        }
        else if (delta > 10.2f && delta < 11.0f)
        {
            float x = gameObject.transform.position.x + 0.2f * Speed;
            float y = gameObject.transform.position.y + 0.9f * Speed;
            gameObject.transform.position = new Vector3(x, y, 0);

            _anim.SetBool("IsUp", true);
            if (_audio)
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(Audio);
                _audio = false;
            }
        }
        else if (delta > 11.0f && delta < 12.0f)
        {
            float x = gameObject.transform.position.x + 0.2f * Speed;
            float y = gameObject.transform.position.y - 0.9f * Speed;
            gameObject.transform.position = new Vector3(x, y, 0);

            _anim.SetBool("IsDown", false);

            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 1;
        }
        else if (delta > 12.0f)
        {
            Destroy(gameObject);
            duck.IsDuck = true;
        }
        else
        {
            float x = gameObject.transform.position.x + 0.4f * Speed;
            float y = gameObject.transform.position.y;
            gameObject.transform.position = new Vector3(x, y, 0);

            _anim.SetBool("IsRunner", false);
        }
    }
}
