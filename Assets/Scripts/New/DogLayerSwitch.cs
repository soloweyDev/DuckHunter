using UnityEngine;

public class DogLayerSwitch : MonoBehaviour
{
    public int sortingOrder = 0;
    private SpriteRenderer _sprite;

    void SwitchLayerBack()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sortingLayerName = "Dog";
    }

    void SwitchLayerFront()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sortingLayerName = "Foreground";
    }
}
