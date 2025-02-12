using Godot;

namespace Zelda2D.Scripts.Inventory;

public partial class InventoryItem : Resource
{
    public enum SlotType
    {
        NotEquipable,
        RightHand,
        LeftHand,
        Potions
    }

    public int Count { get; set; } = 1;

    public string Name => _name;
    public SlotType Type => _type;
    public Texture2D Texture => _texture;
    public Texture2D SideTexture => _sideTexture;
    public RectangleShape2D GroundCollisionShape => _groundCollisionShape;
    public int MaxCount => _maxCount;
    public int Price => _price;

    [ExportGroup("物品信息")] [Export] private string _name = "";

    [Export] private SlotType _type = SlotType.NotEquipable;

    [Export] private Texture2D _texture;
    [Export] private Texture2D _sideTexture;
    
    [Export] private RectangleShape2D _groundCollisionShape;

    [Export] private int _maxCount;
    [Export] private int _price;
}
