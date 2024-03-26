using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    public class Camera
    {
        private Viewport viewport; // Store the viewport
        

        public Matrix Transform { get; private set; }
        public Vector2 Position { get; set; }
        private float zoom = 1.0f;
        private Rectangle? bounds;

        public Camera(Viewport viewport, Rectangle? bounds = null)
        {
            this.viewport = viewport; // Store the viewport
            this.bounds = bounds;
            UpdateMatrix();
        }

        public void UpdateMatrix()
        {
            Transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                        Matrix.CreateScale(zoom) *
                        Matrix.CreateTranslation(new Vector3(viewport.Width * 0.5f, viewport.Height * 0.5f, 0));
            ClampToBounds();
        }

        private void ClampToBounds()
        {
            if (!bounds.HasValue) return;

            var cameraMax = new Vector2(bounds.Value.X + bounds.Value.Width - (viewport.Width / zoom),
                bounds.Value.Y + bounds.Value.Height - (viewport.Height / zoom));

            Position = Vector2.Clamp(Position, new Vector2(bounds.Value.X, bounds.Value.Y), cameraMax);
        }

        public void Follow(Vector2 target)
        {
            Position = target - new Vector2(viewport.Width / 2, viewport.Height / 2);
            ClampToBounds();
        }
    }
}