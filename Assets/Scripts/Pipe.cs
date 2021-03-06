using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using ExtensionMethods;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    public ConnectionHandler Connections;

    [HideInInspector]
    public Vector3Int Position = new Vector3Int(-1, -1, -1);

    [HideInInspector]
    public Vector3 Rotation;

    private bool _isInGrid = false;

    [HideInInspector]
    public bool IsInGrid
    {
        get { return _isInGrid; }
        set
        {
            _isInGrid = value;
            SetStationary(value);
        }
    }

    public Grid parentGrid;
    private Rigidbody rigidbody;
    
    void Start()
    {
        parentGrid = GetComponentInParent<Grid>();
        rigidbody = GetComponent<Rigidbody>();

        if (Connections == null) Connections = GetComponent<ConnectionHandler>();
        if (Connections == null) Connections = new ConnectionHandler();

        //var WantedRotation = gameObject.transform.localEulerAngles.RoundToNearestMultiple(90);
        //Connections.UpdateConnections(WantedRotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetStationary(bool newValue)
    {
        rigidbody.isKinematic = newValue;
        rigidbody.useGravity = !newValue;
    }
    
    public void OnPickup()
    {
        parentGrid.RemoveFromGrid(this);
    }

    public void OnDetach()
    {
        //Move back into grid
        gameObject.transform.localPosition = gameObject.transform.localPosition.Clamp(0, parentGrid.Size.x, 0, parentGrid.Size.y, 0, parentGrid.Size.z);

        //Round position
        var WantedPosition = Vector3Int.RoundToInt(gameObject.transform.localPosition);
        var WantedRotation = gameObject.transform.localRotation.eulerAngles.RoundToNearestMultiple(90);

        Connections.UpdateConnections(WantedRotation);

        //Try to add to the grid
        if (parentGrid.AddToGrid(this, WantedPosition, WantedRotation)) 
        {
            Position = WantedPosition;
            gameObject.transform.localPosition = WantedPosition;
            gameObject.transform.localRotation = Quaternion.Euler(WantedRotation);
        };
    }

    public void OnHeldUpdate()
    {
    }

    public bool CanConnectTo(Pipe pipe, Vector3Int connectionPoint)
    {
        connectionPoint *= -1; //Invert vector
        foreach(var connectionVector in Connections.ConnectionVectors)
        {
            if (connectionPoint == connectionVector) return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "Pipe: " + Position.x + " - " + Position.y + " - " + Position.z;
    }
}
