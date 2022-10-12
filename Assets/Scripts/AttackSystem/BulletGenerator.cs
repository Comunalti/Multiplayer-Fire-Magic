using KevinCastejon.MoreAttributes;
using UnityEngine;

namespace AttackSystem
{
    public class BulletGenerator : MonoBehaviour
    {
        [SerializeField] [ReadOnlyOnPlay] private GameObject bulletPrefab;
        [SerializeField] [ReadOnlyOnPlay] private Transform pivot;
        public GameObject CreateBullet(Vector2 mouseWorldPosition, ulong clientId)
        {
            var ab =  mouseWorldPosition - (Vector2)transform.position;
            var instance = Instantiate(bulletPrefab,pivot.position,Quaternion.identity);
            instance.transform.right = ab.normalized;
            return instance;
        }
    }
}