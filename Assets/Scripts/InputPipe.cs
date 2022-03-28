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

        var interactable = GetComponent<Interactable>();
        var throwable = GetComponent<Throwable>();

        Destroy(interactable);
        Destroy(throwable);

        pipe.parentGrid.AddToGrid(pipe, Vector3Int.RoundToInt(pipe.transform.localPosition), pipe.transform.localEulerAngles, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
