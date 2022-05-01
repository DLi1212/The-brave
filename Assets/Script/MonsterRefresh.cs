using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRefresh : MonoBehaviour
{
    [SerializeField] private GameObject Monster;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int Num;
    private float timer;
    private int numObjects;

    void Update()
    {
        timer += Time.deltaTime;
        while (timer > 15)
        {
            timer = 0;
            numObjects = transform.childCount;
            if (numObjects < Num)
            {
                GameObject mObjectClone = Instantiate(Monster, spawnPoint.position, Quaternion.identity);
                mObjectClone.SetActive(true);
                mObjectClone.transform.SetParent(transform);
            }
        }

    }

}

