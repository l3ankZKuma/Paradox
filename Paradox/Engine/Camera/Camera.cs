using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Camera
{
    public Matrix ViewMatrix;
    private Vector2 _position;
    private Viewport _viewport;

    public Camera(Viewport viewport)
    {
        _viewport = viewport;
        UpdateViewMatrix();
    }

    public void Follow(Vector2 targetPosition, float lerpFactor = 0.1f)
    {
        // Calculate the desired x position to follow the target, maintaining the centering effect.
        float desiredX = targetPosition.X - _viewport.Width / 2f;

        // Linearly interpolates between the current x position and the desired x position based on the lerpFactor.
        _position.X = MathHelper.Lerp(_position.X, desiredX, lerpFactor);

        // Ensure the x-position is always greater than or equal to 0.
        _position.X = Math.Max(_position.X, 0);

        // Ensure the camera does not go beyond the maximum x limit (12800 - viewport width)
        float maxX = 12520+280 - _viewport.Width;
        _position.X = Math.Min(_position.X, maxX);

        // y-position remains unchanged, meaning it's fixed to whatever value it was set to initially or otherwise.

        UpdateViewMatrix();
    }

    private void UpdateViewMatrix()
    {
        ViewMatrix = Matrix.CreateTranslation(new Vector3(-_position, 0));
    }
}