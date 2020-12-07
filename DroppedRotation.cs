using Terraria.ModLoader;

namespace DroppedRotation
{
	public class DroppedRotation : Mod
	{
		public static RotationStorage[] rotations;
		public static bool rotationEnabled;
		public static float rotationIncrease;
		public static bool verticalEnabled;
		public static float verticalIncrease;

		public override void Load()
		{
			rotations = new RotationStorage[byte.MaxValue];
			rotationEnabled = ModContent.GetInstance<DroppedConfig>().RotationEnabled;
			rotationIncrease = ModContent.GetInstance<DroppedConfig>().RotationIncrease;
			verticalEnabled = ModContent.GetInstance<DroppedConfig>().VerticalEnabled;
			verticalIncrease = ModContent.GetInstance<DroppedConfig>().VerticalIncrease;
		}

		public override void Unload()
		{
			rotations = null;
		}
	}

	public struct RotationStorage
	{
		public float X;
		public bool XIncrease;
		public float Y;
		public bool YIncrease;
		public int itemType;

		public RotationStorage(float x = 1f, bool xIncrease = false, float y = 0f, bool yIncrease = false, int type = -1)
		{
			X = x;
			XIncrease = xIncrease;
			Y = y;
			YIncrease = yIncrease;
			itemType = type;
		}
	}
}