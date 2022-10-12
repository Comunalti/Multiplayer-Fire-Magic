using KevinCastejon.MoreAttributes;
using UnityEngine;

namespace HealthSystem
{
    public class LocalPlayerManager : MonoBehaviour
    {
        public static LocalPlayerManager instance;
        private void Awake()
        {
            instance = this;
        }

        [ReadOnlyOnPlay] public Camera camera;
    }
}