using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public readonly Vector3Int Size = new Vector3Int(9, 9, 9);
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
        if (!IsInGrid(gridPosition))
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
        while (!foundSpot && checkingIndex < spotsToCheck.Length)
        {
            Vector3Int newSpot = gridPosition + spotsToCheck[checkingIndex];

            if (IsInGrid(newSpot))
                foundSpot = (ObjectGrid[newSpot.x, newSpot.y, newSpot.z] != null);

            checkingIndex++;
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

        Debug.Log($"X: {gridPosition.x}, Y: {gridPosition.y} Z: {gridPosition.z}");
        ObjectGrid[gridPosition.x, gridPosition.y, gridPosition.z] = pipe;
        pipe.IsInGrid = true;
        return true;
    }

    public void RemoveFromGrid(Pipe pipe)
    {
        pipe.IsInGrid = false;
        ObjectGrid[pipe.Position.x, pipe.Position.y, pipe.Position.z] = null;
    }

    private bool IsInGrid(Vector3Int position)
    {
        return position.x < Size.x && position.x >= 0 &&
               position.y < Size.y && position.y >= 0 &&
               position.z < Size.z && position.z >= 0;
    }
}
