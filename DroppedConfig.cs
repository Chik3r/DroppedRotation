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

		[DefaultValue(false)]
		[Header("[Experimental] \"3D\" Items")]
		[Label("Add depth to dropped items")]
		public bool DepthEnabled;

		[Range(1, 4)]
		[Increment(1)]
		[DefaultValue(1)]
		[Label("Depth amount for dropped items")]
		[DrawTicks]
		public int DepthLayers;

		public override void OnChanged()
		{
			DroppedRotation.rotationEnabled = RotationEnabled;
			DroppedRotation.rotationIncrease = RotationIncrease;
			DroppedRotation.verticalEnabled = VerticalEnabled;
			DroppedRotation.verticalIncrease = VerticalIncrease;
			DroppedRotation.depthEnabled = DepthEnabled;
			DroppedRotation.depthLayers = DepthLayers;
		}
	}
}
