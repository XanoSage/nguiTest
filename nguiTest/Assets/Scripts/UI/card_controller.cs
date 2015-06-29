using UnityEngine;
using System.Collections;

public class card_controller : MonoBehaviour {

	#region Variables

	private card_model _model;

	#endregion

	#region MonoBehaviours Actions

	// Use this for initialization

	void Awake()
	{
		_model = GetComponent<card_model>();

		if (_model == null) {
			throw new MissingComponentException("card_controller.Start - can't find card_model_component");
		}
	}

	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region Actions

	public void Init(int card_number)
	{
		_model.card_number.text = card_number.ToString();
	}

	#endregion
}
