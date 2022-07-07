using UnityEngine;
using System;

namespace Throwing_Self.Assets.New_Scripts
{
    public abstract class GameState {
        public abstract void Invoke ();
    }

    public class Victory : GameState {
        public static Victory victory = new Victory();

        public event Action OnVictory;

        public override void Invoke()
        {
            Debug.Log("Victory");
            OnVictory?.Invoke();
        }
    }

    public class Defeat : GameState {
        public static event Action OnDefeat;

        public override void Invoke()
        {
            Debug.Log("Defeat");
            OnDefeat?.Invoke();
        }
    }
}