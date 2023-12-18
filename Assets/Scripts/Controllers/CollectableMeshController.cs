using System.Threading.Tasks;
using DG.Tweening;
using Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Controllers
{
    public class CollectableMeshController : MonoBehaviour
    {
        [SerializeField] private CollectableManager collectableManager;
        [SerializeField] private SkinnedMeshRenderer meshRenderer;

        public async void ChangeCollectableMaterial(ColorTypes colorType)
        {
            var colorHandler = Addressables.LoadAssetAsync<Material>($"Collectable/Color_{colorType}");
            meshRenderer.material = colorHandler.WaitForCompletion() != null ? colorHandler.Result : null;
        }

        public void CheckColorType(DroneColorAreaManager droneColorAreaRef)
        {
            collectableManager.MatchType = (collectableManager.CurrentColorType == droneColorAreaRef.CurrentColorType)
                ? MatchType.Match
                : MatchType.UnMatched;
        }

        public async void ActivateOutline(bool isOutlineActive)
        {
            float outlineValue = isOutlineActive ? 71 : 0;
            await Task.Delay(2000);
            meshRenderer.material.DOFloat(outlineValue, "_OutlineSize", 1f);
        }
    }
}
