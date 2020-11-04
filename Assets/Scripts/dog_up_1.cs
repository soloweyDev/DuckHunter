using UnityEngine;

public class dog_up_1 : MonoBehaviour
{
    public float Speed;

    private float _curTime;

    // Start is called before the first frame update
    void Start()
    {
        _curTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.time - _curTime;
        if (delta < 2.0f)
        {
            float y = gameObject.transform.position.y + 0.9f * Speed;
            if (y > -0.82f)
            {
                y = -0.82f;
            }
            gameObject.transform.position = new Vector3(0, y, 0);
        }
        else
        {
            float y = gameObject.transform.position.y - 0.9f * Speed;
            if (y < -2.3f)
            {
                Destroy(gameObject);
                duck.IsDuckDie = false;
            }
            gameObject.transform.position = new Vector3(0, y, 0);
        }
    }
}
