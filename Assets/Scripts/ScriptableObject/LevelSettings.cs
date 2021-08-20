using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Levels settings", menuName = "Level settings data", order = 10)]
public class LevelSettings : ScriptableObject
{
    [SerializeField] [Tooltip("Количество уровней")] public List<int> levels;
    [SerializeField] [Tooltip("Количество ячеек по ширине в уровне")] public List<int> length;
    [SerializeField] [Tooltip("Количество ячеек по длинне в уровне")] public List<int> height;
    [SerializeField] [Tooltip("Набор в уровне")] public List<BundleScriptableObject> bundles;
}
