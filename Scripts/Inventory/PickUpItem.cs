using Godot;

namespace Zelda2D.Scripts.Inventory;

public partial class PickUpItem : Area2D
{
    private CollisionShape2D _collisionShape;

    private Sprite2D _sprite;
    [ExportGroup("可拾取物配置")] [Export] public InventoryItem inventoryItem;
    [Export] public int ItemCount { get; set; } = 1;

    public override void _Ready()
    {
        _sprite = GetNode<Sprite2D>("Sprite2D");
        _collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        // 初始化
        _sprite.Texture = inventoryItem.Texture;
        _collisionShape.Shape = inventoryItem.GroundCollisionShape;
    }
}
