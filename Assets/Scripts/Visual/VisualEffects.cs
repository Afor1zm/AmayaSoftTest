using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class VisualEffects : MonoBehaviour
{
    public void StartBounce(GameObject animatedObject)
    {
        Sequence bounceSequence = DOTween.Sequence();
        bounceSequence.Append(animatedObject.transform.DOScale(0f, 0.25f));
        bounceSequence.Append(animatedObject.transform.DOScale(0.9f, 0.25f));
        bounceSequence.Append(animatedObject.transform.DOScale(1.2f, 0.25f));
        bounceSequence.Append(animatedObject.transform.DOScale(1f, 0.25f));
    }

    public void StartFadeInText(Text text)
    {
        text.DOFade(0f, 0f);
        text.DOFade(1f, 3f);
    }

    public void StartShake(GameObject gameObject)
    {
        gameObject.transform.DOShakeScale(2.0f, strength: new Vector3(1.2f, 1.2f, 0), vibrato: 5, randomness: 1, fadeOut: true);
    }

    public void StartStarsRain(ParticleSystem particles)
    {
        particles.Play();
    }

    public void StartFadeIn(Image animatedObject)
    {        
        animatedObject.DOFade(0f, 0f);
        animatedObject.DOFade(0.5f, 3f);
    }
}
