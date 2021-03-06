// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using static System.Runtime.Intrinsics.X86.Avx;
using static System.Runtime.Intrinsics.X86.Avx2;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System.Runtime.CompilerServices;
using System;

internal struct Intersections
{
    public Vector256<float> Distances;
    public Vector256<int> ThingIndices;

    public static readonly Vector256<float> NullDistance = Vector256.Create(float.MaxValue);
    public static readonly Vector256<int> NullIndex = Vector256.Create(-1);

    public Intersections(Vector256<float> dis, Vector256<int> things)
    {
        Distances = dis;
        ThingIndices = things;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool AllNullIntersections()
    {
        return AllNullIntersections(Distances);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool AllNullIntersections(Vector256<float> dis)
    {
        var cmp = Compare(dis, NullDistance, FloatComparisonMode.EqualOrderedNonSignaling);
        var zero = Vector256<int>.Zero;
        var mask = Avx2.CompareEqual(zero, zero);
        return TestC(cmp, mask.AsSingle());
    }

}
