using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] float detectionRadius;

    public bool highlighted;
    private ParticleSystem highlightParticle;

    public void Start()
    {
        Debug.Log("Faucet Started");
        highlighted = false;
        highlightParticle = GetComponent<ParticleSystem>();
        highlightParticle.Stop();
    }

    public void Update()
    {
    }

    public void FixedUpdate()
    {
        
    }

    void OnTriggerEnter(Collider detected)
    {
        if (!highlighted && LayerMask.LayerToName(detected.gameObject.layer) == "Player")
        {
            AddHighlight();
        }
    }

    void OnTriggerExit(Collider leaving)
    {
        if (highlighted && LayerMask.LayerToName(leaving.gameObject.layer) == "Player")
        {
            RemoveHighlight();
        }
    }

    public void Activate()
    {
        Debug.Log("Faucet Interacted with");
    }

    public void AddHighlight()
    {
        highlighted = true;
        highlightParticle.Play();
        Debug.Log("Highlight On");
    }

    public void RemoveHighlight()
    {
        highlighted = false;
        highlightParticle.Stop();
        Debug.Log("Highlight Off");
    }

}
