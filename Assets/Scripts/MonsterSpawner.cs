using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterPrefab;

    private GameObject spawnedMonster;
    [SerializeField]
    private Transform leftPos, rightPos;
    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnedMonsters());
    }
    IEnumerator SpawnedMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterPrefab.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterPrefab[randomIndex]);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
