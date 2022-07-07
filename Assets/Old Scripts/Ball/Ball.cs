using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 origin;
    private bool canJump;

    private void Start()
    {
        origin = transform.position;
    }

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(!canJump) {
            return;
        }

        if(!Input.GetMouseButtonDown(0)) {
            return;
        }
    }
}
