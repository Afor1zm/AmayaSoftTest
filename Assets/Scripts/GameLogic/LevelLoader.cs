using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private UnityEvent gameEndsEvent;
    private List<GameObject> elementList = new List<GameObject>();
    private PoolingCards pool;
    private GridSpawner gridSpawner;
    private int levelCount;
    private int currentLevel = 0;
    private LevelSettings levelsSettings;

    private void Awake()
    {
        pool = GetComponent<PoolingCards>();
        gridSpawner = GetComponent<GridSpawner>();
        levelsSettings = GetComponent<Settings>().GetSettings();
    }
    private void Start()
    {        
        levelCount = levelsSettings.levels.Count;
        LoadLevel(currentLevel);
    }
    public void IncrimentCurrentLevel()
    {
        currentLevel++;
        for (int i = 0; i < elementList.Count; i++)
        {
            Destroy(elementList[i]);
        }
        elementList.Clear();
        pool.DeletePoolAndBufferData();
        if (currentLevel < levelCount)
            LoadLevel(currentLevel);
        else
        {
            gameEndsEvent.Invoke();
            currentLevel = 0;
        }
    }
    public void LoadLevel(int level)
    {
        if (currentLevel == 0)
            pool.DeleteBannedCardsData();
        if (currentLevel < levelCount)
        {
            pool.SetPoolCards(level);
            pool.SetWinnerCard();
            gridSpawner.SpawnGrid(level);
        }
    }
    public void AddGridElement(GameObject gameObject)
    {
        elementList.Add(gameObject);
    }
}
