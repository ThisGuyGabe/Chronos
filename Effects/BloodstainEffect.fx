sampler uImage0 : register(s0);
float uTime;

float4 BloodstainEffect(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 curCol = tex2D(uImage0, coords);
    float t = coords.x * 8 + coords.y * 8 + uTime;
    t %= 3;

    float4 reallydarkRed = float4(0.6, 0.1, 0.1, 1.0) * curCol.a;

    float4 darkerRed = float4(0.8, 0.3, 0.3, 1.0) * curCol.a;

    float4 lightRed = float4(0.8, 0.2, 0.2, 1.0) * curCol.a;

    if (t < 1)
        return reallydarkRed;
    else if (t < 2)
        return darkerRed;
    else
        return lightRed;
}

technique Technique1
{
    pass HslScrollPass
    {
        PixelShader = compile ps_2_0 BloodstainEffect();
    }
}




