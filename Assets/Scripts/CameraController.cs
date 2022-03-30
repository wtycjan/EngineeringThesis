using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Camera arCamera;
	[SerializeField] private SoundController soundController;
	[SerializeField] private AppSettings settings;

	private List<InteractiveObject> objectList;
	private InteractiveObject lastDetectedInteractiveObject;
	private RaycastHit hitObject;
	private float playTimer = 0;
	private float stopTimer = 0;

	private void Start()
	{
		objectList = FindObjectsOfType<InteractiveObject>().ToList();
	}

	void Update()
	{
		HandleRaycast();
	}

	private void HandleRaycast()
	{
		var screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, arCamera.nearClipPlane);
		Vector3 cameraCenter = arCamera.ScreenToWorldPoint(screenCenter);

		Debug.DrawRay(cameraCenter, transform.forward * settings.RaycastLength, Color.red);
		Physics.Raycast(cameraCenter, transform.forward, out hitObject, settings.RaycastLength, Physics.AllLayers);

		if (hitObject.collider != null && settings.InteractiveObjectLayer.Contains(hitObject.collider.gameObject.layer))
		{
			HandleDisplayingVideo();
		}
		else if(hitObject.collider != null && settings.VideoLayer.Contains(hitObject.collider.gameObject.layer))
		{
			HandleWatchingVideo();
		}
		else
		{
			HandleHidingVideo();
		}
	}

	private void HandleHidingVideo()
	{
		if (stopTimer > settings.TimeToHideVideo)
		{
			ChangeVideoPlaying(null);
			return;
		}

		stopTimer += Time.deltaTime;
		playTimer = 0;
	}

	private void HandleDisplayingVideo()
	{
		if (playTimer > settings.TimeToShowVideo)
		{
			PlaySoundForObject(lastDetectedInteractiveObject);
			ChangeVideoPlaying(lastDetectedInteractiveObject);
			return;
		}

		InteractiveObject interactiveObject = hitObject.collider.GetComponent<InteractiveObject>();
		if (lastDetectedInteractiveObject == interactiveObject)
		{
			playTimer += Time.deltaTime;
			stopTimer = 0;
		}
		else
		{
			playTimer = 0;

			lastDetectedInteractiveObject = interactiveObject;
			return;
		}
	}

	private void HandleWatchingVideo()
	{
		stopTimer = 0;
	}
	
	private void ChangeVideoPlaying(InteractiveObject selected)
	{
		foreach (InteractiveObject current in objectList)
		{
			if (selected != current && current.IsPlaying)
			{
				current.HideVideo();
			}
			else if(selected == current && !current.IsPlaying)
			{
				current.PlayVideo();
			}
		}
	}

	private void PlaySoundForObject(InteractiveObject selected)
	{
		if (!selected.IsPlaying)
		{
			var sound = settings.Sounds.Find(x => x.objectType == selected.ObjectType);
			soundController.PlaySelectedAudioClip(sound.sound);
		}
	}
}
