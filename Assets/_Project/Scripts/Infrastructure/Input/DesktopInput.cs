using UnityEngine;

namespace Project
{
    public class DesktopInput : IInput
    {
        private readonly Camera _camera;

        public Vector2 WorldMousePosition => _camera.ScreenToWorldPoint(Input.mousePosition);

        public DesktopInput(Camera camera) =>
            _camera = camera;
    }
}
