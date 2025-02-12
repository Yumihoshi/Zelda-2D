using Godot;
using LumiVerseFramework;

namespace Zelda2D.Scripts.Player;

public partial class PlayerAnim : AnimationTree
{
    private Vector2 _lastDirection = Vector2.Down;

    public void PlayAnim(Vector2 direction)
    {
        if (direction == Vector2.Zero)
        {
            Set("parameters/conditions/IsIdling", true);
            Set("parameters/conditions/IsMoving", false);
            Set("parameters/Idle/blend_position", _lastDirection);
        }
        else
        {
            Set("parameters/conditions/IsIdling", false);
            Set("parameters/conditions/IsMoving", true);
            Set("parameters/Move/blend_position", direction);
            _lastDirection = direction;
        }
    }
}
