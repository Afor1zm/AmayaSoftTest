using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    private CardData cardData;   
    public CardData CardData { get => cardData; }
    public void Init(CardData initCardData)
    {
        cardData = initCardData;
        GetComponent<SpriteRenderer>().sprite = cardData.Sprite;
    }
}
