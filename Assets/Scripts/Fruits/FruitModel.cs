using System;
using UnityEngine;

public class FruitModel
{
    public bool HasSpawned { get; set; }
    public Vector3 Position { get; set; }

    #region Custom Settings
    public string Name { get; private set; }
    public int Luck { get; private set; }
    #endregion

    #region Default Settings
    public float XSpawnMin { get; private set; }
    public float XSpawnMax { get; private set; }
    public float ZSpawnMin { get; private set; }
    public float ZSpawnMax { get; private set; }
    public Vector3 HideLocation { get; private set; }
    #endregion

    public FruitModel(int luck, string name)
    {
        HasSpawned = false;

        #region Custom Settings
        Luck = luck;
        Name = name;
        #endregion

        #region Default Settings
        XSpawnMin = -4.5f;
        XSpawnMax = 4.5f;
        ZSpawnMin = -4.5f;
        ZSpawnMax = 4.5f;
        HideLocation = new Vector3(0, -1, 0);
        #endregion

        Position = HideLocation;
    }
}
