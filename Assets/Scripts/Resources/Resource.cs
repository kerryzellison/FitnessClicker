using UnityEngine;

namespace Resources{
    [CreateAssetMenu(menuName = "Resource/Game resource", fileName = "New Resource")]
    public class Resource : ScriptableObject{
        public int Owned {
            get => PlayerPrefs.GetInt(this.name, 0);
            set => PlayerPrefs.SetInt(this.name, value);
        }
    }
}
