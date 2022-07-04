using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private float range;

    private IDirectionProvider directionProvider;

    private void Awake()
    {
        origin.TryGetComponent(out directionProvider);
    }

    private void Update()
    {
        transform.up = directionProvider.GetDirection();
        transform.position = (Vector2)origin.position + directionProvider.GetDirection() * range;
    }
}
