public class ExitSceneReaction : Reaction
{
    private SceneController sceneController;


    protected override void SpecificInit()
    {
        sceneController = FindObjectOfType<SceneController>();
    }


    protected override void ImmediateReaction()
    {
        sceneController.ClosePersistentScene();
    }
}