﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;

public class TextureHelper
{
    public static int GetTextureArrayIndexFromTranslation(Translation translation)
    {
        float2 bounds = AntMovementSystem.bounds;
        int TexSize = RefsAuthoring.TexSize;

        float2 texelCoord = new float2(0.5f * (-translation.Value.x / bounds.x) + 0.5f, 0.5f * (-translation.Value.z / bounds.y) + 0.5f);
        int index = (int)(texelCoord.y * TexSize) * TexSize + (int)(texelCoord.x * TexSize);

        return index;
    }

    public static bool PositionWithInMapBounds(float x, float y)
    {
        return PositionWithInMapBounds(new float2(x, y));
    }

    public static bool PositionWithInMapBounds(float2 pos)
    {
        float2 bounds = AntMovementSystem.bounds;
        if (pos.x < 0 || pos.y < 0 || pos.x >= bounds.x || pos.y >= bounds.y)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
