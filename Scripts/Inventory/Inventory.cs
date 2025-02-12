using Godot;
using LumiVerseFramework;

namespace Zelda2D.Scripts.Inventory;

public partial class Inventory : Node
{
    private CanvasLayerInventoryUi _inventoryUi;
    
    public override void _Ready()
    {
        _inventoryUi =
            GetNode<CanvasLayerInventoryUi>("../CanvasLayer_InventoryUI");
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("OpenInventory"))
        {
            _inventoryUi.Trigger();
        }
    }
}