using UnityEngine;

class HelperFunctions
{
    public static Vector2 WrapAroundViewport(Vector3 Position)
    {
        Vector2 viewPos = Camera.main.WorldToViewportPoint(Position);

        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            float newX = InverseClamp(viewPos.x);
            float newY = InverseClamp(viewPos.y);

            return Camera.main.ViewportToWorldPoint(new Vector2(newX, newY));
        }
        else
        {
            return Position;
        }
    }

    public static float InverseClamp(float value, float min = 0, float max = 1)
    {
        if(value < min)
        {
            return max;
        }
        else if(value > max)
        {
            return min;
        }
        else
        {
            return value;
        }
    }

    public static Vector2 RandomOnUnitCircle()
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);

        float x = Mathf.Cos(randomAngle);
        float y = Mathf.Sin(randomAngle);

        return new Vector2(x, y);
    }
}
