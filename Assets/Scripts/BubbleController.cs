using System;
using System.Collections;
using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class BubbleController : MonoBehaviour
{
    [SerializeField] private float _minDelay = 10f;
    [SerializeField] private float _maxDelay = 20f;
    
    [SerializeField] private ParticleSystem _bubbles;
    [SerializeField] private EventReference _bubbleSoundEvent;
    
    private void Start()
    {
        StartCoroutine(PlayParticlesRandomly());
    }

    private IEnumerator PlayParticlesRandomly()
    {
        while (true)
        {
            float waitTime = Random.Range(_minDelay, _maxDelay);
            yield return new WaitForSeconds(waitTime);

            _bubbles.Play();
            RuntimeManager.PlayOneShotAttached(_bubbleSoundEvent, gameObject);
        }
    }
}
