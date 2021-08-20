using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class ObjectClickReciever : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CardData winnerCardData;
    public UnityEvent _levelCompletedEvent;
    private VisualEffects visualEffects;
    private GameObject cardDataObject;
    private ParticleSystem particles;
    private CardData currnetCardData;
    private void Start()
    {
        GetCacheData();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (currnetCardData == winnerCardData)
        {
            StartCoroutine(VisualCoroutine());
        }

        else 
        {
            visualEffects.StartShake(cardDataObject);
        }            
    }

    public void GetWinnerCard(CardData cardData)
    {
        winnerCardData = cardData;       
    }

    private IEnumerator VisualCoroutine()
    {
        visualEffects.StartBounce(cardDataObject);
        visualEffects.StartStarsRain(particles);
        yield return new WaitForSeconds(1);
        _levelCompletedEvent.Invoke();
    }

    private void GetCacheData()
    {
        visualEffects = GetComponent<VisualEffects>();
        cardDataObject = gameObject.GetComponentInChildren<ObjectData>().gameObject;
        particles = gameObject.GetComponentInChildren<ParticleSystem>();
        currnetCardData = gameObject.GetComponentInChildren<ObjectData>().CardData;
    }
}
