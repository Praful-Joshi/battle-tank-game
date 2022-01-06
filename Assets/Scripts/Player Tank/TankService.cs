using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    //other scripts declaration
    internal TankModel model;
    private TankController tank;
    private TankView view;
    public TankScriptableObject[] tankSO;
    private CameraControl cameraControl;

    //component declaration
    public Joystick leftJoystick;

    //declaring variables
    private TankScriptableObject tankScriptableObject;

    protected override void Awake()
    {
        base.Awake();                                                           //singleton implementation    
        createNewTank();                                                        //creates new tank
    }

    private void Start()
    {
        setControllerJoystickRef();                                           //passing joystick reference to the controller
        tank.startTankController();
    }

    private void Update()
    {
        tank.updateTankController();
    }

    private void FixedUpdate()
    {
        tank.fixedUpdateTankController();
    }

    private void createNewTank()
    {
        tankScriptableObject = tankSO[Random.Range(0, 3)];
        model = new TankModel(tankScriptableObject);
        view = model.tankPrefab.GetComponent<TankView>();
        tank = new TankController(model, view);
        Debug.Log(model.color + " tank created");
    }

    private void setControllerJoystickRef()
    {
        if(tank != null)
        {
            tank.setJoystickRef(leftJoystick);
        }
    }

    public GameObject getTankControllerRef()
    {
        return tank.tank;
    }
}
