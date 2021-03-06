using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static bool defeat;

    public static bool PlayerHasBeenDefeated()
    {
        return defeat;
    }

    private static void InvokeDefeat()
    {
        var activeScene = SceneManager.GetActiveScene();
        //activeScene.buildIndex
        SceneManager.LoadScene("LoseScene", LoadSceneMode.Additive);
        defeat = true;
    }

    private void Awake()
    {
        Defeat.OnDefeat += InvokeDefeat;
    }
}
