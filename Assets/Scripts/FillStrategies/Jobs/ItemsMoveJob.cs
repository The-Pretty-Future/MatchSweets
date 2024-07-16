﻿using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using FillStrategies.Models;

namespace FillStrategies.Jobs
{
    public class ItemsMoveJob : MoveJob
    {
        private const float DelayDuration = 0.25f;
        private const float IntervalDuration = 0.25f;

        private readonly float _delay;
        private readonly IEnumerable<ItemMoveData> _itemsData;

        public ItemsMoveJob(IEnumerable<ItemMoveData> items, int delayMultiplier = 0, int executionOrder = 0)
            : base(executionOrder)
        {
            _itemsData = items;
            _delay = delayMultiplier * DelayDuration;
        }

        public override async UniTask ExecuteAsync()
        {
            var itemsSequence = DOTween.Sequence();

            foreach (var itemData in _itemsData)
            {
                var itemMoveTween = CreateItemMoveTween(itemData);
                itemsSequence
                    .Join(itemMoveTween)
                    .PrependInterval(itemMoveTween.Duration() * IntervalDuration);
            }

            itemsSequence.SetDelay(_delay, false).SetEase(Ease.Flash);
            await itemsSequence.AsyncWaitForCompletion();
        }
    }
}
