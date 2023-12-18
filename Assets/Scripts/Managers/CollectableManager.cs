using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Commands;
using DG.Tweening;
using Enums;
using Signals;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] private MoveToGround movementCommand;
    [SerializeField] private CollectableMeshController collectableMeshController;
    [SerializeField] private CapsuleCollider collider;
    [SerializeField] private CollectablePhysicsController collectablePhysicsController;
    [SerializeField] private CollectableAnimationController collectableAnimationController

    public ColorTypes CurrentColorType;
    public MatchType MatchType;

    private void Awake()
    {
        ChangeColor(CurrentColorType);
    }

    public void ChangeColor(ColorTypes colorType)
    {
        CurrentColorType = colorType;
        collectableMeshController.ChangeCollectableMaterial(CurrentColorType);
    }

    public void DecreaseStack()
    {
        HandleStackDecrease();
        DelayedDeath(false);
    }

    public void DecreaseStackOnIdle()
    {
        HandleStackDecrease();
        DelayedDeath(false);
        PlayerSignal.Instance.onIncreaseScale?.Invoke();
    }

    public void DeListStack()
    {
        StackSignals.Instance.onDroneArea?.Invoke(transform.GetSiblingIndex());
    }

    public void IncreaseStack()
    {
        StackSignals.Instance.onIncreaseStack?.Invoke(gameObject);
        collectableAnimationController.ChangeAnimation(CollectableAnimationTypes.Run);
    }

    public async void SetCollectablePositionOnDroneArea(Transform groundTransform)
    {
        collectableAnimationController.ChangeAnimation(CollectableAnimationTypes.Run);
        movementCommand.MoveToGround(groundTransform);
        collectableMeshController.ActivateOutline(false);
        await Task.Delay(4000);
    }

    public void ChangeOutlineState(bool state)
    {
        collectableMeshController.ActivateOutline(state);
    }

    public void DelayedDeath(bool isDelayed)
    {

        collectableAnimationController.ChangeAnimation(CollectableAnimationTypes.Death);
        ChangeOutlineState(true);
        Destroy(gameObject, isDelayed ? 3f : 0.1f);
    }

    public void CheckColorType(DroneColorAreaManager droneColorAreaManager)
    {
        collectableMeshController.CheckColorType(droneColorAreaManager);
    }

    private void OnDestroy()
    {
    }

    private void HandleStackDecrease()
    {
        StackSignals.Instance.onDecreaseStackRoullette?.Invoke(transform.GetSiblingIndex());
        gameObject.transform.parent = null;
    }
}
