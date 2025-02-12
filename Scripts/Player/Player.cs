using Godot;
using LumiVerseFramework;
using Zelda2D.Scripts.Inventory;

namespace Zelda2D.Scripts.Player;

public partial class Player : CharacterBody2D
{
    [ExportGroup("玩家属性")] [Export] public float speed;

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

    /// <summary>
    /// 和地面拾取物品的碰撞检测
    /// </summary>
    /// <param name="area"></param>
    private void OnAreaEntered(Area2D area)
    {
        if (area is not PickUpItem) return;
        area.QueueFree();
    }

    private void Move(float delta)
    {
        // 有输入时移动
        if (_input != Vector2.Zero)
        {
            Velocity = speed * delta * _input;
        }
        // 没有输入时减速
        else
        {
            Velocity = Velocity.MoveToward(Vector2.Zero, speed * delta);
        }

        MoveAndSlide();
    }
}
