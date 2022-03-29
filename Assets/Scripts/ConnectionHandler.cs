using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;


public class ConnectionHandler : MonoBehaviour
{
    //public bool XPos, XNeg, YPos, YNeg, ZPos, ZNeg = false;
    public Vector3Int[] ConnectionVectors = new Vector3Int[6];
    
    public bool oriXPos, oriXNeg, oriYPos, oriYNeg, oriZPos, oriZNeg;

    public ConnectionHandler()
    {
        //oriXPos = XPos;
        //oriXNeg = XNeg;
        //oriYPos = YPos;
        //oriYNeg = YNeg;
        //oriZPos = ZPos;
        //oriZNeg = ZNeg;

    }

    public void Awake()
    {
        UpdateConnections(gameObject.transform.localEulerAngles);
    }

    public void UpdateConnections(Vector3 angles)
    {
        Debug.LogWarning($"{angles.x}:{angles.y}:{angles.z}");

        //XPos = oriXPos;
        //XNeg = oriXNeg;
        //YPos = oriYPos;
        //YNeg = oriYNeg;
        //ZPos = oriZPos;
        //ZNeg = oriZNeg;

        var originalVects = BoolToVect3(oriXPos, oriXNeg, oriYPos, oriYNeg, oriZPos, oriZNeg);
        var rotatedVects = RotateVects(originalVects, angles);
        //Vect3ToBool(rotatedVects, out XPos, out XNeg, out YPos, out YNeg, out ZPos, out ZNeg);
        ConnectionVectors = rotatedVects;
    }

    //Get vectors from booleans
    private Vector3Int[] BoolToVect3(bool xPos, bool xNeg, bool yPos, bool yNeg, bool zPos, bool zNeg)
    {
        Vector3Int[] Vec3s = new Vector3Int[6];

        Vec3s[0] = xPos ? Vector3Int.right : Vector3Int.zero;
        Vec3s[1] = xNeg ? Vector3Int.left : Vector3Int.zero;

        Vec3s[2] = yPos ? Vector3Int.up : Vector3Int.zero;
        Vec3s[3] = yNeg ? Vector3Int.down : Vector3Int.zero;

        Vec3s[4] = zPos ? Vector3Int.forward : Vector3Int.zero;
        Vec3s[5] = zNeg ? Vector3Int.back : Vector3Int.zero;

        return Vec3s;
    }

    private Vector3Int[] RotateVects(Vector3Int[] vects, Vector3 eulerRotation)
    {
        for (int i = 0; i < vects.Length; i++)
        {
            var originalVect = vects[i];
            var rotatedVect = Quaternion.Euler(eulerRotation) * originalVect;

            vects[i] = Vector3Int.RoundToInt(rotatedVect);
        }

        return vects;
    }

    //private void Vect3ToBool(Vector3Int[] vects, out bool xPos, out bool xNeg, out bool yPos, out bool yNeg, out bool zPos, out bool zNeg)
    //{
    //    xPos = xNeg = yPos = yNeg = zPos = zNeg = false;
    //
    //    foreach (var vect in vects)
    //    {
    //        if (vect == Vector3Int.right)
    //            xPos = true;
    //        else if (vect == Vector3Int.left)
    //            xNeg = true;
    //        else if (vect == Vector3Int.up)
    //            yPos = true;
    //        else if (vect == Vector3Int.down)
    //            yNeg = true;
    //        else if (vect == Vector3Int.forward)
    //            zPos = true;
    //        else if (vect == Vector3Int.back)
    //            zNeg = true;
    //    }
    //}
}
