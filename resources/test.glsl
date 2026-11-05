#version 330

in vec2 fragTexCoord;
in vec4 fragColor;

out vec4 finalColor;

uniform vec2 iResolution;
uniform float iTime;

void main()
{
    vec2 uv = gl_FragCoord.xy / iResolution.xy;
    
    float wave = cos(uv.y * (sin(iTime)+1)*12.0 + iTime * 3.0) * 0.2;
    float tiledCoord = fract(iTime + uv.x * 10.0 + wave);
    
    float stripe = step(0.5, tiledCoord);

    vec3 colorA = vec3(0.12, 0.12, 0.12); 
    vec3 colorB = vec3(0.1, 0.1, 0.1); 

    vec3 shadedColor = mix(colorA, colorB, stripe);

    finalColor = vec4(shadedColor, 1.0);
}