using UnityEngine;
using UnityEditor;
using ExtensionMethods;

[CustomEditor(typeof(ConnectionHandler))]
public class ConnectionHandlerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Update Position"))
        {
            ConnectionHandler handler = (ConnectionHandler)target;

            var WantedRotation = handler.gameObject.transform.localEulerAngles.RoundToNearestMultiple(90);
            handler.UpdateConnections(WantedRotation);
        }
    }
}
