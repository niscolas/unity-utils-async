using Cysharp.Threading.Tasks;
using niscolas.OdinCompositeAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace niscolas.UnityUtils.Async
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Counter")]
    public class CounterMB : AutoTriggerMonoBehaviour
    {
        [ExtractContent]
        [SerializeField]
        private SerializedCounterData _data;

        public override void Do()
        {
            CounterUtility
                .StartCounting(
                    _data.From,
                    _data.To,
                    i => _data.OnTick?.Invoke(i),
                    () => _data.OnFinished?.Invoke(),
                    _data.FirstTickTimeInterval,
                    _data.TimeInterval)
                .Forget();
        }
    }
}