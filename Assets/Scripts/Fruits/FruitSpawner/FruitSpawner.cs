using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private FruitView[] fruitViews;
    private int TotalLuck;

    private void Start()
    {
        SubscribeToFruits();
        GetTotalLuck();
        SpawnFruit();
    }

    private void SubscribeToFruits()
    {
        foreach (FruitView view in fruitViews)
        {
            view.FruitSpawnRequest.AddListener(SpawnFruit);
        }
    }

    private void GetTotalLuck()
    {
        TotalLuck = 0;
        foreach (FruitView view in fruitViews)
        {
            TotalLuck += view.Luck;
        }
    }

    private void SpawnFruit()
    {
        GetRandomFruit().TriggerSpawn();
    }

    private FruitView GetRandomFruit()
    {
        int randomNumber = Random.Range(0, TotalLuck);

        int cumulativeLuck = 0;
        foreach (FruitView view in fruitViews)
        {
            cumulativeLuck += view.Luck;
            if (randomNumber <= cumulativeLuck)
                return view;
        }

        Debug.Log(""+ randomNumber + cumulativeLuck + TotalLuck);
        return null;
    }
}
