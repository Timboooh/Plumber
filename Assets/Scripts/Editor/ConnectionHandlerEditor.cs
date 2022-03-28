using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConnectionHandler))]
public class ConnectionHandlerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Update Position"))
        {
            ConnectionHandler handler = (ConnectionHandler)target;
            handler.UpdateConnections();
        }
    }
}
