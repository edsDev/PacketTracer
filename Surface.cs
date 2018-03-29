using System.Runtime.Intrinsics;
using System;
using ColorPacket256 = VectorPacket256;

internal class Surface
{
    public Func<VectorPacket256, ColorPacket256> Diffuse;
    public Func<VectorPacket256, ColorPacket256> Specular;
    public Func<VectorPacket256, Vector256<float>> Reflect;
    public float Roughness;

    public Surface(Func<VectorPacket256, ColorPacket256> Diffuse,
                    Func<VectorPacket256, ColorPacket256> Specular,
                    Func<VectorPacket256, Vector256<float>> Reflect,
                    float Roughness)
    {
        this.Diffuse = Diffuse;
        this.Specular = Specular;
        this.Reflect = Reflect;
        this.Roughness = Roughness;
    }
}

