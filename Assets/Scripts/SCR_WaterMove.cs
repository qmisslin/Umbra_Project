﻿using UnityEngine;
using System.Collections;

public class SCR_WaterMove : MonoBehaviour {

	public Vector3 speed = new Vector3(0.01f,1.5f,0f);
	public float waveHeight =  0.5f;
	public float distortionSpeed = 1.0f;

	Material m_Material;
	Vector2 textureOffset;
	Vector3 position;
	float time;
	float initYPos;


	void Start () {

		/* Init var */
		m_Material = GetComponent<Renderer>().material;
		textureOffset = m_Material.GetTextureOffset("_BumpMap");

		m_Material.SetFloat("_Distortion", 12.5f);

		position = transform.position;
		initYPos = position.y;
		time = 0f;
	}

	void Update () {
		/* Wave speed direction */
		textureOffset.x += speed.x * Time.deltaTime;
		textureOffset.y += speed.z * Time.deltaTime;
		m_Material.SetTextureOffset("_BumpMap", textureOffset);
		
		/* Wave speed height */
		time = time + speed.y * Time.deltaTime;
		position.y = initYPos + Mathf.Sin(time) * waveHeight;
		transform.position = position;
	
		/* Changement de la distortion */
		m_Material.SetFloat("_Distortion", 20.0f + 5.0f * Mathf.Sin(time * distortionSpeed));
	}
}
