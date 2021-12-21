using Cysharp.Threading.Tasks;
using niscolas.OdinCompositeAttributes;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Extras;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityUtils
{
    public class DelayedUnityEvent : CachedMonoBehaviour
    {
        [SerializeField]
        private MonoCallbackType _autoTriggerCallback = MonoCallbackType.None;

        [FormerlySerializedAs("_delaySec"), SecondsLabel, SerializeField]
        private FloatReference _secondsDelay;

        [SerializeField]
        private IntReference _framesDelay;

        [SerializeField]
        private DelayType _delayType = DelayType.DeltaTime;

        [SerializeField]
        private UnityEvent _event;

        protected override void Awake()
        {
            base.Awake();
            MonoLifecycleHooksManager.AutoTrigger(_gameObject, Do, _autoTriggerCallback);
        }

        public async void Do()
        {
            await Await.Frames(_framesDelay.Value);

            await Await.Seconds(_secondsDelay, gameObject, _delayType);
            _event?.Invoke();
        }
    }
}