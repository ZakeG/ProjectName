using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestLogReaction))]
public class QuestLogReactionEditor : ReactionEditor
{
    private SerializedProperty messageProperty;


    private const float messageGUILines = 3f;
    private const float areaWidthOffset = 19f;
    private const string textReactionPropMessageName = "message";


    protected override void Init()
    {
        messageProperty = serializedObject.FindProperty(textReactionPropMessageName);
    }


    protected override void DrawReaction()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Message", GUILayout.Width(EditorGUIUtility.labelWidth - areaWidthOffset));
        messageProperty.stringValue = EditorGUILayout.TextArea(messageProperty.stringValue, GUILayout.Height(EditorGUIUtility.singleLineHeight * messageGUILines));
        EditorGUILayout.EndHorizontal();
    }

    protected override string GetFoldoutLabel()
    {
        return "Questlog Reaction";
    }
}
