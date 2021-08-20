using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class ObjectClickReciever : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CardData winnerCardData;
    [SerializeField] public UnityEvent _levelCompletedEvent;
    private VisualEffects visualEffects;
    private void Start()
    {
        visualEffects = GetComponent<VisualEffects>();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.GetComponentInChildren<ObjectData>().CardData == winnerCardData)
        {
            StartCoroutine(VisualCoroutine());
        }

        else 
        {
            visualEffects.StartShake(gameObject.GetComponentInChildren<ObjectData>().gameObject);            
        }            
    }

    public void GetWinnerCard(CardData cardData)
    {
        winnerCardData = cardData;       
    }

    private IEnumerator VisualCoroutine()
    {
        visualEffects.StartBounce(gameObject.GetComponentInChildren<ObjectData>().gameObject);
        visualEffects.StartStarsRain(gameObject);
        yield return new WaitForSeconds(1);
        _levelCompletedEvent.Invoke();
    }
}
