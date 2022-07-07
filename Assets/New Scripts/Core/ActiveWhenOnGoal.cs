using UnityEngine;

namespace Throwing_Self.Assets.New_Scripts
{
    
    public class ActiveWhenOnGoal : MonoBehaviour
    {
        [SerializeField] new private GameObject gameObject;

        private void Active () {
            gameObject.SetActive(true);
        }

        private void Start () {
            Goal.OnGoal += Active;
        }

        private void OnDestroy()
        {
            Goal.OnGoal -= Active;
        }
    }
}