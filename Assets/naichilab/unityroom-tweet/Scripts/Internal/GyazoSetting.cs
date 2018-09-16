using UnityEngine;

namespace naichilab.Scripts.Internal
{
    [CreateAssetMenu(menuName = "GyazoUploader/Create GyazoSetting Asset")]
    public class GyazoSetting : ScriptableObject
    {
        public string GyazoAccessToken;
    }
}