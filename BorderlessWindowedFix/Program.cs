using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace BorderlessWindowedFix
{
    public class Program : ModSystem
    {
        private GameWindow? _gameWindow;
        private ILogger? _logger;
        private ICoreClientAPI? _api;

        public override void StartClientSide(ICoreClientAPI api)
        {
            _api = api;
            _logger = _api.Logger;

            if (OperatingSystem.IsWindows())
            {
                _gameWindow = _api.Forms.Window;

                ApplyFix();

                _gameWindow.Refresh += GameWindow_Refresh;

                _logger.Debug("BorderlessWindowedFix: Fix loaded");
            }
            else
            {
                _logger.Warning("BorderlessWindowedFix: Unsupported operating system, no changes made");
            }

            base.StartClientSide(_api);
        }

        private void GameWindow_Refresh()
        {
            _logger?.Debug("BorderlessWindowedFix: Window changed, reapplying fix");
            ApplyFix();
        }

        private void ApplyFix()
        {
            // MonitorInfo will change if window is moved to another monitor
            MonitorInfo? monitor = Monitors.GetMonitorFromWindow(_api?.Forms.Window) ?? null;

            if (monitor != null && _gameWindow != null)
            {
                // Check for borderless windowed mode
                if (_api?.Settings.Int["gameWindowMode"] == 2)
                {
                    _gameWindow.ClientSize = new Vector2i(monitor.HorizontalResolution, monitor.VerticalResolution);
                }
            }
            else
            {
                _logger?.Error("BorderlessWindowedFix: Game window or monitor could not be found");
            }
        }
    }
}
