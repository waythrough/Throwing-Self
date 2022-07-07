using UnityEngine;

public class ToggleHarmful : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;

    [SerializeField] private float time;

    [SerializeField] private Transform a;
    [SerializeField] private Transform b;

    private float elapsedTime;
    private bool toggle;

    private void FixedUpdate()
    {
        elapsedTime += Time.fixedDeltaTime;

        if (toggle)
        {
            var lerp = Mathf.Clamp(elapsedTime / time, 0, time);
            transform.position = Vector2.Lerp(a.position, b.position, animationCurve.Evaluate(lerp));
            if (Vector2.Distance(transform.position, b.position) < 0.001f)
            {
                toggle = false;
                elapsedTime = 0;
            }
        }

        if (!toggle)
        {
            var lerp = Mathf.Clamp(elapsedTime / time, 0, time);
            transform.position = Vector2.Lerp(b.position, a.position, animationCurve.Evaluate(lerp));
            if (Vector2.Distance(transform.position, a.position) < 0.001f)
            {
                toggle = true;
                elapsedTime = 0;
            }
        }
    }
}
