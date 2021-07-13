using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public Transform target;

	public float smoothSpeed = 10f;
	public Vector3 offset;
	[SerializeField] GameObject panel;
	CanvasGroup CG;
	public float fadeModifier;

    private void Start()
    {
		CG = panel.GetComponent<CanvasGroup>();
	}

    void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;

		transform.LookAt(target);


		CG.alpha += Time.deltaTime / fadeModifier;
	}

	public void reset()
    {
		CG.alpha = 0;
	}


}
