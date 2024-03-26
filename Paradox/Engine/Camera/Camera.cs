using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Paradox
{

    public class Camera
    {
        public Matrix Transform { get; private set; }
        public Vector2 Position { get; set; }
        private float zoom = 1.0f;
        private Rectangle? bounds;
        private Viewport _viewport;

        public Camera(Viewport viewport, Rectangle? bounds = null)
        {
            this.bounds = bounds;
            UpdateMatrix(ref viewport);
        }

        public void UpdateMatrix(ref Viewport viewport)
        {
            Transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                        Matrix.CreateScale(zoom) *
                        Matrix.CreateTranslation(new Vector3(viewport.Width * 0.5f, viewport.Height * 0.5f, 0));
            ClampToBounds();
        }

        private void ClampToBounds()
        {
            if (!bounds.HasValue) return;

            var cameraMax = new Vector2(bounds.Value.X + bounds.Value.Width - (_viewport.Width / zoom),
                bounds.Value.Y + bounds.Value.Height - (_viewport.Height / zoom));

            Position = Vector2.Clamp(Position, new Vector2(bounds.Value.X, bounds.Value.Y), cameraMax);
        }

        public void Follow(Vector2 target)
        {
            Position = target;
            // Here you can implement logic to smoothly follow the target instead of snapping to it
        }
    }

}