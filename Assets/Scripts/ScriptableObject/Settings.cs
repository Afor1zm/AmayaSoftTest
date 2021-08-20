using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private LevelSettings levelSettings;

    public LevelSettings GetSettings()
    {
        return levelSettings;
    }
}
