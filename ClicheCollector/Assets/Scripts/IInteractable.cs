using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Start();
    //activate the item
    public void Activate();
    //highlight item, called when in radius of player
    public void AddHighlight();
    //remove highlight when player is outside radius
    public void RemoveHighlight();
}
