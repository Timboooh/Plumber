using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;


public class ConnectionHandler : MonoBehaviour
{
    public Vector3Int[] ConnectionVectors = new Vector3Int[6];
    
    public bool oriXPos, oriXNeg, oriYPos, oriYNeg, oriZPos, oriZNeg;

    public ConnectionHandler()
    {

    }

    public void Awake()
    {
        UpdateConnections(gameObject.transform.localEulerAngles);
    }

    public void UpdateConnections(Vector3 angles)
    {
        Debug.LogWarning($"{angles.x}:{angles.y}:{angles.z}");


        var originalVects = BoolToVect3(oriXPos, oriXNeg, oriYPos, oriYNeg, oriZPos, oriZNeg);
        var rotatedVects = RotateVects(originalVects, angles);
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
}
