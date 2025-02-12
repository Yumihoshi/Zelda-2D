using Godot;

namespace Zelda2D.Scripts.Inventory;

public partial class PickUpItem : Area2D
{
    [ExportGroup("金币信息")] [Export] public InventoryItem inventoryItem;
    
    private Sprite2D _sprite;
    private CollisionShape2D _collisionShape;

    public override void _Ready()
    {
        _sprite = GetNode<Sprite2D>("Sprite2D");
        _collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        // 初始化
        _sprite.Texture = inventoryItem.Texture;
        _collisionShape.Shape = inventoryItem.GroundCollisionShape;
    }
}
