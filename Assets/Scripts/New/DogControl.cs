using UnityEngine;

public class DogControl : MonoBehaviour
{
    private Animator anim;
    private AudioSource source;

    public AudioClip laugh;
    public AudioClip bark;
    public AudioClip gotDuck;
    public AudioClip intro;

    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        GameManager.OnDuckDeath += PlayPopup;
        GameManager.OnDuckFlyAway += PlayLaugh;
        GameManager.OnNewRound += PlayNewRound;
    }

    public void SpawnDucks()
    {
        GameManager.OnSpawnDucks();
    }

    public void PlayLaugh()
    {
        anim.Play("dog laugh");
    }

    public void PlayBark()
    {
        source.PlayOneShot(bark, 1);
    }

    private void PlayPopup()
    {
        anim.Play("dog popup");
        source.PlayOneShot(gotDuck, 1);
    }

    public void PlayNewRound()
    {
        anim.Play("dog walking");
    }
}
