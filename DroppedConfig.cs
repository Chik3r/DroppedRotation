using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace DroppedRotation
{
	public class DroppedConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Range(0.01f, 0.2f)]
		[Increment(0.01f)]
		[DefaultValue(0.09f)]
		public float RotationIncrease;

		public override void OnChanged()
		{
			DroppedRotation.rotationIncrease = RotationIncrease;
		}
	}
}
