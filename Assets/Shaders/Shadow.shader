Shader "Hidden/NewImageEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                float speed = 0.3;
                float freq = 0.7;
                float amp = 0.7;
                float phase = 0.5;
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                
                float2 p = ( i.uv ) - 0.25;
	
	            float sx = (amp)*1.2 * sin( 9.0 * (freq) * (p.x-phase) - 3.5 * (speed)*(float)_Time*16);
	
	            float dy = 100./ ( 60. * abs(4.9*p.y - sx - 1.2));
	
	            dy += 1./ (50. * length(p - float2(p.x, 0.)));
	
	            fixed4 col2 = fixed4( (p.x - .6) * dy, 0.2 * dy, dy, 2.0 );
                //col2 = fixed4(pow(col2.rgb, 2.2f), 1);
                col2 = 1-col2;
                col2 = col2/150;
                return col * col2;
            }
            ENDCG
        }
    }
}
