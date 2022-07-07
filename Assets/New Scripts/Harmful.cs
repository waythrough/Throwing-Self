using UnityEngine;
using System;

namespace Throwing_Self.Assets.New_Scripts
{
    public class Harmful : MonoBehaviour
    {
        public static Action OnHarmful;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player")) {
                var ballBody = other.GetComponent<Rigidbody2D>();
                ballBody.isKinematic = true;
                ballBody.velocity = Vector2.zero;
                //ballBody.MovePosition(transform.position);
                OnHarmful?.Invoke();
            }
        }
    }
}