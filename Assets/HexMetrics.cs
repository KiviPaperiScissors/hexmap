﻿
using UnityEngine;

// Class: HexMetrics
// This class provides the basic characteristics for the hexagons in the hexgrid.

public static class HexMetrics
{
    public const float outerRadius = 10f;
    public const float innerRadius = outerRadius * 0.866025404f;
    public const int chunkSizeX = 5, chunkSizeZ = 5;

    public static Vector3[] corners =
    {
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f* outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(0f, 0f, outerRadius)
    };
}
