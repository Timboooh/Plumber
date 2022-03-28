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
        Vector3Int[] spotsToCheck = pipe.Connections.GetSpotsToCheck();
        bool foundSpot = false;
        int checkingIndex = 0;
        while (!foundSpot)
        {
            Vector3Int newSpot = gridPosition + spotsToCheck[checkingIndex];
            foundSpot = (ObjectGrid[newSpot.x, newSpot.y, newSpot.z] != null);
        }
        if (!foundSpot)
        {
            Debug.LogWarning("Pipe not able to attach to other pipe");
            return false;
        }

        return true;
    }

    public bool AddToGrid(Pipe pipe, Vector3Int gridPosition, Vector3 wantedRotation, bool ignoreChecks = false)
    {
        if (!ignoreChecks && !CanAddToGrid(pipe, gridPosition)) return false;

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
