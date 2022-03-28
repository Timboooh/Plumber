using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int xGridPlaces = 8;
    public int yGridPlaces = 8;
    public int zGridPlaces = 8;

    private Pipe[,,] ObjectGrid = null;

    // Start is called before the first frame update
    void Start()
    {
        ObjectGrid = new Pipe[xGridPlaces, yGridPlaces, zGridPlaces];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SnapToGrid(Pipe pipeObject, bool add = false)
    {
        var currentPosition = pipeObject.transform.localPosition;
        Debug.LogWarning("SnapToGrid started:" + currentPosition.ToString());
      
        var newPositionFloat = new Vector3(
                        Mathf.Clamp(currentPosition.x, 0, xGridPlaces),
                        Mathf.Clamp(currentPosition.y, 0, xGridPlaces),
                        Mathf.Clamp(currentPosition.z, 0, xGridPlaces));

        var newPositionInt = Vector3Int.RoundToInt(newPositionFloat);

        if(ObjectGrid[newPositionInt.x, newPositionInt.y, newPositionInt.z] == null)
        {
            pipeObject.transform.localPosition = newPositionInt;
            pipeObject.transform.rotation = Quaternion.identity;

            Debug.LogWarning("SnapToGrid done:" + newPositionInt.ToString());

            var rigidbody = pipeObject.gameObject.GetComponent<Rigidbody>();

            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;

            if (add) AddToGrid(pipeObject);
        }        
    }

    public void AddToGrid(Pipe pipeObject, Vector3Int? position = null)
    {
        if (!position.HasValue) position = Vector3Int.RoundToInt(pipeObject.transform.localPosition);

        ObjectGrid[position.Value.x, position.Value.y, position.Value.z] = pipeObject;
    }
}
