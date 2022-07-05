using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 origin;

    private void Start()
    {
        origin = transform.position;
    }

    private void Awake()
    {
        
    }
}
