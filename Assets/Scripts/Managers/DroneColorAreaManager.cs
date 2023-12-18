using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Controllers
{
    public class DroneColorAreaManager : MonoBehaviour
    {
        public ColorTypes CurrentColorType;
        public MatchType matchType = MatchType.UnMatched;

        [SerializeField] private bool openDroneAreaExit;
        [SerializeField] private DroneAreaMeshController droneAreaMeshController;

        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            GetReferences();
        }

        private void GetReferences()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

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
            CoreGameSignals.Instance.onGameInit += OnSetColor;
        }

        private void OnSetColor()
        {
            droneAreaMeshController.ChangeAreaColor(CurrentColorType);
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onGameInit -= OnSetColor;
        }
    }
}
