using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class card_deck_controller : MonoBehaviour {

	#region Constants

	private const int CardInDeck = 52;

	#endregion

	#region Variables

	private card_deck_model _model;

	private Color one_card_color = Color.green;

	private Color second_card_color = Color.cyan;

	private Color third_card_color = Color.yellow;

	private Color fourth_card_color = Color.red;

	private List<Color> card_colors;

	private List<card_controller> card_controllers;

	#endregion

	#region MonoBehaviour Actions

	#endregion

	// Use this for initialization
	private void Start()
	{
		_model = GetComponent<card_deck_model>();

		if (_model == null)
		{
			throw new MissingComponentException("card_deck_controller");
		}

		card_controllers = new List<card_controller>();

		init_colors();

		init();
	}

	// Update is called once per frame
	private void Update()
	{

	}

	#region Actions

	private void init()
	{
		for (int i = 0; i < CardInDeck; i++)
		{
			GameObject game_object = (GameObject) Instantiate(_model.card_prefab);

			if (game_object != null)
			{
				//game_object.transform.SetParent(_model.parent_for_card);

				game_object.transform.rotation = _model.card_prefab.transform.rotation;
				game_object.transform.position = _model.card_prefab.transform.position;
				game_object.transform.localScale = _model.card_prefab.transform.localScale;

				_model.grid.AddChild(game_object.transform);

				card_controller cardcontroller = game_object.transform.GetComponent<card_controller>();

				if (cardcontroller != null)
				{
					cardcontroller.Init(i+1);

					card_controllers.Add(cardcontroller);
				}

				UI2DSprite ui2d_sprite = game_object.transform.GetComponent<UI2DSprite>();
				if (ui2d_sprite != null)
				{
					ui2d_sprite.color = card_colors[i%card_colors.Count];
				}
				_model.grid.repositionNow = true;

			}
		}

		_model.grid.Reposition();

		if (is_need_down_scale()) {
			down_scale();
		}
	}

	private void down_scale()
	{
		foreach (card_controller cardController in card_controllers)
		{
			cardController.transform.localScale = Vector3.one;
		}
	}

	private bool is_need_down_scale()
	{
		foreach (card_controller cardController in card_controllers)
		{
			if (cardController.transform.localScale != Vector3.one)
			{
				return true;
			}
		}
		return false;
	}

	private void init_colors()
	{
		card_colors = new List<Color> {one_card_color, second_card_color, third_card_color, fourth_card_color};
	}

	#endregion
}
