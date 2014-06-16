using UnityEngine;
using System.Collections;
using Leap;

/**
 * This is a static library of leap helper methods.
 * It is not a MonoBehavior and is not instantiale. 
 */

public class LeapUtils
{

		public static int minX = -40;
		public static  int maxX = 40;
		public  static int minY = 120;
		public  static int maxY = 300;
		/**
		 * WILL RETURN INVALID HAND if no hands are found.
		 */

		public static Hand FrontHand (Frame frame)
		{
				Hand h;
				h = Hand.Invalid;
				if (!frame.IsValid) {
						return h;
				}

				foreach (Hand hand in frame.Hands) {
						if (hand.IsValid) {
								if ((!h.IsValid) || h.PalmPosition.z < hand.PalmPosition.z) {
										h = hand;
								}
						}
				}

				return h;
		}

		public static Finger FrontFinger (Frame frame)
		{
				return frame.IsValid ? FrontFinger (frame.Fingers) : Finger.Invalid;
		}

		public static Finger FrontFinger (Hand hand)
		{
				return hand.IsValid ? FrontFinger (hand.Fingers) : Finger.Invalid;
		}

		public static Vector2 Normalize2 (Vector2 v)
		{
				return new Vector2 ((v.x - minX) / (maxX - minX), (v.y - minY) / (maxY - minY));
		}

		public static Finger FrontFinger (FingerList fingers)
		{
				Finger f = Finger.Invalid;

				foreach (Finger finger in fingers) {
						if ((!f.IsValid) || f.StabilizedTipPosition.z < finger.StabilizedTipPosition.z) {
								f = finger;
						}
				}
				return f;
		}

		public static Vector2 ToVector2 (Hand hand, bool normalize)
		{
				return normalize ? Normalize2 (ToVector2 (hand)) : ToVector2 (hand);
		}

		public static Vector2 ToVector2 (Hand hand)
		{
				return new Vector2 (hand.StabilizedPalmPosition.x, hand.StabilizedPalmPosition.y);
		}
	
		public static Vector2 ToVector2 (Finger finger, bool normalize)
		{
				return normalize ? Normalize2 (ToVector2 (finger)) : ToVector2 (finger);
		}

		public static Vector2 ToVector2 (Finger finger)
		{
				return new Vector2 (finger.StabilizedTipPosition.x, finger.StabilizedTipPosition.y);
		}
}
