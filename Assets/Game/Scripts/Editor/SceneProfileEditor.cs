using System.Collections.Generic;
using Game.Scripts.ScriptableObjects;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Editor
{
  public class SceneProfileEditor
  {
    [OnOpenAsset(1)]
    private static bool OnOpenAsset(int id, int line)
    {
      var obj = EditorUtility.InstanceIDToObject(id);

      if (obj is SceneProfile)
      {
        OpenMultiscene((SceneProfile) obj, Event.current.alt);

        return true;
      }
      else if (obj is SceneAsset)
      {
        if (Event.current.alt)
        {
          EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(obj.GetInstanceID()), OpenSceneMode.Additive);

          return true;
        }
        else
        {
          return false;
        }
      }
      else
      {
        return false;
      }
    }

    private static void OpenMultiscene(SceneProfile obj, bool additive)
    {
      Scene activeScene = default(Scene);

      if (additive || EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
      {
        var firstUnloadedScenes = new List<string>();
        var inFirstUnloadedScenes = true;
        Scene firstLoadedScene = default(Scene);

        for (int i = 0; i < obj.Scenes.Count; i++)
        {
          var info = obj.Scenes[i];

          if (info == null) continue;

          var path = AssetDatabase.GetAssetPath(info.GetInstanceID());
          var mode = OpenSceneMode.Single;
          var isActiveScene = info == true;

          var exitedFirstUnloadedScenes = false;

          if (inFirstUnloadedScenes)
          {
            if (!isActiveScene)
            {
              firstUnloadedScenes.Add(path);

              continue;
            }
            else
            {
              inFirstUnloadedScenes     = false;
              exitedFirstUnloadedScenes = true;
            }
          }

          if ((!inFirstUnloadedScenes && !exitedFirstUnloadedScenes) || (additive && exitedFirstUnloadedScenes))
          {
            if ((!additive && isActiveScene))
            {
              mode = OpenSceneMode.Additive;
            }
            else
            {
              mode = OpenSceneMode.AdditiveWithoutLoading;
            }
          }

          var scene = EditorSceneManager.OpenScene(path, mode);

          if (isActiveScene) activeScene                  = scene;
          if (exitedFirstUnloadedScenes) firstLoadedScene = scene;
        }

        for (int i = 0; i < firstUnloadedScenes.Count; i++)
        {
          var path = firstUnloadedScenes[i];
          var scene = EditorSceneManager.OpenScene(path, OpenSceneMode.AdditiveWithoutLoading);
          if (firstLoadedScene.IsValid()) EditorSceneManager.MoveSceneBefore(scene, firstLoadedScene);
        }
      }

      if (!additive && activeScene.IsValid())
      {
        EditorSceneManager.SetActiveScene(activeScene);
      }
    }
  }
}