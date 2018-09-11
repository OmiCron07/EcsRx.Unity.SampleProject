using Game.Scripts.Enums;


namespace Game.Events
{
  public class LoadSceneProfileEvent 
  {
    public SceneProfileEnum SceneProfile { get; private set; }


    public LoadSceneProfileEvent(SceneProfileEnum sceneProfile)
    {
      SceneProfile = sceneProfile;
    }
  }
}
