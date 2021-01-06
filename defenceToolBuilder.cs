using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defenceToolBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    public static defenceToolBuilder instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}
    public GameObject turretToBuild;
    public GameObject turretToBuildprefab;
   // public GameObject turretToBuildprefab1;
	public int money = 300;
	public Text moneyText;
    void Start(){
       // turretToBuild = turretToBuildprefab;
    }
      
	// public GameObject buildEffect;
	// public GameObject sellEffect;

	// private TurretBlueprint turretToBuild;
	// private Node selectedNode;

	// public NodeUI nodeUI;

	// public bool CanBuild { get { return turretToBuild != null; } }
	// public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	// public void SelectNode (Node node)
	// {
	// 	if (selectedNode == node)
	// 	{
	// 		DeselectNode();
	// 		return;
	// 	}

	// 	selectedNode = node;
	// 	turretToBuild = null;

	// 	nodeUI.SetTarget(node);
	// }

	// public void DeselectNode()
	// {
	// 	selectedNode = null;
	// 	nodeUI.Hide();
	// }

	// public void SelectTurretToBuild (TurretBlueprint turret)
	// {
	// 	turretToBuild = turret;
	// 	DeselectNode();
	// }
    public void buildDefenceItem(int Index)
    {

            
            if (Index == 0) // spawn a canon and deduct 60 coins
            {
                turretToBuild = turretToBuildprefab;
            }
            else if(Index == 1)  // spawn a machine gun and deduct 50 coins
            {
                //turretToBuild =  turretToBuildprefab1;
            }

    }
	public int getMoney(){
		return money;
	}

	public void setMoney(int amount){
		money = amount;
		moneyText.text = " " + money ;
	}

	public GameObject GetTurretToBuild()
	{
		if ((money > 70) & (turretToBuild != null)) {
			money = money - 80;
			moneyText.text = " " + money ;
        	Debug.Log("inside defence tool");
			return turretToBuild;
		}
		else if ((money > 70) & (turretToBuild == null))
        {
			Debug.Log("checking");
			return null;
		}
		else{
			return null;
		}

	}
}
