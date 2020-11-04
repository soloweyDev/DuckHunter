using System;
using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    public static Action<Transform> PassSpawnPointTransform;

    void Start()
    {
        PassSpawnPointTransform?.Invoke(transform);
    }
}
