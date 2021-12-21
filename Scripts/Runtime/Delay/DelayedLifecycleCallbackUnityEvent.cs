using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityUtils;

namespace niscolas.UnityUtils.Extras
{
    public class DelayedLifecycleCallbackUnityEvent : AutoTriggerMonoBehaviour
    {
        [SerializeField]
        private DelayWrapper _delay;

        [SerializeField]
        private UnityEvent _event;

        public override async void Do()
        {
            await _delay.Delay(gameObject);
            _event?.Invoke();
        }
    }
}