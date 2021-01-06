using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenceSlot : MonoBehaviour
{

    public Color hoverColor;
	public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    // Start is called before the first frame update

    private Renderer rend;
	private Color startColor;
    GameObject objUi;
    public GameObject buttonCanon;
    private Camera cam;
    bool cannonBool = false;
    public Transform prefab;
    Vector3 mousePos;
    Vector3 objectPos;
    public GameObject canonpre;
    float x;
    float z;
    public GameObject Warning;

    void Start()
    {
        rend = GetComponent<Renderer>();
		startColor = rend.material.color;
        //objUi = GameObject.FindGameObjectWithTag("UIElements");
        //objUi.SetActive(false);
        cam = Camera.main;
  
    }

    void Update()
    {


        // Debug.Log("check1");
        // if (Input.GetMouseButtonDown(0))
        // {
        //     objUi.SetActive(true);
        //     Debug.Log("check2");

        //     Debug.Log("buttonCanon"+ buttonCanon);
        //     Debug.Log("Input.mousePosition"+ Input.mousePosition);

        //     Debug.Log("cam.WorldToScreenPoint(Input.mousePosition)"+ cam.WorldToScreenPoint(Input.mousePosition));
        //     //buttonCanon.transform.position = cam.WorldToScreenPoint(Input.mousePosition);
        //     //Debug.Log("buttonCanon.transform.position"+ buttonCanon.transform.position);
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     if(Physics.Raycast(ray, out hit, 1000F))
        //     {
        //         if(hit.collider.name == "slot"){
        //            mousePos = hit.point;
        //         } 
        //     }   

        //     // Debug.Log("cannonBool "+ cannonBool);
        //     // if(cannonBool==true){
        //     //     Instantiate(prefab, mousePos, Quaternion.identity);
        //     // }
        //     // //mousePos.z = Camera.main.nearClipPlane;
        //     // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        //     // Debug.Log("worldPosition"+ worldPosition);
        //     // Debug.Log("buttonCanon.transform.position"+ buttonCanon.transform.position);

        //     buttonCanon.transform.position = new Vector3(Input.mousePosition.x + 20, Input.mousePosition.y + 6, Input.mousePosition.z + 20) ;

        // }

        // Debug.Log("cannonBool "+ cannonBool);
        // Debug.Log("mousePos in update"+ mousePos);

        // if(mousePos.x>0){
        //     objectPos =  mousePos;
        //     x = mousePos.x;
        //     z = mousePos.z;
        // }
        // //Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        // Debug.Log("objectPos in update"+ objectPos);
        // if(cannonBool==true){
        //         Debug.Log("objectPos inside true"+ objectPos);
        //         Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity);
        //         cannonBool = false;
        // }

    }

    // public void addCanon(){

    //     cannonBool = true;
    //    // Instantiate(prefab, mousePos, Quaternion.identity);
    // }

    // void Start()

    // Update is called once per frame
    void OnMouseEnter ()
	{
		// if (EventSystem.current.IsPointerOverGameObject())
		// 	return;

		// if (!buildManager.CanBuild)
		// 	return;

		// if (buildManager.HasMoney)
		// {
			rend.material.color = hoverColor;
		// } else
		// {
		// 	rend.material.color = notEnoughMoneyColor;
		// }
	}

    void OnMouseExit ()
	{
		rend.material.color = startColor;
    }

    void OnMouseDown ()
	{
        //objUi1 = GameObject.FindWithTag("UIElements");
//        objUi.SetActive(true);
		// if (EventSystem.current.IsPointerOverGameObject())
		// 	return;

		// if (turret != null)
		// {
		// 	buildManager.SelectNode(this);
		// 	return;
		// }

		// if (!buildManager.CanBuild)
		// 	return;

		// BuildTurret(buildManager.GetTurretToBuild());
        GameObject canon = defenceToolBuilder.instance.GetTurretToBuild();
        Debug.Log("canon checck "+ canon);
        //if(canon.name == "Turret" ){

           // canonpre = (GameObject)Instantiate(canon, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //Debug.Log("canonpre checck "+ canonpre);
        //}
        //else{
        if(canon != null)
        {
            canonpre = (GameObject)Instantiate(canon, new Vector3(transform.position.x, transform.position.y - 3.9f, transform.position.z), Quaternion.identity);
        }
        else
        {
            Warning.SetActive(true);
            Debug.Log("select canon");
        }




            
        //}

                

	}



}
