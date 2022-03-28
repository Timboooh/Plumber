using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Pipe : MonoBehaviour
{
    public bool StartPipe = false;
    public bool EndPipe = false;

    public Vector3 Position;
    public Vector3 Rotation;

    private bool IsInGrid = false;

    private Grid parentGrid;
    // Start is called before the first frame update
    void Start()
    {
        parentGrid = GetComponentInParent<Grid>();

        if (StartPipe || EndPipe)
        {
            var interactable = GetComponent<Interactable>();
            var throwable = GetComponent<Throwable>();
            
            Destroy(throwable);
            Destroy(interactable);

            parentGrid.SnapToGrid(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPickup()
    {

    }

    public void OnDetach()
    {
        parentGrid.SnapToGrid(this, true);
    }

    public void OnHeldUpdate()
    {
    }
}
