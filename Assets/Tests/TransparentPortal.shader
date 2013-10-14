Shader "FX/TransparentPortal" { 
Properties {
    _MainTex ("Base (RGB)", 2D) = "white" {}
    
}

Subshader {
    Pass {
    	ColorMask 0
        SetTexture [_MainTex] { combine texture }
        
    }
}

}