using UnityEngine;
using System.Collections;

public class FallAndBack : MonoBehaviour
{
    [SerializeField] new private Rigidbody2D rigidbody2D;
    [SerializeField] private float secondsBeforeComeBack = 1.25f;
    private Vector3 origin;

    private Coroutine coroutine;

    private void Awake () {
        origin = transform.position;
    }

    private void Start()
    {
        coroutine = StartCoroutine(GoBack());
    }

    private void Restore () {
        transform.position = origin;
        rigidbody2D.velocity = Vector2.zero;
    }

    private IEnumerator GoBack () {
        yield return new WaitForSeconds(secondsBeforeComeBack);
        Restore();
        StopCoroutine(coroutine);
        coroutine = null;
    }

    private void Update () {
        if(coroutine == null) {
            coroutine = StartCoroutine(GoBack());
        }
    }
}
