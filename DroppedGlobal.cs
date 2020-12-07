using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace DroppedRotation
{
	public class DroppedGlobal : GlobalItem
	{
		public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			Texture2D texture = Main.itemTexture[item.type];
			Vector2 position = item.position - Main.screenPosition + new Vector2(item.width / 2, item.height - texture.Height * 0.5f + 2f);

			RotationStorage storage;
			if (DroppedRotation.rotations[whoAmI].itemType != item.type)
				storage = new RotationStorage(Main.rand.NextFloat(.8f, .1f), type: item.type);
			else
				storage = DroppedRotation.rotations[whoAmI];

			// Vertical movement
			if (DroppedRotation.verticalEnabled)
			{
				storage.YIncrease = storage.Y > 1.5 ? false : (storage.Y < -2.5 ? true : storage.YIncrease);
				storage.Y += storage.YIncrease ? 0.05f : -0.05f;
				position += new Vector2(0, storage.Y);
			}

			// Horizontal movement
			Vector2 modifiedScale = new Vector2(1f, 1f);
			if (DroppedRotation.rotationEnabled)
			{
				storage.XIncrease = storage.X > .9 ? false : (storage.X < -.9 ? true : storage.XIncrease);
				storage.X += storage.XIncrease ? DroppedRotation.rotationIncrease : -DroppedRotation.rotationIncrease;

				modifiedScale = new Vector2((scale * MathHelper.Clamp(Math.Abs(storage.X), 0f, 1f)), scale);
			}

			spriteBatch.Draw(texture, position, null, alphaColor, rotation, texture.Size() * 0.5f, 
								modifiedScale, storage.X > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);

			// Depth, AKA 3D mode
			if (DroppedRotation.depthEnabled)
			{
				for (int i = 1; i <= DroppedRotation.depthLayers; i++)
				{
					spriteBatch.Draw(texture, position + new Vector2(i, 0), null, alphaColor, rotation, texture.Size() * 0.5f,
									modifiedScale, storage.X > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
				}
			}

			DroppedRotation.rotations[whoAmI] = storage;
			return false;
		}
	}
}
