using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionHandler : MonoBehaviour
{
    public bool XPos, XNeg, YPos, YNeg, ZPos, ZNeg = false;

    private Vector3Int[] connections = new Vector3Int[6];

    public ConnectionHandler()
    {
        UpdateConnections();
    }

    public void UpdateConnections()
    {
        connections = Bool2Vect3(XPos, XNeg, YPos, YNeg, ZPos, ZNeg);

       
    }


    //Get vectors from booleans
    private Vector3Int[] Bool2Vect3(bool xPos, bool xNeg, bool yPos, bool yNeg, bool zPos, bool zNeg)
    {
        Vector3Int[] Vec3s = new Vector3Int[6];

        Vec3s[0] = xPos ? Vector3Int.left : Vector3Int.zero;
        Vec3s[1] = xNeg ? Vector3Int.right : Vector3Int.zero;

        Vec3s[2] = yPos ? Vector3Int.up : Vector3Int.zero;
        Vec3s[3] = yNeg ? Vector3Int.down : Vector3Int.zero;

        Vec3s[4] = zPos ? Vector3Int.forward : Vector3Int.zero;
        Vec3s[5] = zNeg ? Vector3Int.back : Vector3Int.zero;

        return Vec3s;
    }

    private Vector3Int[] RotateVects(Vector3Int vects, Vector3 eulerRotation)
    {

    }
}
