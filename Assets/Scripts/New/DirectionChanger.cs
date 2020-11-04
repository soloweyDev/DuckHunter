using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    public enum Changer
    {
        Horizontal,
        Vertical
    }
    public Changer direction;
    
    void Start()
    {
        GameManager.OnDuckShot += TurnOff;
        GameManager.OnDuckMiss += TurnOff;
        GameManager.OnSpawnDucks += TurnOn;
    }

    public void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.tag == "Duck")
        {
            DuckMovement movement = hit.transform.GetComponent<DuckMovement>();

            if (direction == Changer.Horizontal)
            {
                movement.DirectionChanger(new Vector3(-1.0f, 1.0f, 0.0f));
            }
            else if (direction == Changer.Vertical)
            {
                movement.DirectionChanger(new Vector3(1.0f, -1.0f, 0.0f));
            }
        }
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
}
