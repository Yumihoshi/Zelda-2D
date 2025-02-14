// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/13 17:02
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Godot;
using LumiVerseFramework.Common;

namespace Zelda2D.Scripts.Inventory.Weapon;

public partial class WeaponItem : Resource
{
    [ExportGroup("武器属性")] [Export] private AttackType _attackType;
    [Export] private RectangleShape2D _collisionShape;
    [Export] private Vector2 _downAttachmentPosition;
    [Export] private int _downRotation;
    [Export] private int _downZIndex;

    [ExportGroup("依赖配置")] [Export] private Texture2D _inHandTexture;
    [Export] private Vector2 _leftAttachmentPosition;
    [Export] private int _leftRotation;
    [Export] private int _leftZIndex;
    [Export] private Vector2 _rightAttachmentPosition;
    [Export] private int _rightRotation;
    [Export] private int _rightZIndex;
    [Export] private Texture2D _sideInHandTexture;

    [ExportGroup("手持物品位置")] [Export] private Vector2 _upAttachmentPosition;

    [ExportGroup("旋转")] [Export] private int _upRotation;

    [ExportGroup("Z轴索引")] [Export] private int _upZIndex;

    /// <summary>
    /// 获取手持物品贴图相关数据
    /// </summary>
    /// <param name="direction">方向</param>
    /// <returns></returns>
    public Dictionary<string, object> GetDataForDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return new Dictionary<string, object>
                {
                    { "AttachmentPosition", _upAttachmentPosition },
                    { "Rotation", _upRotation },
                    { "ZIndex", _upZIndex }
                };
            case Direction.Down:
                return new Dictionary<string, object>
                {
                    { "AttachmentPosition", _downAttachmentPosition },
                    { "Rotation", _downRotation },
                    { "ZIndex", _downZIndex }
                };
            case Direction.Left:
                return new Dictionary<string, object>
                {
                    { "AttachmentPosition", _leftAttachmentPosition },
                    { "Rotation", _leftRotation },
                    { "ZIndex", _leftZIndex }
                };
            case Direction.Right:
                return new Dictionary<string, object>
                {
                    { "AttachmentPosition", _rightAttachmentPosition },
                    { "Rotation", _rightRotation },
                    { "ZIndex", _rightZIndex }
                };
            default:
                YumihoshiDebug.Error<WeaponItem>("武器方向",
                    $"{direction.ToString()}枚举类型不存在");
                return null;
        }
    }
}
