using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Gilzoide.ResetAfterPlayMode.Editor
{
    [CreateAssetMenu]
    public class ResetAfterPlayMode : ScriptableObject
    {
        public List<Object> Assets;

#if UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void EnteredPlayMode()
        {
            foreach (ResetAfterPlayMode resetAfterPlayMode in FindAllResetAfterPlayModeAssets())
            {
                resetAfterPlayMode.Setup();
            }
        }

        private static IEnumerable<ResetAfterPlayMode> FindAllResetAfterPlayModeAssets()
        {
            return AssetDatabase.FindAssets($"t:{nameof(ResetAfterPlayMode)}")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<ResetAfterPlayMode>);
        }

        private readonly Dictionary<Object, string> _assetsData = new Dictionary<Object, string>();

        private void Setup()
        {
            _assetsData.Clear();
            foreach (Object asset in Assets)
            {
                if (asset != null)
                {
                    _assetsData[asset] = EditorJsonUtility.ToJson(asset);
                }
            }
            Application.quitting += ResetData;
        }

        private void ResetData()
        {
            foreach (Object asset in Assets)
            {
                if (_assetsData.TryGetValue(asset, out string json))
                {
                    EditorJsonUtility.FromJsonOverwrite(json, asset);
                    EditorUtility.SetDirty(asset);
                }
            }
            _assetsData.Clear();
            Application.quitting -= ResetData;
        }
#endif
    }
}