using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class VectorUtil {
    public static Vector2 Displacement(Vector2 a, Vector2 b) {
        return b - a;
    }

    public static Vector3 Displacement(Vector3 a, Vector3 b) {
        return b - a;
    }
}