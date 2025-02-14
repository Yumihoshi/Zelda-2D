using Godot;

namespace Zelda2D.Scripts.FPS;

public partial class CanvasLayerFps : CanvasLayer
{
    private Label _labelFps;

    public override void _Ready()
    {
        _labelFps = GetNode<Label>("Label_FPS");
    }

    public override void _Process(double delta)
    {
        _labelFps.Text = "FPS: " + Engine.GetFramesPerSecond();
    }
}
