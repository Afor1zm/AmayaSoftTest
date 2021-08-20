using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 10)]
public class BundleScriptableObject : ScriptableObject
{
    [SerializeField] private List <CardData> _cardData;
    public List <CardData> CardData { get => _cardData; }    
}
