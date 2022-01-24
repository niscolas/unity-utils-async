using System;
using niscolas.OdinCompositeAttributes;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Async
{
    [Serializable]
    public class SerializedCounterData
    {
        [SerializeField]
        private IntReference _from = new IntReference();

        [SerializeField]
        private IntReference _to = new IntReference();

        [SecondsLabel]
        [SerializeField]
        private FloatReference _firstTickTimeInterval = new FloatReference();

        [SecondsLabel]
        [SerializeField]
        private FloatReference _timeInterval = new FloatReference();

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<int> _onTick;

        [SerializeField]
        private UnityEvent _onFinished;

        public int From => _from;

        public int To => _to;

        public float FirstTickTimeInterval => _firstTickTimeInterval;

        public float TimeInterval => _timeInterval;

        public UnityEvent<int> OnTick => _onTick;

        public UnityEvent OnFinished => _onFinished;
    }
}