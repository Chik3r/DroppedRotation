using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace DroppedRotation
{
	public class DroppedConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Header("Rotation")]
		[DefaultValue(true)]
		[Label("Enable rotation for dropped items")]
		public bool RotationEnabled;

		[Range(0.01f, 0.2f)]
		[Increment(0.01f)]
		[DefaultValue(0.05f)]
		[Label("Rotation speed")]
		public float RotationIncrease;

		[DefaultValue(true)]
		[Header("Vertical Movement")]
		[Label("Enable vertical movement for dropped items")]
		public bool VerticalEnabled;

		[Range(0.01f, 0.2f)]
		[Increment(0.01f)]
		[DefaultValue(0.09f)]
		[Label("Vertical speed")]
		public float VerticalIncrease;

		public override void OnChanged()
		{
			DroppedRotation.rotationEnabled = RotationEnabled;
			DroppedRotation.rotationIncrease = RotationIncrease;
			DroppedRotation.verticalEnabled = VerticalEnabled;
			DroppedRotation.verticalIncrease = VerticalIncrease;
		}
	}
}
