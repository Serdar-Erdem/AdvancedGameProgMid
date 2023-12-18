using Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Controllers
{
    public class ColorController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        public ColorTypes ColorType;

        private void Awake()
        {
            ChangeAreaColor(ColorType);
        }

        public void ChangeAreaColor(ColorTypes colorType)
        {
            var colorHandler = Addressables.LoadAssetAsync<Material>($"PortalColors/Color_{colorType}");
            meshRenderer.material = colorHandler.WaitForCompletion() != null ? colorHandler.Result : null;
        }
    }
}
