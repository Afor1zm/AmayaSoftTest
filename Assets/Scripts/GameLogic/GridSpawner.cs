using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] [Tooltip("Префаб ячейки")] private GameObject gridElement;
    [SerializeField] private LevelSettings levelsSettings;
    [SerializeField] private VisualEffects visualEffects;
    private int gridLength;
    private int gridHeight;    
    private float stepSpawnX;
    private float stepSpawnY;
    private PoolingCards pool;
    private LevelLoader levelLoader;

    private void Awake()
    {
        pool = GetComponent<PoolingCards>();
        levelsSettings = GetComponent<Settings>().GetSettings();
        levelLoader = GetComponent<LevelLoader>();
    }

    public void SpawnGrid(int level)
    {
        int gridCount = 0;
        stepSpawnX = gridElement.GetComponent<BoxCollider2D>().size.x;
        stepSpawnY = gridElement.GetComponent<BoxCollider2D>().size.y;
        gridHeight = levelsSettings.height[level];
        gridLength = levelsSettings.length[level];
        for (int i = 0; i < gridHeight; i++)
        {
            for (int y = 0; y < gridLength; y++)
            {
                var newElementObject = Instantiate(gridElement, new Vector3(stepSpawnX * y, stepSpawnY * i, 0), Quaternion.identity);                
                newElementObject.GetComponentInChildren<ObjectData>().Init(pool.GetPooledCards()[gridCount]);
                newElementObject.GetComponent<ObjectClickReciever>()._levelCompletedEvent.AddListener(levelLoader.IncrimentCurrentLevel);
                newElementObject.AddComponent(typeof(VisualEffects));                
                levelLoader.AddGridElement(newElementObject);
                gridCount++;
                visualEffects.StartBounce(newElementObject);
            }
        }
    }
}
