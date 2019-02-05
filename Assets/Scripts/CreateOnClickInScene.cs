using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CreateOnClickInScene : MonoBehaviour
{
    public GameObject CreatedObject;
}

#if UNITY_EDITOR
[CustomEditor(typeof(CreateOnClickInScene))]
public class CreateOnClickInSceneEditor : Editor
{
    private CreateOnClickInScene Target { get { return (CreateOnClickInScene)target; } }

    private void OnEnable()
    {
        if (!Application.isPlaying)
        {
            Target.CreatedObject = new GameObject("Editor only object");
        }
    }

    private void OnDisable()
    {
        if (!Application.isPlaying)
        {
            DestroyImmediate(Target.CreatedObject);
            Target.CreatedObject = null;
        }
    }
}
#endif