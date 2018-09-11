using Game.Scripts.Enums;

public class LoadSceneProfileEvent 
{
  public SceneProfileEnum SceneProfile { get; private set; }


  public LoadSceneProfileEvent(SceneProfileEnum sceneProfile)
  {
    SceneProfile = sceneProfile;
  }
}
