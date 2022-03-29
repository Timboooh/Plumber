using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConnectionHandler : MonoBehaviour
{
    public bool XPos, XNeg, YPos, YNeg, ZPos, ZNeg = false;

    public bool oriXPos, oriXNeg, oriYPos, oriYNeg, oriZPos, oriZNeg;

    public ConnectionHandler()
    {
        oriXPos = XPos;
        oriXNeg = XNeg;
        oriYPos = YPos;
        oriYNeg = YNeg;
        oriZPos = ZPos;
        oriZNeg = ZNeg;

    }

    public void Awake()
    {
        UpdateConnections(gameObject.transform.localEulerAngles);
    }

    public void UpdateConnections(Vector3 angles)
    {
        int xRotations = ((int)angles.x+360) / 90 % 4;
        int yRotations = ((int)angles.y+360) / 90 % 4;
        int zRotations = ((int)angles.z+360) / 90 % 4;

        Debug.LogWarning($"{angles.x}:{angles.y}:{angles.z}");
        Debug.LogWarning($"{xRotations}:{yRotations}:{zRotations}");

        XPos = oriXPos;
        XNeg = oriXNeg;
        YPos = oriYPos;
        YNeg = oriYNeg;
        ZPos = oriZPos;
        ZNeg = oriZNeg;

        for (int i = 0; i < xRotations; i++)
        {
            bool YPosOld = YPos;
            YPos = ZNeg;
            ZNeg = YNeg;
            YNeg = ZPos;
            ZPos = YPosOld;
        }

        for (int i = 0; i < yRotations; i++)
        { 
            bool ZNegOld = ZNeg;
            ZNeg = XPos;
            XPos = ZPos;
            ZPos = XNeg;
            XNeg = ZNegOld;
        }

        for (int i = 0; i < zRotations; i++)
        {
            bool XPosOld = XPos;
            XPos = YNeg;
            YNeg = XNeg;
            XNeg = YPos;
            YPos = XPosOld;
        }
    }

    public Vector3Int[] GetSpotsToCheck()
    {
        List<Vector3Int> spotsToCheck = new List<Vector3Int>();
        if (XPos) spotsToCheck.Add(Vector3Int.left);
        if (XNeg) spotsToCheck.Add(Vector3Int.right);

        if (YPos) spotsToCheck.Add(Vector3Int.up);
        if (YNeg) spotsToCheck.Add(Vector3Int.down);

        if (ZPos) spotsToCheck.Add(Vector3Int.forward);
        if (ZNeg) spotsToCheck.Add(Vector3Int.back);

        return spotsToCheck.ToArray();
    }
}
