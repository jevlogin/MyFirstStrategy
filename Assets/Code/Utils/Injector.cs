using System;
using System.Reflection;


namespace Utils
{
    public static class Injector
    {
        private static readonly Type _injectAssetAttributeType = typeof(InjectAssetAttribute);

        public static T Inject<T>(this AssetStorage storage, T target) where T : class
        {
            var targetType = target.GetType();

            while (targetType != null)
            {
                var fields = targetType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (var field in fields)
                {
                    var injectAssetAttribute = field.GetCustomAttribute(_injectAssetAttributeType) as InjectAssetAttribute;
                    if (injectAssetAttribute != null)
                    {
                        var asset = storage.GetAsset(injectAssetAttribute.AssetName);
                        field.SetValue(target, asset);
                    }
                }
                targetType = targetType.BaseType;
            }

            return target;
        }
    }
}