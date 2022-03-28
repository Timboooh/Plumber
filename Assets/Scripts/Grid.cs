using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector3Int Size = new Vector3Int(8, 8, 8);
    private Pipe[,,] ObjectGrid = null;

    // Start is called before the first frame update
    void Start()
    {
        ObjectGrid = new Pipe[Size.x, Size.y, Size.z];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CanAddToGrid(Pipe pipe, Vector3Int gridPosition)
    {
        //Check if pipe is within grid
        if (!(gridPosition.x <= Size.x && gridPosition.x >= 0 &&
              gridPosition.y <= Size.y && gridPosition.y >= 0 &&
              gridPosition.z <= Size.z && gridPosition.z >= 0))
        {
            Debug.LogError("Pipe " + pipe + "is not within the grid");
            return false;
        }

        //Check if spot is available
        if (ObjectGrid[gridPosition.x, gridPosition.y, gridPosition.z] != null)
        {
            Debug.LogWarning("Spot already occupied");
            return false;
        }

        //Check if spot has pipes to attach to
        //TODO
        if (false)
        {
            return false;
        }

        return true;
    }

    public bool AddToGrid(Pipe pipe, Vector3Int gridPosition, Vector3 wantedRotation)
    {
        if (!CanAddToGrid(pipe, gridPosition)) return false;

        //Add pipe to spot
        ObjectGrid[gridPosition.x, gridPosition.y, gridPosition.z] = pipe;
        pipe.IsInGrid = true;
        return true;
    }

    public void RemoveFromGrid(Pipe pipe)
    {
        pipe.IsInGrid = false;
        ObjectGrid[pipe.Position.x, pipe.Position.y, pipe.Position.z] = null;
    }
}
