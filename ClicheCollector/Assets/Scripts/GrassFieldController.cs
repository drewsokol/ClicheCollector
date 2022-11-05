using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassFieldController : MonoBehaviour
{
    [SerializeField] GrassColorChanger.grassstate state;
    private GrassColorChanger[] grassPatches;
    bool changing;

    // Start is called before the first frame update
    void Start()
    {
        grassPatches = GetComponentsInChildren<GrassColorChanger>();
        changing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(grassPatches[0].getState() != state)
        {
            changing = true;
            startRoutine();
        }
    }

    void startRoutine()
    {
        StartCoroutine(updatePatches());
    }

    //update children to new state
    //need a better way....way too many objects...
    IEnumerator updatePatches()
    {
        if(changing == true)
        {
            foreach (var patch in grassPatches)
            {
                patch.setState(state);
            }
        }

        changing = false;

        yield return null;
    }
}
