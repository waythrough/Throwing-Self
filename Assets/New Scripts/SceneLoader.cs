using UnityEngine;
using UnityEngine.SceneManagement;

namespace Throwing_Self.Assets.New_Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private int buildIndex;

        public void Load () {
            SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Single);
        }
    }
}