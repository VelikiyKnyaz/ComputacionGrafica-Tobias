
#ifndef LIGHTNING_T_INCLUDED
#define LIGHTNING_T_INCLUDED

//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

void GetMainLightInfo_float(out float3 direction, out half3 color)
{
    #if defined(SHADERGRAPH_PREVIEW)
    direction = float3(1,1,-1);
    color = 1;
    #else
    Light mainLight = GetMainLight();
    direction = mainLight.direction;
    color = mainLight.color;
    #endif
}

void Add_float(float a, float b, out float c)
{
    c = b + a;
}
#endif