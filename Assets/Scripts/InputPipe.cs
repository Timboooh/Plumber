using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Pipe))]
public class InputPipe : MonoBehaviour
{
    public Pipe pipe;
    // Start is called before the first frame update
    void Start()
    {
        if (pipe == null) pipe = GetComponent<Pipe>();

        var throwable = GetComponent<Throwable>();
        var interactable = GetComponent<Interactable>();

        Destroy(throwable);
        Destroy(interactable);
        
        
    }

    bool added = false;
    // Update is called once per frame
    void Update()
    {
        if (!added)
        {
            pipe.parentGrid.AddToGrid(pipe, Vector3Int.RoundToInt(pipe.transform.localPosition), pipe.transform.localEulerAngles, true);
            added = true;
        }
    }
}
