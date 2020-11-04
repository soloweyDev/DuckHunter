using UnityEngine;

public class DuckHealth : MonoBehaviour
{
    private Animator _animator;

    public bool isInvincible;

    void Start()
    {
        isInvincible = false;
        _animator = gameObject.GetComponent<Animator>();
        GameManager.OnDuckMiss += MakeInvincible;
        GameManager.OnDuckShot += MakeInvincible;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "KillZone")
        {
            if (StaticVars.duckNum > 10)
            {
                GameManager.OnNewRound();
                Destroy(this.gameObject);
            }
            else
            {
                GameManager.OnDuckDeath();
                Destroy(this.gameObject);
            }
        }

        if (hit.tag == "FlyAwayZone")
        {
            if (StaticVars.duckNum > 10)
            {
                GameManager.OnNewRound();
                Destroy(this.gameObject);
            }
            else
            {
                GameManager.OnDuckFlyAway();
                Destroy(this.gameObject);
            }
        }

        print(StaticVars.duckNum);
    }

    public void KillDuck()
    {
        if (isInvincible == false)
        {
            GameManager.OnDuckShot();
            _animator.Play("duck death");
        }
    }

    public void MakeInvincible()
    {
        isInvincible = true;
    }
}
