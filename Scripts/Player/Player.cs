using Godot;

namespace Zelda2D.Scripts.Player;

public partial class Player : CharacterBody2D
{
    [ExportGroup("玩家属性")] [Export] public float Speed;

    private PlayerAnimationController _animationController;

    public override void _Ready()
    {
        // 获取动画控制器
        _animationController =
            GetNode<PlayerAnimationController>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        Move((float)delta);
    }

    private void Move(float delta)
    {
        // 获取输入方向
        Vector2 direction =
            Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        // 有输入时移动
        if (direction != Vector2.Zero)
            Velocity = Speed * delta * direction;
        // 没有输入时减速
        else
            Velocity = Velocity.MoveToward(Vector2.Zero, Speed * delta);

        MoveAndSlide();
    }
}
