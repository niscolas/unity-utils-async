using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Async
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Delayed Unity Event")]
    public class DelayedUnityEventMB : AutoTriggerMonoBehaviour
    {
        [SerializeField]
        private DelayWrapper _delay;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _event;

        public override async void Do()
        {
            await _delay.Delay(gameObject);
            _event?.Invoke();
        }
    }
}