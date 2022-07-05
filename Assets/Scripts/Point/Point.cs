using UnityEngine;
using System;

public class Point : MonoBehaviour
{
    public static event Action OnPlayerEnter;
    public static event Action OnPlayerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerExit?.Invoke();
        }
    }
}
