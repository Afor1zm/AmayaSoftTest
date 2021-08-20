using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class PoolingCards : MonoBehaviour
{    
    [SerializeField] private SetWinnerCardEvent _onSendWinnerCard;
    private CardData winnerCard;
    private LevelSettings levelsSettings;
    private BundleScriptableObject bundleSettings;
    private List<CardData> bufferCardList = new List<CardData>();
    private List<CardData> poolledCards = new List<CardData>();
    private List<CardData> bannedCards = new List<CardData>();
    private int cards;
    private int randomIndex;

    private void Awake()
    {        
        levelsSettings = GetComponent<Settings>().GetSettings();
    }
    public void SetPoolCards(int level)
    {
        bundleSettings = levelsSettings.bundles[level];
        bufferCardList.AddRange(bundleSettings.CardData);
        cards = levelsSettings.height[level] * levelsSettings.length[level];
        for (int i = 0; i < cards; i++)
        {
            randomIndex = Random.Range(0, bufferCardList.Count);
            poolledCards.Add(bufferCardList[randomIndex]);
            bufferCardList.Remove(bufferCardList[randomIndex]);
        }
    }
    public void SetWinnerCard()
    {
        if (bannedCards.Count == 0)
        {
            winnerCard = poolledCards[Random.Range(0, poolledCards.Count)];
        }
        else do
            {
                winnerCard = poolledCards[Random.Range(0, poolledCards.Count)];
            } while (bannedCards.Contains(winnerCard));
        _onSendWinnerCard.Invoke(winnerCard);
        bannedCards.Add(winnerCard);
    }

    public List<CardData> GetPooledCards()
    {
        return poolledCards;
    }

    public void DeletePoolAndBufferData()
    {
        bufferCardList.Clear();
        poolledCards.Clear();
    }

    public void DeleteBannedCardsData()
    {
        bannedCards.Clear();
    }
    [System.Serializable]
    public class SetWinnerCardEvent : UnityEvent<CardData> { }
}
