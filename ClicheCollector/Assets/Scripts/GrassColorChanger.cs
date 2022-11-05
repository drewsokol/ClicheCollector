using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassColorChanger : MonoBehaviour
{
    public enum grassstate { lush, dead};

    [SerializeField] float speed;
    [SerializeField] Color lushColor;
    [SerializeField] Color deadColor;
    [SerializeField] grassstate state;
    
    private Color currentColor;
    private MeshRenderer[] grassRenderers;

    // Start is called before the first frame update
    void Start()
    {
        grassRenderers = GetComponentsInChildren<MeshRenderer>();
        if(state == grassstate.lush)
        {
            currentColor = lushColor;
        }
        else
        {
            currentColor = deadColor;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((state == grassstate.lush && currentColor != lushColor) || (state == grassstate.dead && currentColor != deadColor))
        {
            changeColor();
        }
    }

    private void changeColor()
    {
        Color targetColor = grassstate.lush == state ? lushColor : deadColor;
        currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * speed);
        foreach (var r in grassRenderers)
        {
            r.material.color = currentColor;
        }
    }

    public void setState(grassstate newState)
    {
        state = newState;
    }

    public grassstate getState()
    {
        return state;
    }
}
