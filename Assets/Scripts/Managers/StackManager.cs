using System.Collections.Generic;
using System.Threading.Tasks;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class StackManager : MonoBehaviour
    {
        [SerializeField] private GameObject collectablePrefab;
        [SerializeField] private int initAmount = 4;
        [SerializeField] private List<GameObject> stackList;
        [SerializeField] private Transform tempHolder;

        private Transform playerManager;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void SubscribeEvents()
        {
            StackSignals.Instance.onIncreaseStack += OnIncreaseStack;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onGameInitLevel += FindPlayer;
            StackSignals.Instance.onDroneArea += OnDroneAreaDecrease;
            StackSignals.Instance.onDecreaseStackRoullette += OnDecreaseStackRoullette;
            StackSignals.Instance.onDoubleStack += OnDoubleStack;
            StackSignals.Instance.onDecreaseStack += OnDecreaseStack;
            CoreGameSignals.Instance.onPlay += OnInitRunAnimation;
            StackSignals.Instance.onAnimationChange += OnChangeAnimationInStack;
            StackSignals.Instance.onColorChange += OnChangeColor;
        }

        private void UnSubscribeEvents()
        {
            StackSignals.Instance.onIncreaseStack -= OnIncreaseStack;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onGameInitLevel -= FindPlayer;
            StackSignals.Instance.onDroneArea -= OnDroneAreaDecrease;
            StackSignals.Instance.onDoubleStack -= OnDoubleStack;
            StackSignals.Instance.onDecreaseStack -= OnDecreaseStack;
            StackSignals.Instance.onDecreaseStackRoullette += OnDecreaseStackRoullette;
            StackSignals.Instance.onAnimationChange -= OnChangeAnimationInStack;
            StackSignals.Instance.onColorChange -= OnChangeColor;
        }

        private void Start()
        {
            OnInitalStackSettings();
        }

        private void FixedUpdate()
        {
            LerpStack();
        }

        private void LerpStack()
        {
            if (stackList.Count == 0 || playerManager == null) return;

            stackList[0].transform.position = Vector3.Lerp(stackList[0].transform.position, playerManager.position - Vector3.forward * 0.8f, 0.2f);
            Quaternion toPlayerRotation = Quaternion.LookRotation(playerManager.position - stackList[0].transform.position);
            stackList[0].transform.rotation = Quaternion.Slerp(stackList[0].transform.rotation, toPlayerRotation, 1f);

            for (int index = 1; index < stackList.Count; index++)
            {
                stackList[index].transform.position = Vector3.Lerp(stackList[index].transform.position, stackList[index - 1].transform.position - Vector3.forward * 0.8f, 0.2f);
                Quaternion toRotation = Quaternion.LookRotation(stackList[index - 1].transform.position - stackList[index].transform.position);
                toRotation = Quaternion.Euler(0, toRotation.eulerAngles.y, 0);
                stackList[index].transform.rotation = Quaternion.Slerp(stackList[index - 1].transform.rotation, toRotation, 1f);
            }
        }

        private void OnIncreaseStack(GameObject currentGameObject)
        {
            ScoreSignals.Instance.onChangeScore(ScoreTypes.IncScore, ScoreVariableType.LevelScore);
            currentGameObject.transform.SetParent(transform);
            stackList.Add(currentGameObject);
        }

        private void OnDecreaseStack(int removedIndex)
        {
            ScoreSignals.Instance.onChangeScore(ScoreTypes.DecScore, ScoreVariableType.LevelScore);
            if (stackList[removedIndex] == null) return;

            stackList[removedIndex].transform.parent = tempHolder;
            stackList.RemoveAt(removedIndex);
            stackList.TrimExcess();

            if (stackList.Count == 0)
                CoreGameSignals.Instance.onChangeGameState?.Invoke(GameStates.Failed);
        }

        private void OnDecreaseStackRoullette(int removedIndex)
        {
            if (stackList[removedIndex] == null) return;

            stackList[removedIndex].SetActive(false);
            stackList.RemoveAt(removedIndex);
            stackList.TrimExcess();

            if (stackList.Count == 0)
            {
                SaveSignals.Instance.onChangeSaveData(SaveTypes.TotalColorman, 100);
                CoreGameSignals.Instance.onChangeGameState?.Invoke(GameStates.Roulette);
            }
        }

        private async void OnDroneAreaDecrease(int index)
        {
            ScoreSignals.Instance.onChangeScore(ScoreTypes.DecScore, ScoreVariableType.LevelScore);
            stackList[index].transform.parent = tempHolder;
            stackList.RemoveAt(index);
            stackList.TrimExcess();

            if (stackList.Count == 0)
            {
                await Task.Delay(5000);
                DroneAreaSignals.Instance.onDroneCheckStarted?.Invoke();
                await Task.Delay(3000);
                DroneAreaSignals.Instance.onDroneCheckCompleted?.Invoke();
            }
        }

        private void OnDoubleStack()
        {
            OnChangeStack(stackList.Count * 2);
        }

        private void OnChangeStack(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var gameObject = Instantiate(collectablePrefab, Vector3.back * i, Quaternion.identity);
                OnIncreaseStack(gameObject);
                gameObject.GetComponent<CollectableManager>().ChangeAnimationOnController(CollectableAnimationTypes.Crouch);
            }
        }

        private void OnChangeColor(ColorTypes colorType)
        {
            foreach (var collectable in stackList)
            {
                if (collectable == null) continue;

                collectable.GetComponent<CollectableManager>().ChangeColor(colorType);
            }
        }

        private void OnInitRunAnimation()
        {
            OnChangeAnimationInStack(CollectableAnimationTypes.Run);
        }

        private void OnChangeAnimationInStack(CollectableAnimationTypes currentAnimation)
        {
            foreach (var collectable in stackList)
            {
                if (collectable == null) continue;

                collectable.GetComponent<CollectableManager>().ChangeAnimationOnController(currentAnimation);
            }
        }

        private void OnInitalStackSettings()
        {
            FindPlayer();
            OnChangeStack(initAmount);
            StackSignals.Instance.onAnimationChange?.Invoke(CollectableAnimationTypes.Crouch);
        }

        private void FindPlayer()
        {
            playerManager = FindObjectOfType<PlayerManager>().transform;
        }

        private void DeleteStack()
        {
            foreach (var collectable in stackList)
            {
                if (collectable == null) continue;

                collectable.transform.SetParent(null);
                Destroy(collectable);
                ScoreSignals.Instance.onChangeScore(ScoreTypes.DecScore, ScoreVariableType.LevelScore);
            }
        }

        private async void OnReset()
