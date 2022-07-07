using UnityEngine;
using System;

namespace Throwing_Self.Assets.New_Scripts
{
    public class GameManager : MonoBehaviour
    {
        private static bool victory;
        private static bool defeat;

        public static bool isVictory () {
            return victory;
        }

        public static bool isDefeat () {
            return defeat;
        }

        public static void Notify (GameState gameState) {
            gameState.Invoke();
        }
    }
}