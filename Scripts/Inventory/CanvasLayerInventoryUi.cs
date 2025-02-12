using Godot;
using LumiVerseFramework;

namespace Zelda2D.Scripts.Inventory;

public partial class CanvasLayerInventoryUi : CanvasLayer
{
    [ExportGroup("背包槽位设置")] [Export] public int Size { get; set; } = 8;
    [Export] public int Column { get; set; } = 4;

    private GridContainer _gridContainer;
    private PackedScene _inventorySlotPrefab;

    public override void _Ready()
    {
        InitNode();
        Init();
    }

    private void InitNode()
    {
        _gridContainer = GetNode<GridContainer>("%GridContainer");
        _inventorySlotPrefab =
            ResourceLoader.Load<PackedScene>(
                "res://Prefabs/UI/InventorySlot.tscn");
    }

    private void Init()
    {
        // 初始化
        _gridContainer.Columns = Column;
        for (int i = 0; i < Size; i++)
        {
            Node inventorySlot = _inventorySlotPrefab.Instantiate();
            _gridContainer.AddChild(inventorySlot);
        }
    }

    /// <summary>
    /// 切换显示状态
    /// </summary>
    public void Trigger()
    {
        Visible = !Visible;
    }
}
