using UnityEngine;
using System;

public class Defeat : MonoBehaviour
{

    
    public static event Action OnDefeat;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Derrota...");
        OnDefeat?.Invoke();
    }
}
