﻿using System.Collections.Generic;
using Common.Enums;

namespace Common.Models
{
    public class ItemSequence
    {
        public ItemSequenceType Type { get; }
        public IReadOnlyList<GridSlot> SolvedGridSlots { get; }

        public ItemSequence(ItemSequenceType type, IReadOnlyList<GridSlot> solvedGridSlots)
        {
            Type = type;
            SolvedGridSlots = solvedGridSlots;
        }
    }
}