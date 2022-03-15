﻿using UnityEngine;

namespace Common.Interfaces
{
    public interface IItem
    {
        int SpriteIndex { get; }
        bool IsDestroyed { get; }
        Transform Transform { get; }
        SpriteRenderer SpriteRenderer { get; }

        void Show();
        void Hide();
        void SetSprite(int index, Sprite sprite);
        void SetWorldPosition(Vector3 position);
        Vector3 GetWorldPosition();
    }
}