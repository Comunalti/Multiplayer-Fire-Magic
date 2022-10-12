using Unity.Mathematics;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] private bool isQuitting;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if(isQuitting){return;}
        Instantiate(prefab,transform.position,quaternion.identity);
    }
}
