using System;
using Cysharp.Threading.Tasks;
using niscolas.OdinCompositeAttributes;
using niscolas.UnityUtils.Extras;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityUtils
{
    [Serializable]
    public class DelayWrapper
    {
        [SecondsLabel, SerializeField]
        private FloatReference _seconds;

        [SerializeField]
        private IntReference _frames;

        [SerializeField]
        private DelayType _delayType = DelayType.DeltaTime;

        public UniTask Delay(GameObject gameObject = null)
        {
            return UniTask.WhenAll(
                Await.Seconds(_seconds.Value, gameObject, _delayType),
                Await.Frames(_frames.Value, gameObject));
        }
    }
}