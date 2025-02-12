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

    public int Count = 1;

    [ExportGroup("物品信息")] [Export] public string Name = "";

    [Export] public SlotType Type = SlotType.NotEquipable;

    [Export] public Texture2D Texture;
    [Export] public Texture2D SideTexture;

    /// <summary>
    /// 地面碰撞形状
    /// </summary>
    [Export] public RectangleShape2D GroundCollisionShape;

    [Export] public int MaxCount;
    [Export] public int Price;
}
