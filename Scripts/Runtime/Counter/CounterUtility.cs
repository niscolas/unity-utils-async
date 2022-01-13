using System;
using Cysharp.Threading.Tasks;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace niscolas.UnityUtils.Async
{
    public static class CounterUtility
    {
        public static async UniTask StartCounting(
            int from,
            int to,
            Action<int> callback,
            Action finishedCallback = null,
            float firstTickTimeInterval = 0,
            float timeInterval = 1)
        {
            await Await.Seconds(firstTickTimeInterval);

            foreach (int i in from.EnumerableFor(to))
            {
                callback(i);
                await Await.Seconds(timeInterval);
            }

            finishedCallback?.Invoke();
        }

    }
}