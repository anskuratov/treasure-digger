using System.Collections.Generic;
using Commands;
using Commands.Core;
using Controller;
using Model;
using UnityEngine;

public class MainComposition : MonoBehaviour
{
	private const int ShovelsAmount = 25;
	private const int GoldGoal = 5;
	private const int FieldSize = 10;
	private const int CellDepth = 4;

	private ShovelController _shovelController;
	private GoldWalletController _goldWalletController;
	private readonly Dictionary<int, CellController> _cellControllers = new Dictionary<int, CellController>();
	private GoldBarsSpawnerController _goldBarsSpawnerController;

	private IPerformer _performer;

	private void Awake()
	{
		InitializeModelsAndControllers();
		BindingCommands();
	}

	private void Start()
	{
		_performer.Invoke(new LoadGame());
	}

	private void InitializeModelsAndControllers()
	{
		var shovel = new ShovelModel(ShovelsAmount);
		_shovelController = new ShovelController(shovel);

		var gold = new GoldWalletModel(GoldGoal);
		_goldWalletController = new GoldWalletController(gold);

		for (int i = 0; i < FieldSize * FieldSize; ++i)
		{
			var cell = new CellModel(CellDepth);
			_cellControllers.Add(i, new CellController(cell, i));
		}

		var goldBarsSpawnerModel = new GoldBarsSpawnerModel();
		_goldBarsSpawnerController = new GoldBarsSpawnerController(goldBarsSpawnerModel);
	}

	private void BindingCommands()
	{
		var storageManager = new StorageManager();

		ICommandPool commandPool = new CommandPool();
		commandPool.Register<LoadGame>(new LoadGameCommand(_shovelController, _goldWalletController, _cellControllers,
			_goldBarsSpawnerController));
		commandPool.Register<Dig>(new DigCommand(_shovelController, storageManager));
		commandPool.Register<CollectGold>(new CollectGoldCommand(_goldWalletController, storageManager));
		commandPool.Register<SpawnGoldBar>(new SpawnGoldBarCommand(_goldBarsSpawnerController, storageManager));

		var performerFactory = new PerformerFactory();
		_performer = performerFactory.Create(commandPool);
	}
}