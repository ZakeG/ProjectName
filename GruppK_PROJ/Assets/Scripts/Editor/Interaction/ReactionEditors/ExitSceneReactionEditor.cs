using UnityEditor;

[CustomEditor(typeof(ExitSceneReaction))]
public class ExitSceneReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Exit to end scene Reaction";
    }
}
