using Godot;

namespace Zelda2D.Scripts.Player;

public partial class PlayerAnim : AnimationPlayer
{
    private Vector2 _lastDirection = Vector2.Down;

    public void PlayAnim(Vector2 direction)
    {
        if (direction.X != 0 && direction.Y != 0) return;
        if (direction == Vector2.Zero)
        {
            if (_lastDirection.X > 0)
            {
                Play("Player/IdleRight");
            }
            else if (_lastDirection.X < 0)
            {
                Play("Player/IdleLeft");
            }
            else if (_lastDirection.Y > 0)
            {
                Play("Player/IdleDown");
            }
            else if (_lastDirection.Y < 0)
            {
                Play("Player/IdleUp");
            }
        }
        else
        {
            if (direction.X > 0)
            {
                Play("Player/MoveRight");
            }
            else if (direction.X < 0)
            {
                Play("Player/MoveLeft");
            }
            else if (direction.Y > 0)
            {
                Play("Player/MoveDown");
            }
            else if (direction.Y < 0)
            {
                Play("Player/MoveUp");
            }
        }

        _lastDirection = direction;
    }
}
