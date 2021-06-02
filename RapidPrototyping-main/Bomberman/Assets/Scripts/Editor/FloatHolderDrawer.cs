using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(FloatHolder))]
public class FloatHolderDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);

        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        position.height = EditorGUIUtility.singleLineHeight;
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var rect = new Rect(position.x, position.y, position.width / 2, position.height);
        var type = property.FindPropertyRelative("type").enumValueIndex;
        EditorGUI.PropertyField(rect, property.FindPropertyRelative("type"), GUIContent.none);
        switch ((FloatHolder.FloatType)type)
        {
            case FloatHolder.FloatType.Constant:
                rect.x += position.width / 2f;
                EditorGUI.PropertyField(rect, property.FindPropertyRelative("constantValue"), GUIContent.none);
                break;
            case FloatHolder.FloatType.BlackBoard:
                rect.x += position.width / 2f;
                EditorGUI.PropertyField(rect, property.FindPropertyRelative("blackBoardVariableName"), GUIContent.none);
                break;
            case FloatHolder.FloatType.FloatVariable:
                rect.x += position.width / 2f;
                EditorGUI.PropertyField(rect, property.FindPropertyRelative("floatVariable"), GUIContent.none);
                break; 
        }

        

        //    public FloatType type;
    //public float constantValue;
   // public FloatVariable floatVariable;
    //public string blackBoardVariableName;

    EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
