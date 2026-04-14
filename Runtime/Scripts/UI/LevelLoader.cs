using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NarrationsJouables.UI
{
    public class LevelLoader : MonoBehaviour
    {
        public string levelNameToLoad;
        public int levelIndexToLoad = -1;

        private bool loading = false;

        public void LoadLevelByName()
        {
            StartCoroutine(LoadCoroutine(levelNameToLoad, -1));
        }

        public void LoadLevelByID()
        {
            StartCoroutine(LoadCoroutine("", levelIndexToLoad));
        }

        public void LoadLevel(string levelName)
        {
            StartCoroutine(LoadCoroutine(levelName, -1));
        }

        public void LoadLevel(int levelIndex)
        {
            StartCoroutine(LoadCoroutine("", levelIndex));
        }

        IEnumerator LoadCoroutine(string levelName, int levelIndex)
        {
            if (levelIndex < 0 && string.IsNullOrWhiteSpace(levelName)) yield break; // no valid scene name or index
            if (loading) yield break;   // don't load if already loading
            
            loading = true;
            yield return null;  // wait to let any visual change to happen before loading
            Application.backgroundLoadingPriority = ThreadPriority.High;

            if (levelIndex >= 0)
            {
                var asyncOp = SceneManager.LoadSceneAsync(levelIndex);
                asyncOp.completed += NormalLoadPriority;
            }
            else
            {
                var asyncOp = SceneManager.LoadSceneAsync(levelName);
                asyncOp.completed += NormalLoadPriority;
            }
        }

        private void NormalLoadPriority(AsyncOperation obj)
        {
            Application.backgroundLoadingPriority = ThreadPriority.Normal;
        }
    }
}