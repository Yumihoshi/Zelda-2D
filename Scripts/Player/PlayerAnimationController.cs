using System.Collections.Generic;
using Godot;

namespace Zelda2D.Scripts.Player;

public partial class PlayerAnimationController : AnimatedSprite2D
{
	private readonly Dictionary<string, string> _movementToIdle = new()
	{
		{"MoveLeft", "IdleLeft"},
		{"MoveRight", "IdleRight"},
		{"MoveUp", "IdleUp"},
		{"MoveDown", "IdleDown"},
	};

	/// <summary>
	/// 播放动画
	/// </summary>
	/// <param name="direction"></param>
	public void PlayMoveAnim(Vector2 direction)
	{
		if (direction.X > 0)
		{
			Play("MoveRight");
		}
		else if (direction.X < 0)
		{
			Play("MoveLeft");
		}
		
		if (direction.Y > 0)
		{
			Play("MoveDown");
		}
		else if (direction.Y < 0)
		{
			Play("MoveUp");
		}
	}

	/// <summary>
	/// 播放空闲动画
	/// </summary>
	public void PlayIdleAnim()
	{
		if (_movementToIdle.TryGetValue(Animation, out string idleAnimation))
		{
			Play(idleAnimation);
		}
	}
}