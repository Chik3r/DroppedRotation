using Terraria.ModLoader;

namespace DroppedRotation
{
	public class DroppedRotation : Mod
	{
		public static RotationStorage[] rotations;
		public static float rotationIncrease;

		public override void Load()
		{
			rotations = new RotationStorage[byte.MaxValue];
			rotationIncrease = ModContent.GetInstance<DroppedConfig>().RotationIncrease;
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
		public int itemType;

		public RotationStorage(float x = 1f, bool xIncrease = false, int type = -1)
		{
			X = x;
			XIncrease = xIncrease;
			itemType = type;
		}
	}
}