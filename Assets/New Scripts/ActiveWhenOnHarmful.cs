using UnityEngine;
using System;

namespace Throwing_Self.Assets.New_Scripts
{
    public class ActiveWhenOnHarmful : MonoBehaviour
    {
        [SerializeField] new private GameObject gameObject;

        private void Active () {
            gameObject.SetActive(true);
        }

        private void Start () {
            Harmful.OnHarmful += Active;
        }

        private void OnDestroy()
        {
            Harmful.OnHarmful -= Active;
        }
    }
}