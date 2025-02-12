using Godot;
using LumiVerseFramework;

namespace Zelda2D.Scripts.Player;

public partial class Player : CharacterBody2D
{
    [ExportGroup("玩家属性")] [Export] public float Speed;

    private PlayerAnim _playerAnim;
    private Vector2 _input;

    public override void _Ready()
    {
        _playerAnim = GetNode<PlayerAnim>("AnimationTree");
    }

    public override void _Process(double delta)
    {
        _input =
            Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        _playerAnim.PlayAnim(_input);
    }

    public override void _PhysicsProcess(double delta)
    {
        Move((float)delta);
    }

    private void Move(float delta)
    {
        // 有输入时移动
        if (_input != Vector2.Zero)
        {
            Velocity = Speed * delta * _input;
        }
        // 没有输入时减速
        else
        {
            Velocity = Velocity.MoveToward(Vector2.Zero, Speed * delta);
        }

        MoveAndSlide();
    }
}
