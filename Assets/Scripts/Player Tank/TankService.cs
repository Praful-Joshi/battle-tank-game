using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    //other scripts ref
    internal TankModel model;
    internal static TankController tankController;
    private TankView view;
    public TankScriptableObject[] tankSO;
    private TankScriptableObject tankScriptableObject;

    //declaring components
    public Joystick leftJoystick;

    //declaring variables
    public static GameObject createdTank;

    protected override void Awake()
    {
        base.Awake();                                                           //singleton implementation    
        createNewTank();                                                        //creates new tank
    }

    private void Start()
    {
        setControllerJoystickRef();                                           //passing joystick reference to the controller
        tankController.startTankController();
    }

    private void Update()
    {
        tankController.updateTankController();
    }

    private void FixedUpdate()
    {
        tankController.fixedUpdateTankController();
    }

    private void createNewTank()
    {
        tankScriptableObject = tankSO[Random.Range(0, 3)];
        model = new TankModel(tankScriptableObject);
        view = model.tankPrefab.GetComponent<TankView>();
        tankController = new TankController(model, view);
        Debug.Log(model.color + " tank created");
    }

    private void setControllerJoystickRef()
    {
        if(tankController != null)
        {
            tankController.setJoystickRef(leftJoystick);
        }
    }

    public GameObject getTankControllerRef()
    {
        return tankController.tankGameobject;
    }
}
