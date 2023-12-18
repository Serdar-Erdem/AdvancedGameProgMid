using System;
using System.Collections.Generic;
using Enums;
using UnityEngine.Events;
using Extentions;


namespace Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
        private UnityAction<ScoreTypes, ScoreVariableType> onChangeScoreCallback = delegate { };
        private Func<ScoreVariableType, int> onGetScoreCallback = delegate { return 0; };
        private UnityAction<List<int>> onUpdateScoreCallback = delegate { };
        private UnityAction onAddLevelTototalScoreCallback = delegate { };

        public event UnityAction<ScoreTypes, ScoreVariableType> onChangeScore
        {
            add => onChangeScoreCallback += value;
            remove => onChangeScoreCallback -= value;
        }

        public event Func<ScoreVariableType, int> onGetScore
        {
            add => onGetScoreCallback += value;
            remove => onGetScoreCallback -= value;
        }

        public event UnityAction<List<int>> onUpdateScore
        {
            add => onUpdateScoreCallback += value;
            remove => onUpdateScoreCallback -= value;
        }

        public event UnityAction onAddLevelTototalScore
        {
            add => onAddLevelTototalScoreCallback += value;
            remove => onAddLevelTototalScoreCallback -= value;
        }

        public void InvokeOnChangeScore(ScoreTypes scoreType, ScoreVariableType variableType)
        {
            onChangeScoreCallback?.Invoke(scoreType, variableType);
        }

        public int InvokeOnGetScore(ScoreVariableType variableType)
        {
            return onGetScoreCallback?.Invoke(variableType) ?? 0;
        }

        public void InvokeOnUpdateScore(List<int> scores)
        {
            onUpdateScoreCallback?.Invoke(scores);
        }

        public void InvokeOnAddLevelToTotalScore()
        {
            onAddLevelTototalScoreCallback?.Invoke();
        }
    }
}
