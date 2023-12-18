using System.Collections;
using System.Threading.Tasks;
using DG.Tweening;
using Enums;
using Controllers;
using Signals;
using UnityEngine;
using System.Collections.Generic;

public class DroneAreaManager : MonoBehaviour
{
    [SerializeField] private GameObject droneColliderObject;
    [SerializeField] private List<Collider> droneColliderForDetect;
    [SerializeField] private List<DroneColorAreaManager> droneColorAreaManagers;
    [SerializeField] private GameObject droneObject;


    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        DroneAreaSignals.Instance.onDroneCheckCompleted += OnDroneCheckCompleted;
        DroneAreaSignals.Instance.onDroneCheckStarted += OnDroneCheckStarted;
    }

    private void UnsubscribeEvents()
    {
        DroneAreaSignals.Instance.onDroneCheckCompleted -= OnDroneCheckCompleted;
        DroneAreaSignals.Instance.onDroneCheckStarted -= OnDroneCheckStarted;
    }

    private async void OnDroneCheckStarted()
    {
        droneObject.SetActive(true);
        await Task.Delay(200);

        foreach (var droneColorAreaManager in droneColorAreaManagers)
        {
            if (droneColorAreaManager.matchType == MatchType.UnMatched)
            {
                droneColorAreaManager.gameObject.transform.DOScaleZ(0, 0.5f).OnComplete(() =>
                {
                    droneColorAreaManager.gameObject.transform.DOScaleX(0, 0.5f);
                });
            }
        }
    }

    private void OnDroneCheckCompleted()
    {
        ChangeColliders();
    }

    private async void ChangeColliders()
    {
        foreach (var collider in droneColliderForDetect)
        {
            collider.enabled = false;
        }

        droneColliderObject.SetActive(true);
        await Task.Delay(200);
        droneColliderObject.SetActive(false);
    }
}
