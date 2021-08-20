using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeInScreen : MonoBehaviour
{
    [SerializeField] private Image screenObject;
    [SerializeField] private VisualEffects visualEffects;

    public void FadingIn()
    {
        visualEffects.StartFadeIn(screenObject);
    }
}
