using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Utils
{
    [CreateAssetMenu(fileName = "AssetStorage", menuName = "Data/AssetStorage", order = 51)]
    public sealed class AssetStorage : ScriptableObject
    {
        [SerializeField] private List<GameObject> _assets;

        public GameObject GetAsset(string assetName)
        {
            return _assets.FirstOrDefault(asset => asset.name == assetName);
        }
    }
}