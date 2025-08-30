// cee00d2aaa71742248a1a43893a85c11, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ActivateTrigger
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
	public enum Mode
	{
		Trigger,
		Replace,
		Activate,
		Enable,
		Animate,
		Deactivate
	}

	public Mode action = Mode.Activate;

	public Object target;

	public GameObject source;

	public int triggerCount = 1;

	public bool repeatTrigger;

	private void DoActivateTrigger()
	{
		triggerCount--;
		if (triggerCount != 0 && !repeatTrigger)
		{
			return;
		}
		Object obj = ((!(target != null)) ? base.gameObject : target);
		Behaviour behaviour = obj as Behaviour;
		GameObject gameObject = obj as GameObject;
		if (behaviour != null)
		{
			gameObject = behaviour.gameObject;
		}
		switch (action)
		{
		case Mode.Trigger:
			gameObject.BroadcastMessage("DoActivateTrigger");
			break;
		case Mode.Replace:
			if (source != null)
			{
				Object.Instantiate(source, gameObject.transform.position, gameObject.transform.rotation);
				Object.DestroyObject(gameObject);
			}
			break;
		case Mode.Activate:
			gameObject.active = true;
			break;
		case Mode.Enable:
			if (behaviour != null)
			{
				behaviour.enabled = true;
			}
			break;
		case Mode.Animate:
			gameObject.animation.Play();
			break;
		case Mode.Deactivate:
			gameObject.active = false;
			break;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		DoActivateTrigger();
	}
}
