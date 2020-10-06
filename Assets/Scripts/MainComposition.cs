using System.Collections.Generic;
using System.Linq;
using Behaviour;
using Commands;
using Commands.Core;
using Controller;
using DefaultNamespace;
using Model;
using UnityEngine;

public class MainComposition : MonoBehaviour
{
	private const int ShovelsAmount = 200;
	private const int GoldGoal = 5;
	private const int FieldSize = 10;
	private const int CellDepth = 4;
	private static readonly Vector2 ElementSize = new Vector2(1, 1);

	[SerializeField]
	private Transform _uiParent;

	private IPerformer _performer;

	private ShovelController _shovelController;
	private GoldWalletController _goldWalletController;
	private readonly Dictionary<int, CellController> _cellControllers = new Dictionary<int, CellController>();
	private GoldBarsSpawnerController _goldBarsSpawnerController;
	private GameProcessController _gameProcessController;

	private void Awake()
	{
		InitializeModelsAndControllers();
		BindingCommands();
	}

	private void Start()
	{
		CreateObjects();
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
			var cell = new CellModel(CellDepth, i);
			_cellControllers.Add(i, new CellController(cell));
		}

		var goldBarsSpawnerModel = new GoldBarsSpawnerModel();
		_goldBarsSpawnerController = new GoldBarsSpawnerController(goldBarsSpawnerModel);

		var gameProcessModel = new GameProcessModel();
		_gameProcessController = new GameProcessController(gameProcessModel);
	}

	private void BindingCommands()
	{
		var storageManager = new StorageManager();

		ICommandPool commandPool = new CommandPool();
		var performerFactory = new PerformerFactory();
		_performer = performerFactory.Create(commandPool);

		commandPool.Register<LoadGame>(new LoadGameCommand(storageManager, _cellControllers.Values.ToList(),
			_shovelController, _goldWalletController, _goldBarsSpawnerController, _gameProcessController));
		commandPool.Register<Dig>(new DigCommand(_performer, _shovelController, storageManager));
		commandPool.Register<SpawnGoldBar>(new SpawnGoldBarCommand(_goldBarsSpawnerController, storageManager));
		commandPool.Register<CollectGold>(new CollectGoldCommand(_goldWalletController, _goldBarsSpawnerController,
			storageManager));
		commandPool.Register<EndGame>(new EndGameCommand(_gameProcessController, storageManager));
		commandPool.Register<RestartGame>(new RestartGameCommand(_shovelController, _goldWalletController,
			_cellControllers, _goldBarsSpawnerController, _gameProcessController, storageManager));
	}

	private void CreateObjects()
	{
		var shovelView = Instantiate(Resources.Load<ShovelView>(PrefabPath.ShovelView), _uiParent);
		shovelView.Initialize(new ShovelView.Data(_shovelController));

		var goldWalletView = Instantiate(Resources.Load<GoldWalletView>(PrefabPath.GoldWalletView), _uiParent);
		goldWalletView.Initialize(new GoldWalletView.Data(_performer, _goldWalletController));

		var fieldView = Instantiate(Resources.Load<FieldView>(PrefabPath.FieldView), null);
		fieldView.Initialize(new FieldView.Data(_performer, _cellControllers, FieldSize, ElementSize));

		var goldBarSpawner = Instantiate(Resources.Load<GoldBarsSpawnerView>(PrefabPath.GoldBarsSpawnerView), null);
		goldBarSpawner.Initialize(new GoldBarsSpawnerView.Data(_performer, _goldBarsSpawnerController, FieldSize,
			ElementSize));

		Instantiate(Resources.Load<BagView>(PrefabPath.BagView), null);

		var gameProcessView = Instantiate(Resources.Load<GameProcessView>(PrefabPath.GameProcessView), _uiParent);
		gameProcessView.Initialize(new GameProcessView.Data(_performer, _gameProcessController));
	}
}