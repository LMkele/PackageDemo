
using UnityEngine;
using UnityGameFramework.Runtime;
public class enterGame : MonoBehaviour
{
    public void EnterGame()
    {
        SceneComponent Scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();
        string[] loadedSceneAssetNames = Scene.GetLoadedSceneAssetNames();
        for (int i = 0; i < loadedSceneAssetNames.Length; i++)
        {
            Scene.UnloadScene(loadedSceneAssetNames[i]);
        }
        Scene.LoadScene("Assets/Demo/Game.unity", this);
        ProcedureComponent procedure = UnityGameFramework.Runtime.GameEntry.GetComponent<ProcedureComponent>();
    }
}