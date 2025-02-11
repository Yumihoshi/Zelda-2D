using System.ComponentModel;
using Godot;

namespace Zelda2D.Scripts;

public partial class Player : CharacterBody2D
{
    [ExportGroup("玩家属性")] [Export]
    public float Speed;

    public override void _PhysicsProcess(double delta)
    {
        Move((float)delta);
    }

    private void Move(float delta)
    {
        Vector2 direction =
            Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        // 有输入时移动
        if (direction != Vector2.Zero)
        {
            Velocity = Speed * delta * direction;
        }
        // 没有输入时减速
        else
        {
            Velocity = Velocity.MoveToward(Vector2.Zero, Speed * delta);
        }

        MoveAndSlide();
    }
}
