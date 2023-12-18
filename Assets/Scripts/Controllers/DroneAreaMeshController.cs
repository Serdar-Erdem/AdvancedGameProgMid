using Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Controllers
{
    public class DroneAreaMeshController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        public void ChangeAreaColor(ColorTypes colorType)
        {
            var colorHandler = Addressables.LoadAssetAsync<Material>($"CoreColor/Color_{colorType}");
            meshRenderer.material = colorHandler.Result;
        }
    }
}
