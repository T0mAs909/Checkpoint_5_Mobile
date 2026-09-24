using UnityEngine;

public enum EnemyType
{
    Enemy1,
    Enemy2
}

public class Factory : MonoBehaviour
{
    [SerializeField] GameObject enemy1Prefab;
    [SerializeField] GameObject enemy2Prefab;

    public GameObject CreateEnemy(EnemyType enemyType, Vector3 enemyPosition)
    {
        GameObject prefab = null;
        switch (enemyType)
        {
            case EnemyType.Enemy1:
                prefab = enemy1Prefab;
                break;
            case EnemyType.Enemy2:
                prefab = enemy2Prefab;
                break;
        }
        return Instantiate(prefab, enemyPosition, prefab.transform.rotation);
    }
}