using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] [Tooltip("Префаб ячейки")] private GameObject gridElement;
    [SerializeField] private LevelSettings levelsSettings;
    [SerializeField] private VisualEffects visualEffects;
    private PoolingCards pool;
    private LevelLoader levelLoader;
    private BoxCollider2D gridElementCollider;
    private int gridLength;
    private int gridHeight;    
    private float stepSpawnX;
    private float stepSpawnY;    

    private void Awake()
    {
        GetCachedData();
    }

    public void SpawnGrid(int level)
    {
        int gridCount = 0;
        GetGridparametres(level);
        CreateGrid(gridCount);
    }

    private void InitializationCreatedElement(GameObject newElement, int pooledIndex)
    {
        newElement.GetComponentInChildren<ObjectData>().Init(pool.GetPooledCards()[pooledIndex]);
        newElement.GetComponent<ObjectClickReciever>()._levelCompletedEvent.AddListener(levelLoader.IncrimentCurrentLevel);
        newElement.AddComponent(typeof(VisualEffects));
    }

    private void GetCachedData()
    {
        pool = GetComponent<PoolingCards>();
        levelsSettings = GetComponent<Settings>().GetSettings();
        levelLoader = GetComponent<LevelLoader>();
        gridElementCollider = gridElement.GetComponent<BoxCollider2D>();
    }
    private void GetGridparametres(int level)
    {
        stepSpawnX = gridElementCollider.size.x;
        stepSpawnY = gridElementCollider.size.y;
        gridHeight = levelsSettings.height[level];
        gridLength = levelsSettings.length[level];
    }

    private void CreateGrid(int numberOfElements)
    {
        for (int i = 0; i < gridHeight; i++)
        {
            for (int y = 0; y < gridLength; y++)
            {
                GameObject newElementObject = Instantiate(gridElement, new Vector3(stepSpawnX * y, stepSpawnY * i, 0), Quaternion.identity);
                InitializationCreatedElement(newElementObject, numberOfElements);
                levelLoader.AddGridElement(newElementObject);
                numberOfElements++;
                visualEffects.StartBounce(newElementObject);
            }
        }
    }
}
