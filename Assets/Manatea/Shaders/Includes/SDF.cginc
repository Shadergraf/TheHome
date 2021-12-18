
// All functions taken from Inigo Quilez Blog
// https://www.iquilezles.org/www/index.htm

#include "Assets/Manatea/Shaders/Includes/Common.cginc"


float sdCutoff(float d, float2 uv, float offset = 0, float smoothing = 1)
{
	return saturate(offset - (d * 2 / smoothing / length(fwidth(uv))));
}

float sdOutline(float d, float2 uv, float thickness = 1, float smoothing = 1.5)
{
	float sub = d * 2 / smoothing / length(fwidth(uv));
	return saturate(thickness / 2 - sub) * 
	(1 - saturate(-thickness / 2 - sub));
}

// Converts signed distances to debug colors
float3 sdColoring(float d)
{
	float3 col = 1.0 - sign(d) * float3(0.1, 0.4, 0.7);
	col *= 1.0 - pow(E, -3.0 * abs(d));
	col *= 0.8 + 0.2 * cos(150.0 * d);
	col = lerp(col, 1.0, 1.0 - smoothstep(0.0, 0.01, abs(d)));
	return col;
}


// 2D signed distance to circle
float sdCircle(float2 p, float r)
{
	return length(p) - r;
}

// 2D signed distance to box
float sdBox(float2 p, float2 b)
{
	float2 d = abs(p) - b;
	return length(max(d, 0.0)) + min(max(d.x, d.y), 0.0);
}

// 2D signed distance to triangle
float sdTriangleIsosceles(float2 p, float2 q)
{
	p.x = abs(p.x);
	float2 a = p - q * clamp(dot(p, q) / dot(q, q), 0.0, 1.0);
	float2 b = p - q * float2(clamp(p.x / q.x, 0.0, 1.0), 1.0);
	float k = sign(q.y);
	float d = min(dot(a, a), dot(b, b));
	float s = max(k * (p.x * q.y - p.y * q.x), k * (p.y - q.y));
	return sqrt(d) * sign(s);
}


float sdUnion(float d1, float d2)
{
    return min(d1, d2);
}
float sdSubtraction(float d1, float d2)
{
    return max(-d1, d2);
}
float sdIntersection(float d1, float d2)
{
    return max(d1, d2);
}

float sdSmoothUnion(float d1, float d2, float k)
{
    float h = max(k - abs(d1 - d2), 0.0);
    return min(d1, d2) - h * h * 0.25 / k;
}

float sdSmoothSubtraction(float d1, float d2, float k)
{
    float h = max(k - abs(-d1 - d2), 0.0);
    return max(-d1, d2) + h * h * 0.25 / k;
}

float sdSmoothIntersection(float d1, float d2, float k)
{
    float h = max(k - abs(d1 - d2), 0.0);
    return max(d1, d2) + h * h * 0.25 / k;
}
