using UnityEditor;
using UnityEngine;
using System;

public class EdgeCollider2DEditor : EditorWindow {

	[MenuItem("Window/EdgeCollider2D Snap")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(EdgeCollider2DEditor));
	}

	EdgeCollider2D edge;
	Vector2[] vertices = new Vector2[0];
	LineRenderer line;
	Vector2 scrollPos = new Vector2();

	void OnGUI()
	{
		GUILayout.Label ("EdgeCollider2D point editor", EditorStyles.boldLabel);
		edge = (EdgeCollider2D) EditorGUILayout.ObjectField("EdgeCollider2D to edit", edge, typeof(EdgeCollider2D), true);
		line = (LineRenderer) EditorGUILayout.ObjectField("LineRenderer to edit", line, typeof(LineRenderer), true);

		GUILayout.Label ("Points ("+vertices.Length+")", EditorStyles.boldLabel);
		if (vertices.Length != 0) {
			scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
			for (int i = 0; i < vertices.Length; ++i) {
				vertices[i] = (Vector2) EditorGUILayout.Vector2Field("Element "+i, vertices[i]);
			}
			EditorGUILayout.EndScrollView();
		}

		GUILayout.Label ("Actions", EditorStyles.boldLabel);
		if (GUILayout.Button ("Retrieve From Collider")) {
			RetrieveCollider();
		}
		
		if (GUILayout.Button ("Set Values")) {
			SetValues();
		}

		if (GUILayout.Button ("Refresh References")) {
			Refresh();
		}

		if (GUILayout.Button ("Process all")) {
			Refresh();
			SetValues();
		}
	}

	void Refresh() {
		for (int i = 0; i < Selection.gameObjects.Length; ++i) {
			EdgeCollider2D aux = Selection.gameObjects[i].GetComponent<EdgeCollider2D>();
			if (aux)edge = aux;
			
			LineRenderer aux2 = Selection.gameObjects[i].GetComponent<LineRenderer>();
			if (aux2) line = aux2;
		}
	}

	void SetValues() {
		if (edge)
			edge.points = vertices;
		
		if (line) {
			for (int i = 0; i < vertices.Length; ++i) {
				line.SetPosition(i, (Vector3)vertices[i]);
			}
		}
	}

	void RetrieveCollider() {
		if (edge) {
			vertices = edge.points;
		}
	}
}
