using System;
using niscolas.UnityUtils.Extras;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Plugins.UnityAtomsMonoBehaviourUtils
{
    public class Timer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private IntReference _timeLeft;

        [Header("Events")]
        [FormerlySerializedAs("onTimerFinished"), SerializeField]
        private UnityEvent _finished;

        public async void HandleTimerAsync()
        {
            do
            {
                try
                {
                    await Await.Seconds(1, gameObject);
                    _timeLeft.Value--;
                }
                catch (Exception)
                {
                    break;
                }
            } while (_timeLeft >= 0);

            if (_timeLeft < 0)
            {
                _finished?.Invoke();
            }
        }
    }
}
