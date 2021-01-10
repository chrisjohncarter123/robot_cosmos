using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Robot;


[CustomEditor(typeof(RobotManipulator))]
public class RobotManipulatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        RobotManipulator robotManipulator = (RobotManipulator)target;

        if(GUILayout.Button("Create New Robot"))
        {
            robotManipulator.DestroyImmediateRobot();
            robotManipulator.CreateNewRobot();
        }
        if(GUILayout.Button("Delete Robot"))
        {
            robotManipulator.DestroyImmediateRobot();
        }

    }
}

