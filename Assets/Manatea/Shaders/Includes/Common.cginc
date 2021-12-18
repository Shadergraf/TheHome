
// The circle constant. Defined as the circumference of a circle divided by its radius. Equivalent to 2*pi
#define TAU 6.28318530717959

// An obscure circle constant. Defined as the circumference of a circle divided by its diameter. Equivalent to 0.5*tau
#define PI 3.14159265359

// Euler's number. The base of the natural logarithm. f(x)=e^x is equal to its own derivative
#define E 2.71828182846

// The golden ratio. It is the value of a/b where a/b = (a+b)/a. It's the positive root of x^2-x-1
#define GOLDEN_RATIO 1.61803398875

// The square root of two. The length of the vector (1,1)</summary>
#define SQRT2 1.41421356237

// The inverse square root of two. One devided by the length of the vector (1,1)
#define SQRT2INV 0.70710678119

// Multiply an angle in degrees by this, to convert it to radians
#define Deg2Rad TAU / 360

// Multiply an angle in radians by this, to convert it to degrees
#define Rad2Deg 360 / TAU


// Inverse lerp
inline float ilerp(float a, float b, float v)
{
    return (v - a) / (b - a);
}
