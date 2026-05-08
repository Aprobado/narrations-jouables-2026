#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace NarrationsJouables.MaterialUtility
{
    [ExecuteAlways]
    public class MaterialFloatController : MonoBehaviour
    {
        [SerializeField] private Material material;
        [SerializeField] private string propertyName;
        [Header("We can animate this")] public float value;

        [Header("This is the default value when we start and stop the game")] [SerializeField]
        private float defaultValue;

        private void Awake()
        {
            if (material == null) return;
            material.SetFloat(propertyName, defaultValue);
        }

        private void OnEnable()
        {
            #if UNITY_EDITOR
            if (!EditorApplication.isPlaying) return;
            #endif
            if (material == null) return;
            if (Application.isPlaying && !material.HasFloat(propertyName))
            {
                Debug.LogWarning($"Material has no property with name \"{propertyName}\"");
                enabled = false;
            }
        }

        private void OnDestroy()
        {
            if (material == null) return;
            material.SetFloat(propertyName, defaultValue);
        }

        private void OnDidApplyAnimationProperties()
        {
            if (material == null) return;
            material.SetFloat(propertyName, value);
        }
    }
}
