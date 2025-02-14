using Godot;
using Zelda2D.Scripts.Inventory.Weapon;

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

    [ExportGroup("物品信息")] [Export] public string Name { get; set; } = "";
    [Export] public SlotType Type { get; set; } = SlotType.NotEquipable;
    [Export] public Texture2D Texture { get; set; }
    [Export] public Texture2D SideTexture { get; set; }
    [Export] public RectangleShape2D GroundCollisionShape { get; set; }
    [Export] public int MaxCount { get; set; }
    [Export] public int Count { get; set; } = 1;
    [Export] public int Price { get; set; }

    [ExportGroup("可选")]
    [Export]
    public WeaponItem WeaponItemInventory { get; set; }
}
