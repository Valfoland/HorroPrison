using UnityEngine;

namespace Scenes.Scripts
{
    [CreateAssetMenu(fileName = "PrefabsContainer", menuName = "Scriptable Objects/PrefabsContainer")]
    public class PrefabsContainer : ScriptableObject
    {
        [field: SerializeField] public LoadingScreen LoadingScreen { get; private set; }

        [field: SerializeField] public LoadingScreen MenuScreen { get; private set; }

        [field: SerializeField] public LoadingScreen ShopScreen { get; private set; }

        [field: SerializeField] public LoadingScreen BattlePassScreen { get; private set; }

        [field: SerializeField] public LoadingScreen LevelScreen { get; private set; }
    }
}