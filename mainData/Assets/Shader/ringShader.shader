Shader "UnlitAlpha"

{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) A (Alpha)", 2D) = "white" { }
    }

    Category
    {
       
       ZWrite Off
       Cull Back
       Blend SrcAlpha OneMinusSrcAlpha
 		Fog {Mode Off} 
        Tags {Queue=Transparent}
        SubShader
        {
            Pass
            {
                Lighting Off
                SetTexture [_MainTex]
                {
                    constantColor [_Color]
                    Combine texture * constant, texture * constant
                }
            }
        }
    }
}