using UnityEngine;

public interface IDirectionProvider
{
    Vector2 GetDirection();
}

public class Direction : MonoBehaviour, IDirectionProvider
{
    [SerializeField] private Transform origin;

    private Vector2 direction;
    private Vector2 mousePositionIntoWorld;

    public Vector2 GetDirection()
    {
        return direction;
    }

    private void ComputeDirection()
    {
        direction = (mousePositionIntoWorld - (Vector2)origin.position).normalized;
    }

    private void ComputeMousePositionIntoWorld()
    {
        mousePositionIntoWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void DebugDirection () {
        print(direction);
    }

    private void Update()
    {
        ComputeMousePositionIntoWorld();
        ComputeDirection();
        DebugDirection();
    }
}
