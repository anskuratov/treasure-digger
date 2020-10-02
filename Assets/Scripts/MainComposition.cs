using System.Collections.Generic;
using Commands;
using Commands.Core;
using Model;
using Controller;
using UnityEngine;

public class MainComposition : MonoBehaviour
{
	private const int ShovelsAmount = 25;
	private const int GoldGoal = 5;
	private const int FieldSize = 10;
	private const int CellDepth = 4;

	private ShovelController _shovelController;
	private GoldController _goldController;
	private readonly Dictionary<int, CellController> _cellControllers = new Dictionary<int, CellController>();

	private void Awake()
	{
		InitializeModelAndControllers();
		BindingCommands();
	}

	private void Start()
	{
	}

	private void InitializeModelAndControllers()
	{
		var shovel = new ShovelModel(ShovelsAmount);
		_shovelController = new ShovelController(shovel);

		var gold = new GoldModel(GoldGoal);
		_goldController = new GoldController(gold);

		for (int i = 0; i < FieldSize * FieldSize; ++i)
		{
			var cell = new CellModel(CellDepth);
			_cellControllers.Add(i, new CellController(cell, i));
		}
	}

	private void BindingCommands()
	{
		ICommandPool commandPool = new CommandPool();
		commandPool.Register<Dig, DigCommand>();
	}
}