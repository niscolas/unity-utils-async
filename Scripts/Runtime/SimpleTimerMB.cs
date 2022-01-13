using System;
using Cysharp.Threading.Tasks;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Async
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Simple Timer")]
    public class SimpleTimerMB : AutoTriggerMB
    {
        [SerializeField]
        private IntReference _initialTimeLeft;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _finished;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private IntReference _currentTimeLeft;

        public override void Do()
        {
            HandleTimerAsync().Forget();
        }

        public async UniTaskVoid HandleTimerAsync()
        {
            _currentTimeLeft.Value = _initialTimeLeft.Value;

            do
            {
                try
                {
                    await Await.Seconds(1, gameObject);
                    _currentTimeLeft.Value--;
                }
                catch (Exception)
                {
                    break;
                }
            } while (_currentTimeLeft >= 0);

            if (_currentTimeLeft < 0)
            {
                _finished?.Invoke();
            }
        }
    }
}