using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionTextChanger : MonoBehaviour
{
    [SerializeField] private Text missionText;
    [SerializeField] private VisualEffects visualEffects;
    public void SetMissionText(CardData winnerCardData)
    {
        missionText.text = $" Find {winnerCardData.Identifier}";
        visualEffects.StartFadeInText(missionText);
    }
}
