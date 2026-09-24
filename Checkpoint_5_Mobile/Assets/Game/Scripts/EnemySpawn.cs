using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] Factory factory;
    int typeEnemy;

    void Start()
    {
        SpawnEnemy1();
        StartCoroutine(Spawn());
    }

    void Update()
    {
        
    }

    public void SpawnEnemy1()
    {
        factory.CreateEnemy(EnemyType.Enemy1, transform.position);
    }

    public void SpawnEnemy2()
    {
        factory.CreateEnemy(EnemyType.Enemy2, transform.position);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5);

        typeEnemy = Random.Range(1, 3);

        if(typeEnemy == 1)
        {
            SpawnEnemy1();
        }

        if (typeEnemy == 2)
        {
            SpawnEnemy2();
        }

        StartCoroutine(Spawn());
    }
}