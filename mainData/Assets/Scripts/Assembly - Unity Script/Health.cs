// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Health
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Health : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class Hit$75 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Health $self_422;

			public $(Health self_)
			{
				$self_422 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					if (!$self_422.rigidbody.isKinematic)
					{
						if ($self_422.DamageFlashTimer == 0f)
						{
							$self_422.Health = checked($self_422.Health - 1);
							$self_422.BroadcastMessage("audioOn", 16);
							$self_422.SendMessage("boostOff");
							$self_422.SendMessage("setGUIHealth", $self_422.Health);
							$self_422.DamageFlashTimer = $self_422.DamageFlashTime;
							RenderSettings.ambientLight = Color.red;
							Camera.main.SendMessage("cameraShake");
						}
						if ($self_422.Health > 0)
						{
							$self_422.renderer.material.color = Color.red;
							return Yield(2, new WaitForSeconds(1f));
						}
						UnityEngine.Object.Instantiate($self_422.Explosion, $self_422.transform.position, Quaternion.identity);
						GameObject.Find("LevelControl").SendMessage("playerKilled");
						UnityEngine.Object.Destroy($self_422.gameObject);
					}
					goto IL_017f;
				case 2:
					$self_422.renderer.material.color = Color.white;
					goto IL_017f;
				case 1:
					break;
					IL_017f:
					Yield(1, null);
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Health $self_423;

		public Hit$75(Health self_)
		{
			$self_423 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_423);
		}
	}

	public int Health;

	public Transform Explosion;

	public float DamageFlashTime;

	private float DamageFlashTimer;

	private Color StartAmbientLight;

	public Health()
	{
		DamageFlashTime = 0.75f;
	}

	public void Start()
	{
		StartAmbientLight = RenderSettings.ambientLight;
		Camera.main.SendMessage("setShakeTime", DamageFlashTime);
		SendMessage("setGUIHealth", Health);
	}

	public void Update()
	{
		if (DamageFlashTimer > 0f)
		{
			DamageFlashTimer -= Time.deltaTime;
			if (DamageFlashTimer < 0f)
			{
				DamageFlashTimer = 0f;
				RenderSettings.ambientLight = StartAmbientLight;
			}
		}
	}

	public IEnumerator Hit()
	{
		return new Hit$75(this).GetEnumerator();
	}

	public void makeInvincible()
	{
		DamageFlashTimer = 1f;
	}

	public void healthCollected()
	{
		checked
		{
			Health++;
			if (Health > 5)
			{
				Health = 5;
			}
			SendMessage("setGUIHealth", Health);
		}
	}

	public void Main()
	{
	}
}
