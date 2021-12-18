using System.Runtime.CompilerServices;
using UnityEngine;

namespace Manatea
{
	public static class ManaMathExtensions
	{

		const MethodImplOptions INLINE = MethodImplOptions.AggressiveInlining;

		#region Vector rotation and angles

		/// <summary>Returns the angle of this vector, in radians</summary>
		/// <param name="v">The vector to get the angle of. It does not have to be normalized</param>
		/// <seealso cref="ManaMath.DirToAng"/>
		[MethodImpl(INLINE)] public static float Angle(this Vector2 v) => Mathf.Atan2(v.y, v.x);

		/// <summary>Rotates the vector 90 degrees clockwise (negative Z axis rotation)</summary>
		[MethodImpl(INLINE)] public static Vector2 Rotate90CW(this Vector2 v) => new Vector2(v.y, -v.x);

		/// <summary>Rotates the vector 90 degrees counter-clockwise (positive Z axis rotation)</summary>
		[MethodImpl(INLINE)] public static Vector2 Rotate90CCW(this Vector2 v) => new Vector2(-v.y, v.x);

		/// <summary>Rotates the vector around <c>pivot</c> with the given angle (in radians)</summary>
		/// <param name="pivot">The point to rotate around</param>
		/// <param name="angRad">The angle to rotate by, in radians</param>
		[MethodImpl(INLINE)] public static Vector2 RotateAround(this Vector2 v, Vector2 pivot, float angRad) => Rotate(v - pivot, angRad) + pivot;

		/// <summary>Rotates the vector around <c>(0,0)</c> with the given angle (in radians)</summary>
		/// <param name="angRad">The angle to rotate by, in radians</param>
		public static Vector2 Rotate(this Vector2 v, float angRad)
		{
			float ca = Mathf.Cos(angRad);
			float sa = Mathf.Sin(angRad);
			return new Vector2(ca * v.x - sa * v.y, sa * v.x + ca * v.y);
		}

		/// <summary>Converts an angle in degrees to radians</summary>
		[MethodImpl(INLINE)] public static float DegToRad(this float angDegrees) => angDegrees * ManaMath.Deg2Rad;

		/// <summary>Converts an angle in radians to degrees</summary>
		[MethodImpl(INLINE)] public static float RadToDeg(this float angRadians) => angRadians * ManaMath.Rad2Deg;

		#endregion

		#region Swizzling

		/// <summary>Returns X and Y as a Vector2, equivalent to <c>new Vector2(v.x,v.y)</c></summary>
		[MethodImpl(INLINE)] public static Vector2 XY(this Vector2 v) => new Vector2(v.y, v.x);

		/// <summary>Returns Y and X as a Vector2, equivalent to <c>new Vector2(v.y,v.x)</c></summary>
		[MethodImpl(INLINE)] public static Vector2 YX(this Vector2 v) => new Vector2(v.y, v.x);

		/// <summary>Returns X and Z as a Vector2, equivalent to <c>new Vector2(v.x,v.z)</c></summary>
		[MethodImpl(INLINE)] public static Vector2 XZ(this Vector3 v) => new Vector2(v.x, v.z);

		/// <summary>Returns Y and Z as a Vector2, equivalent to <c>new Vector2(v.y,v.z)</c></summary>
		[MethodImpl(INLINE)] public static Vector2 YZ(this Vector3 v) => new Vector2(v.y, v.z);

		/// <summary>Returns this vector as a Vector3, slotting X into X, and Y into Z, and the input value y into Y.
		/// Equivalent to <c>new Vector3(v.x,y,v.y)</c></summary>
		[MethodImpl(INLINE)] public static Vector3 XZtoXYZ(this Vector2 v, float y = 0) => new Vector3(v.x, y, v.y);

		/// <summary>Returns this vector as a Vector3, slotting X into X, and Y into Y, and the input value z into Z.
		/// Equivalent to <c>new Vector3(v.x,v.y,z)</c></summary>
		[MethodImpl(INLINE)] public static Vector3 XYtoXYZ(this Vector2 v, float z = 0) => new Vector3(v.x, v.y, z);

		/// <summary>Sets X to 0</summary>
		[MethodImpl(INLINE)] public static Vector2 FlattenX(this Vector2 v) => new Vector2(0f, v.y);

		/// <summary>Sets Y to 0</summary>
		[MethodImpl(INLINE)] public static Vector2 FlattenY(this Vector2 v) => new Vector2(v.x, 0f);

		/// <summary>Sets X to 0</summary>
		[MethodImpl(INLINE)] public static Vector3 FlattenX(this Vector3 v) => new Vector3(0f, v.y, v.z);

		/// <summary>Sets Y to 0</summary>
		[MethodImpl(INLINE)] public static Vector3 FlattenY(this Vector3 v) => new Vector3(v.x, 0f, v.z);

		/// <summary>Sets Z to 0</summary>
		[MethodImpl(INLINE)] public static Vector3 FlattenZ(this Vector3 v) => new Vector3(v.x, v.y, 0f);

		#endregion

		#region Vector directions & magnitudes

		/// <summary>Returns a vector with the same direction, but with the given magnitude.
		/// Equivalent to <c>v.normalized*mag</c></summary>
		[MethodImpl(INLINE)] public static Vector2 WithMagnitude(this Vector2 v, float mag) => v.normalized * mag;

		/// <summary>Returns a vector with the same direction, but with the given magnitude.
		/// Equivalent to <c>v.normalized*mag</c></summary>
		[MethodImpl(INLINE)] public static Vector3 WithMagnitude(this Vector3 v, float mag) => v.normalized * mag;

		/// <summary>Returns the vector going from one position to another, also known as the displacement.
		/// Equivalent to <c>target-v</c></summary>
		[MethodImpl(INLINE)] public static Vector2 To(this Vector2 v, Vector2 target) => target - v;

		/// <summary>Returns the vector going from one position to another, also known as the displacement.
		/// Equivalent to <c>target-v</c></summary>
		[MethodImpl(INLINE)] public static Vector3 To(this Vector3 v, Vector3 target) => target - v;

		/// <summary>Returns the normalized direction from this vector to the target.
		/// Equivalent to <c>(target-v).normalized</c> or <c>v.To(target).normalized</c></summary>
		[MethodImpl(INLINE)] public static Vector2 DirTo(this Vector2 v, Vector2 target) => (target - v).normalized;

		/// <summary>Returns the normalized direction from this vector to the target.
		/// Equivalent to <c>(target-v).normalized</c> or <c>v.To(target).normalized</c></summary>
		[MethodImpl(INLINE)] public static Vector3 DirTo(this Vector3 v, Vector3 target) => (target - v).normalized;

		#endregion

		#region Color manipulation

		/// <summary>Returns the same color, but with the specified alpha value</summary>
		/// <param name="a">The new alpha value</param>
		[MethodImpl(INLINE)] public static Color WithAlpha(this Color c, float a) => new Color(c.r, c.g, c.b, a);

		/// <summary>Returns the same color and alpha, but with RGB multiplied by the given value</summary>
		/// <param name="m">The multiplier for the RGB channels</param>
		[MethodImpl(INLINE)] public static Color MultiplyRGB(this Color c, float m) => new Color(c.r * m, c.g * m, c.b * m, c.a);

		/// <summary>Returns the same color and alpha, but with the RGB values multiplief by another color</summary>
		/// <param name="m">The color to multiply RGB by</param>
		[MethodImpl(INLINE)] public static Color MultiplyRGB(this Color c, Color m) => new Color(c.r * m.r, c.g * m.g, c.b * m.b, c.a);

		/// <summary>Returns the same color, but with the alpha channel multiplied by the given value</summary>
		/// <param name="m">The multiplier for the alpha</param>
		[MethodImpl(INLINE)] public static Color MultiplyA(this Color c, float m) => new Color(c.r, c.g, c.b, c.a * m);

		#endregion

		#region Simple float and int operations

		/// <summary>Returns true if v is between or equal to <c>min</c> &amp; <c>max</c></summary>
		/// <seealso cref="Between(float,float,float)"/>
		[MethodImpl(INLINE)] public static bool Within(this float v, float min, float max) => v >= min && v <= max;

		/// <summary>Returns true if v is between or equal to <c>min</c> &amp; <c>max</c></summary>
		/// <seealso cref="Between(int,int,int)"/>
		[MethodImpl(INLINE)] public static bool Within(this int v, int min, int max) => v >= min && v <= max;

		/// <summary>Returns true if v is between, but not equal to, <c>min</c> &amp; <c>max</c></summary>
		/// <seealso cref="Within(float,float,float)"/>
		[MethodImpl(INLINE)] public static bool Between(this float v, float min, float max) => v > min && v < max;

		/// <summary>Returns true if v is between, but not equal to, <c>min</c> &amp; <c>max</c></summary>
		/// <seealso cref="Within(int,int,int)"/>
		[MethodImpl(INLINE)] public static bool Between(this int v, int min, int max) => v > min && v < max;

		/// <summary>Clamps the value to be at least <c>min</c></summary>
		[MethodImpl(INLINE)] public static float AtLeast(this float v, float min) => v < min ? min : v;

		/// <summary>Clamps the value to be at least <c>min</c></summary>
		[MethodImpl(INLINE)] public static int AtLeast(this int v, int min) => v < min ? min : v;

		/// <summary>Clamps the value to be at most <c>max</c></summary>
		[MethodImpl(INLINE)] public static float AtMost(this float v, float max) => v > max ? max : v;

		/// <summary>Clamps the value to be at most <c>max</c></summary>
		[MethodImpl(INLINE)] public static int AtMost(this int v, int max) => v > max ? max : v;

		/// <summary>Squares the value. Equivalent to <c>v*v</c></summary>
		[MethodImpl(INLINE)] public static float Square(this float v) => v * v;

		/// <summary>Squares the value. Equivalent to <c>v*v</c></summary>
		[MethodImpl(INLINE)] public static int Square(this int v) => v * v;

		/// <summary>The next integer, modulo <c>length</c>. Behaves the way you want with negative values for stuff like array index access etc</summary>
		[MethodImpl(INLINE)] public static int NextMod(this int value, int length) => (value + 1).Mod(length);

		/// <summary>The previous integer, modulo <c>length</c>. Behaves the way you want with negative values for stuff like array index access etc</summary>
		[MethodImpl(INLINE)] public static int PrevMod(this int value, int length) => (value - 1).Mod(length);

		#endregion

		#region Extension method counterparts of the static ManaMath functions - lots of boilerplate in here

		#region Math operations

		/// <inheritdoc cref="ManaMath.Sqrt(float)"/>
		[MethodImpl(INLINE)] public static float Sqrt(this float value) => ManaMath.Sqrt(value);

		/// <inheritdoc cref="ManaMath.Sqrt(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Sqrt(this Vector2 value) => ManaMath.Sqrt(value);

		/// <inheritdoc cref="ManaMath.Sqrt(Vector3)"/>
		[MethodImpl(INLINE)] public static Vector3 Sqrt(this Vector3 value) => ManaMath.Sqrt(value);

		/// <inheritdoc cref="ManaMath.Sqrt(Vector4)"/>
		[MethodImpl(INLINE)] public static Vector4 Sqrt(this Vector4 value) => ManaMath.Sqrt(value);

		/// <inheritdoc cref="ManaMath.Cbrt(float)"/>
		[MethodImpl(INLINE)] public static float Cbrt(this float value) => ManaMath.Cbrt(value);

		/// <inheritdoc cref="ManaMath.Pow(float, float)"/>
		[MethodImpl(INLINE)] public static float Pow(this float value, float exponent) => ManaMath.Pow(value, exponent);

		#endregion

		#region Absolute Values

		/// <inheritdoc cref="ManaMath.Abs(float)"/>
		[MethodImpl(INLINE)] public static float Abs(this float value) => ManaMath.Abs(value);

		/// <inheritdoc cref="ManaMath.Abs(int)"/>
		[MethodImpl(INLINE)] public static int Abs(this int value) => ManaMath.Abs(value);

		/// <inheritdoc cref="ManaMath.Abs(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Abs(this Vector2 v) => ManaMath.Abs(v);

		/// <inheritdoc cref="ManaMath.Abs(Vector3)"/>
		[MethodImpl(INLINE)] public static Vector3 Abs(this Vector3 v) => ManaMath.Abs(v);

		/// <inheritdoc cref="ManaMath.Abs(Vector4)"/>
		[MethodImpl(INLINE)] public static Vector4 Abs(this Vector4 v) => ManaMath.Abs(v);

		#endregion

		#region Clamping

		/// <inheritdoc cref="ManaMath.Clamp(float,float,float)"/>
		[MethodImpl(INLINE)] public static float Clamp(this float value, float min, float max) => ManaMath.Clamp(value, min, max);

		/// <inheritdoc cref="ManaMath.Clamp(Vector2,Vector2,Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Clamp(this Vector2 v, Vector2 min, Vector2 max) => ManaMath.Clamp(v, min, max);

		/// <inheritdoc cref="ManaMath.Clamp(Vector3,Vector3,Vector3)"/>
		[MethodImpl(INLINE)] public static Vector3 Clamp(this Vector3 v, Vector3 min, Vector3 max) => ManaMath.Clamp(v, min, max);

		/// <inheritdoc cref="ManaMath.Clamp(Vector4,Vector4,Vector4)"/>
		[MethodImpl(INLINE)] public static Vector4 Clamp(this Vector4 v, Vector4 min, Vector4 max) => ManaMath.Clamp(v, min, max);

		/// <inheritdoc cref="ManaMath.Clamp(int,int,int)"/>
		[MethodImpl(INLINE)] public static int Clamp(this int value, int min, int max) => ManaMath.Clamp(value, min, max);

		/// <inheritdoc cref="ManaMath.Clamp01(float)"/>
		[MethodImpl(INLINE)] public static float Clamp01(this float value) => ManaMath.Clamp01(value);

		/// <inheritdoc cref="ManaMath.Clamp01(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Clamp01(this Vector2 v) => ManaMath.Clamp01(v);

		/// <inheritdoc cref="ManaMath.Clamp01(Vector3)"/>
		[MethodImpl(INLINE)] public static Vector3 Clamp01(this Vector3 v) => ManaMath.Clamp01(v);

		/// <inheritdoc cref="ManaMath.Clamp01(Vector4)"/>
		[MethodImpl(INLINE)] public static Vector4 Clamp01(this Vector4 v) => ManaMath.Clamp01(v);

		/// <inheritdoc cref="ManaMath.ClampNeg1to1(float)"/>
		[MethodImpl(INLINE)] public static float ClampNeg1to1(this float value) => ManaMath.ClampNeg1to1(value);

		/// <inheritdoc cref="ManaMath.ClampNeg1to1(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 ClampNeg1to1(this Vector2 v) => ManaMath.ClampNeg1to1(v);

		/// <inheritdoc cref="ManaMath.ClampNeg1to1(Vector3)"/>
		[MethodImpl(INLINE)] public static Vector3 ClampNeg1to1(this Vector3 v) => ManaMath.ClampNeg1to1(v);

		/// <inheritdoc cref="ManaMath.ClampNeg1to1(Vector4)"/>
		[MethodImpl(INLINE)] public static Vector4 ClampNeg1to1(this Vector4 v) => ManaMath.ClampNeg1to1(v);

		#endregion

		#region Min & Max

		/// <inheritdoc cref="ManaMath.Min(Vector2)"/>
		[MethodImpl(INLINE)] public static float Min(this Vector2 v) => ManaMath.Min(v);

		/// <inheritdoc cref="ManaMath.Min(Vector3)"/>
		[MethodImpl(INLINE)] public static float Min(this Vector3 v) => ManaMath.Min(v);

		/// <inheritdoc cref="ManaMath.Min(Vector4)"/>
		[MethodImpl(INLINE)] public static float Min(this Vector4 v) => ManaMath.Min(v);

		/// <inheritdoc cref="ManaMath.Max(Vector2)"/>
		[MethodImpl(INLINE)] public static float Max(this Vector2 v) => ManaMath.Max(v);

		/// <inheritdoc cref="ManaMath.Max(Vector3)"/>
		[MethodImpl(INLINE)] public static float Max(this Vector3 v) => ManaMath.Max(v);

		/// <inheritdoc cref="ManaMath.Max(Vector4)"/>
		[MethodImpl(INLINE)] public static float Max(this Vector4 v) => ManaMath.Max(v);

		#endregion

		#region Signs & Rounding

		/// <inheritdoc cref="ManaMath.Sign(float)"/>
		[MethodImpl(INLINE)] public static float Sign(this float value) => ManaMath.Sign(value);

		/// <inheritdoc cref="ManaMath.Sign(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Sign(this Vector2 value) => ManaMath.Sign(value);

		/// <inheritdoc cref="ManaMath.Sign(Vector3)"/>
		[MethodImpl(INLINE)] public static Vector3 Sign(this Vector3 value) => ManaMath.Sign(value);

		/// <inheritdoc cref="ManaMath.Sign(Vector4)"/>
		[MethodImpl(INLINE)] public static Vector4 Sign(this Vector4 value) => ManaMath.Sign(value);

		/// <inheritdoc cref="ManaMath.Sign(int)"/>
		[MethodImpl(INLINE)] public static int Sign(this int value) => ManaMath.Sign(value);

		/// <inheritdoc cref="ManaMath.SignAsInt(float)"/>
		[MethodImpl(INLINE)] public static int SignAsInt(this float value) => ManaMath.SignAsInt(value);

		/// <inheritdoc cref="ManaMath.SignWithZero(float,float)"/>
		[MethodImpl(INLINE)] public static float SignWithZero(this float value, float zeroThreshold = 0.000001f) => ManaMath.SignWithZero(value, zeroThreshold);

		/// <inheritdoc cref="ManaMath.SignWithZero(Vector2,float)"/>
		[MethodImpl(INLINE)] public static Vector2 SignWithZero(this Vector2 value, float zeroThreshold = 0.000001f) => ManaMath.SignWithZero(value, zeroThreshold);

		/// <inheritdoc cref="ManaMath.SignWithZero(Vector3,float)"/>
		[MethodImpl(INLINE)] public static Vector3 SignWithZero(this Vector3 value, float zeroThreshold = 0.000001f) => ManaMath.SignWithZero(value, zeroThreshold);

		/// <inheritdoc cref="ManaMath.SignWithZero(Vector4,float)"/>
		[MethodImpl(INLINE)] public static Vector4 SignWithZero(this Vector4 value, float zeroThreshold = 0.000001f) => ManaMath.SignWithZero(value, zeroThreshold);

		/// <inheritdoc cref="ManaMath.SignWithZero(int)"/>
		[MethodImpl(INLINE)] public static int SignWithZero(this int value) => ManaMath.SignWithZero(value);

		/// <inheritdoc cref="ManaMath.SignWithZeroAsInt(float,float)"/>
		[MethodImpl(INLINE)] public static int SignWithZeroAsInt(this float value, float zeroThreshold = 0.000001f) => ManaMath.SignWithZeroAsInt(value, zeroThreshold);

		/// <inheritdoc cref="ManaMath.Floor(float)"/>
		[MethodImpl(INLINE)] public static float Floor(this float value) => ManaMath.Floor(value);

		/// <inheritdoc cref="ManaMath.Floor(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Floor(this Vector2 value) => ManaMath.Floor(value);

		/// <inheritdoc cref="ManaMath.Floor(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector3 Floor(this Vector3 value) => ManaMath.Floor(value);

		/// <inheritdoc cref="ManaMath.Floor(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector4 Floor(this Vector4 value) => ManaMath.Floor(value);

		/// <inheritdoc cref="ManaMath.FloorToInt(float)"/>
		[MethodImpl(INLINE)] public static int FloorToInt(this float value) => ManaMath.FloorToInt(value);

		/// <inheritdoc cref="ManaMath.FloorToInt(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2Int FloorToInt(this Vector2 value) => ManaMath.FloorToInt(value);

		/// <inheritdoc cref="ManaMath.FloorToInt(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector3Int FloorToInt(this Vector3 value) => ManaMath.FloorToInt(value);

		/// <inheritdoc cref="ManaMath.Ceil(float)"/>
		[MethodImpl(INLINE)] public static float Ceil(this float value) => ManaMath.Ceil(value);

		/// <inheritdoc cref="ManaMath.Ceil(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Ceil(this Vector2 value) => ManaMath.Ceil(value);

		/// <inheritdoc cref="ManaMath.Ceil(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector3 Ceil(this Vector3 value) => ManaMath.Ceil(value);

		/// <inheritdoc cref="ManaMath.Ceil(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector4 Ceil(this Vector4 value) => ManaMath.Ceil(value);

		/// <inheritdoc cref="ManaMath.CeilToInt(float)"/>
		[MethodImpl(INLINE)] public static int CeilToInt(this float value) => ManaMath.CeilToInt(value);

		/// <inheritdoc cref="ManaMath.CeilToInt(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2Int CeilToInt(this Vector2 value) => ManaMath.CeilToInt(value);

		/// <inheritdoc cref="ManaMath.CeilToInt(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector3Int CeilToInt(this Vector3 value) => ManaMath.CeilToInt(value);

		/// <inheritdoc cref="ManaMath.Round(float)"/>
		[MethodImpl(INLINE)] public static float Round(this float value) => ManaMath.Round(value);

		/// <inheritdoc cref="ManaMath.Round(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Round(this Vector2 value) => ManaMath.Round(value);

		/// <inheritdoc cref="ManaMath.Round(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector3 Round(this Vector3 value) => ManaMath.Round(value);

		/// <inheritdoc cref="ManaMath.Round(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector4 Round(this Vector4 value) => ManaMath.Round(value);

		/// <inheritdoc cref="ManaMath.Round(float)"/>
		[MethodImpl(INLINE)] public static float Round(this float value, float snapInterval) => ManaMath.Round(value, snapInterval);

		/// <inheritdoc cref="ManaMath.Round(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Round(this Vector2 value, float snapInterval) => ManaMath.Round(value, snapInterval);

		/// <inheritdoc cref="ManaMath.Round(Vector2,float)"/>
		[MethodImpl(INLINE)] public static Vector3 Round(this Vector3 value, float snapInterval) => ManaMath.Round(value, snapInterval);

		/// <inheritdoc cref="ManaMath.Round(Vector2,float)"/>
		[MethodImpl(INLINE)] public static Vector4 Round(this Vector4 value, float snapInterval) => ManaMath.Round(value, snapInterval);

		/// <inheritdoc cref="ManaMath.RoundToInt(float)"/>
		[MethodImpl(INLINE)] public static int RoundToInt(this float value) => ManaMath.RoundToInt(value);

		/// <inheritdoc cref="ManaMath.RoundToInt(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2Int RoundToInt(this Vector2 value) => ManaMath.RoundToInt(value);

		/// <inheritdoc cref="ManaMath.RoundToInt(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector3Int RoundToInt(this Vector3 value) => ManaMath.RoundToInt(value);

		#endregion

		#region Range Repeating

		/// <inheritdoc cref="ManaMath.Frac(float)"/>
		[MethodImpl(INLINE)] public static float Frac(this float x) => ManaMath.Frac(x);

		/// <inheritdoc cref="ManaMath.Frac(Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Frac(this Vector2 v) => ManaMath.Frac(v);

		/// <inheritdoc cref="ManaMath.Frac(Vector3)"/>
		[MethodImpl(INLINE)] public static Vector3 Frac(this Vector3 v) => ManaMath.Frac(v);

		/// <inheritdoc cref="ManaMath.Frac(Vector4)"/>
		[MethodImpl(INLINE)] public static Vector4 Frac(this Vector4 v) => ManaMath.Frac(v);

		/// <inheritdoc cref="ManaMath.Repeat(float,float)"/>
		[MethodImpl(INLINE)] public static float Repeat(this float value, float length) => ManaMath.Repeat(value, length);

		/// <inheritdoc cref="ManaMath.Mod(int,int)"/>
		[MethodImpl(INLINE)] public static int Mod(this int value, int length) => ManaMath.Mod(value, length);

		#endregion

		#region Smoothing & Easing Curves

		/// <inheritdoc cref="ManaMath.Smooth01(float)"/>
		[MethodImpl(INLINE)] public static float Smooth01(this float x) => ManaMath.Smooth01(x);

		/// <inheritdoc cref="ManaMath.Smoother01(float)"/>
		[MethodImpl(INLINE)] public static float Smoother01(this float x) => ManaMath.Smoother01(x);

		/// <inheritdoc cref="ManaMath.SmoothCos01(float)"/>
		[MethodImpl(INLINE)] public static float SmoothCos01(this float x) => ManaMath.SmoothCos01(x);

		#endregion

		#region Value & Vector interpolation

		/// <inheritdoc cref="ManaMath.Remap(float,float,float,float,float)"/>
		[MethodImpl(INLINE)] public static float Remap(this float v, float iMin, float iMax, float oMin, float oMax) => ManaMath.Remap(iMin, iMax, oMin, oMax, v);

		/// <inheritdoc cref="ManaMath.Remap(Vector2,Vector2,Vector2,Vector2,Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Remap(this Vector2 v, Vector2 iMin, Vector2 iMax, Vector2 oMin, Vector2 oMax) => ManaMath.Remap(iMin, iMax, oMin, oMax, v);

		/// <inheritdoc cref="ManaMath.Remap(Vector3,Vector3,Vector3,Vector3,Vector3)"/>
		[MethodImpl(INLINE)] public static Vector3 Remap(this Vector3 v, Vector3 iMin, Vector3 iMax, Vector3 oMin, Vector3 oMax) => ManaMath.Remap(iMin, iMax, oMin, oMax, v);

		/// <inheritdoc cref="ManaMath.Remap(Vector4,Vector4,Vector4,Vector4,Vector4)"/>
		[MethodImpl(INLINE)] public static Vector4 Remap(this Vector4 v, Vector4 iMin, Vector4 iMax, Vector4 oMin, Vector4 oMax) => ManaMath.Lerp(oMin, oMax, ManaMath.InverseLerp(iMin, iMax, v));

		/// <inheritdoc cref="ManaMath.Remap(Rect,Rect,Vector2)"/>
		[MethodImpl(INLINE)] public static Vector2 Remap(this Vector2 iPos, Rect iRect, Rect oRect) => Remap(iRect.min, iRect.max, oRect.min, oRect.max, iPos);

		/// <inheritdoc cref="ManaMath.Remap(Bounds,Bounds,Vector3)"/>
		[MethodImpl(INLINE)] public static Vector3 Remap(this Vector3 iPos, Bounds iBounds, Bounds oBounds) => Remap(iBounds.min, iBounds.max, oBounds.min, oBounds.max, iPos);

		/// <inheritdoc cref="ManaMath.Remap(float,float,float,float,float)"/>
		[MethodImpl(INLINE)] public static float RemapClamped(this float value, float iMin, float iMax, float oMin, float oMax) => ManaMath.Lerp(oMin, oMax, ManaMath.InverseLerpClamped(iMin, iMax, value));

		#endregion

		#region Vector Math

		/// <inheritdoc cref="ManaMath.GetDirAndMagnitude(Vector2)"/>
		[MethodImpl(INLINE)] public static (Vector2 dir, float magnitude) GetDirAndMagnitude(this Vector2 v) => ManaMath.GetDirAndMagnitude(v);

		/// <inheritdoc cref="ManaMath.GetDirAndMagnitude(Vector3)"/>
		[MethodImpl(INLINE)] public static (Vector3 dir, float magnitude) GetDirAndMagnitude(this Vector3 v) => ManaMath.GetDirAndMagnitude(v);

		/// <inheritdoc cref="ManaMath.ClampMagnitude(Vector2,float,float)"/>
		[MethodImpl(INLINE)] public static Vector2 ClampMagnitude(this Vector2 v, float min, float max) => ManaMath.ClampMagnitude(v, min, max);

		/// <inheritdoc cref="ManaMath.ClampMagnitude(Vector3,float,float)"/>
		[MethodImpl(INLINE)] public static Vector3 ClampMagnitude(this Vector3 v, float min, float max) => ManaMath.ClampMagnitude(v, min, max);

		#endregion

		#endregion


	}

}